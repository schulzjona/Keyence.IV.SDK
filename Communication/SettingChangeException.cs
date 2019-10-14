// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.SettingChangeException
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Keyence.IV.Sdk.Communication
{
  [Serializable]
  internal sealed class SettingChangeException : Exception
  {
    internal SettingChangeException()
    {
    }

    internal SettingChangeException(string message)
      : base(message)
    {
    }

    internal SettingChangeException(string message, Exception inner)
      : base(message, inner)
    {
    }

    internal SettingChangeException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
