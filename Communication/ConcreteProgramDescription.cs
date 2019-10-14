// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ConcreteProgramDescription
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using Keyence.IV.Sdk.Common;
using System.Drawing;

namespace Keyence.IV.Sdk.Communication
{
  internal class ConcreteProgramDescription : ProgramDescription
  {
    private readonly IProgramSetting _baseData;
    private readonly CmosType _cmosType;

    internal ConcreteProgramDescription(CmosType cmosType, IProgramSetting src)
    {
      this._baseData = src;
      this._cmosType = cmosType;
    }

    public override string ProgramName
    {
      get
      {
        return this._baseData.ProgramName;
      }
    }

    public override int ProgramNo
    {
      get
      {
        return this._baseData.ProgramNo;
      }
    }

    public override bool ExternalTrigger
    {
      get
      {
        return this._baseData.ExternalTrigger;
      }
    }

    public override ushort TriggerCycleMilliSec
    {
      get
      {
        return this._baseData.TriggerCycleMilliSec;
      }
    }

    public override ToolSettingBase PositionAdjustSetting
    {
      get
      {
        return this._baseData.PositionAdjustSetting;
      }
    }

    public override ToolSettingBase this[byte toolNo]
    {
      get
      {
        return this._baseData[toolNo];
      }
    }

    public override Keyence.IV.Sdk.Image MasterImage
    {
      get
      {
        Color[] masterImageData = new Color[76800];
        if (this._cmosType == CmosType.CmosMono)
        {
          for (int index1 = 0; index1 < 240; ++index1)
          {
            for (int index2 = 0; index2 < 320; ++index2)
            {
              byte num = this._baseData.MonochromeMaster[index1 * 320 + index2];
              masterImageData[index1 * 320 + index2] = Color.FromArgb((int) num, (int) num, (int) num);
            }
          }
        }
        else
        {
          for (int index1 = 0; index1 < 240; ++index1)
          {
            for (int index2 = 0; index2 < 320; ++index2)
            {
              short num = this._baseData.ColorMaster[index1 * 320 + index2];
              masterImageData[index1 * 320 + index2] = Color.FromArgb(((int) num & 63488) >> 8, ((int) num & 2000) >> 3, ((int) num & 31) << 3);
            }
          }
        }
        return (Keyence.IV.Sdk.Image) new ConcreteImage(masterImageData);
      }
    }
  }
}
