// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.AreaColorSensorOperationSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Algorithm
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct AreaColorSensorOperationSetting
  {
    [FieldOffset(0)]
    public byte byHiThresholdSettingType;
    [FieldOffset(1)]
    public unsafe fixed byte abyReserved[3];
    [FieldOffset(4)]
    public uint dwHiThreshold;
    [FieldOffset(8)]
    public uint dwLowThreshold;
  }
}
