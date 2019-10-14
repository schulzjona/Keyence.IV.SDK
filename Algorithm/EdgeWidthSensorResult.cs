// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.EdgeWidthSensorResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct EdgeWidthSensorResult
  {
    public uint dwMatchPercent;
    public unsafe fixed byte asDispPosition[16];
    public byte byActiveEdgeCount;
    public byte byMasterMaxEdgeStrength;
    public byte byMasterEdgeCount;
    public byte byDetectCount;
    public ScalingSetting sScalingSetting;
    public unsafe fixed byte sEdgeAbsPosition[8];
    public ushort wWidth;
    public ushort wMasterWidth;
    public unsafe fixed byte asMasterPosition[16];
    public unsafe fixed ushort awPosition[40];
  }
}
