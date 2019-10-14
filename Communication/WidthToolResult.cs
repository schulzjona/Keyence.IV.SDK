﻿// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.WidthToolResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;

namespace Keyence.IV.Sdk.Communication
{
  internal class WidthToolResult : PositionAdjustExcludeToolResult
  {
    public unsafe WidthToolResult(SensorResult* result, SensorSetting* setting)
      : base(result)
    {
      this.Scaling = new ToolScalingResult(setting->sEdgeWidth.sScalingSetting.byScalingValid != (byte) 0, (ulong) result->sEdgeWidth.dwMatchPercent, (ulong) result->sEdgeWidth.dwMatchPercent);
      this.Value = this.Scaling.Enabled ? (ushort) 0 : (ushort) result->sEdgeWidth.dwMatchPercent;
    }

    public override sealed ushort Value
    {
      get
      {
        return base.Value;
      }
      protected set
      {
        base.Value = value;
      }
    }

    public override bool IsDrawInSettingPosition(
      PositionAdjustToolSettingBase posSetting,
      PositionAdjustToolResultBase posResult)
    {
      if (posSetting == null || posResult == null)
        return true;
      return !posResult.Ok;
    }
  }
}
