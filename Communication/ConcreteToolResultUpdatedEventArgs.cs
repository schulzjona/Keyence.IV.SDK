// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ConcreteToolResultUpdatedEventArgs
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;
using Keyence.IV.Sdk.Common;
using System;

namespace Keyence.IV.Sdk.Communication
{
  internal sealed class ConcreteToolResultUpdatedEventArgs : ToolResultUpdatedEventArgs
  {
    private readonly ToolResultBase[] _toolResults;

    internal unsafe ConcreteToolResultUpdatedEventArgs(VsaRunningInfo* runninfInfo)
    {
      uint dwDetectTime = runninfInfo->dwDetectTime;
      uint dwBankTriggerNo = runninfInfo->dwBankTriggerNo;
      bool flag = runninfInfo->byDetectOk == (byte) 1;
      SensorSetting*[] sensorSettings = ConcreteToolResultUpdatedEventArgs.GetSensorSettings(runninfInfo);
      SensorResult*[] sensorResults = ConcreteToolResultUpdatedEventArgs.GetSensorResults(runninfInfo);
      this._toolResults = new ToolResultBase[17];
      for (int index = 0; index < sensorResults.Length; ++index)
        this._toolResults[index] = (ToolResultBase) ToolKindBase.Create(sensorResults[index], sensorSettings[index]);
      this.ProcessingTimeMicroSec = dwDetectTime;
      this.TotalStatusResult = flag;
      this.TriggerCount = dwBankTriggerNo;
      this.PositionAdjust = this._toolResults[0];
    }

    public override uint ProcessingTimeMicroSec { get; protected set; }

    public override bool TotalStatusResult { get; protected set; }

    public override uint TriggerCount { get; protected set; }

    public override ToolResultBase PositionAdjust { get; protected set; }

    public override ToolResultBase this[byte toolNo]
    {
      get
      {
        if ((byte) 17 <= toolNo)
          throw new IndexOutOfRangeException();
        return this._toolResults[(int) toolNo];
      }
    }

    public override string[] PropetyList { get; internal set; }

    private static unsafe SensorSetting*[] GetSensorSettings(
      VsaRunningInfo* runninfInfo)
    {
      return new SensorSetting*[17]
      {
        &runninfInfo->sSettingInfo.asSensor0,
        &runninfInfo->sSettingInfo.asSensor1,
        &runninfInfo->sSettingInfo.asSensor2,
        &runninfInfo->sSettingInfo.asSensor3,
        &runninfInfo->sSettingInfo.asSensor4,
        &runninfInfo->sSettingInfo.asSensor5,
        &runninfInfo->sSettingInfo.asSensor6,
        &runninfInfo->sSettingInfo.asSensor7,
        &runninfInfo->sSettingInfo.asSensor8,
        &runninfInfo->sSettingInfo.asSensor9,
        &runninfInfo->sSettingInfo.asSensor10,
        &runninfInfo->sSettingInfo.asSensor11,
        &runninfInfo->sSettingInfo.asSensor12,
        &runninfInfo->sSettingInfo.asSensor13,
        &runninfInfo->sSettingInfo.asSensor14,
        &runninfInfo->sSettingInfo.asSensor15,
        &runninfInfo->sSettingInfo.asSensor16
      };
    }

    private static unsafe SensorResult*[] GetSensorResults(VsaRunningInfo* runninfInfo)
    {
      return new SensorResult*[17]
      {
        &runninfInfo->asSensorResult0,
        &runninfInfo->asSensorResult1,
        &runninfInfo->asSensorResult2,
        &runninfInfo->asSensorResult3,
        &runninfInfo->asSensorResult4,
        &runninfInfo->asSensorResult5,
        &runninfInfo->asSensorResult6,
        &runninfInfo->asSensorResult7,
        &runninfInfo->asSensorResult8,
        &runninfInfo->asSensorResult9,
        &runninfInfo->asSensorResult10,
        &runninfInfo->asSensorResult11,
        &runninfInfo->asSensorResult12,
        &runninfInfo->asSensorResult13,
        &runninfInfo->asSensorResult14,
        &runninfInfo->asSensorResult15,
        &runninfInfo->asSensorResult16
      };
    }
  }
}
