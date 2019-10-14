// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.VisionSensorStore
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Communication;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Keyence.IV.Sdk
{
  public sealed class VisionSensorStore : IDisposable
  {
    private static VisionSensorRepository _repository;
    private static IPAddress _startPoint;
    private readonly VisionSensorRepository _repositoryRef;

    static VisionSensorStore()
    {
      IList<IPAddress> clients;
      try
      {
        clients = AvailableNicExplorer.GetClients();
      }
      catch (SocketException ex)
      {
        throw new PlatformNotSupportedException("Couldn't find available NIC.");
      }
      if (clients.Count < 1)
        throw new PlatformNotSupportedException("Couldn't find available NIC.");
      VisionSensorStore.StartPoint = clients[0];
    }

    public VisionSensorStore()
    {
      VisionSensorStore._repository = VisionSensorRepository.GetInstance();
      VisionSensorStore._repository.ChangeStartAddress(VisionSensorStore.StartPoint);
      this._repositoryRef = VisionSensorStore._repository;
    }

    public static IPAddress StartPoint
    {
      get
      {
        return VisionSensorStore._startPoint;
      }
      set
      {
        if (!AvailableNicExplorer.GetClients().Contains(value))
          throw new ArgumentException("Designated Nic couldn't be found.");
        VisionSensorStore._startPoint = value;
        if (VisionSensorStore._repository == null)
          return;
        VisionSensorStore._repository.ChangeStartAddress(VisionSensorStore._startPoint);
      }
    }

    public void Dispose()
    {
      if (this._repositoryRef == null)
        return;
      VisionSensorRepository.ReleaseInstance();
      VisionSensorStore._repository = (VisionSensorRepository) null;
    }

    public IVisionSensor Create(IPAddress ipAddress, ushort portNo)
    {
      return this._repositoryRef.Create(ipAddress, portNo);
    }

    public IVisionSensorIVHSeries CreateIVHSeries(
      IPAddress ipAddress,
      ushort portNo)
    {
      return this._repositoryRef.CreateIVHSeries(ipAddress, portNo);
    }
  }
}
