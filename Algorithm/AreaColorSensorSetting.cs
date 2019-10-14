// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.AreaColorSensorSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Algorithm
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct AreaColorSensorSetting
  {
    [FieldOffset(0)]
    public AreaHsvThreshold sAreaHsvThreshold;
    [FieldOffset(14)]
    public VectorAreaItem sTemplateVector;
    [FieldOffset(30)]
    public unsafe fixed byte abyPadding00[2];
    [FieldOffset(32)]
    public AreaColorSensorOperationSetting sOperationSetting;
    [FieldOffset(44)]
    public byte byFirstPointValid;
    [FieldOffset(45)]
    public byte byPadding;
    [FieldOffset(46)]
    public Hsv sHSVFirstPoint;
    [FieldOffset(50)]
    public unsafe fixed byte abyPadding01[2];
  }
}
