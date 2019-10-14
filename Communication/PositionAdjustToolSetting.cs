// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.PositionAdjustToolSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal class PositionAdjustToolSetting : PositionAdjustToolSettingBase
  {
    internal unsafe PositionAdjustToolSetting(BankSettingVsa* pVsaSetting)
      : base(pVsaSetting)
    {
      this.ToolWindow = WindowShapeCreator.Create(&pVsaSetting->sRegisterSetting.sPositionAdjust.sTemplateVector);
      this.OkMaxValue = 100;
      this.OkMinValue = (int) pVsaSetting->sOperationSetting.sPositionAdjust.wScore;
      this.MaxValue = 100;
      this.MinValue = 0;
      this.ToolType = "PositionAdjust";
    }

    public override sealed int MinValue
    {
      get
      {
        return base.MinValue;
      }
      protected set
      {
        base.MinValue = value;
      }
    }

    public override sealed int MaxValue
    {
      get
      {
        return base.MaxValue;
      }
      protected set
      {
        base.MaxValue = value;
      }
    }

    public override sealed int OkMinValue
    {
      get
      {
        return base.OkMinValue;
      }
      protected set
      {
        base.OkMinValue = value;
      }
    }

    public override sealed int OkMaxValue
    {
      get
      {
        return base.OkMaxValue;
      }
      protected set
      {
        base.OkMaxValue = value;
      }
    }

    public override sealed WindowShape ToolWindow
    {
      get
      {
        return base.ToolWindow;
      }
      protected set
      {
        base.ToolWindow = value;
      }
    }
  }
}
