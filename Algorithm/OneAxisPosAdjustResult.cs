// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.OneAxisPosAdjustResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct OneAxisPosAdjustResult
  {
    public ushort wMatchPercent;
    public PositionControl sPositionDescription;
    public EdgeInfo sDispPosition;
    public ushort wMasterPosition;
    public byte byEdgeExtractDirection;
    public byte byDetectCount;
    public unsafe fixed ushort awPosition[40];
    public byte byMasterMaxEdgeStrength;
    public unsafe fixed byte abyReserved[3];
  }
}
