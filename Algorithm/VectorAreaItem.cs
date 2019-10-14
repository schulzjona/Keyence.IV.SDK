// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.VectorAreaItem
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Algorithm
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct VectorAreaItem
  {
    [FieldOffset(0)]
    public VectorAreaItemHeader sHeader;
    [FieldOffset(4)]
    public VectorAreaItemRectangle sRectangle;
    [FieldOffset(4)]
    public VectoreAreaItemCircle sCircle;
    [FieldOffset(4)]
    public VectoreAreaItemEllipse sEllipse;
  }
}
