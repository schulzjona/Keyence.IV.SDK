// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.SensorSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Algorithm
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct SensorSetting
  {
    [FieldOffset(0)]
    public unsafe fixed sbyte acSensorName[8];
    [FieldOffset(8)]
    public unsafe fixed byte abyNotSettingReserved[24];
    [FieldOffset(32)]
    public ShapeSensorSetting sShape;
    [FieldOffset(32)]
    public PositionAdjustSetting sPositionAdjust;
    [FieldOffset(32)]
    public CountSensorSetting sCount;
    [FieldOffset(32)]
    public AreaColorSensorSetting sAreaColor;
    [FieldOffset(32)]
    public AreaMonoSensorSetting sAreaMono;
    [FieldOffset(32)]
    public EdgePresenceSensorSetting sEdgePresence;
    [FieldOffset(32)]
    public EdgeWidthSensorSetting sEdgeWidth;
    [FieldOffset(32)]
    public EdgePitchSensorSetting sEdgePitch;
    [FieldOffset(32)]
    public DiameterSensorSetting sDiameter;
    [FieldOffset(32)]
    public EdgePixelCountSensorSetting sEdgePixelCount;
    [FieldOffset(32)]
    public OneAxisPosadjustSensorSetting sOneAxisPosAdjust;
    [FieldOffset(32)]
    public TwoAxesPosadjustSensorSetting sTwoAxesPosAdjust;
    [FieldOffset(32)]
    public ReservedSensorSetting sReserved;
  }
}
