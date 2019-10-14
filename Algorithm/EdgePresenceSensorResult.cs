// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.EdgePresenceSensorResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct EdgePresenceSensorResult
  {
    public ushort wMatchPercent;
    public byte byReserved;
    public byte byActiveEdgeCount;
    public EdgeInfo sPresencePosition;
    public unsafe fixed ushort awCountPosition[64];
    public PointW sFirstEdgeAbsPosition;
    public ushort wMasterPresencePosition;
    public byte byMasterEdgeCount;
    public byte byMasterMaxEdgeStrength;
  }
}
