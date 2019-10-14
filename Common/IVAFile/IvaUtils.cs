// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.IVAFile.IvaUtils
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;
using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common.IVAFile
{
  internal static class IvaUtils
  {
    public static bool BytesToStructure<T>(ref T structure, byte[] bytes) where T : struct
    {
      Type type = typeof (T);
      int num1 = Marshal.SizeOf(type);
      if (num1 > bytes.Length)
        return false;
      IntPtr num2 = Marshal.AllocHGlobal(num1);
      try
      {
        Marshal.Copy(bytes, 0, num2, num1);
        structure = (T) Marshal.PtrToStructure(num2, type);
      }
      finally
      {
        Marshal.FreeHGlobal(num2);
      }
      return true;
    }

    private static byte[] StructureToBytes<T>(ref T structure) where T : struct
    {
      int length = Marshal.SizeOf(typeof (T));
      byte[] destination = new byte[length];
      IntPtr num = Marshal.AllocHGlobal(length);
      try
      {
        Marshal.StructureToPtr((object) structure, num, false);
        Marshal.Copy(num, destination, 0, length);
      }
      finally
      {
        Marshal.FreeHGlobal(num);
      }
      return destination;
    }

    public static bool CopyStructure<T1, T2>(ref T1 src, ref T2 dst)
      where T1 : struct
      where T2 : struct
    {
      int cb = Marshal.SizeOf(typeof (T1));
      Type type = typeof (T2);
      int num1 = Marshal.SizeOf(type);
      if (cb < num1)
        return false;
      IntPtr num2 = Marshal.AllocHGlobal(cb);
      try
      {
        Marshal.StructureToPtr((object) src, num2, false);
        dst = (T2) Marshal.PtrToStructure(num2, type);
      }
      finally
      {
        Marshal.FreeHGlobal(num2);
      }
      return true;
    }

    public static bool IsCompatibleSettingVersion(
      SettingVersion targetVersion,
      SettingVersion requireVersion)
    {
      if (targetVersion.wSpecialOrderVersion != (ushort) 0)
      {
        if (requireVersion.wSpecialOrderVersion != (ushort) 0 && (int) requireVersion.wSpecialOrderVersion != (int) targetVersion.wSpecialOrderVersion)
          return false;
      }
      else if (requireVersion.wSpecialOrderVersion != (ushort) 0)
        return false;
      return (int) targetVersion.wMajorVersion >= (int) requireVersion.wMajorVersion && ((int) targetVersion.wMajorVersion != (int) requireVersion.wMajorVersion || (int) targetVersion.wMinorVersion >= (int) requireVersion.wMinorVersion);
    }

    public static ushort CalcSum<T>(ushort sum, ref T structure) where T : struct
    {
      int size = Marshal.SizeOf(typeof (T));
      return (ushort) IvaUtils.CalcSum32(0U, IvaUtils.StructureToBytes<T>(ref structure), size);
    }

    public static uint CalcSum32(uint sum, byte[] bytes, int size)
    {
      for (int index = 0; index < size; ++index)
        sum += (uint) bytes[index];
      return sum;
    }
  }
}
