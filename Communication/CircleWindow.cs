// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.CircleWindow
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Drawing;

namespace Keyence.IV.Sdk.Communication
{
  internal class CircleWindow : WindowShape
  {
    private readonly short _centerX;
    private readonly short _centerY;
    private readonly ushort _diameter;

    public CircleWindow(short centerX, short centerY, ushort diameter)
    {
      this._centerX = centerX;
      this._centerY = centerY;
      this._diameter = diameter;
    }

    public uint Diameter
    {
      get
      {
        return (uint) this._diameter;
      }
    }

    public override Point Center
    {
      get
      {
        return new Point((int) this._centerX, (int) this._centerY);
      }
    }

    public override int Angle
    {
      get
      {
        return 0;
      }
    }
  }
}
