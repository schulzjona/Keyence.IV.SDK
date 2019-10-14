// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.WorkSpace
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;

namespace Keyence.IV.Sdk.Communication
{
  internal struct WorkSpace
  {
    public readonly Type ExpectType;
    public readonly IntPtr Address;
    public readonly int Size;

    public WorkSpace(Type type, IntPtr address, int size)
    {
      this.ExpectType = type;
      this.Address = address;
      this.Size = size;
    }
  }
}
