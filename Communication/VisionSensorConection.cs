// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.VisionSensorConection
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;
using System.Net;
using System.Net.Sockets;

namespace Keyence.IV.Sdk.Communication
{
  internal class VisionSensorConection : IConnection
  {
    private readonly byte[] _rawReceiveBuffer = new byte[512000];
    private readonly object _syncRoot = new object();
    private const int TIMEOUT_MS = 60000;
    private readonly IPAddress _startAddress;
    private readonly IPAddress _ipAddress;
    private readonly ushort _portNo;
    private Socket _socket;

    internal VisionSensorConection(IPAddress startAddress, IPAddress ipAddress, ushort portNo)
    {
      this._startAddress = startAddress;
      this._ipAddress = ipAddress;
      this._portNo = portNo;
    }

    public bool Connect()
    {
      IPEndPoint ipEndPoint = new IPEndPoint(this._ipAddress, (int) this._portNo);
      this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      this._socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 60000);
      this._socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 60000);
      this._socket.Bind((EndPoint) new IPEndPoint(this._startAddress, 0));
      try
      {
        this._socket.Connect((EndPoint) ipEndPoint);
      }
      catch (SocketException ex)
      {
        throw new ConnectionLostException(ex.Message);
      }
      return true;
    }

    public void Disconnect()
    {
      this._socket.Disconnect(false);
      this._socket.Close();
      this._socket = (Socket) null;
    }

    public void Send(byte[] data, int size)
    {
      int num;
      lock (this._syncRoot)
        num = this.TrySend(data, size);
      if (num != size)
        throw new ConnectionLostException("Failed to send data.");
    }

    public byte[] Receive()
    {
      int length = 0;
      do
      {
        length += this.TryReceive(length);
      }
      while (this._socket.Available != 0);
      byte[] numArray = new byte[length];
      Array.Copy((Array) this._rawReceiveBuffer, (Array) numArray, length);
      return numArray;
    }

    private int TrySend(byte[] data, int size)
    {
      try
      {
        return this._socket.Send(data, size, SocketFlags.None);
      }
      catch (SocketException ex)
      {
        throw new ConnectionLostException(ex.Message);
      }
    }

    private int TryReceive(int previouslyReceivedSize)
    {
      try
      {
        lock (this._syncRoot)
          return this._socket.Receive(this._rawReceiveBuffer, previouslyReceivedSize, this._rawReceiveBuffer.Length - previouslyReceivedSize, SocketFlags.None);
      }
      catch (SocketException ex)
      {
        throw new ConnectionLostException(ex.Message);
      }
      catch (ObjectDisposedException ex)
      {
        throw new ConnectionLostException(ex.Message);
      }
    }

    private bool Equals(VisionSensorConection other)
    {
      if (object.ReferenceEquals((object) null, (object) other))
        return false;
      if (object.ReferenceEquals((object) this, (object) other))
        return true;
      if (object.Equals((object) other._ipAddress, (object) this._ipAddress))
        return (int) other._portNo == (int) this._portNo;
      return false;
    }

    public override bool Equals(object obj)
    {
      if (object.ReferenceEquals((object) null, obj))
        return false;
      if (object.ReferenceEquals((object) this, obj))
        return true;
      if (obj.GetType() != typeof (VisionSensorConection))
        return false;
      return this.Equals((VisionSensorConection) obj);
    }

    public override int GetHashCode()
    {
      return (this._ipAddress != null ? this._ipAddress.GetHashCode() : 0) * 397 ^ this._portNo.GetHashCode();
    }

    public override string ToString()
    {
      return "IPAddress:" + (object) this._ipAddress + " PortNo: " + (object) this._portNo;
    }
  }
}
