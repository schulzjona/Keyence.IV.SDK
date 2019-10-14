// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.AreaMonoSensorResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Algorithm
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct AreaMonoSensorResult
  {
    [FieldOffset(0)]
    public uint dwMasterArea;
    [FieldOffset(4)]
    public ushort wMatchPercent;
    [FieldOffset(6)]
    public unsafe fixed byte abyReserved[2];
    [FieldOffset(8)]
    public uint dwArea;
    [FieldOffset(12)]
    public uint dwWhiteOverArea;
  }
}
