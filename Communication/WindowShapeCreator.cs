// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.WindowShapeCreator
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;
using System;

namespace Keyence.IV.Sdk.Communication
{
  internal static class WindowShapeCreator
  {
    internal static unsafe WindowShape Create(VectorAreaItem* pVector)
    {
      switch (pVector->sHeader.byVectorType)
      {
        case 0:
          return WindowShapeCreator.CreateRectangleWindow(&pVector->sRectangle);
        case 1:
          return WindowShapeCreator.CreateCircleWindow(&pVector->sCircle);
        default:
          throw new ArgumentException();
      }
    }

    private static unsafe WindowShape CreateCircleWindow(
      VectoreAreaItemCircle* vectoreAreaItemCircle)
    {
      return (WindowShape) new CircleWindow(vectoreAreaItemCircle->sCenterPosition.nX, vectoreAreaItemCircle->sCenterPosition.nY, vectoreAreaItemCircle->wDiameter);
    }

    private static unsafe WindowShape CreateRectangleWindow(
      VectorAreaItemRectangle* vectorAreaItemRectangle)
    {
      return (WindowShape) new RectangleWindow(vectorAreaItemRectangle->sCenterPosition.nX, vectorAreaItemRectangle->sCenterPosition.nY, vectorAreaItemRectangle->wWidth, vectorAreaItemRectangle->wHeight, vectorAreaItemRectangle->nRotationAngle);
    }
  }
}
