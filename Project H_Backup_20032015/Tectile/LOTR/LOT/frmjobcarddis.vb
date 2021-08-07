Imports System.Data.SqlClient
Public Class frmjobcarddis
    Dim ds As New DataSet2
    Public FROMWHERE As String = ""
    Public LOTNO As String = ""

    Private Sub frmjobcarddis_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If FROMWHERE <> "LOTR" Then
            frmlotr.Visible = True
        End If
    End Sub
    Private Sub frmjobcarddis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
       
        Dim da As New SqlDataAdapter
        If FROMWHERE = "LOTR" Then
            Dim DAT1 As New Date
            Dim DAT2 As New Date
            DAT1 = FRMJOBCARDSELE.MaskedTextBox1.Text
            DAT2 = FRMJOBCARDSELE.MaskedTextBox2.Text
            da = New SqlDataAdapter("Select * from tblLotr WHERE DATE>='" & DAT1.Month & "-" & DAT1.Day & "-" & DAT1.Year & "' AND DATE<='" & DAT2.Month & "-" & DAT2.Day & "-" & DAT2.Year & "'", cn)
        Else
            da = New SqlDataAdapter("Select * from tblLotr WHERE LOTNO='" & LOTNO & "'", cn)
        End If
        da.Fill(ds, "tblLotr")
        Dim rpt As New rptjobcard
        rpt.SetDataSource(ds)
        da = New SqlDataAdapter("Select * from tblLotrt", cn)
        da.Fill(ds, "tblLotrt")
        Dim rpt2 As New rptjobcard2
        rpt2.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt
        close1()

    End Sub
End Class