// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.VisionSensor
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Keyence.IV.Sdk.Communication
{
  internal class VisionSensor : IVisionSensor, IDisposable
  {
    protected readonly AutoCommunicator AutoCommunicator;
    protected readonly ITcpCommand Command;
    protected readonly IDataRepository DataRepository;
    protected readonly IErrorRepository ErrorRepository;
    protected readonly CommandSequencer Sequencer;

    internal VisionSensor(
      IDataRepository dataRepository,
      IErrorRepository errorRepository,
      ITcpCommand command)
    {
      this.Command = command;
      this.DataRepository = dataRepository;
      this.ErrorRepository = errorRepository;
      try
      {
        this.Sequencer = new CommandSequencer(dataRepository, command);
        this.AutoCommunicator = new AutoCommunicator(dataRepository, command);
        this.Sequencer.VerifyTargetJustAfterConnectionConfirmed();
      }
      catch (ConnectionLostException ex)
      {
        this.Dispose();
        throw;
      }
      this.AutoCommunicator.ImageAcquired += new ImageAcquiredEventHandler(this.MediateImageAcquiredEvent);
      this.AutoCommunicator.ResultUpdated += new ToolResultUpdatedEventHandler(this.MediateToolResultUpdatedEvent);
      errorRepository.ErrorStatusUpdated += new ErrorDetectedEventHandler(this.MediateErrorDetectedEvent);
      this.Sequencer.ProgramSettingsUpdated += new ProgramSettingsUpdatedEventHandler(this.MediateProgramSettingsUpdatedEvent);
      this.AutoCommunicator.ProgramSettingsUpdated += new ProgramSettingsUpdatedEventHandler(this.MediateProgramSettingsUpdatedEvent);
    }

    public ProgramHeader[] Programs
    {
      get
      {
        IList<ProgramHeader> programs = this.DataRepository.GetPrograms();
        ProgramHeader[] array = new ProgramHeader[programs.Count];
        programs.CopyTo(array, 0);
        return array;
      }
    }

    public ProgramDescription ActiveProgram
    {
      get
      {
        return this.DataRepository.GetActiveProgram();
      }
    }

    public SensorError[] Errors
    {
      get
      {
        IList<SensorError> errors = this.ErrorRepository.GetErrors();
        SensorError[] array = new SensorError[errors.Count];
        errors.CopyTo(array, 0);
        return array;
      }
    }

    public bool PasswordRequired
    {
      get
      {
        return this.DataRepository.LoginRequired;
      }
    }

    public bool Unlocked
    {
      get
      {
        return this.DataRepository.LoggedIn;
      }
    }

    public bool ExternalProgramSwitch
    {
      get
      {
        return this.DataRepository.ExternalProgramSwitch;
      }
    }

    public bool EventEnable
    {
      get
      {
        if (this.AutoCommunicator.EnableEvent && this.ErrorRepository.EnableEvent)
          return this.Sequencer.EnableEvent;
        return false;
      }
      set
      {
        this.AutoCommunicator.EnableEvent = value;
        this.ErrorRepository.EnableEvent = value;
        this.Sequencer.EnableEvent = value;
      }
    }

    public string ModelName
    {
      get
      {
        return this.DataRepository.ModelName;
      }
    }

    public string DeviceName
    {
      get
      {
        return this.DataRepository.MachineName;
      }
    }

    public string SensorVersion
    {
      get
      {
        return this.DataRepository.SensorVersion;
      }
    }

    public string SerialNo
    {
      get
      {
        return this.DataRepository.SerialNo;
      }
    }

    public event EventHandler Disposing = delegate {};

    public void TickTack()
    {
      try
      {
        this.AutoCommunicator.DoWork(false);
      }
      catch (ConnectionLostException ex)
      {
        this.Dispose();
        throw;
      }
    }

    public bool Unlock(string password)
    {
      return this.DataRepository.Login(password);
    }

    public void Lock()
    {
      this.DataRepository.Logout();
    }

    public void SwitchProgramTo(ProgramHeader destinationProgram)
    {
      try
      {
        this.Sequencer.SwitchProgram(destinationProgram.ProgramNo);
        this.AutoCommunicator.DoWork(true);
      }
      catch (SettingChangeException ex)
      {
        this.Dispose();
        throw new ConnectionLostException(ex.Message, (Exception) ex);
      }
      catch (ConnectionLostException ex)
      {
        this.Dispose();
        throw;
      }
    }

    public void Trigger()
    {
      try
      {
        if (!this.DataRepository.ManualTriggerAcceptable)
          throw new InvalidOperationException("Manual Trigger is Invalid.");
        if (this.DataRepository.LoginRequired && !this.DataRepository.LoggedIn)
          throw new InvalidOperationException("Unlock is needed.");
        this.Command.EnterTrigger();
      }
      catch (ConnectionLostException ex)
      {
        this.Dispose();
        throw;
      }
    }

    public void ClearError(SensorError occurredError)
    {
      this.ErrorRepository.ClearError(occurredError);
    }

    public void DrawWindow(Graphics graphics, Color ok, Color ng, byte toolNo)
    {
      ProgramDescription activeProgram = this.DataRepository.GetActiveProgram();
      ToolResultRender.DrawWindow(graphics, ok, ng, activeProgram.PositionAdjustSetting, activeProgram[toolNo], this.DataRepository.PositionAdjustResult, this.DataRepository[toolNo]);
    }

    public event ProgramSettingsUpdatedEventHandler ProgramSettingsUpdated = delegate {};

    public event ImageAcquiredEventHandler ImageAcquired = delegate {};

    public event ToolResultUpdatedEventHandler ResultUpdated = delegate {};

    public event ErrorDetectedEventHandler ErrorStatusUpdated = delegate {};

    public void Dispose()
    {
      this.Disposing((object) this, EventArgs.Empty);
    }

    private void MediateProgramSettingsUpdatedEvent(
      object sender,
      ProgramSettingsUpdatedEventArgs e)
    {
      e.PropetyList = new string[2]
      {
        "ActiveProgram",
        "Programs"
      };
      this.ProgramSettingsUpdated(sender, e);
    }

    private void MediateImageAcquiredEvent(object sender, ImageAcquiredEventArgs e)
    {
      this.ImageAcquired(sender, e);
    }

    private void MediateToolResultUpdatedEvent(object sender, ToolResultUpdatedEventArgs e)
    {
      this.ResultUpdated(sender, e);
    }

    private void MediateErrorDetectedEvent(object sender, ErrorDetectedEventArgs e)
    {
      e.PropetyList = new string[1]{ "Errors" };
      this.ErrorStatusUpdated(sender, e);
    }
  }
}
