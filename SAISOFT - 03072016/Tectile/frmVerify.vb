Imports System.Data.SqlClient
Public Class frmVerify

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CheckData()
    End Sub
    Private Sub CheckData()
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            ' TO check if lot is present in Lot Entry(tblLotr) But Not in Lot Detail Entry(tblLotrt)

            cmd = New SqlCommand("select lotno from tblLotr where lotno not in (Select distinct vrno from tblLotrt)", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, DG1.Rows.Count - 1).Value = dr.Item(0)
                DG1.Item(1, DG1.Rows.Count - 1).Value = "This lot is present in lot entry but no detail entry found for this Lot"
            End While
            dr.Close()

            'To check if gpcs and total entrry in lotrt is same or not.
            cmd = New SqlCommand("select tblLotr.lotno from tblLotr group by tblLotr.lotno having (sum(gpcs)<>(select count(*) from tblLotrt where tbllotr.lotno=tbllotrt.lotno))", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, DG1.Rows.Count - 1).Value = dr.Item(0)
                DG1.Item(1, DG1.Rows.Count - 1).Value = "Pcs for this lotno is not same as total detail entry"
            End While
            dr.Close()
            'To check if gmtr is proper or not in lotr and lotrt.

            cmd = New SqlCommand("select * " & _
            "from " & _
" (select lotno, sum(gmtr) as col1" & _
           " from tblLotrt" & _
" group by tblLotrt.lotno) t1 INNER JOIN" & _
" (select lotno, gmtr as col2" & _
" from tblLotr) t2 ON t1.lotno = t2.lotno where t1.col1 <> t2.col2", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, DG1.Rows.Count - 1).Value = "lotno = " & dr.Item(0) & " Detail Entry Sum =" & dr.Item(1) & " Lot Entry Gmtr=" & dr.Item(3)
                DG1.Item(1, DG1.Rows.Count - 1).Value = "Gmtr is not proper in lotr and lotrt"
            End While
            dr.Close()
            'To check total pcs in sale and sale1 is same or not.
            cmd = New SqlCommand("select * " & _
            "from " & _
"(select billno, sum(grpcs) as col1 " & _
            "from sale1 " & _
"group by sale1.billno) t1 INNER JOIN " & _
"(select billno, grpcs as col2 " & _
"from sale) t2 ON t1.billno = t2.billno where t1.col1 <> t2.col2", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, DG1.Rows.Count - 1).Value = "BillNo = " & dr.Item(0) & " Sale1 =" & dr.Item(1) & " Sale=" & dr.Item(3)
                DG1.Item(1, DG1.Rows.Count - 1).Value = "Gpcs is not proper in sale and sale1"
            End While
            dr.Close()
            cmd = New SqlCommand("select * " & _
            "from " & _
"(select billno, sum(grmtr) as col1 " & _
            "from sale1 " & _
"group by sale1.billno) t1 INNER JOIN " & _
"(select billno, grqty as col2 " & _
"from sale) t2 ON t1.billno = t2.billno where t1.col1 <> t2.col2", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, DG1.Rows.Count - 1).Value = "BillNo = " & dr.Item(0) & " Sale1 =" & dr.Item(1) & " Sale=" & dr.Item(3)
                DG1.Item(1, DG1.Rows.Count - 1).Value = "Gmtr is not proper in sale and sale1"
            End While
            dr.Close()
            'To check total gmtr in salet and sale1
            cmd = New SqlCommand("select * " & _
            "from " & _
"(select lotno, SR,sum(grmtr) as col1 " & _
            "from salet " & _
"group by salet.lotno,salet.sr) t1 INNER JOIN " & _
"(select lotno,srno,grmtr as col2 " & _
"from sale1) t2 ON t1.lotno = t2.lotno and t1.sr=t2.srno where t1.col1 <> t2.col2", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, DG1.Rows.Count - 1).Value = "BillNo = " & dr.Item(0) & " Sale1 =" & dr.Item(1) & " Sale=" & dr.Item(3)
                DG1.Item(1, DG1.Rows.Count - 1).Value = "Gmtr is not proper in salet and sale1"
            End While
            dr.Close()
            'To check total gpcs in salet and sale1
            cmd = New SqlCommand("select * " & _
            "from " & _
"(select lotno, SR,count(*) as col1 " & _
            "from salet " & _
"group by salet.lotno,salet.sr) t1 INNER JOIN " & _
"(select lotno,srno,grpcs as col2 " & _
"from sale1) t2 ON t1.lotno = t2.lotno and t1.sr=t2.srno where t1.col1 <> t2.col2", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, DG1.Rows.Count - 1).Value = "BillNo = " & dr.Item(0) & " Salet =" & dr.Item(1) & " Sale1=" & dr.Item(3)
                DG1.Item(1, DG1.Rows.Count - 1).Value = "Gpcs is not proper in salet and sale1"
            End While

            dr.Close()
            'To check finish mtr is same in salet and sale1 or not.
            cmd = New SqlCommand("select *" & _
            "from " & _
"(select lotno, SR,sum(qty) as col1 " & _
            "from salet " & _
"group by salet.lotno,salet.sr) t1 INNER JOIN " & _
"(select lotno,srno,qty as col2 " & _
"from sale1) t2 ON t1.lotno = t2.lotno and t1.sr=t2.srno where t1.col1 <> t2.col2", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, DG1.Rows.Count - 1).Value = "Lotno = " & dr.Item(0) & " Salet =" & dr.Item(1) & " Sale1=" & dr.Item(3)
                DG1.Item(1, DG1.Rows.Count - 1).Value = "Fnish Mtr is not proper in salet and sale1"
            End While

            dr.Close()
            'To check finish mtr in sale and salet or not.
            cmd = New SqlCommand("select * " & _
            "from " & _
"(select vrno,sum(qty) as col1 " & _
            "from sale1 " & _
"group by sale1.vrno) t1 INNER JOIN " & _
"(select vrno,qty as col2 " & _
"from sale) t2 ON t1.vrno = t2.vrno where t1.col1 <> t2.col2", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, DG1.Rows.Count - 1).Value = "Lotno = " & dr.Item(0) & " Sale1 =" & dr.Item(1) & " Sale=" & dr.Item(3)
                DG1.Item(1, DG1.Rows.Count - 1).Value = "Fnish Mtr is not proper in sale1 and sale"
            End While
            dr.Close()
            cmd = New SqlCommand("select * " & _
            "from " & _
"(select lotno,gmtr-gbalmtr as col1 " & _
"from tblLotr) t1 INNER JOIN " & _
"(select lotno,sum(grmtr) as col2 " & _
"from sale1 group by lotno) t2 ON t1.lotno = t2.lotno where t1.col1 <> t2.col2", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, DG1.Rows.Count - 1).Value = "Lotno = " & dr.Item(0) & " Lotr =" & dr.Item(1) & " Sale1=" & dr.Item(3)
                DG1.Item(1, DG1.Rows.Count - 1).Value = "Balance Mtr is not proper in Lotr and Sale1"
            End While
            dr.Close()

            close1()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class