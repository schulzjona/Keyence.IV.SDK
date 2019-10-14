// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.ThumbnailImage
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;
using System.Drawing;

namespace Keyence.IV.Sdk
{
  public sealed class ThumbnailImage
  {
    private readonly byte[] _byteData;

    public byte[] ByteData
    {
      get
      {
        return this._byteData;
      }
    }

    internal ThumbnailImage(Color[] imageData)
    {
      if (imageData.Length != 4800)
        throw new ArgumentException();
      this._byteData = new byte[imageData.Length * 3];
      for (int index = 0; index < imageData.Length; ++index)
      {
        this._byteData[3 * index] = imageData[index].B;
        this._byteData[3 * index + 1] = imageData[index].G;
        this._byteData[3 * index + 2] = imageData[index].R;
      }
    }
  }
}
