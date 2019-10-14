// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.IvaReader
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using Keyence.IV.Sdk.Common.IVAFile;
using System;
using System.IO;

namespace Keyence.IV.Sdk
{
  public sealed class IvaReader : IDisposable
  {
    private bool _disposed;
    private readonly FileStream _reader;
    private bool _canRead;
    private IvaFileHandler _ivaHandler;

    public bool Disposed
    {
      get
      {
        return this._disposed;
      }
    }

    public bool CanRead
    {
      get
      {
        return this._canRead;
      }
    }

    private CmosType CmosType
    {
      get
      {
        this.ThrowExceptionIfDisposed();
        this.ThrowExceptionIfClosed();
        return (CmosType) this._ivaHandler.CommonHandler.CameraVersion.sProof.sCameraSpec.byCmosSensorKind;
      }
    }

    public IvaReader(string filePath)
    {
      if (!File.Exists(filePath))
        throw new IvaFileException(IvaFileErrors.FileErrorsOpen);
      try
      {
        this._reader = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
        this._canRead = true;
      }
      catch (Exception ex)
      {
        throw new IvaFileException(IvaFileErrors.FileErrorsOpen);
      }
      IvaFileErrors error = Ivff.IvaLoad((Stream) this._reader, out this._ivaHandler);
      if (error != IvaFileErrors.FileErrorsNone)
        throw new IvaFileException(error);
    }

    ~IvaReader()
    {
      this.Dispose(false);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    public void Close()
    {
      this.ThrowExceptionIfDisposed();
      if (this._reader != null)
        this._reader.Close();
      this._canRead = false;
    }

    public IvaProgramDescription[] GetProgramDescriptionList()
    {
      this.ThrowExceptionIfDisposed();
      this.ThrowExceptionIfClosed();
      IvBankList[] bankList = new IvBankList[32];
      int num = (int) Ivff.IvaLoadBankList((Stream) this._reader, ref this._ivaHandler, ref bankList);
      IvaProgramDescription[] programDescriptionArray = new IvaProgramDescription[32];
      for (int index = 0; index < 32; ++index)
        programDescriptionArray[index] = new IvaProgramDescription(index, this.CmosType, ref bankList[index]);
      return programDescriptionArray;
    }

    private void ThrowExceptionIfDisposed()
    {
      if (this._disposed)
        throw new ObjectDisposedException(this.GetType().ToString());
    }

    private void ThrowExceptionIfClosed()
    {
      if (!this._canRead)
        throw new IvaFileException(IvaFileErrors.FileErrorsOpen);
    }

    private void Dispose(bool disposing)
    {
      if (this._disposed)
        return;
      if (disposing)
        this.Close();
      this._disposed = true;
    }

    internal Holder<BankSettingAll> GetBankSettingAll(int programNo)
    {
      this.ThrowExceptionIfDisposed();
      this.ThrowExceptionIfClosed();
      Holder<BankSettingAll> holder = new Holder<BankSettingAll>();
      int num = (int) Ivff.LoadBankSettingAll((Stream) this._reader, ref this._ivaHandler.CameraBankHeader, programNo, ref holder.Target);
      return holder;
    }

    internal Holder<VisionSensorSystemSetting> GetSystemSetting()
    {
      this.ThrowExceptionIfDisposed();
      this.ThrowExceptionIfClosed();
      Holder<VisionSensorSystemSetting> holder = new Holder<VisionSensorSystemSetting>();
      int num = (int) Ivff.IvaLoadSystemSetting((Stream) this._reader, ref this._ivaHandler.CameraSystemHeader, ref holder.Target);
      return holder;
    }

    internal Holder<VisionSensorVersion> GetFileSensorVersion()
    {
      this.ThrowExceptionIfDisposed();
      this.ThrowExceptionIfClosed();
      return new Holder<VisionSensorVersion>()
      {
        Target = this._ivaHandler.CommonHandler.CameraVersion
      };
    }

    internal Holder<IvVersionInfoData> GetFileVersionInfo()
    {
      this.ThrowExceptionIfDisposed();
      this.ThrowExceptionIfClosed();
      return new Holder<IvVersionInfoData>()
      {
        Target = this._ivaHandler.CommonHandler.VersionInfo
      };
    }
  }
}
