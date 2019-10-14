// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.SensorErrorCollection
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System;
using System.Collections.Generic;

namespace Keyence.IV.Sdk.Communication
{
  internal class SensorErrorCollection : EventArgs
  {
    private readonly List<SensorError> _errors = new List<SensorError>();

    public SensorErrorCollection()
    {
    }

    public SensorErrorCollection(SensorError error)
    {
      this._errors = new List<SensorError>();
      this._errors.Add(error);
    }

    public SensorErrorCollection(uint error1, uint error2, uint error3, uint error4)
    {
      for (int index = 0; index < 32; ++index)
      {
        if (((int) (error1 >> index) & 1) == 1)
          this._errors.Add((SensorError) new ConcreteSensorError((ErrI) (index + 1)));
        if (((int) (error2 >> index) & 1) == 1)
          this._errors.Add((SensorError) new ConcreteSensorError((ErrI) (index + 32 + 1)));
        if (((int) (error3 >> index) & 1) == 1)
          this._errors.Add((SensorError) new ConcreteSensorError((ErrI) (index + 64 + 1)));
        if (((int) (error4 >> index) & 1) == 1)
          this._errors.Add((SensorError) new ConcreteSensorError((ErrI) (index + 96 + 1)));
      }
    }

    public IList<SensorError> UserNotifyError
    {
      get
      {
        return (IList<SensorError>) this._errors;
      }
    }

    public unsafe void WriteVal(uint* perror1, uint* perror2, uint* perror3, uint* perror4)
    {
      *perror1 = 0U;
      *perror2 = 0U;
      *perror3 = 0U;
      *perror4 = 0U;
      foreach (SensorError error in this._errors)
      {
        switch (((int) error.ErrorCode - 1) / 32)
        {
          case 0:
            uint* numPtr1 = perror1;
            int num1 = (int) *numPtr1 | 1 << ((int) error.ErrorCode - 1) % 32;
            *numPtr1 = (uint) num1;
            continue;
          case 1:
            uint* numPtr2 = perror2;
            int num2 = (int) *numPtr2 | 1 << ((int) error.ErrorCode - 1) % 32;
            *numPtr2 = (uint) num2;
            continue;
          case 2:
            uint* numPtr3 = perror3;
            int num3 = (int) *numPtr3 | 1 << ((int) error.ErrorCode - 1) % 32;
            *numPtr3 = (uint) num3;
            continue;
          default:
            uint* numPtr4 = perror4;
            int num4 = (int) *numPtr4 | 1 << ((int) error.ErrorCode - 1) % 32;
            *numPtr4 = (uint) num4;
            continue;
        }
      }
    }

    public void Remove(SensorError clearError)
    {
      if (!this._errors.Contains(clearError))
        return;
      this._errors.Remove(clearError);
    }

    public bool Equals(SensorErrorCollection compareTarget)
    {
      if (compareTarget.UserNotifyError.Count != this.UserNotifyError.Count)
        return false;
      foreach (SensorError sensorError in (IEnumerable<SensorError>) this.UserNotifyError)
      {
        if (!compareTarget.UserNotifyError.Contains(sensorError))
          return false;
      }
      return true;
    }

    public void Clear()
    {
      this.UserNotifyError.Clear();
    }
  }
}
