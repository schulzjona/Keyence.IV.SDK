// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.ToolExtendResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk
{
  public sealed class ToolExtendResult
  {
    public bool Enabled { get; private set; }

    public ushort Value1 { get; private set; }

    public ushort Value2 { get; private set; }

    internal ToolExtendResult()
    {
      this.Enabled = false;
      this.Value1 = (ushort) 0;
      this.Value2 = (ushort) 0;
    }

    internal ToolExtendResult(bool enabled, ushort value1, ushort value2)
    {
      this.Enabled = enabled;
      this.Value1 = value1;
      this.Value2 = value2;
    }
  }
}
