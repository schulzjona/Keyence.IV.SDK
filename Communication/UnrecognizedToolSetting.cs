// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.UnrecognizedToolSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal sealed class UnrecognizedToolSetting : ToolSettingInternalBase
  {
    public unsafe UnrecognizedToolSetting(BankSettingVsa* pVsaSetting)
      : base(pVsaSetting)
    {
      this.ToolType = "Unrecognized";
      this.MaxValue = 0;
      this.MinValue = 0;
      this.OkMaxValue = 0;
      this.OkMinValue = 0;
      this.ToolWindow = (WindowShape) new RectangleWindow((short) 160, (short) 120, (ushort) 100, (ushort) 100, (short) 0);
    }
  }
}
