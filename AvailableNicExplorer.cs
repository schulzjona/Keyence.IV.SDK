// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.AvailableNicExplorer
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Keyence.IV.Sdk
{
  public static class AvailableNicExplorer
  {
    public static IList<IPAddress> GetClients()
    {
      List<IPAddress> ipAddressList = new List<IPAddress>();
      foreach (IPAddress address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
      {
        if (Regex.IsMatch(address.ToString(), "^[0-9]+\\.[0-9]+\\.[0-9]+\\.[0-9]+$"))
          ipAddressList.Add(address);
      }
      return (IList<IPAddress>) ipAddressList;
    }
  }
}
