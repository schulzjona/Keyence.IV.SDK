// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.VectorAreaItemRectangle
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct VectorAreaItemRectangle
  {
    public PointN sCenterPosition;
    public ushort wWidth;
    public ushort wHeight;
    public short nRotationAngle;
    public unsafe fixed byte abyReserved[2];
  }
}
