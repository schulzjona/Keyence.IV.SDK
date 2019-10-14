// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.CheckedTcpCommand
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System;

namespace Keyence.IV.Sdk.Communication
{
  internal class CheckedTcpCommand : ITcpCommand
  {
    private readonly TcpCommand _command;

    internal CheckedTcpCommand(IConnection connection)
    {
      this._command = new TcpCommand(connection);
    }

    public event EventHandler<SensorErrorCollection> GetError = delegate {};

    public ISensorModeState GetInitialModeState()
    {
      ISensorModeState initialModeState = this._command.GetInitialModeState();
      this.VerifyCommandResponse((ICauseError) initialModeState);
      return initialModeState;
    }

    public ISensorCurrentSettingInformation GetSettingChangeInfo()
    {
      ISensorCurrentSettingInformation settingChangeInfo = this._command.GetSettingChangeInfo();
      this.VerifyCommandResponse((ICauseError) settingChangeInfo);
      return settingChangeInfo;
    }

    public IClearErrorResult ClearError(SensorError clearError)
    {
      IClearErrorResult clearErrorResult = this._command.ClearError(clearError);
      this.VerifyCommandResponse((ICauseError) clearErrorResult);
      return clearErrorResult;
    }

    public ISensorModeState SetStateTransition(ISensorModeState newState)
    {
      ISensorModeState sensorModeState = this._command.SetStateTransition(newState);
      this.VerifyCommandResponse((ICauseError) sensorModeState);
      return sensorModeState;
    }

    public ISensorVersion ExchangeVersion()
    {
      ISensorVersion sensorVersion = this._command.ExchangeVersion();
      this.VerifyCommandResponse((ICauseError) sensorVersion);
      return sensorVersion;
    }

    public IProgramNo SwitchBank(IProgramNo programNo)
    {
      IProgramNo programNo1 = this._command.SwitchBank(programNo);
      this.VerifyCommandResponse((ICauseError) programNo1);
      return programNo1;
    }

    public IManualTriggerResult EnterTrigger()
    {
      IManualTriggerResult manualTriggerResult = this._command.EnterTrigger();
      this.VerifyCommandResponse((ICauseError) manualTriggerResult);
      return manualTriggerResult;
    }

    public ISensorData GetSensorData(bool getAll)
    {
      ISensorData sensorData = this._command.GetSensorData(getAll);
      this.GetError((object) this, sensorData.SensorErrors);
      this.VerifyCommandResponse((ICauseError) sensorData);
      return sensorData;
    }

    public ISensorSystemSetting GetSystemSetting()
    {
      ISensorSystemSetting systemSetting = this._command.GetSystemSetting();
      this.VerifyCommandResponse((ICauseError) systemSetting);
      return systemSetting;
    }

    public IProgramList GetBankList()
    {
      IProgramList bankList = this._command.GetBankList();
      this.VerifyCommandResponse((ICauseError) bankList);
      return bankList;
    }

    public IProgramSetting GetBankSetting(IProgramNo programNo)
    {
      IProgramSetting bankSetting = this._command.GetBankSetting(programNo);
      this.VerifyCommandResponse((ICauseError) bankSetting);
      return bankSetting;
    }

    public IAsyncProcessStartResult StartConfirmBankSetting(
      uint configuredBits,
      bool flashOnly,
      uint unonfiguredBits)
    {
      IAsyncProcessStartResult processStartResult = this._command.StartConfirmBankSetting(configuredBits, flashOnly, unonfiguredBits);
      this.VerifyCommandResponse((ICauseError) processStartResult);
      return processStartResult;
    }

    public IProgress QueryConfirmBankSettingStatus()
    {
      IProgress progress = this._command.QueryConfirmBankSettingStatus();
      this.VerifyCommandResponse((ICauseError) progress);
      return progress;
    }

    public IAsyncProcessStartResult StartConfirmSystemSetting()
    {
      IAsyncProcessStartResult processStartResult = this._command.StartConfirmSystemSetting();
      this.VerifyCommandResponse((ICauseError) processStartResult);
      return processStartResult;
    }

    public IProgress QueryConfirmSystemSettingStatus()
    {
      IProgress progress = this._command.QueryConfirmSystemSettingStatus();
      this.VerifyCommandResponse((ICauseError) progress);
      return progress;
    }

    public IProgramNo SetBankSetting(
      ref BankSettingAll bankSettingAll,
      IProgramNo programNo)
    {
      IProgramNo programNo1 = this._command.SetBankSetting(ref bankSettingAll, programNo);
      this.VerifyCommandResponse((ICauseError) programNo1);
      return programNo1;
    }

    public IProgramNo DeleteBankSetting(IProgramNo programNo)
    {
      IProgramNo programNo1 = this._command.DeleteBankSetting(programNo);
      this.VerifyCommandResponse((ICauseError) programNo1);
      return programNo1;
    }

    public IConfiguredBits GetConfiguredBits()
    {
      IConfiguredBits configuredBits = this._command.GetConfiguredBits();
      this.VerifyCommandResponse((ICauseError) configuredBits);
      return configuredBits;
    }

    private void VerifyCommandResponse(ICauseError causeError)
    {
      if (!causeError.Error.Sustainable)
        throw new ConnectionLostException(causeError.Error.Description);
      if (causeError.Error.ErrorCode == (ushort) 0)
        return;
      this.GetError((object) this, new SensorErrorCollection(causeError.Error));
    }
  }
}
