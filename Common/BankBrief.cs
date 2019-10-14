// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.BankBrief
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal struct BankBrief
  {
    public BankName sBankName;
    public TriggerSetting sTriggerSetting;
    public byte byConfiguredBank;
    public unsafe fixed byte bySenosrType[17];
    public byte byEnable;
    public unsafe fixed byte abyNotSettingReserved[35];
    public ThumbnailImage uThumbnailImage;
    public ScreenArea sScreenArea;
    public unsafe fixed byte abyOutPattern[4];
    public unsafe fixed byte abyPadding[2];
    public uint dwSensorSettingChangeCounter;
  }
}
