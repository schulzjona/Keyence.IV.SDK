// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ColorAreaToolSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System;

namespace Keyence.IV.Sdk.Communication
{
  internal class ColorAreaToolSetting : ToolSettingInternalBase
  {
    internal unsafe ColorAreaToolSetting(BankSettingVsa* pVsaSetting)
      : base(pVsaSetting)
    {
      this.ToolWindow = WindowShapeCreator.Create(&pVsaSetting->sRegisterSetting.sAreaColor.sTemplateVector);
      this.OkMaxValue = (int) pVsaSetting->sOperationSetting.sAreaColor.dwHiThreshold;
      this.OkMinValue = (int) pVsaSetting->sOperationSetting.sAreaColor.dwLowThreshold;
      this.MinValue = 0;
      switch (pVsaSetting->sOperationSetting.sAreaColor.byHiThresholdSettingType)
      {
        case 0:
          this.MaxValue = 100;
          this.OkMaxValue = this.MaxValue;
          break;
        case 1:
          this.MaxValue = 200;
          break;
        case 2:
          this.MaxValue = 999;
          break;
        default:
          throw new ArgumentException();
      }
      this.ToolType = "ColorArea";
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
