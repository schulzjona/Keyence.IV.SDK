﻿// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.DiameterSensorSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct DiameterSensorSetting
  {
    public DiameterValidArea sValidArea;
    public ScalingSetting sScalingSetting;
    public ScalingDispSetting sScalingDispSetting;
    public unsafe fixed byte byReserved[4];
    public ThresholdWithHiSetting sOperationSetting;
  }
}
