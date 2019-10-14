// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.ScalingDispSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct ScalingDispSetting
  {
    public uint dwDispMax;
    public byte byDotPosition;
    public byte byScalingValid;
    public unsafe fixed byte abyReservedPre[2];
    public byte byUnitType;
    public unsafe fixed byte abyReservedSec[3];
  }
}
