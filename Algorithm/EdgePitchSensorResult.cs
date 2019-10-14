// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Algorithm.EdgePitchSensorResult
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Algorithm
{
  internal struct EdgePitchSensorResult
  {
    public uint dwMatchPercent;
    public uint dwMatchPerMin;
    public uint dwMatchPerMax;
    public unsafe fixed ushort awDispPosition[64];
    public uint dwPitchResult;
    public ScalingSetting sScalingSetting;
    public byte byPitchCount;
    public byte byActiveEdgeCount;
    public byte byMasterPitchCount;
    public byte byMasterActiveEdgeCount;
    public ushort wMasterPitchAve;
    public byte byMasterMaxEdgeStrength;
    public byte byPitchMaxMinReslut;
    public byte byDetectMode;
    public byte byReserved;
    public unsafe fixed ushort awPitchWidth[2];
    public unsafe fixed byte abyReserved[2];
  }
}
