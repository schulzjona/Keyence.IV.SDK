// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Common.ReplyForGetSensorData
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Communication;

namespace Keyence.IV.Sdk.Common
{
  internal struct ReplyForGetSensorData
  {
    public readonly unsafe ImageSetMono* PMonoImage;
    public unsafe ImageSetColor* PColorImage;
    public unsafe Histogram* PHistogram;
    public unsafe VsaRunningInfo* PRunninfInfo;
    public unsafe VisionSensorState* PSensorState;
    public unsafe Summary* PSummary;
    public unsafe CommHeader* Pheader;

    public unsafe ReplyForGetSensorData(WorkSpace readBuffer)
    {
      *(ReplyForGetSensorData*) ref this = new ReplyForGetSensorData();
      int size = readBuffer.Size;
      this.Pheader = (CommHeader*) (void*) readBuffer.Address;
      int num = size - sizeof (CommHeader);
      if (num < 0)
        throw new ConnectionLostException("Received Header size is invalid.");
      // ISSUE: reference to a compiler-generated field
      byte fixedElementField = this.Pheader->uOption0.abyCode.FixedElementField;
      byte* numPtr1 = (byte*) ((CommHeader*) (void*) readBuffer.Address + 1);
      if (((int) fixedElementField >> 1 & 1) == 1 && sizeof (StructSize) <= num && ((StructSize*) numPtr1)->lLength == sizeof (VisionSensorState))
      {
        num -= sizeof (StructSize) + sizeof (VisionSensorState);
        if (num < 0)
          throw new ConnectionLostException("Received SensorState data size is invalid.");
        byte* numPtr2 = numPtr1 + sizeof (StructSize);
        this.PSensorState = (VisionSensorState*) numPtr2;
        numPtr1 = numPtr2 + sizeof (VisionSensorState);
      }
      if (((int) fixedElementField & 1) == 1 && sizeof (StructSize) <= num && ((StructSize*) numPtr1)->lLength == sizeof (ImageSetMono))
      {
        num -= sizeof (StructSize) + sizeof (ImageSetMono);
        if (num < 0)
          throw new ConnectionLostException("Received monochrome image data size is invalid");
        byte* numPtr2 = numPtr1 + sizeof (StructSize);
        this.PMonoImage = (ImageSetMono*) numPtr2;
        numPtr1 = numPtr2 + sizeof (ImageSetMono);
      }
      if (((int) fixedElementField & 1) == 1 && sizeof (StructSize) <= num && ((StructSize*) numPtr1)->lLength == sizeof (ImageSetColor))
      {
        num -= sizeof (StructSize) + sizeof (ImageSetColor);
        if (num < 0)
          throw new ConnectionLostException("Received color Image data size is invalid.");
        byte* numPtr2 = numPtr1 + sizeof (StructSize);
        this.PColorImage = (ImageSetColor*) numPtr2;
        numPtr1 = numPtr2 + sizeof (ImageSetColor);
      }
      if (((int) fixedElementField >> 2 & 1) == 1 && sizeof (StructSize) <= num && ((StructSize*) numPtr1)->lLength == sizeof (VsaRunningInfo))
      {
        num -= sizeof (StructSize) + sizeof (VsaRunningInfo);
        if (num < 0)
          throw new ConnectionLostException("Received runninf info size is invalid.");
        byte* numPtr2 = numPtr1 + sizeof (StructSize);
        this.PRunninfInfo = (VsaRunningInfo*) numPtr2;
        numPtr1 = numPtr2 + sizeof (VsaRunningInfo);
      }
      if (((int) fixedElementField >> 3 & 1) == 1 && sizeof (StructSize) <= num && ((StructSize*) numPtr1)->lLength == sizeof (Summary))
      {
        num -= sizeof (StructSize) + sizeof (Summary);
        if (num < 0)
          throw new ConnectionLostException("Received summary data size is invalid.");
        byte* numPtr2 = numPtr1 + sizeof (StructSize);
        this.PSummary = (Summary*) numPtr2;
        numPtr1 = numPtr2 + sizeof (Summary);
      }
      if (((int) fixedElementField >> 4 & 1) != 1 || sizeof (StructSize) > num || ((StructSize*) numPtr1)->lLength != sizeof (Histogram))
        return;
      if (num - (sizeof (StructSize) + sizeof (Histogram)) < 0)
        throw new ConnectionLostException("Received histogram data size is invalid.");
      this.PHistogram = (Histogram*) (numPtr1 + sizeof (StructSize));
    }
  }
}
