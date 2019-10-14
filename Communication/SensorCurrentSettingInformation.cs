// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.SensorCurrentSettingInformation
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal class SensorCurrentSettingInformation : ISensorCurrentSettingInformation, ICauseError
  {
    public unsafe SensorCurrentSettingInformation(ReplyForGetSettingChangeInfo* reply)
    {
      // ISSUE: reference to a compiler-generated field
      this.ActiveBankNo = reply->header.uOption0.abyCode.FixedElementField;
      this.ActiveSettingChangeCounter = reply->header.uOption1.dwCode;
      this.AnySettingChangeCounter = reply->header.uOption2.dwCode;
      this.Error = (SensorError) new ConcreteSensorError((ErrI) reply->header.wErrorId);
    }

    internal unsafe SensorCurrentSettingInformation(VisionSensorState* pState)
    {
      this.ActiveBankNo = pState->sSettingChangeInfo.byActiveBankNo;
      this.ActiveSettingChangeCounter = pState->sSettingChangeInfo.dwActiveSettingChangeCounter;
      this.AnySettingChangeCounter = pState->sSettingChangeInfo.dwAnySettingChangeCounter;
      this.Error = (SensorError) new ConcreteSensorError(ErrI.ErriNone);
    }

    public byte ActiveBankNo { get; private set; }

    public uint ActiveSettingChangeCounter { get; private set; }

    public uint AnySettingChangeCounter { get; private set; }

    public SensorError Error { private set; get; }
  }
}
