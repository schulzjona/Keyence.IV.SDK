// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ConcreteImage
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;
using System.Drawing;

namespace Keyence.IV.Sdk.Communication
{
  internal class ConcreteImage : Keyence.IV.Sdk.Image
  {
    internal ConcreteImage(Color[] masterImageData)
    {
      if (masterImageData.Length != 76800)
        throw new ArgumentException();
      this.ByteData = ConcreteImage.ConvertToByteDataFrom(masterImageData);
      this.Region = new Rectangle(Point.Empty, new Size(320, 240));
    }

    internal ConcreteImage(Size size, Point leftTop, Color[] imageData)
    {
      if (size.Width * size.Height != imageData.Length)
        throw new ArgumentException();
      Color[] color = new Color[76800];
      for (int index1 = 0; index1 < size.Height; ++index1)
      {
        for (int index2 = 0; index2 < size.Width; ++index2)
          color[(index1 + leftTop.Y) * 320 + (index2 + leftTop.X)] = imageData[index1 * size.Width + index2];
      }
      this.ByteData = ConcreteImage.ConvertToByteDataFrom(color);
      this.Region = new Rectangle(leftTop, size);
    }

    public override sealed Rectangle Region { get; protected set; }

    public override sealed byte[] ByteData { get; protected set; }

    private static byte[] ConvertToByteDataFrom(Color[] color)
    {
      byte[] numArray = new byte[color.Length * 3];
      for (int index = 0; index < color.Length; ++index)
      {
        numArray[3 * index] = color[index].B;
        numArray[3 * index + 1] = color[index].G;
        numArray[3 * index + 2] = color[index].R;
      }
      return numArray;
    }
  }
}
