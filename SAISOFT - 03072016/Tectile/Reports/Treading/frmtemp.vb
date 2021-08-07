Imports System.Data.SqlClient
Public Class frmtemp
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Private Sub frmtemp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim i As Integer
        Dim shead As String = ""
        Dim mhead As String = ""
        Dim asd As String = ""
        Dim shead1 As String = ""
        Dim mhead1 As String = ""
        Dim asd1 As String = ""
        Dim asdtotal As Decimal
        i = 0
        Dim mheadtotal As Decimal
        Dim sheadtotal As Decimal
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=E:\My VB WORK\tectile -neworgnew18-10-2011 trading\Tectile\bin\Debug\3NewDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
        cn.Open()
        sql = "Select ASD,tblledg.ACName as ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode " & "" & "group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD order by ASD,tblMh.Mhead,tblSh.Shead"
        cmd = New SqlCommand(Sql, cn)
        dr = cmd.ExecuteReader
        While dr.Read
            MsgBox(dr.Item("ASD"))
        End While
        dr.Close()
    End Sub
End Class