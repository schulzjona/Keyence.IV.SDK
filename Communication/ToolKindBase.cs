// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ToolKindBase
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;
using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal static class ToolKindBase
  {
    internal static unsafe ToolSettingInternalBase Create(
      BankSettingVsa* pVsaSetting)
    {
      switch (pVsaSetting->sRegisterSetting.bySensorType)
      {
        case 0:
          return (ToolSettingInternalBase) new NoneToolSetting(pVsaSetting);
        case 1:
          return (ToolSettingInternalBase) new PositionAdjustToolSetting(pVsaSetting);
        case 2:
          return (ToolSettingInternalBase) new OutlineToolSetting(pVsaSetting);
        case 3:
          return (ToolSettingInternalBase) new ColorAreaToolSetting(pVsaSetting);
        case 4:
          return (ToolSettingInternalBase) new MonochromeAreaToolSetting(pVsaSetting);
        case 9:
          return (ToolSettingInternalBase) new EdgeToolSetting(pVsaSetting);
        case 10:
          return (ToolSettingInternalBase) new WidthToolSetting(pVsaSetting);
        case 11:
          return (ToolSettingInternalBase) new PitchToolSetting(pVsaSetting);
        case 12:
          return (ToolSettingInternalBase) new DiameterToolSetting(pVsaSetting);
        case 13:
          return (ToolSettingInternalBase) new EdgePixelsToolSetting(pVsaSetting);
        case 14:
          return (ToolSettingInternalBase) new OneAxisAdjustmentToolSetting(pVsaSetting);
        case 15:
          return (ToolSettingInternalBase) new TwoAxisAdjustmentToolSetting(pVsaSetting);
        default:
          return (ToolSettingInternalBase) new UnrecognizedToolSetting(pVsaSetting);
      }
    }

    internal static unsafe ToolResultInternalBase Create(
      SensorResult* pResult,
      SensorSetting* pSetting)
    {
      switch (pResult->bySensorType)
      {
        case 0:
          return (ToolResultInternalBase) new NoneToolResult(pResult);
        case 1:
          return (ToolResultInternalBase) new PositionAdjustToolResult(pResult);
        case 2:
          return (ToolResultInternalBase) new OutlineToolResult(pResult);
        case 3:
          return (ToolResultInternalBase) new ColorAreaToolResult(pResult);
        case 4:
          return (ToolResultInternalBase) new MonochromeAreaToolResult(pResult);
        case 9:
          return (ToolResultInternalBase) new EdgeToolResult(pResult);
        case 10:
          return (ToolResultInternalBase) new WidthToolResult(pResult, pSetting);
        case 11:
          return (ToolResultInternalBase) new PitchToolResult(pResult, pSetting);
        case 12:
          return (ToolResultInternalBase) new DiameterToolResult(pResult, pSetting);
        case 13:
          return (ToolResultInternalBase) new EdgePixelsToolResult(pResult);
        case 14:
          return (ToolResultInternalBase) new OneAxisAdjustmentToolResult(pResult);
        case 15:
          return (ToolResultInternalBase) new TwoAxisAdjustmentToolResult(pResult);
        default:
          return (ToolResultInternalBase) new UnrecognizedToolResult(pResult);
      }
    }
  }
}
