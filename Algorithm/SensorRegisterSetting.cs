// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.SensorRegisterSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Algorithm
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct SensorRegisterSetting
  {
    [FieldOffset(0)]
    public byte bySensorType;
    [FieldOffset(1)]
    public unsafe fixed byte abyReserved[3];
    [FieldOffset(4)]
    public ShapeSensorRegisterSetting sShape;
    [FieldOffset(4)]
    public PositionAdjustRegisterSetting sPositionAdjust;
    [FieldOffset(4)]
    public CountSensorRegisterSetting sCount;
    [FieldOffset(4)]
    public AreaColorSensorRegisterSetting sAreaColor;
    [FieldOffset(4)]
    public AreaMonoSensorRegisterSetting sAreaMono;
    [FieldOffset(4)]
    public EdgePresenceSensorRegisterSetting sEdgePresence;
    [FieldOffset(4)]
    public EdgeWidthSensorRegisterSetting sEdgeWidth;
    [FieldOffset(4)]
    public EdgePitchSensorRegisterSetting sEdgePitch;
    [FieldOffset(4)]
    public EdgePixelCountSensorRegisterSetting sEdgePixelCount;
    [FieldOffset(4)]
    public DiameterSensorRegisterSetting sDiameter;
    [FieldOffset(4)]
    public OneAxisPosAdjustSensorRegisterSetting sOneAxisPosAdjust;
    [FieldOffset(4)]
    public TwoAxesPosAdjustSensorRegisterSetting sTwoAxesPosAdjust;
    [FieldOffset(4)]
    public SensorRegisterSettingDetail sAllocate;
  }
}
