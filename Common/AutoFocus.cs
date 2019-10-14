// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.AutoFocus
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct AutoFocus
  {
    [FieldOffset(0)]
    public byte byAutoFocus;
    [FieldOffset(1)]
    public byte byProofValueDisableFlg;
    [FieldOffset(2)]
    public unsafe fixed byte abyNotSettingReserved[2];
    [FieldOffset(4)]
    public ushort wNearRange;
    [FieldOffset(6)]
    public ushort wFarRange;
    [FieldOffset(8)]
    public ushort wOneStepWidth;
    [FieldOffset(10)]
    public ushort wNeighborhoodRejectWidth;
  }
}
