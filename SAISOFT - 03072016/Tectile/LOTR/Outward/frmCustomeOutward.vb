Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmCustomeOutward
    Dim ds As New DataSet2
    Dim rpt As New rptOutwardCustome
    Private Sub frmCustomeOutward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from sale1", cn)
            da.Fill(ds, "sale1")

            rpt.SetDataSource(ds)
            Dim p1 As New ParameterFields
            Dim field1 As New ParameterField ' ParameterField for 1st param
            Dim value1 As New ParameterDiscreteValue  ' ParameterField for 2nd param
            Dim field2 As New ParameterField ' ParameterField for 1st param
            Dim value2 As New ParameterDiscreteValue  ' ParameterField for 2nd param
            Dim field3 As New ParameterField ' ParameterField for 1st param
            Dim value3 As New ParameterDiscreteValue  ' ParameterField for 2nd param

            'Now set first param
            field1.ParameterFieldName = "Group1"
            value1.Value = "ITNAME"
            field1.CurrentValues.Add(value1)
            p1.Add(field1)
            field2.ParameterFieldName = "Group2"
            value2.Value = "NAME"
            field2.CurrentValues.Add(value2)
            p1.Add(field2)
            field3.ParameterFieldName = "Group3"
            value3.Value = ""
            field3.CurrentValues.Add(value3)
            p1.Add(field3)
            setlocations()
            CrystalReportViewer1.ParameterFieldInfo = passparam()
            CrystalReportViewer1.ReportSource = rpt
            close1()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub LOCATION1(ByVal STR As String, ByVal STR2 As String)
        Try
           

            rpt.ReportDefinition.ReportObjects(STR).Width = Split(STR2).ElementAt(2)


            rpt.ReportDefinition.ReportObjects(STR).Height = Split(STR2).ElementAt(1)


            rpt.ReportDefinition.ReportObjects(STR).Left = Split(STR2).ElementAt(5)
            rpt.ReportDefinition.ReportObjects(STR).Top = 100

        Catch ex As Exception
            '   MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub setlocations()
        With frmOutwordCustomeSelection
            LOCATION1("vrno1", .vrno)
            LOCATION1("BkName1", .bkname)
            LOCATION1("bkcode1", .bkcode)
            LOCATION1("chno1", .chno)
            LOCATION1("chdt1", .chdt)
            LOCATION1("billno", .billno)
            LOCATION1("oubno1", .oubno)
            LOCATION1("billdt1", .billdt)
            LOCATION1("name1", .Name)
            LOCATION1("namecr1", .NameCr)
            LOCATION1("srno1", .SrNo)
            LOCATION1("itname1", .Itname)
            LOCATION1("itcode1", .Itcode)
            LOCATION1("pcs1", .Pcs)
            LOCATION1("pack1", .PACK)
            LOCATION1("qty1", .Qty)
            LOCATION1("rate1", .Rate)
            LOCATION1("unit1", .Unit)
            LOCATION1("amount1", .Amount)
            LOCATION1("accode1", .Accode)
            LOCATION1("accodecr1", .Accodecr)
            LOCATION1("prcode1", .prcode)
            LOCATION1("process1", .Process)
            LOCATION1("style1", .Style)
            LOCATION1("shade1", .Shade)
            LOCATION1("mstcode1", .mstcode)
            LOCATION1("width1", .width1)
            LOCATION1("grpcs1", .Grpcs)
            LOCATION1("grmtr1", .GrMtr)
            LOCATION1("grrate1", .Grrate)
            LOCATION1("grval1", .GrVAL)
            LOCATION1("desgno1", .Desgno)
            LOCATION1("lotno1", .lotno)
            LOCATION1("shortage1", .shortage)
            LOCATION1("remark1", .remark)
            LOCATION1("MachineNo1", .machineno)
            LOCATION1("Sumofpcs1", .Pcs)
            LOCATION1("Sumofpcs2", .Pcs)
            LOCATION1("Sumofpcs3", .Pcs)
            LOCATION1("Sumofpcs4", .Pcs)
            LOCATION1("Sumofpcs5", .Pcs)
            LOCATION1("Sumofpcs6", .Pcs)
            LOCATION1("Sumofpcs7", .Pcs)
            LOCATION1("Sumofpcs8", .Pcs)
            LOCATION1("Sumofpcs18", .Pcs)
            LOCATION1("Sumofpcs17", .Pcs)
            LOCATION1("Sumofqty1", .Qty)
            LOCATION1("Sumofqty2", .Qty)
            LOCATION1("Sumofqty3", .Qty)
            LOCATION1("Sumofqty4", .Qty)
            LOCATION1("Sumofqty5", .Qty)
            LOCATION1("Sumofqty6", .Qty)
            LOCATION1("Sumofqty7", .Qty)
            LOCATION1("Sumofqty8", .Qty)
            LOCATION1("Sumofqty17", .Qty)
            LOCATION1("Sumofqty18", .Qty)
            LOCATION1("SumofGrpcs1", .Grpcs)
            LOCATION1("SumofGrpcs2", .Grpcs)
            LOCATION1("SumofGrpcs3", .Grpcs)
            LOCATION1("SumofGrpcs4", .Grpcs)
            LOCATION1("SumofGrpcs5", .Grpcs)
            LOCATION1("SumofGrpcs6", .Grpcs)
            LOCATION1("SumofGrpcs7", .Grpcs)
            LOCATION1("SumofGrpcs8", .Grpcs)
            LOCATION1("SumofGrpcs17", .Grpcs)
            LOCATION1("SumofGrpcs18", .Grpcs)

            LOCATION1("SumofGrmtr1", .GrMtr)
            LOCATION1("SumofGrmtr2", .GrMtr)
            LOCATION1("SumofGrmtr3", .GrMtr)
            LOCATION1("SumofGrmtr4", .GrMtr)
            LOCATION1("SumofGrmtr5", .GrMtr)
            LOCATION1("SumofGrmtr6", .GrMtr)
            LOCATION1("SumofGrmtr7", .GrMtr)
            LOCATION1("SumofGrmtr8", .GrMtr)
            LOCATION1("SumofGrmtr17", .GrMtr)
            LOCATION1("SumofGrmtr18", .GrMtr)

            LOCATION1("SumOfAmount1", .Amount)
            LOCATION1("SumOfAmount2", .Amount)
            LOCATION1("SumOfAmount3", .Amount)
            LOCATION1("SumOfAmount4", .Amount)
            LOCATION1("SumOfAmount5", .Amount)
            LOCATION1("SumOfAmount6", .Amount)
            LOCATION1("SumOfAmount7", .Amount)
            LOCATION1("SumOfAmount8", .Amount)
            LOCATION1("SumOfAmount17", .Amount)
            LOCATION1("SumOfAmount18", .Amount)


        End With
    End Sub
    Private Function passparam() As ParameterFields
        Dim p1 As New ParameterFields
        Dim vrnof As New ParameterField
        Dim bknamef As New ParameterField
        Dim bkcodef As New ParameterField
        Dim chnof As New ParameterField
        Dim chdtf As New ParameterField
        Dim billnof As New ParameterField
        Dim oubnof As New ParameterField
        Dim billdtf As New ParameterField
        Dim Namef As New ParameterField
        Dim NameCrf As New ParameterField
        Dim SrNof As New ParameterField
        Dim Itnamef As New ParameterField
        Dim Itcodef As New ParameterField
        Dim Pcsf As New ParameterField
        Dim PACKf As New ParameterField
        Dim Qtyf As New ParameterField
        Dim Ratef As New ParameterField
        Dim Unitf As New ParameterField
        Dim Amountf As New ParameterField
        Dim Accodef As New ParameterField
        Dim Accodecrf As New ParameterField
        Dim prcodef As New ParameterField
        Dim Processf As New ParameterField
        Dim Stylef As New ParameterField
        Dim Shadef As New ParameterField
        Dim mstcodef As New ParameterField
        Dim mstf As New ParameterField
        Dim width1f As New ParameterField
        Dim Grpcsf As New ParameterField
        Dim GrMtrf As New ParameterField
        Dim Grratef As New ParameterField
        Dim GrVALf As New ParameterField
        Dim Desgnof As New ParameterField
        Dim lotnof As New ParameterField
        Dim shortagef As New ParameterField
        Dim remarkf As New ParameterField
        Dim machinenof As New ParameterField
        Dim groupp1f As New ParameterField
        Dim groupp2f As New ParameterField
        Dim groupp3f As New ParameterField
        Dim groupp4f As New ParameterField
        Dim groupp5f As New ParameterField
        Dim groupp6f As New ParameterField
        Dim groupp7f As New ParameterField
        Dim groupp8f As New ParameterField
        Dim groupp9f As New ParameterField
        Dim detailsrequiredf As New ParameterField
        Dim vrnoV As New ParameterDiscreteValue
        Dim bknameV As New ParameterDiscreteValue
        Dim bkcodeV As New ParameterDiscreteValue
        Dim chnoV As New ParameterDiscreteValue
        Dim chdtV As New ParameterDiscreteValue
        Dim billnoV As New ParameterDiscreteValue
        Dim oubnoV As New ParameterDiscreteValue
        Dim billdtV As New ParameterDiscreteValue
        Dim NameV As New ParameterDiscreteValue
        Dim NameCrV As New ParameterDiscreteValue
        Dim SrNoV As New ParameterDiscreteValue
        Dim ItnameV As New ParameterDiscreteValue
        Dim ItcodeV As New ParameterDiscreteValue
        Dim PcsV As New ParameterDiscreteValue
        Dim PACKV As New ParameterDiscreteValue
        Dim QtyV As New ParameterDiscreteValue
        Dim RateV As New ParameterDiscreteValue
        Dim UnitV As New ParameterDiscreteValue
        Dim AmountV As New ParameterDiscreteValue
        Dim AccodeV As New ParameterDiscreteValue
        Dim AccodecrV As New ParameterDiscreteValue
        Dim prcodeV As New ParameterDiscreteValue
        Dim ProcessV As New ParameterDiscreteValue
        Dim StyleV As New ParameterDiscreteValue
        Dim ShadeV As New ParameterDiscreteValue
        Dim mstcodeV As New ParameterDiscreteValue
        Dim mstV As New ParameterDiscreteValue
        Dim width1V As New ParameterDiscreteValue
        Dim GrpcsV As New ParameterDiscreteValue
        Dim GrMtrV As New ParameterDiscreteValue
        Dim GrrateV As New ParameterDiscreteValue
        Dim GrVALV As New ParameterDiscreteValue
        Dim DesgnoV As New ParameterDiscreteValue
        Dim lotnoV As New ParameterDiscreteValue
        Dim shortageV As New ParameterDiscreteValue
        Dim remarkV As New ParameterDiscreteValue
        Dim machinenoV As New ParameterDiscreteValue
        Dim groupp1V As New ParameterDiscreteValue
        Dim groupp2V As New ParameterDiscreteValue
        Dim groupp3V As New ParameterDiscreteValue
        Dim groupp4V As New ParameterDiscreteValue
        Dim groupp5V As New ParameterDiscreteValue
        Dim groupp6V As New ParameterDiscreteValue
        Dim groupp7V As New ParameterDiscreteValue
        Dim groupp8V As New ParameterDiscreteValue
        Dim groupp9V As New ParameterDiscreteValue
        Dim detailsrequiredv As New ParameterDiscreteValue
        vrnof.ParameterFieldName = "vrno"
        bknamef.ParameterFieldName = "bkname"
        bkcodef.ParameterFieldName = "bkcode"
        chnof.ParameterFieldName = "chno"
        chdtf.ParameterFieldName = "chdt"
        billnof.ParameterFieldName = "billno"
        oubnof.ParameterFieldName = "oubno"
        billdtf.ParameterFieldName = "billdt"
        Namef.ParameterFieldName = "Name"
        NameCrf.ParameterFieldName = "NameCr"
        SrNof.ParameterFieldName = "SrNo"
        Itnamef.ParameterFieldName = "Itname"
        Itcodef.ParameterFieldName = "Itcode"
        Pcsf.ParameterFieldName = "Pcs"
        PACKf.ParameterFieldName = "PACK"
        Qtyf.ParameterFieldName = "Qty"
        Ratef.ParameterFieldName = "Rate"
        Unitf.ParameterFieldName = "Unit"
        Amountf.ParameterFieldName = "Amount"
        Accodef.ParameterFieldName = "Accode"
        Accodecrf.ParameterFieldName = "Accodecr"
        prcodef.ParameterFieldName = "prcode"
        Processf.ParameterFieldName = "Process"
        Stylef.ParameterFieldName = "Style"
        Shadef.ParameterFieldName = "Shade"
        mstcodef.ParameterFieldName = "mstcode"
        mstf.ParameterFieldName = "mst"
        width1f.ParameterFieldName = "width"
        Grpcsf.ParameterFieldName = "Grpcs"
        GrMtrf.ParameterFieldName = "GrMtr"
        Grratef.ParameterFieldName = "Grrate"
        GrVALf.ParameterFieldName = "GrVAL"
        Desgnof.ParameterFieldName = "Desgno"
        lotnof.ParameterFieldName = "lotno"
        shortagef.ParameterFieldName = "shortage"
        remarkf.ParameterFieldName = "remark"
        machinenof.ParameterFieldName = "machineno"
        groupp1f.ParameterFieldName = "groupp1"
        groupp2f.ParameterFieldName = "groupp2"
        groupp3f.ParameterFieldName = "groupp3"
        groupp4f.ParameterFieldName = "groupp4"
        groupp5f.ParameterFieldName = "groupp5"
        groupp6f.ParameterFieldName = "groupp6"
        groupp7f.ParameterFieldName = "groupp7"
        groupp8f.ParameterFieldName = "groupp8"
        groupp9f.ParameterFieldName = "groupp9"
        detailsrequiredf.ParameterFieldName = "DetailsRequired"
        With frmOutwordCustomeSelection
            vrnoV.Value = .vrno
            bknameV.Value = .bkname
            bkcodeV.Value = .bkcode
            chnoV.Value = .chno
            chdtV.Value = .chdt
            billnoV.Value = .billno
            oubnoV.Value = .oubno
            billdtV.Value = .billdt
            NameV.Value = .Name
            NameCrV.Value = .NameCr
            SrNoV.Value = .SrNo
            ItnameV.Value = .Itname
            ItcodeV.Value = .Itcode
            PcsV.Value = .Pcs
            PACKV.Value = .PACK
            QtyV.Value = .Qty
            RateV.Value = .Rate
            UnitV.Value = .Unit
            AmountV.Value = .Amount
            AccodeV.Value = .Accode
            AccodecrV.Value = .Accodecr
            prcodeV.Value = .prcode
            ProcessV.Value = .Process
            StyleV.Value = .Style
            ShadeV.Value = .Shade
            mstcodeV.Value = .mstcode
            mstV.Value = .mst
            width1V.Value = .width1
            GrpcsV.Value = .Grpcs
            GrMtrV.Value = .GrMtr
            GrrateV.Value = .Grrate
            GrVALV.Value = .GrVAL
            DesgnoV.Value = .Desgno
            lotnoV.Value = .lotno
            shortageV.Value = .shortage
            remarkV.Value = .remark
            machinenoV.Value = .machineno
            groupp1V.Value = .Groupp1
            groupp2V.Value = .Groupp2
            groupp3V.Value = .Groupp3
            groupp4V.Value = .Groupp4
            groupp5V.Value = .Groupp5
            groupp6V.Value = .Groupp6
            groupp7V.Value = .Groupp7
            groupp8V.Value = .groupp8
            groupp9V.Value = .groupp9
            detailsrequiredv.Value = .detailsrequired

        End With

        vrnof.CurrentValues.Add(vrnoV)
        bknamef.CurrentValues.Add(bknameV)
        bkcodef.CurrentValues.Add(bkcodeV)
        chnof.CurrentValues.Add(chnoV)
        chdtf.CurrentValues.Add(chdtV)
        billnof.CurrentValues.Add(billnoV)
        oubnof.CurrentValues.Add(oubnoV)
        billdtf.CurrentValues.Add(billdtV)
        Namef.CurrentValues.Add(NameV)
        NameCrf.CurrentValues.Add(NameCrV)
        SrNof.CurrentValues.Add(SrNoV)
        Itnamef.CurrentValues.Add(ItnameV)
        Itcodef.CurrentValues.Add(ItcodeV)
        Pcsf.CurrentValues.Add(PcsV)
        PACKf.CurrentValues.Add(PACKV)
        Qtyf.CurrentValues.Add(QtyV)
        Ratef.CurrentValues.Add(RateV)
        Unitf.CurrentValues.Add(UnitV)
        Amountf.CurrentValues.Add(AmountV)
        Accodef.CurrentValues.Add(AccodeV)
        Accodecrf.CurrentValues.Add(AccodecrV)
        prcodef.CurrentValues.Add(prcodeV)
        Processf.CurrentValues.Add(ProcessV)
        Stylef.CurrentValues.Add(StyleV)
        Shadef.CurrentValues.Add(ShadeV)
        mstcodef.CurrentValues.Add(mstcodeV)
        mstf.CurrentValues.Add(mstV)
        width1f.CurrentValues.Add(width1V)
        Grpcsf.CurrentValues.Add(GrpcsV)
        GrMtrf.CurrentValues.Add(GrMtrV)
        Grratef.CurrentValues.Add(GrrateV)
        GrVALf.CurrentValues.Add(GrVALV)
        Desgnof.CurrentValues.Add(DesgnoV)
        lotnof.CurrentValues.Add(lotnoV)
        shortagef.CurrentValues.Add(shortageV)
        remarkf.CurrentValues.Add(remarkV)
        machinenof.CurrentValues.Add(machinenoV)
        groupp1f.CurrentValues.Add(groupp1V)
        groupp2f.CurrentValues.Add(groupp2V)
        groupp3f.CurrentValues.Add(groupp3V)
        groupp4f.CurrentValues.Add(groupp4V)
        groupp5f.CurrentValues.Add(groupp5V)
        groupp6f.CurrentValues.Add(groupp6V)
        groupp7f.CurrentValues.Add(groupp7V)
        groupp8f.CurrentValues.Add(groupp8V)
        groupp9f.CurrentValues.Add(groupp9V)
        detailsrequiredf.CurrentValues.Add(detailsrequiredv)
        p1.Add(vrnof)
        p1.Add(bknamef)
        p1.Add(bkcodef)
        p1.Add(chnof)
        p1.Add(chdtf)
        p1.Add(billnof)
        p1.Add(oubnof)
        p1.Add(billdtf)
        p1.Add(Namef)
        p1.Add(NameCrf)
        p1.Add(SrNof)
        p1.Add(Itnamef)
        p1.Add(Itcodef)
        p1.Add(Pcsf)
        p1.Add(PACKf)
        p1.Add(Qtyf)
        p1.Add(Ratef)
        p1.Add(Unitf)
        p1.Add(Amountf)
        p1.Add(Accodef)
        p1.Add(Accodecrf)
        p1.Add(prcodef)
        p1.Add(Processf)
        p1.Add(Stylef)
        p1.Add(Shadef)
        p1.Add(mstcodef)
        p1.Add(mstf)
        p1.Add(width1f)
        p1.Add(Grpcsf)
        p1.Add(GrMtrf)
        p1.Add(Grratef)
        p1.Add(GrVALf)
        p1.Add(Desgnof)
        p1.Add(lotnof)
        p1.Add(shortagef)
        p1.Add(remarkf)
        p1.Add(machinenof)
        p1.Add(groupp1f)
        p1.Add(groupp2f)
        p1.Add(groupp3f)
        p1.Add(groupp4f)
        p1.Add(groupp5f)
        p1.Add(groupp6f)
        p1.Add(groupp7f)
        p1.Add(groupp8f)
        p1.Add(groupp9f)
        p1.Add(detailsrequiredf)
        Dim field1 As New ParameterField ' ParameterField for 1st param
        Dim value1 As New ParameterDiscreteValue  ' ParameterField for 2nd param
        Dim field2 As New ParameterField ' ParameterField for 1st param
        Dim value2 As New ParameterDiscreteValue  ' ParameterField for 2nd param
        Dim field3 As New ParameterField ' ParameterField for 1st param
        Dim value3 As New ParameterDiscreteValue  ' ParameterField for 2nd param
        Dim field4 As New ParameterField ' ParameterField for 1st param
        Dim value4 As New ParameterDiscreteValue  ' ParameterField for 2nd param
        Dim field5 As New ParameterField ' ParameterField for 1st param
        Dim value5 As New ParameterDiscreteValue  ' ParameterField for 2nd param
        Dim field6 As New ParameterField ' ParameterField for 1st param
        Dim value6 As New ParameterDiscreteValue  ' ParameterField for 2nd param
        Dim field7 As New ParameterField ' ParameterField for 1st param
        Dim value7 As New ParameterDiscreteValue  ' ParameterField for 2nd param
        Dim field8 As New ParameterField ' ParameterField for 1st param
        Dim value8 As New ParameterDiscreteValue  ' ParameterField for 2nd param
        Dim field9 As New ParameterField ' ParameterField for 1st param
        Dim value9 As New ParameterDiscreteValue  ' ParameterField for 2nd param

        With frmOutwordCustomeSelection
            'Now set first param
            field1.ParameterFieldName = "Group1"
            value1.Value = .group1
            field1.CurrentValues.Add(value1)
            p1.Add(field1)
            field2.ParameterFieldName = "Group2"
            value2.Value = .group2
            field2.CurrentValues.Add(value2)
            p1.Add(field2)
            field3.ParameterFieldName = "Group3"
            value3.Value = .group3
            field3.CurrentValues.Add(value3)
            p1.Add(field3)
            field4.ParameterFieldName = "Group4"
            value4.Value = .group4
            field4.CurrentValues.Add(value4)
            p1.Add(field4)
            field5.ParameterFieldName = "Group5"
            value5.Value = .group5
            field5.CurrentValues.Add(value5)
            p1.Add(field5)
            field6.ParameterFieldName = "Group6"
            value6.Value = .group6
            field6.CurrentValues.Add(value6)
            p1.Add(field6)
            field7.ParameterFieldName = "Group7"
            value7.Value = .group7
            field7.CurrentValues.Add(value7)
            p1.Add(field7)
            field8.ParameterFieldName = "Group8"
            value8.Value = .group8
            field8.CurrentValues.Add(value8)
            p1.Add(field8)
            field9.ParameterFieldName = "Group9"
            value9.Value = .group9
            field9.CurrentValues.Add(value9)
            p1.Add(field9)
            'field3.ParameterFieldName = "Group3"
            'value3.Value = ""
            'field3.CurrentValues.Add(value3)
            'p1.Add(field3)
        End With
        Return p1

    End Function
End Class