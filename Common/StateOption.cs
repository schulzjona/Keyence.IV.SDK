// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.StateOption
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Common
{
  internal enum StateOption
  {
    StateOptionNothing = 0,
    StateOptionTrigNum = 1,
    StateOptionFocusEval = 2,
    StateOptionStats = 4,
    StateOptionHistogram = 8,
    StateOptionDummyBank = 16, // 0x00000010
    StateOptionTrigFree = 32, // 0x00000020
    StateOptionKeepImg = 64, // 0x00000040
  }
}
