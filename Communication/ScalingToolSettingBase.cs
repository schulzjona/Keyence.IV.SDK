// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ScalingToolSettingBase
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;
using Keyence.IV.Sdk.Common;
using System;

namespace Keyence.IV.Sdk.Communication
{
  internal abstract class ScalingToolSettingBase : ToolSettingInternalBase
  {
    private static readonly uint[,] SC_ADW_SCALING_DISP_TABLE = new uint[6, 4]
    {
      {
        1000U,
        9999000U,
        1000U,
        0U
      },
      {
        100U,
        999900U,
        1000U,
        1U
      },
      {
        10U,
        99990U,
        1000U,
        2U
      },
      {
        1U,
        9999U,
        1000U,
        3U
      },
      {
        1U,
        999U,
        100U,
        3U
      },
      {
        1U,
        0U,
        100U,
        3U
      }
    };
    private static readonly uint[] SC_ADW_SCALING_RATIO = new uint[3]
    {
      1U,
      2U,
      10U
    };
    private const int SCALING_MAX_0_DOT_BASE = 1000;
    private const int SCALING_MAX_1_DOT_BASE = 100;
    private const int SCALING_MAX_2_DOT_BASE = 10;
    private const int SCALING_MAX_3_DOT_BASE = 1;
    private const uint SCALING_MAX_DISP = 9999000;
    private const uint SCALING_MAX_0_DOT_DISP = 9999000;
    private const uint SCALING_MAX_1_DOT_DISP = 999900;
    private const uint SCALING_MAX_2_DOT_DISP = 99990;
    private const uint SCALING_MAX_3_DOT_DISP = 9999;
    private const uint SCALING_MAX_4_DOT_DISP = 999;
    private const uint SCALING_MAX_5_DOT_DISP = 0;
    private const uint SCALING_MIN_DISP_MAX_MM = 1000;
    private const uint SCALING_MAX_3_DOT_DISP_MM = 10000;
    private const int SCALING_0_DOT = 0;
    private const int SCALING_1_DOT = 1;
    private const int SCALING_2_DOT = 2;
    private const int SCALING_3_DOT = 3;
    private const int SCALING_ALLIGN_4_DIGIT = 1000;
    private const int SCALING_ALLIGN_3_DIGIT = 100;
    private const int SCALING_DOT_DISP_TYPE_MAX = 6;
    private const int SCALING_MAX_DOT_POSITION_INCH = 3;
    private const int SCALING_MAX_DOT_POSITION_MM = 2;
    private const int SCALING_DISP_MIN = 100;

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

    protected unsafe ScalingToolSettingBase(BankSettingVsa* pVsaSetting)
      : base(pVsaSetting)
    {
    }

    protected void Initialize(
      ScalingSetting scalingSetting,
      ThresholdWithHiSetting thresholdSetting)
    {
      this.Scaling = ScalingToolSettingBase.GetScaling(scalingSetting, thresholdSetting);
      if (!this.Scaling.Enabled)
      {
        this.OkMaxValue = (int) thresholdSetting.dwHiThreshold;
        this.OkMinValue = (int) thresholdSetting.dwLowThreshold;
      }
      this.MinValue = 0;
      this.MaxValue = ScalingToolSettingBase.GetMaxValue(thresholdSetting);
      if (thresholdSetting.byHiThresholdSettingType != (byte) 0)
        return;
      this.OkMaxValue = this.MaxValue;
    }

    private static ToolScalingSetting GetScaling(
      ScalingSetting scalingSetting,
      ThresholdWithHiSetting thresholdSetting)
    {
      if (scalingSetting.byScalingValid == (byte) 0)
        return new ToolScalingSetting();
      uint pdwEdgeThresholdMax;
      byte pbyDotPosition;
      ScalingToolSettingBase.GetScalingThresholdRange(scalingSetting, thresholdSetting, out pdwEdgeThresholdMax, out pbyDotPosition);
      uint num = thresholdSetting.byHiThresholdSettingType == (byte) 0 ? pdwEdgeThresholdMax : thresholdSetting.dwHiThreshold;
      return new ToolScalingSetting(true, (ulong) pdwEdgeThresholdMax, 0UL, (ulong) num, (ulong) thresholdSetting.dwLowThreshold);
    }

    private static int GetMaxValue(ThresholdWithHiSetting thresholdSetting)
    {
      switch (thresholdSetting.byHiThresholdSettingType)
      {
        case 0:
          return 100;
        case 1:
          return 200;
        case 2:
          return 999;
        default:
          throw new ArgumentException();
      }
    }

    private static void GetScalingThresholdRange(
      ScalingSetting scalingSetting,
      ThresholdWithHiSetting thresholdSetting,
      out uint pdwEdgeThresholdMax,
      out byte pbyDotPosition)
    {
      uint num1 = scalingSetting.dwDispValue * ScalingToolSettingBase.SC_ADW_SCALING_RATIO[(int) thresholdSetting.byHiThresholdSettingType];
      if (num1 > 9999000U)
      {
        uint num2 = 9999000;
        byte num3 = 0;
        pdwEdgeThresholdMax = num2;
        pbyDotPosition = num3;
      }
      else
      {
        byte num2;
        for (num2 = (byte) 0; num2 < (byte) 5; ++num2)
        {
          if (num1 > ScalingToolSettingBase.SC_ADW_SCALING_DISP_TABLE[(int) num2 + 1, 1])
          {
            uint num3 = ScalingToolSettingBase.SC_ADW_SCALING_DISP_TABLE[(int) num2, 0] * ScalingToolSettingBase.SC_ADW_SCALING_DISP_TABLE[(int) num2, 2];
            if (num1 % num3 != 0U)
              num1 = (num1 + num3) / num3 * num3;
            if (num1 > ScalingToolSettingBase.SC_ADW_SCALING_DISP_TABLE[(int) num2, 1])
              num1 = ScalingToolSettingBase.SC_ADW_SCALING_DISP_TABLE[(int) num2, 1];
            else if ((int) num1 == (int) ScalingToolSettingBase.SC_ADW_SCALING_DISP_TABLE[(int) num2 + 1, 0] + (int) ScalingToolSettingBase.SC_ADW_SCALING_DISP_TABLE[(int) num2 + 1, 1])
            {
              num1 = ScalingToolSettingBase.SC_ADW_SCALING_DISP_TABLE[(int) num2 + 1, 1];
              num2 = (byte) ScalingToolSettingBase.SC_ADW_SCALING_DISP_TABLE[(int) num2 + 1, 3];
              break;
            }
            num2 = (byte) ScalingToolSettingBase.SC_ADW_SCALING_DISP_TABLE[(int) num2, 3];
            break;
          }
        }
        if (num1 < 100U)
          num1 = 100U;
        if ((byte) 1 == scalingSetting.byUnitType)
        {
          if (num2 > (byte) 3)
            num2 = (byte) 3;
        }
        else if (scalingSetting.byUnitType == (byte) 0)
        {
          if (num2 > (byte) 2)
            num2 = (byte) 2;
          if (num1 < 1000U)
            num1 = 1000U;
          if (num1 == 9999U)
            num1 = 10000U;
        }
        pdwEdgeThresholdMax = num1;
        pbyDotPosition = num2;
      }
    }

    private enum UnitType
    {
      Mm,
      Inch,
    }

    private enum ScaleDispTable
    {
      DotBase,
      DotDispMax,
      AllignDigit,
      DotNum,
    }
  }
}
