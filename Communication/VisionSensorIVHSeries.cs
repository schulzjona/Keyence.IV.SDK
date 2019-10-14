// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.VisionSensorIVHSeries
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using Keyence.IV.Sdk.Common.IVAFile;
using System;

namespace Keyence.IV.Sdk.Communication
{
  internal class VisionSensorIVHSeries : VisionSensor, IVisionSensorIVHSeries, IVisionSensor, IDisposable
  {
    internal VisionSensorIVHSeries(
      IDataRepository dataRepository,
      IErrorRepository errorRepository,
      ITcpCommand command)
      : base(dataRepository, errorRepository, command)
    {
    }

    public void ImportSingleProgram(IvaReader reader, int srcProgramNo, int dstProgramNo)
    {
      if (srcProgramNo < 0 || 32 <= srcProgramNo)
        throw new ArgumentException("Invalid program no.", nameof (srcProgramNo));
      if (dstProgramNo < 0 || 32 <= dstProgramNo)
        throw new ArgumentException("Invalid program no.", nameof (dstProgramNo));
      if (reader.Disposed)
        throw new InvalidOperationException("Reader was disposed.");
      if (!reader.CanRead)
        throw new InvalidOperationException("Reader can't read.");
      if (this.DataRepository.LoginRequired)
      {
        if (!this.DataRepository.LoggedIn)
          throw new InvalidOperationException("Unlock is needed.");
      }
      try
      {
        if ((int) reader.GetSystemSetting().Target.sUtility.byUnitType != (int) this.DataRepository.UnitType)
          throw new IvaFileException(IvaFileErrors.FileErrorsCompatible);
        if (!this.CheckSensorType(ref reader.GetFileSensorVersion().Target))
          throw new IvaFileException(IvaFileErrors.FileErrorsCompatible);
        Holder<IvVersionInfoData> fileVersionInfo = reader.GetFileVersionInfo();
        if (!this.CheckMasterSlaveCompatibility(ref fileVersionInfo.Target))
          throw new IvaFileException(IvaFileErrors.FileErrorsCompatible);
        if (!this.CheckIvFileSettingVersion(ref fileVersionInfo.Target))
          throw new IvaFileException(IvaFileErrors.FileErrorsCompatible);
        if (reader.GetProgramDescriptionList()[srcProgramNo].Configured)
          this.Sequencer.SetBankSetting(ref reader.GetBankSettingAll(srcProgramNo).Target, dstProgramNo);
        else
          this.Sequencer.DeleteBankSetting(dstProgramNo);
        this.AutoCommunicator.DoWork(true);
      }
      catch (SettingChangeException ex)
      {
        this.Dispose();
        throw new ConnectionLostException(ex.Message, (Exception) ex);
      }
      catch (ConnectionLostException ex)
      {
        this.Dispose();
        throw;
      }
    }

    private bool CheckIvFileSettingVersion(ref IvVersionInfoData versionInfo)
    {
      if (versionInfo.MinSensorVersion.wSpecialOrderVersion != (ushort) 0 && (this.DataRepository.SpecialOrderVersion == (ushort) 0 || (int) versionInfo.MinSensorVersion.wSpecialOrderVersion > (int) this.DataRepository.SpecialOrderVersion))
        return false;
      if ((int) versionInfo.MinSensorVersion.wMajorVersion <= (int) this.DataRepository.MajorVersion && ((int) versionInfo.MinSensorVersion.wMajorVersion != (int) this.DataRepository.MajorVersion || (int) versionInfo.MinSensorVersion.wMinorVersion <= (int) this.DataRepository.MinorVersion))
        return true;
      if (versionInfo.MinSensorVersion.wMajorVersion > (ushort) 1 || versionInfo.MinSensorVersion.wMajorVersion != (ushort) 1 || versionInfo.MinSensorVersion.wMinorVersion <= (ushort) 4)
        ;
      return false;
    }

    private bool CheckMasterSlaveCompatibility(ref IvVersionInfoData versionInfo)
    {
      switch (this.DataRepository.SensorType)
      {
        case VisionSensorType.SeparateMasterAmp:
          if (((int) versionInfo.AmpCompatible & 254) > 0)
            return false;
          break;
        case VisionSensorType.SeparateSlaveAmp:
          if (((int) versionInfo.AmpCompatible & 253) > 0)
            return false;
          break;
        case VisionSensorType.TypeBuiltin:
          if (((int) versionInfo.AmpCompatible & (int) byte.MaxValue) > 0)
            return false;
          break;
        default:
          return false;
      }
      return true;
    }

    private bool CheckSensorType(ref VisionSensorVersion sensorVersion)
    {
      if (sensorVersion.sProof.byVisionSensorType == (byte) 253 || sensorVersion.sProof.byVisionSensorType == (byte) 254)
      {
        if (this.DataRepository.SensorType != VisionSensorType.SeparateMasterAmp && this.DataRepository.SensorType != VisionSensorType.SeparateSlaveAmp)
          return false;
      }
      else if ((VisionSensorType) sensorVersion.sProof.byVisionSensorType != this.DataRepository.SensorType)
        return false;
      return (CmosType) sensorVersion.sProof.sCameraSpec.byCmosSensorKind == this.DataRepository.CmosSensorType && (FocusDistance) sensorVersion.sProof.sCameraSpec.byFocusDistanceKind == this.DataRepository.FocusDistance;
    }
  }
}
