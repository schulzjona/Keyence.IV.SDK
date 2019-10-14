// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.MultiWindowShape
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Communication;

namespace Keyence.IV.Sdk
{
  public sealed class MultiWindowShape
  {
    public bool Enabled { get; private set; }

    public WindowShape ToolWindow1 { get; private set; }

    public WindowShape ToolWindow2 { get; private set; }

    internal MultiWindowShape()
    {
      this.Enabled = false;
      this.ToolWindow1 = (WindowShape) new EmptyWindow();
      this.ToolWindow2 = (WindowShape) new EmptyWindow();
    }

    internal MultiWindowShape(WindowShape toolWindow1, WindowShape toolWindow2)
    {
      this.Enabled = true;
      this.ToolWindow1 = toolWindow1;
      this.ToolWindow2 = toolWindow2;
    }
  }
}
