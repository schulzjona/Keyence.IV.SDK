// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.EdgePresenceThresholdWithHiSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Algorithm
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct EdgePresenceThresholdWithHiSetting
  {
    [FieldOffset(0)]
    public byte byMatchPercentLimitSettingType;
    [FieldOffset(1)]
    public byte byEnableHiThreshould;
    [FieldOffset(2)]
    public unsafe fixed byte abyReserved[2];
    [FieldOffset(4)]
    public uint dwHiThreshold;
    [FieldOffset(8)]
    public uint dwLowThreshold;
  }
}
