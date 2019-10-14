// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.TcpCommand
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using Keyence.IV.Sdk.Common.IVAFile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Communication
{
  internal class TcpCommand : ITcpCommand
  {
    private const ushort COMM_HEADER_ID = 4427;
    private const int TIMEOUT_MSEC = 45000;
    private readonly IConnection _connection;

    internal TcpCommand(IConnection connection)
    {
      this._connection = connection;
    }

    public event EventHandler<SensorErrorCollection> GetError;

    public unsafe ISensorModeState GetInitialModeState()
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForGetInitialModeState));
      RequestForGetInitialModeState* address = (RequestForGetInitialModeState*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 4;
      address->header.lBodyLength = 0;
      address->header.uOption0.dwCode = 0U;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForGetInitialModeState));
      SensorModeState sensorModeState = new SensorModeState((ReplyForGetInitialModeState*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (ISensorModeState) sensorModeState;
    }

    public unsafe ISensorCurrentSettingInformation GetSettingChangeInfo()
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForGetSettingChangeInfo));
      RequestForGetSettingChangeInfo* address = (RequestForGetSettingChangeInfo*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 8;
      address->header.lBodyLength = 0;
      address->header.uOption0.dwCode = 0U;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForGetSettingChangeInfo));
      SensorCurrentSettingInformation settingInformation = new SensorCurrentSettingInformation((ReplyForGetSettingChangeInfo*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (ISensorCurrentSettingInformation) settingInformation;
    }

    public unsafe IClearErrorResult ClearError(SensorError clearTargetError)
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForClearError));
      RequestForClearError* address = (RequestForClearError*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 12;
      if (!clearTargetError.ProgramaticallyClearable)
        throw new ArgumentException("This Error can't clear programatically.");
      new SensorErrorCollection(clearTargetError).WriteVal(&address->header.uOption0.dwCode, &address->header.uOption1.dwCode, &address->header.uOption2.dwCode, &address->header.uOption3.dwCode);
      address->header.lBodyLength = 0;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForClearError));
      ClearErrorResult clearErrorResult = new ClearErrorResult((ReplyForClearError*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (IClearErrorResult) clearErrorResult;
    }

    public unsafe ISensorModeState SetStateTransition(ISensorModeState newState)
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForSetStateTransition));
      RequestForSetStateTransition* address = (RequestForSetStateTransition*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 6;
      address->header.lBodyLength = 0;
      address->header.uOption0.abyCode[0] = (byte) newState.VisionSensorStateEnum;
      address->header.uOption0.abyCode[1] = (byte) newState.VisionSensorMode;
      address->header.uOption0.awCode[1] = (ushort) 0;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForSetStateTransition));
      SensorModeState sensorModeState = new SensorModeState((ReplyForSetStateTransition*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (ISensorModeState) sensorModeState;
    }

    public unsafe ISensorVersion ExchangeVersion()
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForExchangeVersionInfo));
      RequestForExchangeVersionInfo* address = (RequestForExchangeVersionInfo*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 5;
      address->header.lBodyLength = Marshal.SizeOf((object) address->size) + Marshal.SizeOf((object) address->monitorVersion);
      address->size.wKind = (ushort) 0;
      address->size.wElementNum = (ushort) 1;
      address->size.lLength = Marshal.SizeOf((object) address->monitorVersion);
      address->monitorVersion.sSettingVersion.wMajorVersion = (ushort) 1;
      address->monitorVersion.sSettingVersion.wMinorVersion = (ushort) 1;
      address->monitorVersion.sSettingVersion.wSpecialOrderVersion = (ushort) 0;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForExchangeVersionInfo));
      SensorVersion sensorVersion = new SensorVersion((ReplyForExchangeVersionInfo*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (ISensorVersion) sensorVersion;
    }

    public unsafe IProgramNo SwitchBank(IProgramNo programNo)
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForSwitchBank));
      RequestForSwitchBank* address = (RequestForSwitchBank*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 57;
      address->header.lBodyLength = 0;
      address->header.uOption0.abyCode[0] = (byte) programNo.No;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForSwitchBank));
      ProgramNo programNo1 = new ProgramNo((ReplyForSwitchBank*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (IProgramNo) programNo1;
    }

    public unsafe IManualTriggerResult EnterTrigger()
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForManualTrigger));
      RequestForManualTrigger* address = (RequestForManualTrigger*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 1;
      address->header.lBodyLength = 0;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForManualTrigger));
      ManualTriggerResult manualTriggerResult = new ManualTriggerResult((ReplyForManualTrigger*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (IManualTriggerResult) manualTriggerResult;
    }

    public unsafe ISensorData GetSensorData(bool getAll)
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForGetSensorData));
      RequestForGetSensorData* address = (RequestForGetSensorData*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 7;
      address->header.lBodyLength = 0;
      address->header.uOption0.abyCode[0] = getAll ? (byte) 1 : (byte) 0;
      address->header.uOption0.abyCode[1] = (byte) 0;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace variableLengthReply = this.ReceiveVariableLengthReply(typeof (ReplyForGetSensorData));
      SensorData sensorData = new SensorData(new ReplyForGetSensorData(variableLengthReply));
      TcpCommand.ReleaseReceiveBuffer(variableLengthReply);
      return (ISensorData) sensorData;
    }

    public unsafe ISensorSystemSetting GetSystemSetting()
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForGetSystemSetting));
      RequestForGetSystemSetting* address = (RequestForGetSystemSetting*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 10;
      address->header.lBodyLength = 0;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForGetSystemSetting));
      SensorSystemSetting sensorSystemSetting = new SensorSystemSetting((ReplyForGetSystemSetting*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (ISensorSystemSetting) sensorSystemSetting;
    }

    public unsafe IProgramList GetBankList()
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForGetBankList));
      RequestForGetBankList* address = (RequestForGetBankList*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 56;
      address->header.lBodyLength = 0;
      address->header.uOption0.abyCode[0] = (byte) 1;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForGetBankList));
      ProgramList programList = new ProgramList((ReplyForGetBankList*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (IProgramList) programList;
    }

    public unsafe IConfiguredBits GetConfiguredBits()
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForGetBankList));
      RequestForGetBankList* address = (RequestForGetBankList*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 56;
      address->header.lBodyLength = 0;
      address->header.uOption0.abyCode[0] = (byte) 1;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForGetBankList));
      ConfiguredBits configuredBits = new ConfiguredBits((ReplyForGetBankList*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (IConfiguredBits) configuredBits;
    }

    public unsafe IProgramSetting GetBankSetting(IProgramNo programNo)
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForGetBankSetting));
      RequestForGetBankSetting* address = (RequestForGetBankSetting*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 11;
      address->header.lBodyLength = 0;
      address->header.uOption0.abyCode[0] = (byte) programNo.No;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForGetBankSetting));
      ProgramSetting programSetting = new ProgramSetting(programNo, (ReplyForGetBankSetting*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (IProgramSetting) programSetting;
    }

    public unsafe IAsyncProcessStartResult StartConfirmBankSetting(
      uint configuredBits,
      bool flashOnly,
      uint unonfiguredBits)
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForStartConfirmBankSetting));
      RequestForStartConfirmBankSetting* address = (RequestForStartConfirmBankSetting*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 17;
      address->header.lBodyLength = 0;
      address->header.uOption0.dwCode = configuredBits;
      address->header.uOption1.abyCode[0] = (byte) 1;
      address->header.uOption1.abyCode[1] = flashOnly ? (byte) 1 : (byte) 0;
      address->header.uOption2.dwCode = unonfiguredBits;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForStartConfirmBankSetting));
      StartConfirmBankSettingResult bankSettingResult = new StartConfirmBankSettingResult((ReplyForStartConfirmBankSetting*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (IAsyncProcessStartResult) bankSettingResult;
    }

    public unsafe IProgress QueryConfirmBankSettingStatus()
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForQueryConfirmBankSettingStatus));
      RequestForQueryConfirmBankSettingStatus* address = (RequestForQueryConfirmBankSettingStatus*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 18;
      address->header.lBodyLength = 0;
      address->header.uOption0.abyCode[0] = (byte) 1;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForQueryConfirmBankSettingStatus));
      Progress progress = new Progress((ReplyForQueryConfirmBankSettingStatus*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (IProgress) progress;
    }

    public unsafe IAsyncProcessStartResult StartConfirmSystemSetting()
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForStartConfirmSystemSetting));
      RequestForStartConfirmSystemSetting* address = (RequestForStartConfirmSystemSetting*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 15;
      address->header.lBodyLength = 0;
      address->header.uOption0.abyCode[0] = (byte) 1;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForStartConfirmSystemSetting));
      StartConfirmSystemSettingResult systemSettingResult = new StartConfirmSystemSettingResult((ReplyForStartConfirmSystemSetting*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (IAsyncProcessStartResult) systemSettingResult;
    }

    public unsafe IProgress QueryConfirmSystemSettingStatus()
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForQueryConfirmSystemSettingStatus));
      RequestForQueryConfirmSystemSettingStatus* address = (RequestForQueryConfirmSystemSettingStatus*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 16;
      address->header.lBodyLength = 0;
      address->header.uOption0.abyCode[0] = (byte) 1;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForQueryConfirmSystemSettingStatus));
      Progress progress = new Progress((ReplyForQueryConfirmSystemSettingStatus*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (IProgress) progress;
    }

    public unsafe IProgramNo SetBankSetting(
      ref BankSettingAll bankSettingAll,
      IProgramNo programNo)
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForSetBankSetting));
      RequestForSetBankSetting* address = (RequestForSetBankSetting*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 20;
      address->header.lBodyLength = Marshal.SizeOf(typeof (BankSettingAll)) + Marshal.SizeOf(typeof (StructSize));
      address->header.uOption0.abyCode[0] = (byte) programNo.No;
      address->size.wKind = (ushort) 10;
      address->size.wElementNum = (ushort) 1;
      address->size.lLength = Marshal.SizeOf(typeof (BankSettingAll));
      address->body = bankSettingAll;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForSetBankSetting));
      ProgramNo programNo1 = new ProgramNo((ReplyForSwitchBank*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (IProgramNo) programNo1;
    }

    public unsafe IProgramNo DeleteBankSetting(IProgramNo programNo)
    {
      WorkSpace workSpace = TcpCommand.GetWorkSpace(typeof (RequestForGetBankSetting));
      RequestForGetBankSetting* address = (RequestForGetBankSetting*) (void*) workSpace.Address;
      address->header.wCommHeaderId = (ushort) 4427;
      address->header.byCommandKind = (byte) 59;
      address->header.lBodyLength = 0;
      address->header.uOption0.abyCode[0] = (byte) programNo.No;
      this.SendRequest(workSpace);
      TcpCommand.ReleaseWorkSpace(workSpace);
      WorkSpace fixedLengthReply = this.ReceiveFixedLengthReply(typeof (ReplyForSwitchBank));
      ProgramNo programNo1 = new ProgramNo((ReplyForSwitchBank*) (void*) fixedLengthReply.Address);
      TcpCommand.ReleaseReceiveBuffer(fixedLengthReply);
      return (IProgramNo) programNo1;
    }

    private static unsafe WorkSpace GetWorkSpace(Type type)
    {
      int num = Marshal.SizeOf(type);
      IntPtr address = Marshal.AllocHGlobal(num);
      byte* numPtr = (byte*) (void*) address;
      for (int index = 0; index < num; ++index)
        numPtr[index] = (byte) 0;
      return new WorkSpace(type, address, num);
    }

    private void SendRequest(WorkSpace sendBuffer)
    {
      byte[] numArray = new byte[sendBuffer.Size];
      Marshal.Copy(sendBuffer.Address, numArray, 0, sendBuffer.Size);
      this._connection.Send(numArray, sendBuffer.Size);
    }

    private static void ReleaseWorkSpace(WorkSpace buffer)
    {
      Marshal.FreeHGlobal(buffer.Address);
    }

    private WorkSpace ReceiveVariableLengthReply(Type expectedType)
    {
      List<byte> byteList = new List<byte>();
      int count = Marshal.SizeOf(typeof (CommHeader));
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      while (byteList.Count < count && stopwatch.ElapsedMilliseconds < 45000L)
        byteList.AddRange((IEnumerable<byte>) this._connection.Receive());
      if (byteList.Count < count)
        throw new ConnectionLostException(string.Format("Type: {0} size is incorrect. Received size is {1}, but expected size is {2}.", (object) expectedType, (object) byteList.Count, (object) count));
      byte[] numArray = new byte[count];
      byteList.CopyTo(0, numArray, 0, count);
      CommHeader structure = new CommHeader();
      IvaUtils.BytesToStructure<CommHeader>(ref structure, numArray);
      int num1 = structure.lBodyLength + count;
      while (byteList.Count < num1 && stopwatch.ElapsedMilliseconds < 45000L)
        byteList.AddRange((IEnumerable<byte>) this._connection.Receive());
      if (byteList.Count != num1)
        throw new ConnectionLostException(string.Format("Type: {0} size is incorrect. Received size is {1}, but expected size is {2}.", (object) expectedType, (object) byteList.Count, (object) num1));
      byte[] array = byteList.ToArray();
      IntPtr num2 = Marshal.AllocHGlobal(array.Length);
      Marshal.Copy(array, 0, num2, array.Length);
      return new WorkSpace(expectedType, num2, array.Length);
    }

    private WorkSpace ReceiveFixedLengthReply(Type expectedType)
    {
      int num1 = Marshal.SizeOf(expectedType);
      List<byte> byteList = new List<byte>();
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      while (byteList.Count < num1 && stopwatch.ElapsedMilliseconds < 45000L)
        byteList.AddRange((IEnumerable<byte>) this._connection.Receive());
      if (byteList.Count != num1)
        throw new ConnectionLostException(string.Format("Type: {0} size is incorrect. Received size is {1}, but expected size is {2}.", (object) expectedType, (object) byteList.Count, (object) num1));
      byte[] array = byteList.ToArray();
      IntPtr num2 = Marshal.AllocHGlobal(array.Length);
      Marshal.Copy(array, 0, num2, array.Length);
      return new WorkSpace(expectedType, num2, array.Length);
    }

    private static void ReleaseReceiveBuffer(WorkSpace buffer)
    {
      Marshal.FreeHGlobal(buffer.Address);
    }
  }
}
