// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.IVAFile.IvThumbnailColor
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common.IVAFile
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct IvThumbnailColor
  {
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4800, ArraySubType = UnmanagedType.U2)]
    public ushort[] ImageBuffer;
  }
}
