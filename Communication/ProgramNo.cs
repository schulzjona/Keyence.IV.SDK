// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ProgramNo
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System;

namespace Keyence.IV.Sdk.Communication
{
  internal class ProgramNo : IProgramNo, ICauseError
  {
    internal ProgramNo(int no)
    {
      if (no < 0 || 32 <= no)
        throw new ArgumentOutOfRangeException();
      this.No = no;
    }

    internal unsafe ProgramNo(ReplyForSwitchBank* reply)
    {
      // ISSUE: reference to a compiler-generated field
      this.No = (int) reply->header.uOption0.abyCode.FixedElementField;
      this.Error = (SensorError) new ConcreteSensorError((ErrI) reply->header.wErrorId);
    }

    public int No { get; private set; }

    public SensorError Error { private set; get; }
  }
}
