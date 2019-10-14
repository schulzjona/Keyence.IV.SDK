// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.Progress
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal class Progress : IProgress, ICauseError
  {
    private const int COMPLETE_PERCENTAGE = 100;

    public unsafe Progress(ReplyForQueryConfirmBankSettingStatus* pReply)
    {
      this.Error = (SensorError) new ConcreteSensorError((ErrI) pReply->header.wErrorId);
      // ISSUE: reference to a compiler-generated field
      this.Completed = pReply->header.uOption0.abyCode.FixedElementField == (byte) 100;
    }

    public unsafe Progress(ReplyForQueryConfirmSystemSettingStatus* pReply)
    {
      this.Error = (SensorError) new ConcreteSensorError((ErrI) pReply->header.wErrorId);
      // ISSUE: reference to a compiler-generated field
      this.Completed = pReply->header.uOption0.abyCode.FixedElementField == (byte) 100;
    }

    public bool Completed { get; private set; }

    public SensorError Error { private set; get; }
  }
}
