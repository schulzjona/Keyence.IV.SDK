// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.StringConverter
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Keyence.IV.Sdk.Communication
{
  internal static class StringConverter
  {
    public static unsafe string StringFromAscii(sbyte* buffer, int length)
    {
      byte[] numArray = new byte[length];
      Marshal.Copy((IntPtr) ((void*) buffer), numArray, 0, length);
      string str = Encoding.ASCII.GetString(numArray);
      int startIndex = str.IndexOf("\0", StringComparison.Ordinal);
      if (startIndex >= 0)
        return str.Remove(startIndex);
      return str;
    }

    public static unsafe string StringFromUnicode(ushort* buffer, int length)
    {
      byte[] numArray = new byte[length * 2];
      Marshal.Copy((IntPtr) ((void*) buffer), numArray, 0, length * 2);
      string str = Encoding.Unicode.GetString(numArray);
      int startIndex = str.IndexOf("\0", StringComparison.Ordinal);
      if (startIndex >= 0)
        return str.Remove(startIndex);
      return str;
    }
  }
}
