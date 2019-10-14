// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.LightAdjustSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct LightAdjustSetting
  {
    [FieldOffset(0)]
    public byte byEnable;
    [FieldOffset(1)]
    public byte byPadding;
    [FieldOffset(2)]
    public RectArea sArea;
    [FieldOffset(10)]
    public unsafe fixed byte abyEepReserved[16];
  }
}
