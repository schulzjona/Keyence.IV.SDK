// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.CommHeader
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal struct CommHeader
  {
    public ushort wCommHeaderId;
    public byte byCommandKind;
    public byte byRsv;
    public int lBodyLength;
    public Option uOption0;
    public Option uOption1;
    public Option uOption2;
    public Option uOption3;
    public ushort wErrorId;
    public unsafe fixed byte abyRsv[6];
  }
}
