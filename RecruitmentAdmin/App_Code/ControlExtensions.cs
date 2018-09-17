// Decompiled with JetBrains decompiler
// Type: ControlExtensions
// Assembly: App_Code, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CCFCF570-EAC0-4D2F-8EF3-866C275AB6B3
// Assembly location: C:\Users\atifhussain\Desktop\Dlls\Axact Recruitment\App_Code.dll

using System.Collections.Generic;
using System.Web.UI;

public static class ControlExtensions
{
  public static IEnumerable<T> GetAllControlsOfType<T>(this Control parent) where T : Control
  {
    List<T> objList = new List<T>();
    foreach (Control control in parent.Controls)
    {
      if (control is T)
        objList.Add((T) control);
      if (control.HasControls())
        objList.AddRange(control.GetAllControlsOfType<T>());
    }
    return (IEnumerable<T>) objList;
  }
}
