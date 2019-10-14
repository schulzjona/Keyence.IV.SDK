// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.InSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal struct InSetting
  {
    public byte byInType;
    public unsafe fixed byte abyPattern[6];
    public unsafe fixed byte abyInterunitLogicIn[6];
    public byte byInterferencePreventionDelay;
    public byte byInternalCycleControl;
    public byte byErrorClearWithReset;
    public unsafe fixed byte abyEepReserved[7];
  }
}
