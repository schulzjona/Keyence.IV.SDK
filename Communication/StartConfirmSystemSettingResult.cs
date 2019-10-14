// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.StartConfirmSystemSettingResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal class StartConfirmSystemSettingResult : IAsyncProcessStartResult, ICauseError
  {
    public unsafe StartConfirmSystemSettingResult(ReplyForStartConfirmSystemSetting* pReply)
    {
      this.Error = (SensorError) new ConcreteSensorError((ErrI) pReply->header.wErrorId);
      this.Success = true;
    }

    public bool Success { private set; get; }

    public SensorError Error { private set; get; }
  }
}
