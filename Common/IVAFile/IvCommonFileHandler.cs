// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.IVAFile.IvCommonFileHandler
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common.IVAFile
{
  internal struct IvCommonFileHandler
  {
    public uint VersionInfoID;
    public IvVersionInfoData VersionInfo;
    public VisionSensorVersion CameraVersion;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.U4)]
    public uint[] BlockOffsetTable;
    public IvCommonCheckWork CheckerWork;
    public IvCommonBlockHeader VersionInfofHeader;
    public IvCommonBlockHeader CameraInfofHeader;
    public IvCommonBlockHeader BlockOffsetHeader;
  }
}
