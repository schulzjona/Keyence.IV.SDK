// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.DiameterToolSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal class DiameterToolSetting : ScalingToolSettingBase
  {
    internal unsafe DiameterToolSetting(BankSettingVsa* pVsaSetting)
      : base(pVsaSetting)
    {
      this.ToolWindow = WindowShapeCreator.Create(&pVsaSetting->sRegisterSetting.sDiameter.sValidArea.sTemplateVector);
      this.Initialize(pVsaSetting->sRegisterSetting.sDiameter.sCircleDetecting.sScalingSetting, pVsaSetting->sOperationSetting.sDiameter);
      this.ToolType = "Diameter";
    }
  }
}
