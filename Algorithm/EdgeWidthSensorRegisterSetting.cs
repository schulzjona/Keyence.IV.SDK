// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.EdgeWidthSensorRegisterSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct EdgeWidthSensorRegisterSetting
  {
    public byte byEdgeThreshold;
    public byte byFilter;
    public byte byMode;
    public byte byMasterEdgeCount;
    public unsafe fixed byte sEdgeDesignation[8];
    public VectorAreaItem sTemplateVector;
    public EdgeWidthSensorMask sMask;
    public ScalingSetting sScalingSetting;
    public unsafe fixed ushort awMasterPosition[2];
  }
}
