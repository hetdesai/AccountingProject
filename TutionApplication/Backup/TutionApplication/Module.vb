Imports System.Data.OleDb
Module Module1
    Public cn As New OleDbConnection
    Public Sub Connect()
        cn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\TutionApplication\TutionApplication\bin\ITtution.mdb")
        'cn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\ITtution.mdb")
        cn.Open()
    End Sub
    Public Sub Close1()
        cn.Close()
    End Sub

End Module
