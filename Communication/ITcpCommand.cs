// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ITcpCommand
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System;

namespace Keyence.IV.Sdk.Communication
{
  internal interface ITcpCommand
  {
    event EventHandler<SensorErrorCollection> GetError;

    ISensorModeState GetInitialModeState();

    ISensorCurrentSettingInformation GetSettingChangeInfo();

    IClearErrorResult ClearError(SensorError clearError);

    ISensorModeState SetStateTransition(ISensorModeState newState);

    ISensorVersion ExchangeVersion();

    IProgramNo SwitchBank(IProgramNo programNo);

    IManualTriggerResult EnterTrigger();

    ISensorData GetSensorData(bool getAll);

    ISensorSystemSetting GetSystemSetting();

    IProgramList GetBankList();

    IProgramSetting GetBankSetting(IProgramNo programNo);

    IAsyncProcessStartResult StartConfirmBankSetting(
      uint configuredBits,
      bool flashOnly,
      uint unonfiguredBits);

    IProgress QueryConfirmBankSettingStatus();

    IAsyncProcessStartResult StartConfirmSystemSetting();

    IProgress QueryConfirmSystemSettingStatus();

    IProgramNo SetBankSetting(ref BankSettingAll bankSettingAll, IProgramNo programNo);

    IProgramNo DeleteBankSetting(IProgramNo programNo);

    IConfiguredBits GetConfiguredBits();
  }
}
