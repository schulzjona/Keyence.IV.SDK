// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.SensorOperationSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Algorithm
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct SensorOperationSetting
  {
    [FieldOffset(0)]
    public ShapeSensorOperationSetting sShape;
    [FieldOffset(0)]
    public PositionAdjustOperationSetting sPositionAdjust;
    [FieldOffset(0)]
    public CountSensorOperationSetting sCount;
    [FieldOffset(0)]
    public AreaColorSensorOperationSetting sAreaColor;
    [FieldOffset(0)]
    public AreaMonoSensorOperationSetting sAreaMono;
    [FieldOffset(0)]
    public EdgePresenceThresholdWithHiSetting sEdgePresence;
    [FieldOffset(0)]
    public ThresholdWithHiSetting sEdgeWidth;
    [FieldOffset(0)]
    public ThresholdWithHiSetting sEdgePitch;
    [FieldOffset(0)]
    public ThresholdWithHiSetting sEdgePixelCount;
    [FieldOffset(0)]
    public ThresholdWithHiSetting sDiameter;
    [FieldOffset(0)]
    public OneAxisPosAdjustSensorOperationSetting sOneAxisPosAdjust;
    [FieldOffset(0)]
    public OneAxisPosAdjustSensorOperationSetting sTwoAxesPosAdjust;
    [FieldOffset(0)]
    public SensorOperationSettingDetail sAllocate;
  }
}
