// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.ProgramDescription
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk
{
  public abstract class ProgramDescription
  {
    public abstract string ProgramName { get; }

    public abstract int ProgramNo { get; }

    public abstract bool ExternalTrigger { get; }

    public abstract ushort TriggerCycleMilliSec { get; }

    public abstract ToolSettingBase PositionAdjustSetting { get; }

    public abstract ToolSettingBase this[byte toolNo] { get; }

    public abstract Image MasterImage { get; }
  }
}
