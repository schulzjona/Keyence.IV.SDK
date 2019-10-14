// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.IVAFile.IvVersionInfoData
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common.IVAFile
{
  internal struct IvVersionInfoData
  {
    public byte CreatorID;
    public byte AmpCompatible;
    public byte HardwareVersion;
    private byte _reserved_;
    public uint FileSize;
    public SettingVersion FileVersion;
    public SettingVersion CommDataVersion;
    public SettingVersion SensorVersion;
    public SettingVersion PictureVersion;
    public IvSoftwareVersion SimulatorVersion;
    public IvSoftwareVersion ApplicationVersion;
    public SettingVersion MinFileVersion;
    public SettingVersion MinCommDataVersion;
    public SettingVersion MinSensorVersion;
  }
}
