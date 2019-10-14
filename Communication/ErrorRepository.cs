// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ErrorRepository
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;
using System.Collections.Generic;

namespace Keyence.IV.Sdk.Communication
{
  internal class ErrorRepository : IErrorRepository
  {
    private SensorErrorCollection _errorCollection = new SensorErrorCollection();
    private bool _eventRise = true;
    private readonly ITcpCommand _command;

    internal ErrorRepository(ITcpCommand command)
    {
      this._command = command;
      command.GetError += new EventHandler<SensorErrorCollection>(this.AddError);
    }

    public bool EnableEvent
    {
      get
      {
        return this._eventRise;
      }
      set
      {
        this._eventRise = value;
      }
    }

    public event ErrorDetectedEventHandler ErrorStatusUpdated = delegate {};

    public IList<SensorError> GetErrors()
    {
      return this._errorCollection.UserNotifyError;
    }

    public bool ClearError(SensorError error)
    {
      if (!error.ProgramaticallyClearable)
        return false;
      if (!this._errorCollection.UserNotifyError.Contains(error))
        return true;
      bool flag = false;
      foreach (SensorError clearError in (IEnumerable<SensorError>) this._command.ClearError(error).ClearedError.UserNotifyError)
      {
        if (this._errorCollection.UserNotifyError.Contains(clearError))
          this._errorCollection.Remove(clearError);
        if (clearError.Equals((object) error))
          flag = true;
      }
      if (flag)
        this.RaiseErrorStatusChangedEvent((object) this, (ErrorDetectedEventArgs) new ConcreteErrorDetectedEventArgs());
      return flag;
    }

    private void RaiseErrorStatusChangedEvent(object sender, ErrorDetectedEventArgs e)
    {
      if (!this.EnableEvent)
        return;
      this.ErrorStatusUpdated(sender, e);
    }

    private void AddError(object sender, SensorErrorCollection e)
    {
      if (e.Equals(this._errorCollection))
        return;
      this._errorCollection.Clear();
      this._errorCollection = e;
      this.RaiseErrorStatusChangedEvent(sender, (ErrorDetectedEventArgs) new ConcreteErrorDetectedEventArgs());
    }
  }
}
