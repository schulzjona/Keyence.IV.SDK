// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.ToolScalingResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk
{
  public sealed class ToolScalingResult
  {
    public bool Enabled { get; private set; }

    public ulong Value1 { get; private set; }

    public ulong Value2 { get; private set; }

    internal ToolScalingResult()
    {
      this.Enabled = false;
      this.Value1 = 0UL;
      this.Value2 = 0UL;
    }

    internal ToolScalingResult(bool enabled, ulong value1, ulong value2)
    {
      this.Enabled = enabled;
      this.Value1 = value1;
      this.Value2 = value2;
    }
  }
}
