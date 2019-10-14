// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.SensorSystemSetting
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;

namespace Keyence.IV.Sdk.Communication
{
  internal class SensorSystemSetting : ISensorSystemSetting, ICauseError
  {
    internal SensorSystemSetting(ReplyForGetSystemSetting* reply)
    {
      // ISSUE: unable to decompile the method.
    }

    public bool PasswordEnable { get; private set; }

    public bool ExternalProgramSwitch { get; private set; }

    public string Password { get; private set; }

    public string MachineName { get; private set; }

    public byte UnitType { get; private set; }

    public byte InterferencePreventionDelay { get; private set; }

    public byte[] InterunitLogicOuts { get; private set; }

    public byte[] InterunitLogicIns { get; private set; }

    public SensorError Error { private set; get; }
  }
}
