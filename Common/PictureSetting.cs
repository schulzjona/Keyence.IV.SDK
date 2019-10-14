// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.PictureSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal struct PictureSetting
  {
    public ushort wBrightness;
    public byte byBrightnessMode;
    public byte byInternalLight;
    public byte byLightingMode;
    public byte byPadding00;
    public ushort wAutoFocusAdjustPosition;
    public byte byDoubleZoom;
    public byte byPadding01;
    public ScreenArea sScreenArea;
    public byte byColorFilterKind;
    public unsafe fixed byte abyEepReserved[17];
  }
}
