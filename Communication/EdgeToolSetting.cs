// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.EdgeToolSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System;

namespace Keyence.IV.Sdk.Communication
{
  internal class EdgeToolSetting : ToolSettingInternalBase
  {
    internal unsafe EdgeToolSetting(BankSettingVsa* pVsaSetting)
      : base(pVsaSetting)
    {
      this.ToolWindow = WindowShapeCreator.Create(&pVsaSetting->sRegisterSetting.sEdgePresence.sTemplateVector);
      this.OkMaxValue = (int) pVsaSetting->sOperationSetting.sEdgePresence.dwHiThreshold;
      this.OkMinValue = (int) pVsaSetting->sOperationSetting.sEdgePresence.dwLowThreshold;
      this.MinValue = 0;
      switch (pVsaSetting->sOperationSetting.sEdgePresence.byMatchPercentLimitSettingType)
      {
        case 0:
          this.MaxValue = 2;
          break;
        case 1:
          this.MaxValue = 5;
          break;
        case 2:
          this.MaxValue = 10;
          break;
        case 3:
          this.MaxValue = 20;
          break;
        case 4:
          this.MaxValue = 50;
          break;
        default:
          throw new ArgumentException();
      }
      if (pVsaSetting->sOperationSetting.sEdgePresence.byEnableHiThreshould == (byte) 0)
        this.OkMaxValue = this.MaxValue;
      this.ToolType = "Edge";
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
