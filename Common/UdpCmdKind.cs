// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.UdpCmdKind
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal enum UdpCmdKind
  {
    UdpCmdNone = 0,
    UdpCmdVsaStateTransition = 1,
    UdpCmdVsaSearch = 2,
    UdpSaveNetworkSetting = 63, // 0x0000003F
    UdpCmdMax = 64, // 0x00000040
  }
}
