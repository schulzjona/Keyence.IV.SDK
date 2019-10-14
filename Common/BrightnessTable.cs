// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.BrightnessTable
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal struct BrightnessTable
  {
    public unsafe fixed uint adwExposureTime[200];
    public unsafe fixed ushort awInLightVoltageRatio[200];
    public unsafe fixed byte abyAnalogGainNumber[3];
    public unsafe fixed byte abyDigitalGain[3];
    public unsafe fixed byte abyFpgaGain[3];
    public byte byBrightnessTableActiveSize;
    public byte byBrightnessTableOffset;
    public byte byPadding;
  }
}
