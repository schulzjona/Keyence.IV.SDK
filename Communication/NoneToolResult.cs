// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.NoneToolResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;

namespace Keyence.IV.Sdk.Communication
{
  internal class NoneToolResult : ToolResultInternalBase
  {
    internal NoneToolResult()
    {
    }

    internal unsafe NoneToolResult(SensorResult* pResult)
      : base(pResult)
    {
    }
  }
}
