// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.ConnectionLostException
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Keyence.IV.Sdk
{
  [Serializable]
  public sealed class ConnectionLostException : Exception
  {
    internal ConnectionLostException()
    {
    }

    internal ConnectionLostException(string message)
      : base(message)
    {
    }

    internal ConnectionLostException(string message, Exception inner)
      : base(message, inner)
    {
    }

    internal ConnectionLostException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
