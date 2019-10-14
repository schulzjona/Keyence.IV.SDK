// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.IvaFileException
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;

namespace Keyence.IV.Sdk
{
  public sealed class IvaFileException : Exception
  {
    public IvaFileErrors ErrorCode { get; private set; }

    internal IvaFileException(IvaFileErrors error)
      : this(error, IvaFileException.GetMessage(error))
    {
    }

    internal IvaFileException(IvaFileErrors error, string message)
      : base(message)
    {
      this.ErrorCode = error;
    }

    internal IvaFileException(IvaFileErrors error, string message, Exception innerException)
      : base(message, innerException)
    {
      this.ErrorCode = error;
    }

    private static string GetMessage(IvaFileErrors error)
    {
      switch (error)
      {
        case IvaFileErrors.FileErrorsOpen:
          return "File Open Error.";
        case IvaFileErrors.FileErrorsRead:
          return "File Read Error.";
        case IvaFileErrors.FileErrorsIva:
          return "Invalid File Error.";
        case IvaFileErrors.FileErrorsVersion:
          return "File Version Error.";
        case IvaFileErrors.FileErrorsCompatible:
          return "Sensor Compatible Error.";
        case IvaFileErrors.FileErrorsHardware:
          return "Hardware Version Error.";
        default:
          return "Unknown Error.";
      }
    }
  }
}
