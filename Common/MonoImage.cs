// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.MonoImage
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct MonoImage
  {
    [FieldOffset(0)]
    public unsafe fixed byte abyImageBuffer[76800];
    [FieldOffset(0)]
    public unsafe fixed ushort awImageBuffer[38400];
    [FieldOffset(0)]
    public unsafe fixed uint adwImageBuffer[19200];
  }
}
