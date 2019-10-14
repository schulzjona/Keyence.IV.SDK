// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.ScalingSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct ScalingSetting
  {
    public byte byScalingValid;
    public unsafe fixed byte abyReservedPre[3];
    public uint dwDispValue;
    public byte byUnitType;
    public unsafe fixed byte abyReservedSec[3];
  }
}
