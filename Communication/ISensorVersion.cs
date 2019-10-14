// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ISensorVersion
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal interface ISensorVersion : ICauseError
  {
    string ModelName { get; }

    string SerialNo { get; }

    string MacAddress { get; }

    string AplVersion { get; }

    bool AcceptableSettingVersion { get; }

    CmosType CmosSensorType { get; }

    VisionSensorType SensorType { get; }

    FocusDistance FocusDistance { get; }

    ushort SpecialOrderVersion { get; }

    ushort MajorVersion { get; }

    ushort MinorVersion { get; }

    byte HardwareVersion { get; }
  }
}
