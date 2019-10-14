// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.UnrecognizedToolResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;

namespace Keyence.IV.Sdk.Communication
{
  internal sealed class UnrecognizedToolResult : PositionAdjustExcludeToolResult
  {
    public unsafe UnrecognizedToolResult(SensorResult* result)
      : base(result)
    {
      this.Value = (ushort) 0;
    }

    public override bool Ok
    {
      get
      {
        return false;
      }
    }

    public override bool IsDrawInSettingPosition(
      PositionAdjustToolSettingBase posSetting,
      PositionAdjustToolResultBase posResult)
    {
      return true;
    }
  }
}
