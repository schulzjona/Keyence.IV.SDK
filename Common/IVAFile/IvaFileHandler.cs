// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.IVAFile.IvaFileHandler
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common.IVAFile
{
  [StructLayout(LayoutKind.Sequential)]
  internal class IvaFileHandler
  {
    public IvCommonFileHandler CommonHandler;
    public IvCommonBlockHeader CameraSystemHeader;
    public IvCommonBlockHeader CameraNetworkHeader;
    public IvBankSettingBlockHeader CameraBankHeader;
    public IvCommonBlockHeader BankListHeader;
  }
}
