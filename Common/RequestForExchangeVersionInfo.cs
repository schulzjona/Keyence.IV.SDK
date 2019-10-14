// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.RequestForExchangeVersionInfo
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common
{
  internal struct RequestForExchangeVersionInfo
  {
    public CommHeader header;
    public StructSize size;
    public MonitorVersion monitorVersion;

    public unsafe RequestForExchangeVersionInfo(CommHeader header, MonitorVersion monitorVersion)
    {
      *(RequestForExchangeVersionInfo*) ref this = new RequestForExchangeVersionInfo();
      this.header = header;
      this.monitorVersion = monitorVersion;
      this.size.wKind = (ushort) 0;
      this.size.wElementNum = (ushort) 1;
      this.size.lLength = Marshal.SizeOf((object) this.monitorVersion);
    }
  }
}
