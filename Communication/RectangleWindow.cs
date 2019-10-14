// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.RectangleWindow
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Drawing;

namespace Keyence.IV.Sdk.Communication
{
  internal class RectangleWindow : WindowShape
  {
    private readonly short _angle;
    private readonly short _centerX;
    private readonly short _centerY;
    private readonly ushort _height;
    private readonly ushort _width;

    public RectangleWindow(
      short centerX,
      short centerY,
      ushort width,
      ushort height,
      short angle)
    {
      this._centerX = centerX;
      this._centerY = centerY;
      this._width = width;
      this._height = height;
      this._angle = angle;
    }

    public Size Size
    {
      get
      {
        return new Size((int) this._width, (int) this._height);
      }
    }

    public override int Angle
    {
      get
      {
        return (int) this._angle;
      }
    }

    public override Point Center
    {
      get
      {
        return new Point((int) this._centerX, (int) this._centerY);
      }
    }
  }
}
