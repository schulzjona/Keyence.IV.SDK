// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.DataRepository
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System.Collections.Generic;

namespace Keyence.IV.Sdk.Communication
{
  internal class DataRepository : IDataRepository
  {
    private IProgramSetting _activeProgram;
    private ISensorData _latestData;
    private IProgramList _programList;
    private ISensorModeState _sensorModeAndState;
    private ISensorCurrentSettingInformation _settingCounter;
    private ISensorSystemSetting _systemSetting;
    private ISensorVersion _version;

    public VisionSensorMode SensorMode
    {
      get
      {
        return this._sensorModeAndState.VisionSensorMode;
      }
    }

    public VisionSensorStateEnum SensorState
    {
      get
      {
        return this._sensorModeAndState.VisionSensorStateEnum;
      }
    }

    public bool LoginRequired
    {
      get
      {
        return this._systemSetting.PasswordEnable;
      }
    }

    public string MachineName
    {
      get
      {
        return this._systemSetting.MachineName;
      }
    }

    public string ModelName
    {
      get
      {
        return this._version.ModelName;
      }
    }

    public string SensorVersion
    {
      get
      {
        return this._version.AplVersion;
      }
    }

    public string SerialNo
    {
      get
      {
        return this._version.SerialNo;
      }
    }

    public VisionSensorType SensorType
    {
      get
      {
        return this._version.SensorType;
      }
    }

    public FocusDistance FocusDistance
    {
      get
      {
        return this._version.FocusDistance;
      }
    }

    public CmosType CmosSensorType
    {
      get
      {
        return this._version.CmosSensorType;
      }
    }

    public byte UnitType
    {
      get
      {
        return this._systemSetting.UnitType;
      }
    }

    public byte InterferencePreventionDelay
    {
      get
      {
        return this._systemSetting.InterferencePreventionDelay;
      }
    }

    public byte[] InterunitLogicOuts
    {
      get
      {
        return this._systemSetting.InterunitLogicOuts;
      }
    }

    public byte[] InterunitLogicIns
    {
      get
      {
        return this._systemSetting.InterunitLogicIns;
      }
    }

    public bool ExternalProgramSwitch
    {
      get
      {
        return this._systemSetting.ExternalProgramSwitch;
      }
    }

    public ushort SpecialOrderVersion
    {
      get
      {
        return this._version.SpecialOrderVersion;
      }
    }

    public ushort MajorVersion
    {
      get
      {
        return this._version.MajorVersion;
      }
    }

    public ushort MinorVersion
    {
      get
      {
        return this._version.MinorVersion;
      }
    }

    public bool ManualTriggerAcceptable
    {
      get
      {
        return this._activeProgram.ExternalTrigger;
      }
    }

    public bool AcceptableSetting
    {
      get
      {
        return this._version.AcceptableSettingVersion;
      }
    }

    public bool LoggedIn { get; private set; }

    public ToolResultBase PositionAdjustResult
    {
      get
      {
        if (this._latestData == null || this._latestData.ToolResult == null || this._latestData.ToolResult.PositionAdjust == null)
          return (ToolResultBase) new NoneToolResult();
        return this._latestData.ToolResult.PositionAdjust;
      }
    }

    public ToolResultBase this[byte i]
    {
      get
      {
        return this._latestData.ToolResult[i];
      }
    }

    public void Set(ISensorModeState modeAndState)
    {
      this._sensorModeAndState = modeAndState;
    }

    public void Set(ISensorSystemSetting system)
    {
      this._systemSetting = system;
    }

    public void Set(ISensorVersion sensVersion)
    {
      this._version = sensVersion;
    }

    public void Set(IProgramSetting programSetting)
    {
      this._activeProgram = programSetting;
    }

    public void Set(ISensorCurrentSettingInformation settingInfo)
    {
      this._settingCounter = settingInfo;
    }

    public void Set(IProgramList progList)
    {
      this._programList = progList;
    }

    public void Set(ISensorData sensorData)
    {
      this._latestData = sensorData;
    }

    public void Logout()
    {
      if (!this.LoginRequired)
        return;
      this.LoggedIn = false;
    }

    public bool Login(string password)
    {
      if (!this.LoginRequired)
        return true;
      this.LoggedIn = string.Compare(this._systemSetting.Password, password) == 0;
      return this.LoggedIn;
    }

    public bool HasProgramChanged(ISensorCurrentSettingInformation current)
    {
      return (int) this._settingCounter.AnySettingChangeCounter != (int) current.AnySettingChangeCounter;
    }

    public IList<ToolResultBase> GetLatestResult()
    {
      if (this._latestData == null || this._latestData.ToolResult == null || this._latestData.ToolResult.PositionAdjust == null)
        return (IList<ToolResultBase>) new List<ToolResultBase>();
      List<ToolResultBase> toolResultBaseList = new List<ToolResultBase>()
      {
        this._latestData.ToolResult.PositionAdjust
      };
      for (byte index = 1; index < (byte) 17; ++index)
        toolResultBaseList.Add(this._latestData.ToolResult[index]);
      return (IList<ToolResultBase>) toolResultBaseList;
    }

    public IProgramNo GetActiveProgramNo()
    {
      return (IProgramNo) new ProgramNo((int) this._settingCounter.ActiveBankNo);
    }

    public ProgramDescription GetActiveProgram()
    {
      return (ProgramDescription) new ConcreteProgramDescription(this._version.CmosSensorType, this._activeProgram);
    }

    public IList<ProgramHeader> GetPrograms()
    {
      return this._programList.List;
    }
  }
}
