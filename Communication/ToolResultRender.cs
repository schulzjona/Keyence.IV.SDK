// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ToolResultRender
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Algorithm;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Keyence.IV.Sdk.Communication
{
  internal static class ToolResultRender
  {
    private const int COORDINATE_SCALING = 10;
    private const int ANGLE_SCALING = 10;
    private const double DEGREE_TO_RADIAN = 0.0174532925199433;

    internal static void DrawWindow(
      Graphics graphics,
      Color ok,
      Color ng,
      ToolSettingBase positionAdjustSetting,
      ToolSettingBase targetToolSetting,
      ToolResultBase positionAdjustResult,
      ToolResultBase targetToolResult)
    {
      Color color = targetToolResult.Ok ? ok : ng;
      PositionAdjustToolResultBase posResult = positionAdjustResult as PositionAdjustToolResultBase;
      PositionAdjustToolSettingBase posSetting = positionAdjustSetting as PositionAdjustToolSettingBase;
      if (targetToolResult is PositionAdjustIncludeToolResult)
      {
        PositionAdjustIncludeToolResult includeToolResult = targetToolResult as PositionAdjustIncludeToolResult;
        if (includeToolResult.DrawInSettingPosition)
        {
          if (targetToolSetting.MultiToolWindow.Enabled)
            ToolResultRender.DrawVector(graphics, color, targetToolSetting.MultiToolWindow);
          else
            ToolResultRender.DrawVector(graphics, color, targetToolSetting.ToolWindow);
        }
        else if (targetToolSetting.MultiToolWindow.Enabled)
          ToolResultRender.DrawPositionAdjustedVector(graphics, color, targetToolSetting.MultiToolWindow, includeToolResult.Description);
        else
          ToolResultRender.DrawPositionAdjustedVector(graphics, color, targetToolSetting.ToolWindow, includeToolResult.Description);
      }
      else
      {
        PositionAdjustExcludeToolResult excludeToolResult = targetToolResult as PositionAdjustExcludeToolResult;
        if (excludeToolResult != null && (posSetting == null || posResult == null || excludeToolResult.IsDrawInSettingPosition(posSetting, posResult)))
          ToolResultRender.DrawVector(graphics, color, targetToolSetting.ToolWindow);
        else
          ToolResultRender.DrawPositionUnadjustedVector(graphics, color, posSetting, posResult, targetToolSetting.ToolWindow);
      }
    }

    private static void DrawPositionAdjustedVector(
      Graphics graphics,
      Color color,
      MultiWindowShape toolWindows,
      PositionControl description1)
    {
      ToolResultRender.DrawPositionAdjustedVector(graphics, color, toolWindows.ToolWindow1, description1);
      PositionControl description = new PositionControl();
      short num1 = (short) (toolWindows.ToolWindow1.Center.X - (int) description1.sPoint.nX);
      short num2 = (short) (toolWindows.ToolWindow1.Center.Y - (int) description1.sPoint.nY);
      description.sPoint.nX = (short) (toolWindows.ToolWindow2.Center.X + (int) num1);
      description.sPoint.nY = (short) (toolWindows.ToolWindow2.Center.Y + (int) num2);
      description.nAngle = description1.nAngle;
      ToolResultRender.DrawPositionAdjustedVector(graphics, color, toolWindows.ToolWindow2, description);
    }

    private static void DrawPositionAdjustedVector(
      Graphics graphics,
      Color color,
      WindowShape toolWindow,
      PositionControl description)
    {
      WindowShape toolWindow1 = (WindowShape) null;
      RectangleWindow rectangleWindow = toolWindow as RectangleWindow;
      if (rectangleWindow != null)
        toolWindow1 = (WindowShape) new RectangleWindow(description.sPoint.nX, description.sPoint.nY, (ushort) rectangleWindow.Size.Width, (ushort) rectangleWindow.Size.Height, (short) ((int) description.nAngle + toolWindow.Angle));
      CircleWindow circleWindow = toolWindow as CircleWindow;
      if (circleWindow != null)
        toolWindow1 = (WindowShape) new CircleWindow(description.sPoint.nX, description.sPoint.nY, (ushort) circleWindow.Diameter);
      ToolResultRender.DrawVector(graphics, color, toolWindow1);
    }

    private static void DrawPositionUnadjustedVector(
      Graphics graphics,
      Color color,
      PositionAdjustToolSettingBase posSetting,
      PositionAdjustToolResultBase posResult,
      WindowShape toolWindow)
    {
      WindowShape toolWindow1 = (WindowShape) null;
      RectangleWindow rect = toolWindow as RectangleWindow;
      if (rect != null)
        toolWindow1 = (WindowShape) ToolResultRender.PositionAdjustRectangle(posSetting, posResult, rect);
      CircleWindow circle = toolWindow as CircleWindow;
      if (circle != null)
        toolWindow1 = (WindowShape) ToolResultRender.PositionAdjustCircle(posSetting, posResult, circle);
      ToolResultRender.DrawVector(graphics, color, toolWindow1);
    }

    private static RectangleWindow PositionAdjustRectangle(
      PositionAdjustToolSettingBase posSetting,
      PositionAdjustToolResultBase posResult,
      RectangleWindow rect)
    {
      PositionControl positionAdjusted = ToolResultRender.GetPositionAdjusted(posSetting, posResult, (WindowShape) rect);
      return new RectangleWindow(positionAdjusted.sPoint.nX, positionAdjusted.sPoint.nY, (ushort) rect.Size.Width, (ushort) rect.Size.Height, positionAdjusted.nAngle);
    }

    private static CircleWindow PositionAdjustCircle(
      PositionAdjustToolSettingBase posSetting,
      PositionAdjustToolResultBase posResult,
      CircleWindow circle)
    {
      PositionControl positionAdjusted = ToolResultRender.GetPositionAdjusted(posSetting, posResult, (WindowShape) circle);
      return new CircleWindow(positionAdjusted.sPoint.nX, positionAdjusted.sPoint.nY, (ushort) circle.Diameter);
    }

    private static PositionControl GetPositionAdjusted(
      PositionAdjustToolSettingBase posSetting,
      PositionAdjustToolResultBase posResult,
      WindowShape shape)
    {
      PositionControl positionControl = new PositionControl();
      int num1 = shape.Center.X - posSetting.ToolWindow.Center.X;
      int num2 = shape.Center.Y - posSetting.ToolWindow.Center.Y;
      int num3 = (int) posResult.Description.nAngle - posSetting.ToolWindow.Angle;
      double num4 = Math.Cos(Math.PI / 180.0 * (double) num3 / 10.0);
      double num5 = Math.Sin(Math.PI / 180.0 * (double) num3 / 10.0);
      positionControl.sPoint.nX = (short) (num4 * (double) num1 - num5 * (double) num2 + (double) posResult.Description.sPoint.nX);
      positionControl.sPoint.nY = (short) (num5 * (double) num1 + num4 * (double) num2 + (double) posResult.Description.sPoint.nY);
      positionControl.nAngle = (short) (shape.Angle + num3);
      return positionControl;
    }

    private static void DrawVector(Graphics graphics, Color color, MultiWindowShape toolWindows)
    {
      ToolResultRender.DrawVector(graphics, color, toolWindows.ToolWindow1);
      ToolResultRender.DrawVector(graphics, color, toolWindows.ToolWindow2);
    }

    private static void DrawVector(Graphics graphics, Color color, WindowShape toolWindow)
    {
      RectangleWindow rectangleWindow = toolWindow as RectangleWindow;
      using (Pen pen = new Pen(color, 2.5f))
      {
        if (rectangleWindow != null)
          ToolResultRender.DrawRectangle(graphics, pen, rectangleWindow.Center, rectangleWindow.Size, (float) rectangleWindow.Angle);
        CircleWindow circleWindow = toolWindow as CircleWindow;
        if (circleWindow != null)
          ToolResultRender.DrawCircle(graphics, pen, circleWindow.Center, circleWindow.Diameter);
      }
      if (toolWindow == null)
        return;
      ToolResultRender.DrawArrow(graphics, color, toolWindow);
    }

    private static void DrawArrow(Graphics graphics, Color color, WindowShape toolWindow)
    {
      PointF pointF = ToolResultRender.Unscall(toolWindow.Center);
      float angle = ToolResultRender.Unscall((float) toolWindow.Angle);
      using (Pen pen = new Pen(color, 3f))
      {
        pen.EndCap = LineCap.ArrowAnchor;
        graphics.TranslateTransform(pointF.X, pointF.Y);
        graphics.RotateTransform(angle);
        graphics.DrawLine(pen, PointF.Empty, new PointF(15f, 0.0f));
        graphics.DrawLine(pen, PointF.Empty, new PointF(0.0f, -15f));
        graphics.ResetTransform();
      }
    }

    private static void DrawRectangle(
      Graphics graphics,
      Pen pen,
      Point scaledCenter,
      Size scaledSize,
      float scaledAngle)
    {
      PointF pointF = ToolResultRender.Unscall(scaledCenter);
      SizeF sizeF = ToolResultRender.Unscall(scaledSize);
      float angle = ToolResultRender.Unscall(scaledAngle);
      graphics.TranslateTransform(pointF.X, pointF.Y);
      graphics.RotateTransform(angle);
      graphics.DrawRectangle(pen, (float) (-(double) sizeF.Width / 2.0), (float) (-(double) sizeF.Height / 2.0), sizeF.Width, sizeF.Height);
      graphics.ResetTransform();
    }

    private static void DrawCircle(
      Graphics graphics,
      Pen pen,
      Point scaledcenter,
      uint scaledDiameter)
    {
      PointF pointF = ToolResultRender.Unscall(scaledcenter);
      float num = ToolResultRender.Unscall(scaledDiameter);
      graphics.TranslateTransform(pointF.X, pointF.Y);
      graphics.DrawEllipse(pen, (float) (-(double) num / 2.0), (float) (-(double) num / 2.0), num, num);
      graphics.ResetTransform();
    }

    private static PointF Unscall(Point scaledCenter)
    {
      return new PointF((float) scaledCenter.X / 10f, (float) scaledCenter.Y / 10f);
    }

    private static SizeF Unscall(Size scaledSize)
    {
      return new SizeF((float) scaledSize.Width / 10f, (float) scaledSize.Height / 10f);
    }

    private static float Unscall(float scaledAngle)
    {
      return scaledAngle / 10f;
    }

    private static float Unscall(uint scaledDiameter)
    {
      return (float) scaledDiameter / 10f;
    }
  }
}
