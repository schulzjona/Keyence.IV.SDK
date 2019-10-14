// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ToolSettingInternalBase
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal abstract class ToolSettingInternalBase : ToolSettingBase
  {
    internal unsafe ToolSettingInternalBase(BankSettingVsa* pVsaSetting)
    {
      this.ToolName = StringConverter.StringFromAscii(pVsaSetting->acSensorName, 8);
      this.ToolType = string.Empty;
      this.MultiToolWindow = new MultiWindowShape();
      this.Scaling = new ToolScalingSetting();
    }

    public override int MaxValue { get; protected set; }

    public override int MinValue { get; protected set; }

    public override int OkMaxValue { get; protected set; }

    public override int OkMinValue { get; protected set; }

    public override sealed string ToolName { get; protected set; }

    public override WindowShape ToolWindow { get; protected set; }

    public override sealed string ToolType { get; protected set; }

    public override sealed MultiWindowShape MultiToolWindow { get; protected set; }

    public override sealed ToolScalingSetting Scaling { get; protected set; }
  }
}
