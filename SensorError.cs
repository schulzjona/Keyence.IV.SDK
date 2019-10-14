// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.SensorError
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk
{
  public abstract class SensorError
  {
    public abstract ushort ErrorCode { get; }

    public abstract string Description { get; }

    public abstract bool ProgramaticallyClearable { get; }

    public abstract bool Sustainable { get; }
  }
}
