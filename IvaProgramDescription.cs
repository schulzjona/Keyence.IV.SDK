// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.IvaProgramDescription
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using Keyence.IV.Sdk.Common.IVAFile;
using System.Drawing;

namespace Keyence.IV.Sdk
{
  public sealed class IvaProgramDescription
  {
    public int ProgramNo { get; private set; }

    public string ProgramName { get; private set; }

    public bool Configured { get; private set; }

    public bool MasterAvailable { get; private set; }

    public ThumbnailImage ThumbnailImage { get; private set; }

    internal IvaProgramDescription(int index, CmosType cmosType, ref IvBankList src)
    {
      this.ProgramNo = index;
      this.ProgramName = src.BankName;
      this.Configured = src.ConfiguredBank;
      this.MasterAvailable = src.Enable;
      Color[] imageData = new Color[4800];
      if (this.MasterAvailable)
      {
        if (cmosType == CmosType.CmosMono)
        {
          Holder<IvThumbnailMono> holder = new Holder<IvThumbnailMono>();
          IvaUtils.CopyStructure<IvThumbnailImage, IvThumbnailMono>(ref src.ThumbnailImage, ref holder.Target);
          for (int index1 = 0; index1 < 60; ++index1)
          {
            for (int index2 = 0; index2 < 80; ++index2)
            {
              byte num = holder.Target.ImageBuffer[index1 * 80 + index2];
              imageData[index1 * 80 + index2] = Color.FromArgb((int) num, (int) num, (int) num);
            }
          }
        }
        else
        {
          Holder<IvThumbnailColor> holder = new Holder<IvThumbnailColor>();
          IvaUtils.CopyStructure<IvThumbnailImage, IvThumbnailColor>(ref src.ThumbnailImage, ref holder.Target);
          for (int index1 = 0; index1 < 60; ++index1)
          {
            for (int index2 = 0; index2 < 80; ++index2)
            {
              ushort num = holder.Target.ImageBuffer[index1 * 80 + index2];
              imageData[index1 * 80 + index2] = Color.FromArgb(((int) num & 63488) >> 8, ((int) num & 2000) >> 3, ((int) num & 31) << 3);
            }
          }
        }
      }
      this.ThumbnailImage = new ThumbnailImage(imageData);
    }
  }
}
