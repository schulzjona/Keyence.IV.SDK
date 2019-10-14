// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.PartOfTwoAxesresult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct PartOfTwoAxesresult
  {
    public byte byEdgeActive;
    public byte byMasterMaxEdgeStrength;
    public byte byMasterSeparateIndex;
    public byte byReserved1;
    public EdgeInfo sDispPosition;
    public ushort wMasterPosition;
    public byte byEdgeExtractDirection;
    public byte byDetectBit;
    public unsafe fixed ushort awPosition[8];
    public unsafe fixed byte abyReserved2[4];
  }
}
