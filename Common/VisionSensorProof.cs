// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.VisionSensorProof
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;

namespace Keyence.IV.Sdk.Common
{
  internal struct VisionSensorProof
  {
    public CameraSpec sCameraSpec;
    public unsafe fixed sbyte acSerialNo[32];
    public MacAddress sMacAddress;
    public byte byAmpHardwareVersion;
    public byte byVisionSensorType;
    public uint dwCipSerialNo;
    public byte byClockAvailable;
    public unsafe fixed sbyte acProofreadDate[10];
    public byte byPadding01;
    public BrightnessTable sBrightnessTablePulse;
    public BrightnessTable sBrightnessTableDC;
    public unsafe fixed sbyte acGearModuleSerialNo[32];
    public TrapezoidProof sTrapezoidProof;
    public BrightnessModeThre sBrightnessModeThre;
    public MacAddress sAmpSwitchMacAddress;
    public unsafe fixed sbyte acAmpProofreadDate[10];
    public LightPwmCorrection sLightPwmCorrection;
    public byte byHardwareVersion;
    public unsafe fixed byte abyNotSettingReserved[21];
  }
}
