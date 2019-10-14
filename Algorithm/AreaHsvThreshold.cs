// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.AreaHsvThreshold
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct AreaHsvThreshold
  {
    public unsafe fixed ushort awThresholdH[2];
    public unsafe fixed ushort awThresholdS[2];
    public unsafe fixed ushort awThresholdV[2];
    public byte byAreaDetectMode;
    public byte byValid;
  }
}
