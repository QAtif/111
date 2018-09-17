﻿// Decompiled with JetBrains decompiler
// Type: SqlHelperParameterCache
// Assembly: App_Code, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CCFCF570-EAC0-4D2F-8EF3-866C275AB6B3
// Assembly location: C:\Users\atifhussain\Desktop\Dlls\Axact Recruitment\App_Code.dll

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

public sealed class SqlHelperParameterCache
{
  private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

  private SqlHelperParameterCache()
  {
  }

  private static SqlParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
  {
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
      using (SqlCommand command = new SqlCommand(spName, connection))
      {
        connection.Open();
        command.CommandType = CommandType.StoredProcedure;
        SqlCommandBuilder.DeriveParameters(command);
        if (!includeReturnValueParameter)
          command.Parameters.RemoveAt(0);
        SqlParameter[] array = new SqlParameter[command.Parameters.Count];
        command.Parameters.CopyTo(array, 0);
        return array;
      }
    }
  }

  private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
  {
    SqlParameter[] sqlParameterArray = new SqlParameter[originalParameters.Length];
    int index = 0;
    for (int length = originalParameters.Length; index < length; ++index)
      sqlParameterArray[index] = (SqlParameter) ((ICloneable) originalParameters[index]).Clone();
    return sqlParameterArray;
  }

  public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
  {
    string str = connectionString + ":" + commandText;
    SqlHelperParameterCache.paramCache[(object) str] = (object) commandParameters;
  }

  public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
  {
    string str = connectionString + ":" + commandText;
    SqlParameter[] originalParameters = (SqlParameter[]) SqlHelperParameterCache.paramCache[(object) str];
    if (originalParameters == null)
      return (SqlParameter[]) null;
    return SqlHelperParameterCache.CloneParameters(originalParameters);
  }

  public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
  {
    return SqlHelperParameterCache.GetSpParameterSet(connectionString, spName, false);
  }

  public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
  {
    string str = connectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
    return SqlHelperParameterCache.CloneParameters((SqlParameter[]) SqlHelperParameterCache.paramCache[(object) str] ?? (SqlParameter[]) (SqlHelperParameterCache.paramCache[(object) str] = (object) SqlHelperParameterCache.DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter)));
  }
}
