﻿// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.ToolResultBase
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk
{
  public abstract class ToolResultBase
  {
    public abstract bool Ok { get; }

    public abstract ushort Value { get; protected set; }

    public abstract ToolExtendResult Extend { get; protected set; }

    public abstract ToolScalingResult Scaling { get; protected set; }
  }
}