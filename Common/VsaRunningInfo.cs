// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.VsaRunningInfo
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;

namespace Keyence.IV.Sdk.Common
{
  internal struct VsaRunningInfo
  {
    public uint dwRunningTimer;
    public uint dwTriggerNo;
    public uint dwBankTriggerNo;
    public uint dwDetectTime;
    public byte byActiveBankNo;
    public byte byDetectOk;
    public byte byFocusValue;
    public byte byPadding;
    public ushort wNonMaskedFpgaError;
    public unsafe fixed byte abyNotSettingReserved[18];
    public ushort wLightAdjustCoefficient;
    public unsafe fixed byte abyPadding[2];
    public uint dwSensorSettingChangeCounter;
    public RunningInfoSetting sSettingInfo;
    public SensorResult asSensorResult0;
    public SensorResult asSensorResult1;
    public SensorResult asSensorResult2;
    public SensorResult asSensorResult3;
    public SensorResult asSensorResult4;
    public SensorResult asSensorResult5;
    public SensorResult asSensorResult6;
    public SensorResult asSensorResult7;
    public SensorResult asSensorResult8;
    public SensorResult asSensorResult9;
    public SensorResult asSensorResult10;
    public SensorResult asSensorResult11;
    public SensorResult asSensorResult12;
    public SensorResult asSensorResult13;
    public SensorResult asSensorResult14;
    public SensorResult asSensorResult15;
    public SensorResult asSensorResult16;
  }
}
