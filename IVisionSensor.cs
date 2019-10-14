// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.IVisionSensor
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;
using System.Drawing;

namespace Keyence.IV.Sdk
{
  public interface IVisionSensor : IDisposable
  {
    ProgramHeader[] Programs { get; }

    ProgramDescription ActiveProgram { get; }

    SensorError[] Errors { get; }

    bool PasswordRequired { get; }

    bool Unlocked { get; }

    bool ExternalProgramSwitch { get; }

    bool EventEnable { get; set; }

    string ModelName { get; }

    string DeviceName { get; }

    string SensorVersion { get; }

    string SerialNo { get; }

    event ImageAcquiredEventHandler ImageAcquired;

    event ToolResultUpdatedEventHandler ResultUpdated;

    event ErrorDetectedEventHandler ErrorStatusUpdated;

    event ProgramSettingsUpdatedEventHandler ProgramSettingsUpdated;

    event EventHandler Disposing;

    void TickTack();

    bool Unlock(string password);

    void Lock();

    void SwitchProgramTo(ProgramHeader destinationProgram);

    void Trigger();

    void ClearError(SensorError occurredError);

    void DrawWindow(Graphics graphics, Color ok, Color ng, byte toolNo);

    new void Dispose();
  }
}
