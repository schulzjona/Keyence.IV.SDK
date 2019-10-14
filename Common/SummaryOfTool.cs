// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.SummaryOfTool
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal struct SummaryOfTool
  {
    public byte byValid;
    public unsafe fixed byte abyNotSettingReserved[7];
    public uint dwDetectValueMax;
    public uint dwDetectValueMin;
    public uint dwDetectValueAve;
    public uint dwOkCounter;
    public uint dwNgCounter;
  }
}
