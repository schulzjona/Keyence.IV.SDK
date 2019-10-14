// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.SensorVersion
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal class SensorVersion : ISensorVersion, ICauseError
  {
    private readonly SettingVersion _settingVersion;

    public unsafe SensorVersion(ReplyForExchangeVersionInfo* reply)
    {
      this.ModelName = StringConverter.StringFromAscii(reply->version.sProof.sCameraSpec.sModelName.acModelName, 16);
      this.CmosSensorType = (CmosType) reply->version.sProof.sCameraSpec.byCmosSensorKind;
      this.FocusDistance = (FocusDistance) reply->version.sProof.sCameraSpec.byFocusDistanceKind;
      this.SensorType = (VisionSensorType) reply->version.sProof.byVisionSensorType;
      this.SerialNo = StringConverter.StringFromAscii(reply->version.sProof.acSerialNo, 32);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.MacAddress = string.Format("{0:X2}-{1:X2}-{2:X2}-{3:X2}-{4:X2}-{5:X2}", (object) reply->version.sProof.sMacAddress.abyOui.FixedElementField, (object) reply->version.sProof.sMacAddress.abyOui[1], (object) reply->version.sProof.sMacAddress.abyOui[2], (object) reply->version.sProof.sMacAddress.abyNicSpecific.FixedElementField, (object) reply->version.sProof.sMacAddress.abyNicSpecific[1], (object) reply->version.sProof.sMacAddress.abyNicSpecific[2]);
      this.AplVersion = StringConverter.StringFromAscii(reply->version.acAplVersion, 8);
      this._settingVersion = new SettingVersion(reply->version.sSettingVersion.wMajorVersion, reply->version.sSettingVersion.wMinorVersion, reply->version.sSettingVersion.wSpecialOrderVersion);
      this.Error = (SensorError) new ConcreteSensorError((ErrI) reply->header.wErrorId);
      this.HardwareVersion = this.SensorType == VisionSensorType.TypeBuiltin ? reply->version.sProof.byHardwareVersion : reply->version.sProof.byAmpHardwareVersion;
    }

    public SensorError Error { private set; get; }

    public string ModelName { private set; get; }

    public string SerialNo { private set; get; }

    public string MacAddress { private set; get; }

    public string AplVersion { private set; get; }

    public CmosType CmosSensorType { private set; get; }

    public VisionSensorType SensorType { private set; get; }

    public FocusDistance FocusDistance { private set; get; }

    public ushort SpecialOrderVersion
    {
      get
      {
        return this._settingVersion.SoVersion;
      }
    }

    public ushort MajorVersion
    {
      get
      {
        return this._settingVersion.MajorVersion;
      }
    }

    public ushort MinorVersion
    {
      get
      {
        return this._settingVersion.MinorVersion;
      }
    }

    public bool AcceptableSettingVersion
    {
      get
      {
        return this._settingVersion.Acceptable;
      }
    }

    public byte HardwareVersion { private set; get; }
  }
}
