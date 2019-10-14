// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.AutoCommunicator
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Communication
{
  internal class AutoCommunicator
  {
    private bool _eventRise = true;
    private readonly ITcpCommand _command;
    private readonly IDataRepository _repository;

    internal AutoCommunicator(IDataRepository repository, ITcpCommand command)
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

    public event ImageAcquiredEventHandler ImageAcquired = delegate {};

    public event ToolResultUpdatedEventHandler ResultUpdated = delegate {};

    public event ProgramSettingsUpdatedEventHandler ProgramSettingsUpdated = delegate {};

    public void DoWork(bool getAll)
    {
      ISensorData sensorData = this._command.GetSensorData(getAll);
      this._repository.Set(sensorData);
      if (!this.HasProgramChanged(sensorData.SettingCounter))
        this.RaiseGetSensorDataEvent(sensorData);
      else
        this.AcquireUpdatedSensorSettings();
    }

    private bool HasProgramChanged(ISensorCurrentSettingInformation currentCounter)
    {
      return this._repository.HasProgramChanged(currentCounter);
    }

    private void AcquireUpdatedSensorSettings()
    {
      ISensorCurrentSettingInformation currentSettingCounter = this.GetCurrentSettingCounter();
      int num = 0;
      do
      {
        AutoCommunicator.DisconnectIfSensorIsHardlyStabilized(num++);
        this.SetSettingCounter(currentSettingCounter);
        this.AcquireActiveProgramSettings();
        this.AcquireProgramList();
        this.AcquireSystemSettings();
        currentSettingCounter = this.GetCurrentSettingCounter();
      }
      while (this.HasProgramChanged(currentSettingCounter));
      this.ProgramSettingsUpdated((object) this, (ProgramSettingsUpdatedEventArgs) new ConcreteProgramSettingsUpdatedEventArgs());
    }

    private static void DisconnectIfSensorIsHardlyStabilized(int settingGetTimes)
    {
      if (settingGetTimes >= 10)
        throw new ConnectionLostException("VisionSensor state is hardly stabilized.");
    }

    private ISensorCurrentSettingInformation GetCurrentSettingCounter()
    {
      return this._command.GetSettingChangeInfo();
    }

    private void AcquireSystemSettings()
    {
      this._repository.Set(this._command.GetSystemSetting());
    }

    private void AcquireProgramList()
    {
      this._repository.Set(this._command.GetBankList());
    }

    private void AcquireActiveProgramSettings()
    {
      this._repository.Set(this._command.GetBankSetting(this._repository.GetActiveProgramNo()));
    }

    private void SetSettingCounter(ISensorCurrentSettingInformation currentCounter)
    {
      this._repository.Set(currentCounter);
    }

    private void RaiseGetSensorDataEvent(ISensorData sensorData)
    {
      if (!this.EnableEvent)
        return;
      if (sensorData.LiveImage != null)
        this.ImageAcquired((object) this, sensorData.LiveImage);
      if (sensorData.ToolResult == null)
        return;
      this.ResultUpdated((object) this, sensorData.ToolResult);
    }
  }
}
