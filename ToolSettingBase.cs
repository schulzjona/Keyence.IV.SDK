// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.ToolSettingBase
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk
{
  public abstract class ToolSettingBase
  {
    public abstract int MaxValue { get; protected set; }

    public abstract int MinValue { get; protected set; }

    public abstract int OkMaxValue { get; protected set; }

    public abstract int OkMinValue { get; protected set; }

    public abstract string ToolName { get; protected set; }

    public abstract WindowShape ToolWindow { get; protected set; }

    public abstract string ToolType { get; protected set; }

    public abstract MultiWindowShape MultiToolWindow { get; protected set; }

    public abstract ToolScalingSetting Scaling { get; protected set; }
  }
}
