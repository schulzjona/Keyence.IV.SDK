// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.CameraSpec
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct CameraSpec
  {
    [FieldOffset(0)]
    public ModelName sModelName;
    [FieldOffset(32)]
    public AutoFocus sAutoFocus;
    [FieldOffset(44)]
    public byte byCmosSensorKind;
    [FieldOffset(45)]
    public byte byFocusDistanceKind;
    [FieldOffset(46)]
    public byte byAngleOfView;
    [FieldOffset(47)]
    public byte byPadding;
  }
}
