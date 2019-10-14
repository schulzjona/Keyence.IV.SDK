// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.SettingVersion
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

namespace Keyence.IV.Sdk.Communication
{
  internal class SettingVersion
  {
    private readonly ushort _majorVersion;
    private readonly ushort _minorVersion;
    private readonly ushort _soVersion;

    internal SettingVersion(ushort majorVersion, ushort minorVersion, ushort soVersion)
    {
      this._majorVersion = majorVersion;
      this._minorVersion = minorVersion;
      this._soVersion = soVersion;
    }

    public ushort SoVersion
    {
      get
      {
        return this._soVersion;
      }
    }

    public ushort MinorVersion
    {
      get
      {
        return this._minorVersion;
      }
    }

    public ushort MajorVersion
    {
      get
      {
        return this._majorVersion;
      }
    }

    public bool Acceptable
    {
      get
      {
        return true;
      }
    }
  }
}
