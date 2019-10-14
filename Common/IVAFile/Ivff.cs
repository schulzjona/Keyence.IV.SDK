// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.IVAFile.Ivff
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Keyence.IV.Sdk.Common.IVAFile
{
  internal static class Ivff
  {
    private static readonly SettingVersion CURRENT_FILE_VERSION = new SettingVersion()
    {
      wMajorVersion = 1,
      wMinorVersion = 4,
      wSpecialOrderVersion = 0
    };
    private static readonly SettingVersion MINIMUM_FILE_VERSION = new SettingVersion()
    {
      wMajorVersion = 0,
      wMinorVersion = 1,
      wSpecialOrderVersion = 0
    };
    private static readonly Dictionary<BlockOffsetIndex, uint> BLOCK_ID_TABLE = new Dictionary<BlockOffsetIndex, uint>()
    {
      {
        BlockOffsetIndex.VS_SYSTEM_SETTING,
        1397969750U
      },
      {
        BlockOffsetIndex.NETWORK_SETTING,
        1397642070U
      },
      {
        BlockOffsetIndex.BANK_SETTING,
        1396855638U
      },
      {
        BlockOffsetIndex.SUMMARY,
        1498565971U
      },
      {
        BlockOffsetIndex.HISTOGRAM,
        1296520008U
      },
      {
        BlockOffsetIndex.PICTURE_LOG,
        1196379216U
      },
      {
        BlockOffsetIndex.MN_VERSION,
        5656141U
      },
      {
        BlockOffsetIndex.BANK_LIST,
        1280003650U
      },
      {
        BlockOffsetIndex.VS_SYSTEM_LOG,
        1280529238U
      },
      {
        BlockOffsetIndex.COMMUNICATION_LOG,
        1196379203U
      },
      {
        BlockOffsetIndex.SYSTEM_ERROR_LOG,
        1279611725U
      },
      {
        BlockOffsetIndex.SYSTEM_CHANGE_LOG,
        1279480653U
      }
    };
    private const int TEMPORARY_BUFFER_SIZE = 16777216;
    private const uint LIIVFF_MAX_FILE_SIZE = 2147483647;
    private const uint LIIVFF_MAX_BLOCK_SIZE = 2147483647;

    public static IvaFileErrors IvaLoad(Stream stream, out IvaFileHandler ivaHandler)
    {
      Ivff.InitializeIvCommonFilehandler(out ivaHandler);
      if (Ivff.IsResultError(Ivff.LoadIvCommonFilehandler(stream, ref ivaHandler.CommonHandler)))
        return IvaFileErrors.FileErrorsOpen;
      IvffResult result1 = Ivff.CheckFileBlockFirst(stream, ref ivaHandler, BlockOffsetIndex.VS_SYSTEM_SETTING, 0, ref ivaHandler.CameraSystemHeader);
      if (Ivff.IsResultError(result1) || result1 == IvffResult.SIZE_ZERO)
        return IvaFileErrors.FileErrorsIva;
      IvffResult result2 = Ivff.CheckFileBlockFirst(stream, ref ivaHandler, BlockOffsetIndex.NETWORK_SETTING, 0, ref ivaHandler.CameraNetworkHeader);
      return Ivff.IsResultError(result2) || result2 == IvffResult.SIZE_ZERO || (Ivff.IsResultError(Ivff.CheckFileBlockFirst<IvBankSettingBlockHeader>(stream, ref ivaHandler, BlockOffsetIndex.BANK_SETTING, 0, ref ivaHandler.CameraBankHeader, ref ivaHandler.CameraBankHeader.VariableHeader.CommonHeader)) || Ivff.IsResultError(Ivff.CheckFileBlockFirst(stream, ref ivaHandler, BlockOffsetIndex.BANK_LIST, 0, ref ivaHandler.BankListHeader))) ? IvaFileErrors.FileErrorsIva : IvaFileErrors.FileErrorsNone;
    }

    public static IvffResult IvaLoadSystemSetting(
      Stream stream,
      ref IvCommonBlockHeader systemHeader,
      ref VisionSensorSystemSetting systemSetting)
    {
      return Ivff.LoadBlock<VisionSensorSystemSetting>(stream, ref systemSetting, (long) (systemHeader.FilePosition + (int) systemHeader.BlockHeaderSize));
    }

    public static IvffResult IvaLoadBankList(
      Stream stream,
      ref IvaFileHandler ivaHandler,
      ref IvBankList[] bankList)
    {
      return Ivff.LoadBlock<IvBankList>(stream, ref bankList, (long) (ivaHandler.BankListHeader.FilePosition + (int) ivaHandler.BankListHeader.BlockHeaderSize));
    }

    public static IvffResult LoadBankSettingAll(
      Stream stream,
      ref IvBankSettingBlockHeader bankSettingHeader,
      int programNo,
      ref BankSettingAll bankSettingAll)
    {
      if (bankSettingHeader.Elements[programNo].Size != 0)
        return Ivff.LoadBlock<BankSettingAll>(stream, ref bankSettingAll, (long) (bankSettingHeader.VariableHeader.CommonHeader.FilePosition + bankSettingHeader.Elements[programNo].Offset));
      return IvffResult.SIZE_ZERO;
    }

    private static void InitializeIvCommonFilehandler(out IvaFileHandler ivaHandler)
    {
      ivaHandler = new IvaFileHandler();
      ivaHandler.CommonHandler.BlockOffsetTable = new uint[12];
      ivaHandler.CommonHandler.VersionInfoID = 4281929U;
      ivaHandler.CommonHandler.VersionInfo.FileVersion = Ivff.CURRENT_FILE_VERSION;
      ivaHandler.CommonHandler.VersionInfo.MinFileVersion = Ivff.MINIMUM_FILE_VERSION;
    }

    private static IvffResult LoadIvCommonFilehandler(
      Stream stream,
      ref IvCommonFileHandler commonHandler)
    {
      IvffResult result = IvffResult.OK;
      int num = 0;
      bool flag = true;
      IvCommonBlockHeader workHeader = new IvCommonBlockHeader();
      while (flag)
      {
        result = Ivff.CheckBlockFirst(stream, ref commonHandler.CheckerWork, 0, ref workHeader, 0U);
        if (!Ivff.IsResultError(result))
        {
          switch (workHeader.BlockID)
          {
            case 4281929:
              if (num != 0)
                return IvffResult.INVALID;
              commonHandler.VersionInfofHeader = workHeader;
              result = Ivff.LoadBlock<IvVersionInfoData>(stream, ref commonHandler.VersionInfo, (long) (commonHandler.VersionInfofHeader.FilePosition + (int) commonHandler.VersionInfofHeader.BlockHeaderSize));
              if (!Ivff.IsResultError(result))
              {
                if (!IvaUtils.IsCompatibleSettingVersion(Ivff.CURRENT_FILE_VERSION, commonHandler.VersionInfo.MinFileVersion))
                {
                  result = IvffResult.UNCOMPATIBLE;
                  break;
                }
                if (commonHandler.VersionInfo.FileSize < 0U || commonHandler.VersionInfo.FileSize > (uint) int.MaxValue)
                {
                  result = IvffResult.INVALID;
                  break;
                }
                if ((long) commonHandler.VersionInfo.FileSize != stream.Length)
                {
                  result = IvffResult.INVALID;
                  break;
                }
                break;
              }
              break;
            case 5264969:
            case 5527113:
              return IvffResult.INVALID;
            case 5656141:
            case 1196379203:
            case 1196379216:
            case 1230195795:
            case 1279480653:
            case 1279611725:
            case 1280003650:
            case 1280529238:
            case 1296520008:
            case 1314144592:
            case 1347699024:
            case 1396855638:
            case 1397642070:
            case 1397969750:
            case 1414547283:
            case 1414550593:
            case 1498565971:
              result = IvffResult.INVALID;
              break;
            case 5657430:
              if (num == 0)
                return IvffResult.INVALID;
              commonHandler.CameraInfofHeader = workHeader;
              result = Ivff.LoadBlock<VisionSensorVersion>(stream, ref commonHandler.CameraVersion, (long) (commonHandler.CameraInfofHeader.FilePosition + (int) commonHandler.CameraInfofHeader.BlockHeaderSize));
              break;
            case 1397116738:
              if (num == 0)
                return IvffResult.INVALID;
              commonHandler.BlockOffsetHeader = workHeader;
              result = Ivff.LoadBlock<uint>(stream, ref commonHandler.BlockOffsetTable, (long) (commonHandler.BlockOffsetHeader.FilePosition + (int) commonHandler.BlockOffsetHeader.BlockHeaderSize));
              flag = false;
              break;
            default:
              result = IvffResult.OK;
              break;
          }
          if (!Ivff.IsResultError(result))
          {
            try
            {
              stream.Seek((long) (workHeader.FilePosition + workHeader.BlockSize), SeekOrigin.Begin);
            }
            catch (Exception ex)
            {
              break;
            }
            ++num;
          }
          else
            break;
        }
        else
          break;
      }
      if (Ivff.IsResultError(result))
        return IvffResult.FATAL_ERROR;
      return result;
    }

    private static bool IsResultError(IvffResult result)
    {
      return result < IvffResult.OK;
    }

    private static IvffResult CheckFileBlockFirst(
      Stream stream,
      ref IvaFileHandler ivaHandler,
      BlockOffsetIndex index,
      int divideSize,
      ref IvCommonBlockHeader blockHeader)
    {
      uint blockID = Ivff.BLOCK_ID_TABLE[index];
      uint num = ivaHandler.CommonHandler.BlockOffsetTable[(int) index];
      stream.Seek((long) num, SeekOrigin.Begin);
      return Ivff.CheckBlockFirst<IvCommonBlockHeader>(stream, out ivaHandler.CommonHandler.CheckerWork, divideSize, ref blockHeader, ref blockHeader, blockID);
    }

    private static IvffResult CheckFileBlockFirst<T>(
      Stream stream,
      ref IvaFileHandler ivaHandler,
      BlockOffsetIndex index,
      int divideSize,
      ref T header,
      ref IvCommonBlockHeader commonHeader)
      where T : struct
    {
      uint blockID = Ivff.BLOCK_ID_TABLE[index];
      uint num = ivaHandler.CommonHandler.BlockOffsetTable[(int) index];
      stream.Seek((long) num, SeekOrigin.Begin);
      return Ivff.CheckBlockFirst<T>(stream, out ivaHandler.CommonHandler.CheckerWork, divideSize, ref header, ref commonHeader, blockID);
    }

    private static IvffResult CheckBlockFirst(
      Stream stream,
      ref IvCommonCheckWork checkWork,
      int divideSize,
      ref IvCommonBlockHeader workHeader,
      uint blockID)
    {
      return Ivff.CheckBlockFirst<IvCommonBlockHeader>(stream, out checkWork, divideSize, ref workHeader, ref workHeader, blockID);
    }

    private static IvffResult CheckBlockFirst<T>(
      Stream stream,
      out IvCommonCheckWork checkWork,
      int divideSize,
      ref T header,
      ref IvCommonBlockHeader workHeader,
      uint blockID)
      where T : struct
    {
      checkWork = new IvCommonCheckWork();
      IvffResult result1 = Ivff.LoadBlockHeader<T>(stream, ref header);
      if (Ivff.IsResultError(result1))
        return result1;
      if ((int) workHeader.BlockHeaderSize != Marshal.SizeOf(typeof (IvCommonBlockHeader)))
      {
        IvffResult result2 = Ivff.SeekCommonBlockDataTop(stream, ref workHeader);
        if (Ivff.IsResultError(result2))
          return result2;
      }
      if (blockID != 0U && (int) workHeader.BlockID != (int) blockID)
        return IvffResult.UNMACH_BLOCK;
      checkWork.RemainSize = checkWork.TotalSize = workHeader.BlockSize - Marshal.SizeOf(typeof (IvCommonBlockHeader));
      if (divideSize == 0)
      {
        checkWork.DivideSize = checkWork.TotalSize;
        checkWork.DivideCount = 1U;
        IvffResult ivffResult = Ivff.CheckBlockNext(stream, ref checkWork, ref workHeader);
        while (ivffResult == IvffResult.CONTINUE)
          ivffResult = Ivff.CheckBlockNext(stream, ref checkWork, ref workHeader);
        return ivffResult;
      }
      checkWork.DivideSize = divideSize;
      checkWork.DivideCount = (uint) ((workHeader.BlockSize - Marshal.SizeOf(typeof (IvCommonBlockHeader))) / checkWork.DivideSize);
      return IvffResult.CONTINUE;
    }

    private static IvffResult CheckBlockNext(
      Stream stream,
      ref IvCommonCheckWork checkWork,
      ref IvCommonBlockHeader common)
    {
      int val2 = Math.Min(checkWork.DivideSize, checkWork.RemainSize);
      checkWork.RemainSize -= val2;
      ++checkWork.NowCount;
      int size;
      for (; 0 < val2; val2 -= size)
      {
        size = Math.Min(16777216, val2);
        byte[] bytes = new byte[size];
        int readSize;
        if (Ivff.IsResultError(Ivff.ReadNext(stream, bytes, size, out readSize)) || size != readSize)
          return IvffResult.READ_ERROR;
        checkWork.CurSum = IvaUtils.CalcSum32(checkWork.CurSum, bytes, size);
      }
      if (0 < checkWork.RemainSize)
        return IvffResult.CONTINUE;
      return (int) common.BlockDataSum == (int) checkWork.CurSum ? IvffResult.OK : IvffResult.INVALID;
    }

    private static IvffResult SeekCommonBlockDataTop(
      Stream stream,
      ref IvCommonBlockHeader workHeader)
    {
      try
      {
        stream.Seek((long) (workHeader.FilePosition + Marshal.SizeOf(typeof (IvCommonBlockHeader))), SeekOrigin.Begin);
      }
      catch (Exception ex)
      {
        return IvffResult.ACCESS_ERROR;
      }
      return IvffResult.OK;
    }

    private static IvffResult LoadBlockHeader<T>(Stream stream, ref T structure) where T : struct
    {
      int length = Marshal.SizeOf(typeof (T));
      int num1 = Marshal.SizeOf(typeof (IvCommonBlockHeader));
      byte[] bytes1 = new byte[length];
      int readSize;
      if (Ivff.IsResultError(Ivff.ReadNext(stream, bytes1, num1, out readSize)) || num1 != readSize)
        return IvffResult.READ_ERROR;
      IvCommonBlockHeader commonBlockHeader = new IvCommonBlockHeader();
      IvaUtils.BytesToStructure<IvCommonBlockHeader>(ref commonBlockHeader, bytes1);
      IvffResult result = Ivff.CheckIvCommonBlockHeader(ref commonBlockHeader);
      if (Ivff.IsResultError(result))
        return result;
      if ((int) commonBlockHeader.BlockHeaderSize > num1)
      {
        ushort num2 = Math.Min((ushort) ((uint) commonBlockHeader.BlockHeaderSize - (uint) num1), (ushort) (length - num1));
        if ((ushort) 0 < num2)
        {
          byte[] bytes2 = new byte[(int) num2];
          if (Ivff.IsResultError(Ivff.ReadNext(stream, bytes2, (int) num2, out readSize)) || (int) num2 != readSize)
            return IvffResult.READ_ERROR;
          bytes2.CopyTo((Array) bytes1, num1);
        }
      }
      IvaUtils.BytesToStructure<T>(ref structure, bytes1);
      return IvffResult.OK;
    }

    private static IvffResult CheckIvCommonBlockHeader(ref IvCommonBlockHeader common)
    {
      if (Ivff.IsResultError(Ivff.CheckIvBlockId(common.BlockID)) || (int) common.BlockHeaderSize < Marshal.SizeOf(typeof (IvCommonBlockHeader)) || (common.BlockSize < (int) common.BlockHeaderSize || common.BlockSize > int.MaxValue))
        return IvffResult.INVALID;
      ushort commonHeaderSum = common.CommonHeaderSum;
      common.CommonHeaderSum = (ushort) 0;
      ushort num = IvaUtils.CalcSum<IvCommonBlockHeader>((ushort) 0, ref common);
      common.CommonHeaderSum = commonHeaderSum;
      return (int) commonHeaderSum != (int) num ? IvffResult.INVALID : IvffResult.OK;
    }

    private static IvffResult CheckIvBlockId(uint blockId)
    {
      return blockId == 0U ? IvffResult.INVALID : IvffResult.OK;
    }

    private static IvffResult ReadNext(
      Stream stream,
      byte[] bytes,
      int size,
      out int readSize)
    {
      readSize = 0;
      try
      {
        readSize = stream.Read(bytes, 0, size);
      }
      catch (Exception ex)
      {
        return IvffResult.READ_ERROR;
      }
      return IvffResult.OK;
    }

    private static IvffResult LoadBlock<T>(Stream stream, ref T structure, long position) where T : struct
    {
      int count = Marshal.SizeOf(typeof (T));
      byte[] numArray = new byte[count];
      try
      {
        stream.Seek(position, SeekOrigin.Begin);
        stream.Read(numArray, 0, count);
        IvaUtils.BytesToStructure<T>(ref structure, numArray);
      }
      catch (Exception ex)
      {
        return IvffResult.ACCESS_ERROR;
      }
      return IvffResult.OK;
    }

    private static IvffResult LoadBlock<T>(Stream stream, ref T[] array, long position) where T : struct
    {
      Type type = typeof (T);
      int length = Marshal.SizeOf(type);
      try
      {
        stream.Seek(position, SeekOrigin.Begin);
        for (int index = 0; index < array.Length; ++index)
        {
          byte[] numArray = new byte[length];
          stream.Read(numArray, 0, length);
          IntPtr num = Marshal.AllocHGlobal(length);
          try
          {
            Marshal.Copy(numArray, 0, num, length);
            array.SetValue((object) (T) Marshal.PtrToStructure(num, type), index);
          }
          finally
          {
            Marshal.FreeHGlobal(num);
          }
        }
      }
      catch (Exception ex)
      {
        return IvffResult.ACCESS_ERROR;
      }
      return IvffResult.OK;
    }
  }
}
