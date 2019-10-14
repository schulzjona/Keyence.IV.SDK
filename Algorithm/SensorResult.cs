// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.SensorResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Algorithm
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct SensorResult
  {
    [FieldOffset(0)]
    public byte bySensorType;
    [FieldOffset(1)]
    public unsafe fixed byte abyReserved1[3];
    [FieldOffset(4)]
    public uint dwElapsedTime;
    [FieldOffset(8)]
    public byte byResult;
    [FieldOffset(9)]
    public unsafe fixed byte abyReserved2[3];
    [FieldOffset(12)]
    public AreaColorSensorResult sAreaColor;
    [FieldOffset(12)]
    public AreaMonoSensorResult sAreaMono;
    [FieldOffset(12)]
    public CountSensorResult sCount;
    [FieldOffset(12)]
    public PositionAdjustResult sPositionAdjust;
    [FieldOffset(12)]
    public ShapeSensorResult sShape;
    [FieldOffset(12)]
    public EdgePresenceSensorResult sEdgePresence;
    [FieldOffset(12)]
    public EdgeWidthSensorResult sEdgeWidth;
    [FieldOffset(12)]
    public EdgePitchSensorResult sEdgePitch;
    [FieldOffset(12)]
    public EdgePixelCountSensorResult sEdgePixelCount;
    [FieldOffset(12)]
    public DiameterSensorResult sDiameter;
    [FieldOffset(12)]
    public OneAxisPosAdjustResult sOneAxisPosAdjust;
    [FieldOffset(12)]
    public TwoAxesPosAdjustResult sTwoAxesPosAdjust;
  }
}
