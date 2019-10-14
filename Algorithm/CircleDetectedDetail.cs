// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.CircleDetectedDetail
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct CircleDetectedDetail
  {
    public PointL sCenterPosition;
    public uint dwDiameter;
    public byte byEdgeDirection;
    public unsafe fixed byte abyScore[3];
    public uint dwOKPositionBitHigh;
    public uint dwOKPositionBitLow;
    public PointL sTemplatePosition;
    public short nTenthAngle;
    public unsafe fixed byte abyReserved[2];
  }
}
