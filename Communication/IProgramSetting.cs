// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.IProgramSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Communication
{
  internal interface IProgramSetting : ICauseError
  {
    string ProgramName { get; }

    int ProgramNo { get; }

    bool ExternalTrigger { get; }

    ushort TriggerCycleMilliSec { get; }

    ToolSettingBase PositionAdjustSetting { get; }

    ToolSettingBase this[byte toolNo] { get; }

    byte[] MonochromeMaster { get; }

    short[] ColorMaster { get; }
  }
}
