// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.VisionSensorState
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal struct VisionSensorState
  {
    public byte byVisionSensorState;
    public byte byWaitForTrigger;
    public unsafe fixed byte abyNotSettingReserved[10];
    public VisionSensorError sVisionSensorError;
    public InOut sInOut;
    public SettingChangeInfo sSettingChangeInfo;
  }
}
