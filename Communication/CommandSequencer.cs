// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.CommandSequencer
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System;
using System.Threading;

namespace Keyence.IV.Sdk.Communication
{
  internal class CommandSequencer
  {
    private bool _eventRise = true;
    private readonly ITcpCommand _command;
    private readonly IDataRepository _repository;

    internal CommandSequencer(IDataRepository repository, ITcpCommand command)
    {
      this._repository = repository;
      this._command = command;
    }

    public bool EnableEvent
    {
      get
      {
        return this._eventRise;
      }
      set
      {
        this._eventRise = value;
      }
    }

    internal event ProgramSettingsUpdatedEventHandler ProgramSettingsUpdated = delegate {};

    internal void VerifyTargetJustAfterConnectionConfirmed()
    {
      int stateGetTimes = 0;
      do
      {
        ++stateGetTimes;
        this.CheckSensorStateAndMode();
        CommandSequencer.DisconnectIfSensorStateIsHardToChange(stateGetTimes);
      }
      while (!this.IsSensorControllableStateAndMode());
      this.AcquireTargetSensorVersion();
      this.GetInitialSensorData();
    }

    private void CheckSensorStateAndMode()
    {
      this.AcquireSensorStateAndMode();
      if (this.IsSensorUncorrectableMode())
        throw new ConnectionLostException("VisionSensor mode is not Application mode.");
      if (this.IsSensorStateNeedsToBeWait())
        CommandSequencer.WaitASecond();
      if (!this.IsSensorStateCorrectable())
        return;
      this.ChangeSensorToOperationState();
      CommandSequencer.WaitASecond();
    }

    private void AcquireSensorStateAndMode()
    {
      this._repository.Set(this._command.GetInitialModeState());
    }

    private bool IsSensorUncorrectableMode()
    {
      return this._repository.SensorMode != VisionSensorMode.VisionsensorModeApl;
    }

    private bool IsSensorStateNeedsToBeWait()
    {
      return this._repository.SensorState == VisionSensorStateEnum.VisionsensorStateBoot;
    }

    private static void WaitASecond()
    {
      Thread.Sleep(100);
    }

    private bool IsSensorStateCorrectable()
    {
      return this._repository.SensorState == VisionSensorStateEnum.VisionsensorStateConfStop;
    }

    private void ChangeSensorToOperationState()
    {
      this._command.SetStateTransition((ISensorModeState) new SensorModeState(VisionSensorStateEnum.VisionsensorStateOperation, VisionSensorMode.VisionsensorModeApl));
    }

    private static void DisconnectIfSensorStateIsHardToChange(int stateGetTimes)
    {
      if (stateGetTimes >= 10)
        throw new ConnectionLostException("VisionSensor state coudn't be changed.");
    }

    private bool IsSensorControllableStateAndMode()
    {
      if (this._repository.SensorMode == VisionSensorMode.VisionsensorModeApl)
        return this._repository.SensorState == VisionSensorStateEnum.VisionsensorStateOperation;
      return false;
    }

    private void AcquireTargetSensorVersion()
    {
      this._repository.Set(this._command.ExchangeVersion());
      if (!this.IsSettingVersionAccesible())
        throw new ConnectionLostException("VisionSensor setting versionn is not accesible.");
    }

    private bool IsSettingVersionAccesible()
    {
      return this._repository.AcceptableSetting;
    }

    private void GetInitialSensorData()
    {
      ISensorCurrentSettingInformation currentSettingCounter = this.GetCurrentSettingCounter();
      int settingGetTimes = 0;
      do
      {
        this._repository.Set(currentSettingCounter);
        ++settingGetTimes;
        CommandSequencer.DisconnectIfSensorSettingsAreHardlyStabilized(settingGetTimes);
        this.AcquireSystemSettings();
        this.AcquireBankList();
        this.AcquireActiveBankSettings();
        currentSettingCounter = this.GetCurrentSettingCounter();
      }
      while (this._repository.HasProgramChanged(currentSettingCounter));
      if (!this.EnableEvent)
        return;
      this.ProgramSettingsUpdated((object) this, (ProgramSettingsUpdatedEventArgs) new ConcreteProgramSettingsUpdatedEventArgs());
    }

    private static void DisconnectIfSensorSettingsAreHardlyStabilized(int settingGetTimes)
    {
      if (settingGetTimes >= 10)
        throw new ConnectionLostException("VisionSensor setting is hardly stabilized.");
    }

    private void AcquireActiveBankSettings()
    {
      this._repository.Set(this._command.GetBankSetting(this._repository.GetActiveProgramNo()));
    }

    private void AcquireSystemSettings()
    {
      this._repository.Set(this._command.GetSystemSetting());
    }

    private void AcquireBankList()
    {
      this._repository.Set(this._command.GetBankList());
    }

    private ISensorCurrentSettingInformation GetCurrentSettingCounter()
    {
      return this._command.GetSettingChangeInfo();
    }

    internal void SwitchProgram(int programNo)
    {
      this.VerifySwitchProgramExecutionPossibility();
      this.TransitToSettingMode();
      this.ConfirmAllProgramSetting(uint.MaxValue, true);
      this.SendSwitchProgramCommand(new ProgramNo(programNo));
      this.ConfirmSystemSetting();
      this.TransitToOperationMode();
      this.GetInitialSensorData();
    }

    internal void SetBankSetting(ref BankSettingAll bankSettingAll, int programNo)
    {
      this.TransitToSettingMode();
      this.ConfirmAllProgramSetting(uint.MaxValue, true);
      this.SetBankSettingCommand(ref bankSettingAll, new ProgramNo(programNo));
      this.ConfirmProgramSetting(programNo, false, false);
      this.TransitToOperationMode();
      this.GetInitialSensorData();
    }

    internal void DeleteBankSetting(int programNo)
    {
      this.TransitToSettingMode();
      this.ConfirmAllProgramSetting(uint.MaxValue, true);
      this.DeleteBankSettingCommand(programNo);
      this.ConfirmProgramSetting(programNo, false, true);
      this.ConfirmSystemSetting();
      this.TransitToOperationMode();
      this.GetInitialSensorData();
    }

    private void DeleteBankSettingCommand(int programNo)
    {
      this._command.DeleteBankSetting((IProgramNo) new ProgramNo(programNo));
    }

    private void SetBankSettingCommand(ref BankSettingAll bankSettingAll, ProgramNo programNo)
    {
      this._command.SetBankSetting(ref bankSettingAll, (IProgramNo) programNo);
    }

    private void VerifySwitchProgramExecutionPossibility()
    {
      if (this.EnableProgramSwithThroughExternalInput())
        throw new InvalidOperationException("Program switch by external input is enable.");
      if (!this.Loggedin())
        throw new InvalidOperationException("Unlock is required to switch program.");
    }

    private bool EnableProgramSwithThroughExternalInput()
    {
      return this._repository.ExternalProgramSwitch;
    }

    private bool Loggedin()
    {
      if (this._repository.LoginRequired)
        return this._repository.LoggedIn;
      return true;
    }

    private void TransitToSettingMode()
    {
      this._command.SetStateTransition((ISensorModeState) new SensorModeState(VisionSensorStateEnum.VisionsensorStateConfStop, VisionSensorMode.VisionsensorModeApl));
    }

    private void ConfirmAllProgramSetting(uint configuredBits = 4294967295, bool flashOnly = true)
    {
      uint unonfiguredBits = ~this._command.GetConfiguredBits().Bits;
      if (!this._command.StartConfirmBankSetting(configuredBits, flashOnly, unonfiguredBits).Success)
        throw new SettingChangeException("Start confirming bank settings failed.");
      do
        ;
      while (!this._command.QueryConfirmBankSettingStatus().Completed);
    }

    private void ConfirmProgramSetting(int programNo, bool flashOnly = true, bool bNotConfigured = false)
    {
      uint configuredBits = (uint) (1 << new ProgramNo(programNo).No);
      uint num = ~this._command.GetConfiguredBits().Bits;
      uint unonfiguredBits = !bNotConfigured ? num & ~configuredBits : num | configuredBits;
      if (!this._command.StartConfirmBankSetting(configuredBits, flashOnly, unonfiguredBits).Success)
        throw new SettingChangeException("Start confirming bank settings failed.");
      do
        ;
      while (!this._command.QueryConfirmBankSettingStatus().Completed);
    }

    private void SendSwitchProgramCommand(ProgramNo programNo)
    {
      this._command.SwitchBank((IProgramNo) programNo);
    }

    private void ConfirmSystemSetting()
    {
      if (!this._command.StartConfirmSystemSetting().Success)
        throw new SettingChangeException("Start confirming system settings failed.");
      do
        ;
      while (!this._command.QueryConfirmSystemSettingStatus().Completed);
    }

    private void TransitToOperationMode()
    {
      this._command.SetStateTransition((ISensorModeState) new SensorModeState(VisionSensorStateEnum.VisionsensorStateOperation, VisionSensorMode.VisionsensorModeApl));
    }
  }
}
