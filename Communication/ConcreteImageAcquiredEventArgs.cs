// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ConcreteImageAcquiredEventArgs
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System.Drawing;

namespace Keyence.IV.Sdk.Communication
{
  internal class ConcreteImageAcquiredEventArgs : ImageAcquiredEventArgs
  {
    internal unsafe ConcreteImageAcquiredEventArgs(ImageSetMono* monoImage)
    {
      Size size = new Size((int) monoImage->sArea.wWidth / 10, (int) monoImage->sArea.wHeight / 10);
      Point imageLeftTop = ConcreteImageAcquiredEventArgs.GetImageLeftTop(monoImage->sArea);
      Color[] imageData = new Color[size.Width * size.Height];
      for (int index = 0; index < imageData.Length; ++index)
      {
        byte num = monoImage->uMono.abyImageBuffer[index];
        imageData[index] = Color.FromArgb((int) num, (int) num, (int) num);
      }
      this.LiveImage = (Keyence.IV.Sdk.Image) new ConcreteImage(size, imageLeftTop, imageData);
    }

    internal unsafe ConcreteImageAcquiredEventArgs(ImageSetColor* colorImage)
    {
      Size size = new Size((int) colorImage->sArea.wWidth / 10, (int) colorImage->sArea.wHeight / 10);
      Point imageLeftTop = ConcreteImageAcquiredEventArgs.GetImageLeftTop(colorImage->sArea);
      Color[] imageData = new Color[size.Width * size.Height];
      for (int index = 0; index < imageData.Length; ++index)
      {
        ushort num = colorImage->uColor.awImageBuffer[index];
        imageData[index] = Color.FromArgb(((int) num & 63488) >> 8, ((int) num & 2000) >> 3, ((int) num & 31) << 3);
      }
      this.LiveImage = (Keyence.IV.Sdk.Image) new ConcreteImage(size, imageLeftTop, imageData);
    }

    public override sealed Keyence.IV.Sdk.Image LiveImage { get; protected set; }

    public override sealed string[] PropetyList { get; internal set; }

    private static Point GetImageLeftTop(RectArea rectArea)
    {
      return new Point(((int) rectArea.wCx - (int) rectArea.wWidth / 2) / 10, ((int) rectArea.wCy - (int) rectArea.wHeight / 2) / 10);
    }
  }
}
