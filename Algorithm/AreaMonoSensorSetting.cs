// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.AreaMonoSensorSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct AreaMonoSensorSetting
  {
    public AreaHsvThreshold sAreaHsvThreshold;
    public VectorAreaItem sTemplateVector;
    public unsafe fixed byte abyPadding00[2];
    public AreaMonoSensorOperationSetting sOperationSetting;
    public byte byFirstPointValid;
    public byte byPadding;
    public Hsv sHSVFirstPoint;
    public unsafe fixed byte abyPadding01[2];
  }
}
