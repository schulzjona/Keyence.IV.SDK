// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ConnectionFactory
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Net;

namespace Keyence.IV.Sdk.Communication
{
  internal class ConnectionFactory : IConnectionFactory
  {
    private readonly IPAddress _startAddress;
    private ITcpCommand _command;
    private IConnection _connection;
    private IDataRepository _dataRepository;
    private IErrorRepository _errorRepository;

    public ConnectionFactory()
    {
      this._startAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
    }

    public ConnectionFactory(IPAddress startAddress)
    {
      this._startAddress = startAddress;
    }

    public IConnection CreateConnection(IPAddress ipAddress, ushort portNo)
    {
      this._connection = (IConnection) new VisionSensorConection(this._startAddress, ipAddress, portNo);
      this._command = (ITcpCommand) new CheckedTcpCommand(this._connection);
      this._dataRepository = (IDataRepository) new Keyence.IV.Sdk.Communication.DataRepository();
      this._errorRepository = (IErrorRepository) new Keyence.IV.Sdk.Communication.ErrorRepository(this._command);
      return this._connection;
    }

    public ITcpCommand Command
    {
      get
      {
        return this._command;
      }
    }

    public IDataRepository DataRepository
    {
      get
      {
        return this._dataRepository;
      }
    }

    public IErrorRepository ErrorRepository
    {
      get
      {
        return this._errorRepository;
      }
    }
  }
}
