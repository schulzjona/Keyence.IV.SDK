// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.SetUp
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;

namespace Keyence.IV.Sdk.Common
{
  internal struct SetUp
  {
    public TrapezoidAdjust sTrapezoidAdjust;
    public unsafe fixed byte abyPadding[2];
    public WriteBalance sWhiteBalance;
    public byte byReverse;
    public unsafe fixed byte abyEepReserved[19];
  }
}
