// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ToolResultInternalBase
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;

namespace Keyence.IV.Sdk.Communication
{
  internal abstract class ToolResultInternalBase : ToolResultBase
  {
    private readonly bool _isOk;

    internal ToolResultInternalBase()
    {
      this._isOk = false;
      this.Extend = new ToolExtendResult();
      this.Scaling = new ToolScalingResult();
    }

    internal unsafe ToolResultInternalBase(SensorResult* result)
    {
      this._isOk = result->byResult == (byte) 1;
      this.Extend = new ToolExtendResult();
      this.Scaling = new ToolScalingResult();
    }

    public override bool Ok
    {
      get
      {
        return this._isOk;
      }
    }

    public override ushort Value { get; protected set; }

    public override sealed ToolExtendResult Extend { get; protected set; }

    public override sealed ToolScalingResult Scaling { get; protected set; }
  }
}
