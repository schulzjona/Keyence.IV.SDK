// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.ToolScalingSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk
{
  public sealed class ToolScalingSetting
  {
    public bool Enabled { get; private set; }

    public ulong MaxValue { get; private set; }

    public ulong MinValue { get; private set; }

    public ulong OkMaxValue { get; private set; }

    public ulong OkMinValue { get; private set; }

    internal ToolScalingSetting()
    {
      this.Enabled = false;
      this.MaxValue = 0UL;
      this.MinValue = 0UL;
      this.OkMaxValue = 0UL;
      this.OkMinValue = 0UL;
    }

    internal ToolScalingSetting(
      bool enabled,
      ulong maxValue,
      ulong minValue,
      ulong okMaxValue,
      ulong okMinValue)
    {
      this.Enabled = enabled;
      this.MaxValue = maxValue;
      this.MinValue = minValue;
      this.OkMaxValue = okMaxValue;
      this.OkMinValue = okMinValue;
    }
  }
}
