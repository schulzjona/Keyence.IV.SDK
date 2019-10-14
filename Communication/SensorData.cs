// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.SensorData
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System;

namespace Keyence.IV.Sdk.Communication
{
  internal class SensorData : ISensorData, ICauseError
  {
    internal unsafe SensorData(ReplyForGetSensorData reply)
    {
      this.Error = (SensorError) new ConcreteSensorError((ErrI) reply.Pheader->wErrorId);
      if ((IntPtr) reply.PMonoImage != IntPtr.Zero)
        this.LiveImage = (ImageAcquiredEventArgs) new ConcreteImageAcquiredEventArgs(reply.PMonoImage);
      if ((IntPtr) reply.PColorImage != IntPtr.Zero)
        this.LiveImage = (ImageAcquiredEventArgs) new ConcreteImageAcquiredEventArgs(reply.PColorImage);
      if ((IntPtr) reply.PRunninfInfo != IntPtr.Zero)
        this.ToolResult = (ToolResultUpdatedEventArgs) new ConcreteToolResultUpdatedEventArgs(reply.PRunninfInfo);
      if ((IntPtr) reply.PSensorState == IntPtr.Zero)
        return;
      this.SettingCounter = (ISensorCurrentSettingInformation) new SensorCurrentSettingInformation(reply.PSensorState);
      this.SensorErrors = new SensorErrorCollection(reply.PSensorState->sVisionSensorError.dwError1, reply.PSensorState->sVisionSensorError.dwError2, reply.PSensorState->sVisionSensorError.dwError3, reply.PSensorState->sVisionSensorError.dwError4);
    }

    public SensorErrorCollection SensorErrors { get; private set; }

    public ISensorCurrentSettingInformation SettingCounter { get; private set; }

    public ImageAcquiredEventArgs LiveImage { get; private set; }

    public ToolResultUpdatedEventArgs ToolResult { get; private set; }

    public SensorError Error { private set; get; }
  }
}
