// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.SensorModeState
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal class SensorModeState : ISensorModeState, ICauseError
  {
    internal SensorModeState(VisionSensorStateEnum state, VisionSensorMode mode)
    {
      this.VisionSensorStateEnum = state;
      this.VisionSensorMode = mode;
      this.Error = (SensorError) new ConcreteSensorError(ErrI.ErriNone);
    }

    internal unsafe SensorModeState(ReplyForGetInitialModeState* reply)
    {
      // ISSUE: reference to a compiler-generated field
      this.VisionSensorStateEnum = (VisionSensorStateEnum) reply->header.uOption0.abyCode.FixedElementField;
      this.VisionSensorMode = (VisionSensorMode) reply->header.uOption0.abyCode[1];
      this.Error = (SensorError) new ConcreteSensorError((ErrI) reply->header.wErrorId);
    }

    internal unsafe SensorModeState(ReplyForSetStateTransition* reply)
    {
      // ISSUE: reference to a compiler-generated field
      this.VisionSensorStateEnum = (VisionSensorStateEnum) reply->header.uOption0.abyCode.FixedElementField;
      this.VisionSensorMode = (VisionSensorMode) reply->header.uOption0.abyCode[1];
      this.Error = (SensorError) new ConcreteSensorError((ErrI) reply->header.wErrorId);
    }

    public SensorError Error { get; private set; }

    public VisionSensorStateEnum VisionSensorStateEnum { get; private set; }

    public VisionSensorMode VisionSensorMode { get; private set; }
  }
}
