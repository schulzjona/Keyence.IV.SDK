// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.ProgramHeader
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk
{
  public sealed class ProgramHeader
  {
    private readonly bool _externalTrigger;
    private readonly string _programName;
    private readonly int _programNo;
    private readonly ushort _triggerCycleMilliSec;

    internal ProgramHeader(
      string sProgramName,
      int iProgramNo,
      bool bExternalTrigger,
      ushort uTriggerCycleMilliSec)
    {
      this._programName = sProgramName;
      this._programNo = iProgramNo;
      this._externalTrigger = bExternalTrigger;
      this._triggerCycleMilliSec = uTriggerCycleMilliSec;
    }

    public string ProgramName
    {
      get
      {
        return this._programName;
      }
    }

    public int ProgramNo
    {
      get
      {
        return this._programNo;
      }
    }

    public bool ExternalTrigger
    {
      get
      {
        return this._externalTrigger;
      }
    }

    public ushort TriggerCycleMilliSec
    {
      get
      {
        return this._triggerCycleMilliSec;
      }
    }

    public override string ToString()
    {
      return this.ProgramNo.ToString() + ": " + this.ProgramName;
    }
  }
}
