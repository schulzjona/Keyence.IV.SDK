// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.OutlineToolResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;

namespace Keyence.IV.Sdk.Communication
{
  internal class OutlineToolResult : PositionAdjustIncludeToolResult
  {
    internal unsafe OutlineToolResult(SensorResult* result)
      : base(result)
    {
      ushort wDetectedCount = result->sShape.wDetectedCount;
      this.Description = result->sShape.sResult.sPositionDescription;
      this.Value = wDetectedCount == (ushort) 1 ? result->sShape.sResult.wScore : (ushort) 0;
      this.DrawInSettingPosition = wDetectedCount == (ushort) 0;
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
  }
}
