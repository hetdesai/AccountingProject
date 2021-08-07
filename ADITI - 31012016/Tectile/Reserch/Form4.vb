Imports System.Data.SqlClient
Public Class Form4

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            deleted("tblAccount")
            deleted("tblItem")
            deleted("tblPurchase")
            deleted("tblBroker")
            deleted("tblITType")
            deleted("tblPurchaseDetail")
            deleted("tblSH")
            deleted("tblMH")
            deleted("tblUnit")
            deleted("tblPlace")
            deleted("tblOPEN")
            deleted("tblItOpen")
            deleted("tblState")
            deleted("tblBank")
            deleted("tblLedg")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub deleted(ByRef s As String)
        connect()
        Dim cmd As New SqlCommand
        cmd = New SqlCommand("Delete from " & s, cn)
        cmd.ExecuteNonQuery()
        MsgBox(s & "deleted")
        close1()
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class