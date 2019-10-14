// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.IVAFile.IvffResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common.IVAFile
{
  internal enum IvffResult
  {
    ACCESS_ERROR = -100, // -0x00000064
    WRITE_ERROR = -99, // -0x00000063
    READ_ERROR = -98, // -0x00000062
    VERIFY_ERROR = -97, // -0x00000061
    INVALID = -96, // -0x00000060
    UNMACH_BLOCK = -95, // -0x0000005F
    UNCOMPATIBLE = -94, // -0x0000005E
    FATAL_ERROR = -93, // -0x0000005D
    OK = 0,
    SIZE_LESS = 1,
    SIZE_OVER = 2,
    SIZE_ZERO = 3,
    CONTINUE = 4,
  }
}
