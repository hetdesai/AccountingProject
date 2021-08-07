﻿Imports System.Data.SqlClient
Public Class frmsetup
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Private Sub frmsetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            connect()
            da = New SqlDataAdapter("Select * from tblSetup", cn)
            da.Fill(ds)
            MyDataGridView1.DataSource = ds.Tables(0)
            MyDataGridView1.Columns(1).Width = 400
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MessageBox.Show("Are you sure want to change settngs", "Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim cb As New SqlCommandBuilder(da)
                da.Update(ds)
                MessageBox.Show("Settings updated")
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
          

        End If

    End Sub
End Class