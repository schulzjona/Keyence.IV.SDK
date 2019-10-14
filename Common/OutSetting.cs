// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.OutSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal struct OutSetting
  {
    public byte byOutType;
    public byte byPadding;
    public ushort wOneShotTime;
    public ushort wDelayTime;
    public ushort wExtLightTime;
    public unsafe fixed byte abyNC[8];
    public unsafe fixed byte abyInterunitLogicOut[8];
    public unsafe fixed byte abyEepReserved[4];
  }
}
