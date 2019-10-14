// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.BankSettingCommon
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal struct BankSettingCommon
  {
    public byte byConfiguredBank;
    public byte byTriggerError;
    public BankName sBankName;
    public unsafe fixed byte abyOutPattern[4];
    public byte byFlashAreaSettingEnable;
    public byte byPadding;
    public MasterImage sMasterImage;
    public TriggerSetting sTriggerSetting;
    public PictureSetting sPicture;
    public LightAdjustSetting sLightAdjust;
    public unsafe fixed byte abyEepReserved[50];
  }
}
