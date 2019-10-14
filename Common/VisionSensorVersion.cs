// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.VisionSensorVersion
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal struct VisionSensorVersion
  {
    public VisionSensorProof sProof;
    public unsafe fixed sbyte acBootVersion[8];
    public unsafe fixed sbyte acAplVersion[8];
    public unsafe fixed sbyte acFpgaVersion[8];
    public unsafe fixed sbyte acUpdateVersion[8];
    public unsafe fixed sbyte acJiguVersion[8];
    public SettingVersion sCommVersion;
    public SettingVersion sImageVersion;
    public SettingVersion sSettingVersion;
    public ushort wMaxLogImageAvailable;
    public unsafe fixed byte abyPadding00[2];
    public uint dwWorkMemorySize;
    public uint dwSensorKindAvailable;
    public byte byMaxNumBank;
    public byte byMaxNumVsa;
    public unsafe fixed byte abyPadding01[2];
    public uint dwAvilableInfo;
    public uint dwNetworkAvailable;
    public unsafe fixed byte abyNotSettingReserved[32];
  }
}
