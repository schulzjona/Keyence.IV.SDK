// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ProgramList
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System.Collections.Generic;

namespace Keyence.IV.Sdk.Communication
{
  internal class ProgramList : IProgramList, ICauseError
  {
    private readonly ProgramHeader[] _programList = new ProgramHeader[32];

    public unsafe ProgramList(ReplyForGetBankList* reply)
    {
      this.Error = (SensorError) new ConcreteSensorError((ErrI) reply->header.wErrorId);
      BankBrief*[] bankBriefPtrArray = new BankBrief*[32]
      {
        &reply->Brief0,
        &reply->Brief1,
        &reply->Brief2,
        &reply->Brief3,
        &reply->Brief4,
        &reply->Brief5,
        &reply->Brief6,
        &reply->Brief7,
        &reply->Brief8,
        &reply->Brief9,
        &reply->Brief10,
        &reply->Brief11,
        &reply->Brief12,
        &reply->Brief13,
        &reply->Brief14,
        &reply->Brief15,
        &reply->Brief16,
        &reply->Brief17,
        &reply->Brief18,
        &reply->Brief19,
        &reply->Brief20,
        &reply->Brief21,
        &reply->Brief22,
        &reply->Brief23,
        &reply->Brief24,
        &reply->Brief25,
        &reply->Brief26,
        &reply->Brief27,
        &reply->Brief28,
        &reply->Brief29,
        &reply->Brief30,
        &reply->Brief31
      };
      for (int iProgramNo = 0; iProgramNo < bankBriefPtrArray.Length; ++iProgramNo)
      {
        BankBrief* bankBriefPtr = bankBriefPtrArray[iProgramNo];
        this._programList[iProgramNo] = new ProgramHeader(StringConverter.StringFromUnicode(bankBriefPtr->sBankName.awcBankName, 16), iProgramNo, bankBriefPtr->sTriggerSetting.byExternalTrigger != (byte) 0, bankBriefPtr->sTriggerSetting.wInternalyCycleTime);
      }
    }

    public IList<ProgramHeader> List
    {
      get
      {
        return (IList<ProgramHeader>) this._programList;
      }
    }

    public SensorError Error { private set; get; }
  }
}
