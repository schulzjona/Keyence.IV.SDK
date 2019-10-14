// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.IConnectionFactory
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Net;

namespace Keyence.IV.Sdk.Communication
{
  internal interface IConnectionFactory
  {
    ITcpCommand Command { get; }

    IDataRepository DataRepository { get; }

    IErrorRepository ErrorRepository { get; }

    IConnection CreateConnection(IPAddress ipAddress, ushort portNo);
  }
}
