// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.EmptyWindow
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System.Drawing;

namespace Keyence.IV.Sdk.Communication
{
  internal class EmptyWindow : WindowShape
  {
    public override int Angle
    {
      get
      {
        return 0;
      }
    }

    public override Point Center
    {
      get
      {
        return Point.Empty;
      }
    }
  }
}
