﻿// Decompiled with JetBrains decompiler
// Type: XRecCRMLibrary.XRecCRMAPI.AddCustomerCompletedEventArgs
// Assembly: XRecCRMLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DABBCD86-4B3A-41D7-8F33-D19BFAA38EFD
// Assembly location: E:\Services\XCRMServices\XRecCRMLibrary.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace XRecCRMLibrary.XRecCRMAPI
{
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  [GeneratedCode("System.Web.Services", "4.0.30319.1")]
  public class AddCustomerCompletedEventArgs : AsyncCompletedEventArgs
  {
    private object[] results;

    public bool Result
    {
      get
      {
        this.RaiseExceptionIfNecessary();
        return (bool) this.results[0];
      }
    }

    public string Message
    {
      get
      {
        this.RaiseExceptionIfNecessary();
        return (string) this.results[1];
      }
    }

    internal AddCustomerCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
      : base(exception, cancelled, userState)
    {
      this.results = results;
    }
  }
}
