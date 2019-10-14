// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ClearErrorResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal class ClearErrorResult : IClearErrorResult, ICauseError
  {
    private readonly SensorErrorCollection _clearedErrors;

    public unsafe ClearErrorResult(ReplyForClearError* receiveBuffer)
    {
      this.Error = (SensorError) new ConcreteSensorError((ErrI) receiveBuffer->header.wErrorId);
      this._clearedErrors = new SensorErrorCollection(receiveBuffer->header.uOption0.dwCode, receiveBuffer->header.uOption1.dwCode, receiveBuffer->header.uOption2.dwCode, receiveBuffer->header.uOption3.dwCode);
    }

    public SensorError Error { private set; get; }

    public SensorErrorCollection ClearedError
    {
      get
      {
        return this._clearedErrors;
      }
    }
  }
}
