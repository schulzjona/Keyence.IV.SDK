// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.SettingChangeInfo
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct SettingChangeInfo
  {
    [FieldOffset(0)]
    public byte byActiveBankNo;
    [FieldOffset(1)]
    public byte byErrSettingFlg;
    [FieldOffset(2)]
    public unsafe fixed byte abyNotSettingReserved[2];
    [FieldOffset(4)]
    public uint dwActiveSettingChangeCounter;
    [FieldOffset(8)]
    public uint dwAnySettingChangeCounter;

    public unsafe SettingChangeInfo(ReplyForGetSettingChangeInfo reply)
    {
      *(SettingChangeInfo*) ref this = new SettingChangeInfo();
      // ISSUE: reference to a compiler-generated field
      this.byActiveBankNo = reply.header.uOption0.abyCode.FixedElementField;
      this.dwActiveSettingChangeCounter = reply.header.uOption1.dwCode;
      this.dwAnySettingChangeCounter = reply.header.uOption2.dwCode;
    }
  }
}
