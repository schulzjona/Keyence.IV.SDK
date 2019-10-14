// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.IVAFile.IvBankList
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common.IVAFile
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  internal struct IvBankList
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public string BankName;
    public TriggerSetting TriggerSetting;
    [MarshalAs(UnmanagedType.I1)]
    public bool ConfiguredBank;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17, ArraySubType = UnmanagedType.U1)]
    public byte[] SenosrType;
    [MarshalAs(UnmanagedType.I1)]
    public bool Enable;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U1)]
    public byte[] AddingOutPattern;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 31, ArraySubType = UnmanagedType.U1)]
    private byte[] abyNotSettingReserved;
    public IvThumbnailImage ThumbnailImage;
    public ScreenArea sScreenArea;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U1)]
    public byte[] abyOutPattern;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U1)]
    private byte[] abyPadding;
    public uint dwSensorSettingChangeCounter;
  }
}
