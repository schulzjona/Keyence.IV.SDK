// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ProgramSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System;
using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Communication
{
  internal class ProgramSetting : IProgramSetting, ICauseError
  {
    private readonly ToolSettingInternalBase[] _sensorSettings = new ToolSettingInternalBase[17];
    private readonly short[] _colorMaster;
    private readonly bool _externalTrigger;
    private readonly byte[] _monochromeMaster;
    private readonly string _programName;
    private readonly int _programNo;
    private readonly ushort _triggerCycleMilliSec;

    internal unsafe ProgramSetting(IProgramNo programNumber, ReplyForGetBankSetting* reply)
    {
      this.Error = (SensorError) new ConcreteSensorError((ErrI) reply->header.wErrorId);
      this._programNo = programNumber.No;
      this._externalTrigger = reply->bankSetting.sBankSettingCommon.sTriggerSetting.byExternalTrigger != (byte) 0;
      this._triggerCycleMilliSec = reply->bankSetting.sBankSettingCommon.sTriggerSetting.wInternalyCycleTime;
      this._programName = StringConverter.StringFromUnicode(reply->bankSetting.sBankSettingCommon.sBankName.awcBankName, 16);
      this._monochromeMaster = new byte[76800];
      this._colorMaster = new short[76800];
      Marshal.Copy((IntPtr) ((void*) reply->bankSetting.sBankSettingCommon.sMasterImage.sMasterImageSet.uMono.abyImageBuffer), this._monochromeMaster, 0, 76800);
      Marshal.Copy((IntPtr) ((void*) reply->bankSetting.sBankSettingCommon.sMasterImage.sMasterImageSet.uColor.awImageBuffer), this._colorMaster, 0, 76800);
      BankSettingVsa*[] bankSettingVsaPtrArray = new BankSettingVsa*[17]
      {
        &reply->bankSetting.asBankSettingVsa0,
        &reply->bankSetting.asBankSettingVsa1,
        &reply->bankSetting.asBankSettingVsa2,
        &reply->bankSetting.asBankSettingVsa3,
        &reply->bankSetting.asBankSettingVsa4,
        &reply->bankSetting.asBankSettingVsa5,
        &reply->bankSetting.asBankSettingVsa6,
        &reply->bankSetting.asBankSettingVsa7,
        &reply->bankSetting.asBankSettingVsa8,
        &reply->bankSetting.asBankSettingVsa9,
        &reply->bankSetting.asBankSettingVsa10,
        &reply->bankSetting.asBankSettingVsa11,
        &reply->bankSetting.asBankSettingVsa12,
        &reply->bankSetting.asBankSettingVsa13,
        &reply->bankSetting.asBankSettingVsa14,
        &reply->bankSetting.asBankSettingVsa15,
        &reply->bankSetting.asBankSettingVsa16
      };
      for (int index = 0; index < 17; ++index)
        this._sensorSettings[index] = ToolKindBase.Create(bankSettingVsaPtrArray[index]);
    }

    public string ProgramName
    {
      get
      {
        return this._programName;
      }
    }

    public int ProgramNo
    {
      get
      {
        return this._programNo;
      }
    }

    public bool ExternalTrigger
    {
      get
      {
        return this._externalTrigger;
      }
    }

    public ushort TriggerCycleMilliSec
    {
      get
      {
        return this._triggerCycleMilliSec;
      }
    }

    public ToolSettingBase PositionAdjustSetting
    {
      get
      {
        return (ToolSettingBase) this._sensorSettings[0];
      }
    }

    public ToolSettingBase this[byte toolNo]
    {
      get
      {
        if ((byte) 17 <= toolNo)
          throw new IndexOutOfRangeException();
        return (ToolSettingBase) this._sensorSettings[(int) toolNo];
      }
    }

    public byte[] MonochromeMaster
    {
      get
      {
        return this._monochromeMaster;
      }
    }

    public short[] ColorMaster
    {
      get
      {
        return this._colorMaster;
      }
    }

    public SensorError Error { private set; get; }
  }
}
