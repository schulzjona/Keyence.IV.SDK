// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.ToolResultUpdatedEventArgs
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;

namespace Keyence.IV.Sdk
{
  public abstract class ToolResultUpdatedEventArgs : EventArgs, IPossiblyUpdated
  {
    public abstract uint ProcessingTimeMicroSec { get; protected set; }

    public abstract bool TotalStatusResult { get; protected set; }

    public abstract uint TriggerCount { get; protected set; }

    public abstract ToolResultBase PositionAdjust { get; protected set; }

    public abstract ToolResultBase this[byte toolNo] { get; }

    public abstract string[] PropetyList { get; internal set; }
  }
}
