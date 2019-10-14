// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.IVAFile.IvVariableArrayBlockHeader
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common.IVAFile
{
  internal struct IvVariableArrayBlockHeader
  {
    public IvCommonBlockHeader CommonHeader;
    public int Size;
    public ushort Index;
    private ushort _reserved1_;
    public ushort NumElements;
    public ushort TableOffset;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U4)]
    private uint[] _reserved2_;
  }
}
