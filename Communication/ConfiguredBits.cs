// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ConfiguredBits
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal class ConfiguredBits : IConfiguredBits, ICauseError
  {
    public unsafe ConfiguredBits(ReplyForGetBankList* reply)
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
      for (int index = 0; index < bankBriefPtrArray.Length; ++index)
      {
        if (bankBriefPtrArray[index]->byConfiguredBank != (byte) 0)
          this.Bits |= (uint) (1 << index);
      }
    }

    public SensorError Error { get; private set; }

    public uint Bits { get; private set; }
  }
}
