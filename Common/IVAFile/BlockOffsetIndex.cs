// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.IVAFile.BlockOffsetIndex
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common.IVAFile
{
  internal enum BlockOffsetIndex
  {
    INVALID = -1,
    VS_SYSTEM_SETTING = 0,
    NETWORK_SETTING = 1,
    BANK_SETTING = 2,
    SUMMARY = 3,
    HISTOGRAM = 4,
    PICTURE_LOG = 5,
    MN_VERSION = 6,
    BANK_LIST = 7,
    VS_SYSTEM_LOG = 8,
    COMMUNICATION_LOG = 9,
    SYSTEM_ERROR_LOG = 10, // 0x0000000A
    SYSTEM_CHANGE_LOG = 11, // 0x0000000B
    MAX = 12, // 0x0000000C
  }
}
