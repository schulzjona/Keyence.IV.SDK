// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.PitchToolResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;

namespace Keyence.IV.Sdk.Communication
{
  internal class PitchToolResult : PositionAdjustExcludeToolResult
  {
    public unsafe PitchToolResult(SensorResult* result, SensorSetting* setting)
      : base(result)
    {
      this.Value = (ushort) 0;
      this.Extend = new ToolExtendResult(true, (ushort) result->sEdgePitch.dwMatchPerMin, (ushort) result->sEdgePitch.dwMatchPerMax);
      this.Scaling = new ToolScalingResult(setting->sEdgePitch.sScalingSetting.byScalingValid != (byte) 0, (ulong) result->sEdgePitch.dwMatchPerMin, (ulong) result->sEdgePitch.dwMatchPerMax);
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
