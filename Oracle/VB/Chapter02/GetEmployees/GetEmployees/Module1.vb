Imports System
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

Module Module1

  Sub Main()
    '// create and open a connection object
    Dim connstr As String = "User Id=scott; Password=tiger; Data Source=oranet"
    Dim con As OracleConnection = New OracleConnection(connstr)
    con.Open()

    '// the sql statement to retrieve the data from the tables
    Dim sql As String = "select a.empno, a.ename, a.job, b.dname "
    sql += "from emp a, dept b "
    sql += "where a.deptno = b.deptno "
    sql += "order by a.empno"

    '// create the command object
    Dim cmd As OracleCommand = New OracleCommand(sql, con)

    '// execute the command and get a data reader
    Dim dr As OracleDataReader = cmd.ExecuteReader()

    '// display the results to the console window
    '// use a tab character between the columns
    While (dr.Read())
      Console.Write(dr(0).ToString() + Chr(9))
      Console.Write(dr(1).ToString() + Chr(9))
      Console.Write(dr(2).ToString() + Chr(9))
      Console.WriteLine(dr(3).ToString())
    End While

    '// close and dispose the objects
    dr.Close()
    dr.Dispose()
    cmd.Dispose()
    con.Close()
    con.Dispose()
  End Sub

End Module
