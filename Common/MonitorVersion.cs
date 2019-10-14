// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.MonitorVersion
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal struct MonitorVersion
  {
    public unsafe fixed sbyte acModelName[32];
    public unsafe fixed sbyte acSerialNo[32];
    public unsafe fixed byte abyMacAddress[6];
    public unsafe fixed byte __padding__[2];
    public StructTpCalib TpCalib;
    public unsafe fixed byte _RtcInitialSettingDate[12];
    public unsafe fixed byte _FactoryCheckFlag[4];
    public unsafe fixed sbyte acFirstLoader[8];
    public unsafe fixed sbyte acSecondLoader0[8];
    public unsafe fixed sbyte acSecondLoader1[8];
    public unsafe fixed sbyte acDevJigMode[8];
    public unsafe fixed sbyte acMonitorVersion[8];
    public SettingVersion sSettingVersion;
    public unsafe fixed byte abyNotSettingReserved[16];
  }
}
