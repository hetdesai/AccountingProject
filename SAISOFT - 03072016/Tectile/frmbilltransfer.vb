Imports System.Data.SqlClient
Public Class frmbilltransfer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lottransfer()
    End Sub
    Private Sub lottransfer()
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("insert into [D:\WORK\ADITI\TECTILE\BIN\DEBUG\2NEWDB.MDF].dbo.tblLotr (vrno,date,lotno,ichno,item,itcode,acname,accode,width,gpcs,gmtr,remark,mst,lrno,isdesp,loty,lotn,lotc,rlotno,weg,desce,marka,broker,brcode,candate,check1,type) select vrno,date,lotno,ichno,item,itcode,acname,accode,width,gbalpcs,gbalmtr,remark,mst,lrNo,isdesp,loty,lotn,lotc,rlotno,weg,desce,marka,broker,brcode,candate,check1,type from [D:\WORK\SAISOFT\TECTILE\BIN\DEBUG\1NEWDB.MDF].dbo.tblLotr where gbalpcs>0", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update [D:\WORK\ADITI\TECTILE\BIN\DEBUG\2NEWDB.MDF].dbo.tblLotr set gbalpcs=gpcs,gbalmtr=gmtr,isdesp='f'", cn)
            cmd.ExecuteNonQuery()
            close1()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class