// Decompiled with JetBrains decompiler
// Type: Keyence.IV.Sdk.Communication.ExecutingMonitorExplorer
// Assembly: Keyence.IV.Sdk, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 215059BB-0A5E-405A-AF43-11BFFA69E8F1
// Assembly location: C:\Users\jona_\Desktop\New folder\Keyence.IV.Sdk.dll

using System;
using System.IO;
using System.Threading;

namespace Keyence.IV.Sdk.Communication
{
  internal static class ExecutingMonitorExplorer
  {
    private const string MUTEX_NAME = "Global\\KEYENCE_IV-Navigator_Mutex";
    private static Mutex _applicationMutex;

    public static bool Acquire()
    {
      if (ExecutingMonitorExplorer._applicationMutex != null)
        return true;
      bool createdNew = false;
      try
      {
        ExecutingMonitorExplorer._applicationMutex = new Mutex(true, "Global\\KEYENCE_IV-Navigator_Mutex", out createdNew);
      }
      catch (ApplicationException ex)
      {
        return true;
      }
      catch (UnauthorizedAccessException ex)
      {
        return true;
      }
      catch (IOException ex)
      {
        return true;
      }
      finally
      {
        if (!createdNew && ExecutingMonitorExplorer._applicationMutex != null)
        {
          ExecutingMonitorExplorer._applicationMutex.Close();
          ExecutingMonitorExplorer._applicationMutex = (Mutex) null;
        }
      }
      return ExecutingMonitorExplorer._applicationMutex == null;
    }

    public static void Release()
    {
      if (ExecutingMonitorExplorer._applicationMutex == null)
        return;
      ExecutingMonitorExplorer._applicationMutex.Close();
      ExecutingMonitorExplorer._applicationMutex = (Mutex) null;
    }
  }
}
