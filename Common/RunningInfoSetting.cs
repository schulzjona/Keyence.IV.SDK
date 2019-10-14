// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.RunningInfoSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;

namespace Keyence.IV.Sdk.Common
{
  internal struct RunningInfoSetting
  {
    public BankName sBankName;
    public byte byBrightnessMode;
    public byte byPadding;
    public LightAdjustSetting sLightAdjust;
    public unsafe fixed byte abyNotSettingReserved[12];
    public SensorSetting asSensor0;
    public SensorSetting asSensor1;
    public SensorSetting asSensor2;
    public SensorSetting asSensor3;
    public SensorSetting asSensor4;
    public SensorSetting asSensor5;
    public SensorSetting asSensor6;
    public SensorSetting asSensor7;
    public SensorSetting asSensor8;
    public SensorSetting asSensor9;
    public SensorSetting asSensor10;
    public SensorSetting asSensor11;
    public SensorSetting asSensor12;
    public SensorSetting asSensor13;
    public SensorSetting asSensor14;
    public SensorSetting asSensor15;
    public SensorSetting asSensor16;
  }
}
