// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.EdgePitchSensorRegisterSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct EdgePitchSensorRegisterSetting
  {
    public byte byEdgeThreshold;
    public byte byFilter;
    public byte byMode;
    public byte byPitchBrightnessMode;
    public byte byPitchNarrowMode;
    public byte byDetectMode;
    public unsafe fixed byte abyReserved[2];
    public VectorAreaItem sTemplateVector;
    public EdgePresenceSensorMask sMask;
    public ScalingSetting sScalingSetting;
  }
}
