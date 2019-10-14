// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ConcreteSensorError
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System.Collections.Generic;

namespace Keyence.IV.Sdk.Communication
{
  internal class ConcreteSensorError : SensorError
  {
    private static readonly Dictionary<ErrI, string> ERROR_DESCRIPTION = new Dictionary<ErrI, string>();
    private static readonly List<ErrI> CLEARABLE_ERROR = new List<ErrI>();
    private static readonly List<ErrI> SUSTAINABLE_ERROR = new List<ErrI>();
    private readonly ErrI _error;

    static ConcreteSensorError()
    {
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank00, "Program00 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank01, "Program01 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank02, "Program02 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank03, "Program03 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank04, "Program04 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank05, "Program05 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank06, "Program06 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank07, "Program07 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank08, "Program08 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank09, "Program09 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank10, "Program10 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank11, "Program11 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank12, "Program12 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank13, "Program13 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank14, "Program14 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank15, "Program15 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank16, "Program16 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank17, "Program17 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank18, "Program18 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank19, "Program19 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank20, "Program20 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank21, "Program21 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank22, "Program22 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank23, "Program23 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank24, "Program24 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank25, "Program25 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank26, "Program26 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank27, "Program27 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank28, "Program28 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank29, "Program29 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank30, "Program30 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenBank31, "Program31 Broken.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriTrig, "Trigger Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriTeachShortShape, "Outline Tool Teach Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriTeachShortArea, "Area Tool Teach Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriTeachLightAdjust, "Light Adjust Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriTeachShortEdge, "Edge Tool Teach Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFtpTransferOverflow, "FTP Transfar Overflow Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFtpTransferFailure, "FTP Transfar Failure.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFtpConnection, "FTP Connection Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriTeachShortMemory, "Work Memory Short Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriTeachEmptyImg, "Empty Image Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBootEeprom, "Boot EEPROM Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBootFlashrom, "Boot Flash ROM Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriEeprom, "EEPROM Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFlashrom, "Flash ROM Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriBrokenLighit, "Light Broken Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriShipmentConfig, "Shipment Configuration Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadFpgaSystem, "Head FPGA System Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadI2C, "Head FPGA CMOS Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadTimingConf, "Head FPGA Configure Timing Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadTimingTrig, "Head FPGA Trigger Timing Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadPxMisalign, "Head FPGA Pixel Misallign Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadPxEmpty, "Head FPGA Pixel Empty Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadFifoOverflow, "Head FPGA EMIF Overflow Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadFifoUnderflow, "Head FPGA EMIF Underflow Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadUnexpectedTrig, "Head FPGA Unexpected Trigger.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadUnexpectedBehavior, "Head FPGA Unexpected Behavior.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaSystem, "FPGA System Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaI2C, "Cmos Access Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaTimingConf, "FPGA Configure Timing Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaTimingTrig, "FPGA Trigger Timing Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaPxMisalign, "FPGA Pixel Misallign Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaPxEmpty, "FPGA Pixel Empty Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaEmifOverflow, "FPGA EMIF Overflow Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaEmifUnderflow, "FPGA EMIF Underflow Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaUnexpectedReset, "FPGA Unexpected Reset.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaUnexpectedTrig, "FPGA Unexpected Trigger.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaUnexpectedBehavior, "FPGA Unexpected Behavior.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaSerdesRecover, "Amp FPGA Serdes Recover.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaSerdesFail, "Amp FPGA Serdes Fail.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaHeadError, "Amp FPGA Head Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaAcquireConfigData, "FPGA Configuration Data Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriFpgaConfiguration, "FPGA Configuration Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriPictureUnexpectedTrig, "Picture Unexpected Trigger Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriPictureTransfer, "Picture Transfer Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriPictureTimeout, "Picture Timeout Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriMotorAbort, "Motor Abort Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriEthernetAbort, "Ethernet Abort Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadI2CCmos, "Head FPGA CMOS Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadI2CLight, "Head FPGA Light Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadCyclic, "Head FPGA Cyclic Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadConnect, "Head Connect Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadShipmentConfig, "Head Shipment Error");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriHeadAmpComm, "Head Amp Communication Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriSlaveWakeup, "Expansion Unit Wakeup Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriOccupation, "Occupation Error.");
      ConcreteSensorError.ERROR_DESCRIPTION.Add(ErrI.ErriCameraAnyFatalError, "Any Fatal Error.");
      ConcreteSensorError.CLEARABLE_ERROR.Add(ErrI.ErriNone);
      ConcreteSensorError.CLEARABLE_ERROR.Add(ErrI.ErriTrig);
      ConcreteSensorError.CLEARABLE_ERROR.Add(ErrI.ErriTeachShortShape);
      ConcreteSensorError.CLEARABLE_ERROR.Add(ErrI.ErriTeachShortArea);
      ConcreteSensorError.CLEARABLE_ERROR.Add(ErrI.ErriTeachLightAdjust);
      ConcreteSensorError.CLEARABLE_ERROR.Add(ErrI.ErriTeachShortEdge);
      ConcreteSensorError.CLEARABLE_ERROR.Add(ErrI.ErriFtpTransferOverflow);
      ConcreteSensorError.CLEARABLE_ERROR.Add(ErrI.ErriFtpTransferFailure);
      ConcreteSensorError.CLEARABLE_ERROR.Add(ErrI.ErriFtpConnection);
      ConcreteSensorError.CLEARABLE_ERROR.Add(ErrI.ErriTeachShortMemory);
      ConcreteSensorError.CLEARABLE_ERROR.Add(ErrI.ErriTeachEmptyImg);
      ConcreteSensorError.SUSTAINABLE_ERROR.Add(ErrI.ErriNone);
      ConcreteSensorError.SUSTAINABLE_ERROR.Add(ErrI.ErriTrig);
      ConcreteSensorError.SUSTAINABLE_ERROR.Add(ErrI.ErriTeachShortShape);
      ConcreteSensorError.SUSTAINABLE_ERROR.Add(ErrI.ErriTeachShortArea);
      ConcreteSensorError.SUSTAINABLE_ERROR.Add(ErrI.ErriTeachLightAdjust);
      ConcreteSensorError.SUSTAINABLE_ERROR.Add(ErrI.ErriTeachShortEdge);
      ConcreteSensorError.SUSTAINABLE_ERROR.Add(ErrI.ErriFtpTransferOverflow);
      ConcreteSensorError.SUSTAINABLE_ERROR.Add(ErrI.ErriFtpTransferFailure);
      ConcreteSensorError.SUSTAINABLE_ERROR.Add(ErrI.ErriFtpConnection);
      ConcreteSensorError.SUSTAINABLE_ERROR.Add(ErrI.ErriTeachShortMemory);
      ConcreteSensorError.SUSTAINABLE_ERROR.Add(ErrI.ErriTeachEmptyImg);
    }

    internal ConcreteSensorError(ErrI rawError)
    {
      this._error = rawError;
    }

    public override ushort ErrorCode
    {
      get
      {
        return (ushort) this._error;
      }
    }

    public override string Description
    {
      get
      {
        if (!ConcreteSensorError.ERROR_DESCRIPTION.ContainsKey(this._error))
          return string.Empty;
        return ConcreteSensorError.ERROR_DESCRIPTION[this._error];
      }
    }

    public override bool ProgramaticallyClearable
    {
      get
      {
        return ConcreteSensorError.CLEARABLE_ERROR.Contains(this._error);
      }
    }

    public override bool Sustainable
    {
      get
      {
        return ConcreteSensorError.SUSTAINABLE_ERROR.Contains(this._error);
      }
    }

    private bool Equals(ConcreteSensorError other)
    {
      if (object.ReferenceEquals((object) null, (object) other))
        return false;
      if (object.ReferenceEquals((object) this, (object) other))
        return true;
      return object.Equals((object) other._error, (object) this._error);
    }

    public override bool Equals(object obj)
    {
      if (object.ReferenceEquals((object) null, obj))
        return false;
      if (object.ReferenceEquals((object) this, obj))
        return true;
      if (obj.GetType() != typeof (ConcreteSensorError))
        return false;
      return this.Equals((ConcreteSensorError) obj);
    }

    public override int GetHashCode()
    {
      return this._error.GetHashCode();
    }
  }
}
