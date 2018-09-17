// Decompiled with JetBrains decompiler
// Type: XRecCRMLibrary.XRecCRMAPI.EmailSendingStatus
// Assembly: XRecCRMLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DABBCD86-4B3A-41D7-8F33-D19BFAA38EFD
// Assembly location: E:\Services\XCRMServices\XRecCRMLibrary.dll

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace XRecCRMLibrary.XRecCRMAPI
{
  [GeneratedCode("System.Xml", "4.0.30319.1")]
  [XmlType(Namespace = "http://tempuri.org/")]
  [Serializable]
  public enum EmailSendingStatus
  {
    Pending,
    Send,
    Error,
  }
}
