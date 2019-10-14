// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.VisionSensorRepository
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Net;

namespace Keyence.IV.Sdk.Communication
{
  internal class VisionSensorRepository
  {
    private readonly Dictionary<IVisionSensor, IConnection> _dictionary = new Dictionary<IVisionSensor, IConnection>();
    private static int _referenceCount;
    private static VisionSensorRepository _instance;
    private IConnectionFactory _factory;

    private VisionSensorRepository()
    {
      if (ExecutingMonitorExplorer.Acquire())
        throw new ApplicationException("Multiple activations are not possible.");
      this._factory = (IConnectionFactory) new ConnectionFactory();
    }

    public static VisionSensorRepository GetInstance()
    {
      if (VisionSensorRepository._instance == null)
        VisionSensorRepository._instance = new VisionSensorRepository();
      ++VisionSensorRepository._referenceCount;
      return VisionSensorRepository._instance;
    }

    public static void ReleaseInstance()
    {
      --VisionSensorRepository._referenceCount;
      if (VisionSensorRepository._referenceCount > 0)
        return;
      ExecutingMonitorExplorer.Release();
      VisionSensorRepository._instance = (VisionSensorRepository) null;
    }

    public void ChangeStartAddress(IPAddress startAddress)
    {
      this._factory = (IConnectionFactory) new ConnectionFactory(startAddress);
    }

    public IVisionSensor Create(IPAddress ipAddress, ushort portNo)
    {
      IConnection connection = this.CreateConnection(ipAddress, portNo, HardwareVersion.First);
      VisionSensor visionSensor = new VisionSensor(this._factory.DataRepository, this._factory.ErrorRepository, this._factory.Command);
      visionSensor.Disposing += new EventHandler(this.SensorDisposing);
      this._dictionary[(IVisionSensor) visionSensor] = connection;
      return (IVisionSensor) visionSensor;
    }

    public IVisionSensorIVHSeries CreateIVHSeries(
      IPAddress ipAddress,
      ushort portNo)
    {
      IConnection connection = this.CreateConnection(ipAddress, portNo, HardwareVersion.Second);
      VisionSensorIVHSeries visionSensorIvhSeries = new VisionSensorIVHSeries(this._factory.DataRepository, this._factory.ErrorRepository, this._factory.Command);
      visionSensorIvhSeries.Disposing += new EventHandler(this.SensorDisposing);
      this._dictionary[(IVisionSensor) visionSensorIvhSeries] = connection;
      return (IVisionSensorIVHSeries) visionSensorIvhSeries;
    }

    private IConnection CreateConnection(
      IPAddress ipAddress,
      ushort portNo,
      HardwareVersion requiredVersion)
    {
      IConnection connection = this._factory.CreateConnection(ipAddress, portNo);
      if (this._dictionary.ContainsValue(connection))
        throw new InvalidOperationException("VisionSensor with designated address is already created.");
      if (!connection.Connect())
        throw new ConnectionLostException("Connection Failed.");
      if (!this.CheckHardwareVersion((byte) requiredVersion))
        throw new ConnectionLostException("Connection Failed.");
      return connection;
    }

    private void SensorDisposing(object sender, EventArgs e)
    {
      IVisionSensor key = (IVisionSensor) sender;
      key.Disposing -= new EventHandler(this.SensorDisposing);
      if (!this._dictionary.ContainsKey(key))
        return;
      this._dictionary[key].Disconnect();
      this._dictionary.Remove(key);
    }

    private bool CheckHardwareVersion(byte requiredVersion)
    {
      return (int) this._factory.Command.ExchangeVersion().HardwareVersion <= (int) requiredVersion;
    }
  }
}
