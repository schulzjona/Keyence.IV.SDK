// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.IDataRepository
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System.Collections.Generic;

namespace Keyence.IV.Sdk.Communication
{
  internal interface IDataRepository
  {
    VisionSensorMode SensorMode { get; }

    VisionSensorStateEnum SensorState { get; }

    string MachineName { get; }

    string ModelName { get; }

    string SensorVersion { get; }

    string SerialNo { get; }

    VisionSensorType SensorType { get; }

    FocusDistance FocusDistance { get; }

    CmosType CmosSensorType { get; }

    byte UnitType { get; }

    byte InterferencePreventionDelay { get; }

    byte[] InterunitLogicOuts { get; }

    byte[] InterunitLogicIns { get; }

    bool ExternalProgramSwitch { get; }

    ushort SpecialOrderVersion { get; }

    ushort MajorVersion { get; }

    ushort MinorVersion { get; }

    bool ManualTriggerAcceptable { get; }

    bool AcceptableSetting { get; }

    bool LoginRequired { get; }

    bool LoggedIn { get; }

    ToolResultBase PositionAdjustResult { get; }

    ToolResultBase this[byte i] { get; }

    void Set(ISensorModeState modeAndState);

    void Set(ISensorSystemSetting system);

    void Set(ISensorVersion sensVersion);

    void Set(IProgramSetting programSetting);

    void Set(ISensorCurrentSettingInformation settingInfo);

    void Set(IProgramList programList);

    void Set(ISensorData sensorData);

    void Logout();

    bool Login(string password);

    bool HasProgramChanged(ISensorCurrentSettingInformation current);

    IList<ToolResultBase> GetLatestResult();

    IProgramNo GetActiveProgramNo();

    ProgramDescription GetActiveProgram();

    IList<ProgramHeader> GetPrograms();
  }
}
