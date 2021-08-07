Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Public Class FRMVIEWCUSTOM
    Dim RPT As New RPTCUSTOMSALE
    Private Sub FRMVIEWCUSTOM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim DA As New SqlDataAdapter
            Dim DS As New DataSet2
            DA = New SqlDataAdapter("sELECT * FROM SALESC", cn)
            DA.Fill(DS, "salesc")
            DA = New SqlDataAdapter("select * from tblaccount", cn)
            DA.Fill(DS, "tblaccount")
            RPT.SetDataSource(DS)
            ' Rpt.ReportDefinition.Sections(SECTION_NAME>).Height = 1024
            Dim reportobject As New ReportObjectKind
            'reportObject = directcast(RPT .ReportDefinition.ReportObjects["Line1"],REportobjectkind)
            '    Dim i As line
            '  MsgBox(FRMCUSTOMESALE.netamt)
            '      MsgBox(FRMCUSTOMESALE.pcs)
            '     MsgBox(FRMCUSTOMESALE.gramt)
            LOCATION1("vrno1", FRMCUSTOMESALE.vrno)
            LOCATION1("name1", FRMCUSTOMESALE.name1)
            LOCATION1("namecr1", FRMCUSTOMESALE.namecr)
            LOCATION1("billdt1", FRMCUSTOMESALE.billdt)
            LOCATION1("billno1", FRMCUSTOMESALE.billno)
            LOCATION1("chno1", FRMCUSTOMESALE.chno)
            LOCATION1("chdt1", FRMCUSTOMESALE.chdt)
            LOCATION1("oubno1", FRMCUSTOMESALE.oubno)
            LOCATION1("workno1", FRMCUSTOMESALE.workno)
            LOCATION1("shipto1", FRMCUSTOMESALE.shipto)
            LOCATION1("pcs1", FRMCUSTOMESALE.pcs)
            LOCATION1("sumofpcs1", FRMCUSTOMESALE.pcs)
            LOCATION1("sumofpcs2", FRMCUSTOMESALE.pcs)
            LOCATION1("sumofpcs3", FRMCUSTOMESALE.pcs)
            LOCATION1("sumofpcs4", FRMCUSTOMESALE.pcs)
            LOCATION1("sumofpcs5", FRMCUSTOMESALE.pcs)
            LOCATION1("qty1", FRMCUSTOMESALE.qty)
            LOCATION1("sumofqty1", FRMCUSTOMESALE.qty)
            LOCATION1("sumofqty2", FRMCUSTOMESALE.qty)
            LOCATION1("sumofqty3", FRMCUSTOMESALE.qty)
            LOCATION1("sumofqty4", FRMCUSTOMESALE.qty)
            LOCATION1("sumofqty5", FRMCUSTOMESALE.qty)
            LOCATION1("purtype1", FRMCUSTOMESALE.purtype)
            LOCATION1("gramt1", FRMCUSTOMESALE.gramt)
            LOCATION1("bkname1", FRMCUSTOMESALE.bkname)
            LOCATION1("sumofgramt1", FRMCUSTOMESALE.gramt)
            LOCATION1("sumofgramt2", FRMCUSTOMESALE.gramt)
            LOCATION1("sumofgramt3", FRMCUSTOMESALE.gramt)
            LOCATION1("sumofgramt4", FRMCUSTOMESALE.gramt)
            LOCATION1("sumofgramt5", FRMCUSTOMESALE.gramt)
            LOCATION1("netamt1", FRMCUSTOMESALE.netamt)
            LOCATION1("sumofnetamt1", FRMCUSTOMESALE.netamt)
            LOCATION1("sumofnetamt2", FRMCUSTOMESALE.netamt)
            LOCATION1("sumofnetamt3", FRMCUSTOMESALE.netamt)
            LOCATION1("sumofnetamt4", FRMCUSTOMESALE.netamt)
            LOCATION1("sumofnetamt5", FRMCUSTOMESALE.netamt)
            LOCATION1("vrno", FRMCUSTOMESALE.vrno)
            '    LOCATION1("bkname1", FRMCUSTOMESALE.bkname)
             CrystalReportViewer1.ParameterFieldInfo = passparam()
            CrystalReportViewer1.ReportSource = RPT
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub LOCATION1(ByVal STR As String, ByVal STR2 As String)
        Try
            ' MsgBox(STR2)
            '  MsgBox(Split(STR2).ElementAt(6))
            RPT.ReportDefinition.ReportObjects(STR).Width = Split(STR2).ElementAt(2)
            RPT.ReportDefinition.ReportObjects(STR).Height = Split(STR2).ElementAt(1)
            RPT.ReportDefinition.ReportObjects(STR).Left = Split(STR2).ElementAt(5)
            RPT.ReportDefinition.ReportObjects(STR).Top = Split(STR2).ElementAt(6)

        Catch ex As Exception
            '     MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function passparam() As ParameterFields
        Try

            Dim p1 As New ParameterFields
            Dim vrnof As New ParameterField
            Dim vrnov As New ParameterDiscreteValue
            Dim bknamef As New ParameterField
            Dim bknamev As New ParameterDiscreteValue
            Dim chnof As New ParameterField
            Dim chnov As New ParameterDiscreteValue
            Dim chdtf As New ParameterField
            Dim chdtv As New ParameterDiscreteValue
            Dim billnof As New ParameterField
            Dim billnov As New ParameterDiscreteValue
            Dim billdtf As New ParameterField
            Dim billdtv As New ParameterDiscreteValue
            Dim oubnof As New ParameterField
            Dim oubnov As New ParameterDiscreteValue
            Dim namef As New ParameterField
            Dim namev As New ParameterDiscreteValue
            Dim namecrf As New ParameterField
            Dim namecrv As New ParameterDiscreteValue
            Dim purtypef As New ParameterField
            Dim purtypev As New ParameterDiscreteValue
            Dim gramtf As New ParameterField
            Dim gramtv As New ParameterDiscreteValue
            Dim netamtf As New ParameterField
            Dim netamtv As New ParameterDiscreteValue
            Dim worknof As New ParameterField
            Dim worknov As New ParameterDiscreteValue
            Dim shiptof As New ParameterField
            Dim shiptov As New ParameterDiscreteValue
            Dim pcsf As New ParameterField
            Dim pcsv As New ParameterDiscreteValue
            Dim qtyf As New ParameterField
            Dim qtyv As New ParameterDiscreteValue
            Dim grp1f As New ParameterField
            Dim grp1v As New ParameterDiscreteValue
            Dim detailf As New ParameterField
            Dim detailv As New ParameterDiscreteValue
            Dim sum1f As New ParameterField
            Dim sum1v As New ParameterDiscreteValue
            Dim grphed1f As New ParameterField
            Dim grphed1v As New ParameterDiscreteValue
            Dim grphed2f As New ParameterField
            Dim grphed2v As New ParameterDiscreteValue
            Dim sum2f As New ParameterField
            Dim sum2v As New ParameterDiscreteValue
            Dim monthf As New ParameterField
            Dim monthv As New ParameterDiscreteValue
            Dim dayf As New ParameterField
            Dim dayv As New ParameterDiscreteValue
            Dim monthsf As New ParameterField
            Dim monthsv As New ParameterDiscreteValue
            Dim daysf As New ParameterField
            Dim daysv As New ParameterDiscreteValue
            Dim finalf As New ParameterField
            Dim finalv As New ParameterDiscreteValue
            Dim boldf As New ParameterField
            Dim boldv As New ParameterDiscreteValue
            Dim fontf As New ParameterField
            Dim fontv As New ParameterDiscreteValue
            Dim groupheader1f As New ParameterField
            Dim groupheader1v As New ParameterDiscreteValue
            Dim groupheader2f As New ParameterField
            Dim groupheader2v As New ParameterDiscreteValue
            Dim summary1f As New ParameterField
            Dim summary1v As New ParameterDiscreteValue
            Dim summary2f As New ParameterField
            Dim summary2v As New ParameterDiscreteValue
            Dim month1f As New ParameterField
            Dim month1v As New ParameterDiscreteValue
            Dim month2f As New ParameterField
            Dim month2v As New ParameterDiscreteValue
            Dim final1f As New ParameterField
            Dim final1v As New ParameterDiscreteValue
            Dim date1f As New ParameterField
            Dim date1v As New ParameterDiscreteValue
            Dim date2f As New ParameterField
            Dim date2v As New ParameterDiscreteValue
        
            With FRMCUSTOMESALE
                'MsgBox(.groupheader1)
                'Now set first param
                vrnof.ParameterFieldName = "vrno"
                vrnov.Value = .vrno
                '  MsgBox(.vrno)
                bknamef.ParameterFieldName = "bkname"
                bknamev.Value = .bkname
                chnof.ParameterFieldName = "chno"
                chnov.Value = .chno
                chdtf.ParameterFieldName = "chdt"
                chdtv.Value = .chdt
                billnof.ParameterFieldName = "billno"
                billnov.Value = .billno
                billdtf.ParameterFieldName = "billdt"
                billdtv.Value = .billdt
                oubnof.ParameterFieldName = "oubno"
                oubnov.Value = .oubno
                namef.ParameterFieldName = "name"
                namev.Value = .name1
                namecrf.ParameterFieldName = "namecr"
                namecrv.Value = .namecr
                purtypef.ParameterFieldName = "purtype"
                purtypev.Value = .purtype
                gramtf.ParameterFieldName = "gramt"
                gramtv.Value = .gramt
                netamtf.ParameterFieldName = "netamt"
                netamtv.Value = .netamt
                worknof.ParameterFieldName = "workno"
                worknov.Value = .workno
                shiptof.ParameterFieldName = "shipto"
                shiptov.Value = .shipto
                pcsf.ParameterFieldName = "pcs"
                pcsv.Value = .pcs
                qtyf.ParameterFieldName = "qty"
                qtyv.Value = .qty
                grp1f.ParameterFieldName = "grp1"
                grp1v.Value = Split(.grp1).ElementAt(Split(.grp1).Count - 1)
                fontf.ParameterFieldName = "font"
                detailf.ParameterFieldName = "detail"
                If .dg2.Item(10, 9).Value.ToString = "False" Then
                    detailv.Value = "yes"
                    MsgBox("yes")
                Else
                    detailv.Value = "no"
                End If

                sum1f.ParameterFieldName = "summary"
                If .CheckedListBox3.GetItemChecked(2) = True Then
                    sum1v.Value = "yes"
                Else
                    sum1v.Value = "no"
                End If
                sum2f.ParameterFieldName = "summary2"
                If .CheckedListBox3.GetItemChecked(3) = True Then
                    sum2v.Value = "yes"
                Else
                    sum2v.Value = "no"
                End If
                monthf.ParameterFieldName = "month"
                If .CheckedListBox3.GetItemChecked(7) = True Then
                    monthv.Value = "yes"
                Else
                    monthv.Value = "no"
                End If
                dayf.ParameterFieldName = "day"
                If .CheckedListBox3.GetItemChecked(8) = True Then
                    dayv.Value = "yes"
                Else
                    dayv.Value = "no"
                End If
                grphed1f.ParameterFieldName = "groupheader"
                If .CheckedListBox3.GetItemChecked(0) = True Then
                    grphed1v.Value = "yes"
                Else
                    grphed1v.Value = "no"
                End If
                grphed2f.ParameterFieldName = "groupheader2"
                If .CheckedListBox3.GetItemChecked(1) = True Then
                    grphed2v.Value = "yes"
                Else
                    grphed2v.Value = "no"
                End If
                monthsf.ParameterFieldName = "months"
                If .CheckedListBox3.GetItemChecked(5) = True Then
                    monthsv.Value = "yes"
                Else
                    monthsv.Value = "no"
                End If
                daysf.ParameterFieldName = "days"
                If .CheckedListBox3.GetItemChecked(6) = True Then
                    daysv.Value = "yes"
                Else
                    daysv.Value = "no"
                End If
                finalf.ParameterFieldName = "finaltotal"
                If .CheckedListBox3.GetItemChecked(9) = True Then
                    finalv.Value = "yes"
                Else
                    finalv.Value = "no"
                End If
                boldf.ParameterFieldName = "bold"
                groupheader1f.ParameterFieldName = "groupheader1"
                groupheader1v.Value = .groupheader1
                groupheader2f.ParameterFieldName = "groupheader2"
                groupheader2v.Value = .groupheader2
                summary1f.ParameterFieldName = "summary"
                summary1v.Value = .summary1
                summary2f.ParameterFieldName = "summary2"
                summary2v.Value = .summary2
                month1f.ParameterFieldName = "month"
                month1v.Value = .month1
                month2f.ParameterFieldName = "months"
                month2v.Value = .month2
                date1f.ParameterFieldName = "day"
                date1v.Value = .dat1
                date2f.ParameterFieldName = "days"
                date2v.Value = .dat2
                final1f.ParameterFieldName = "final1"
                final1v.Value = .final1

                '    If .CheckedListBox4.GetItemChecked(0) = True Then
                '   boldv.Value = "yes"
                'Else
                '  boldv.Value = "no"
                ' End If

                vrnof.CurrentValues.Add(vrnov)
                bknamef.CurrentValues.Add(bknamev)
                namef.CurrentValues.Add(namev)
                namecrf.CurrentValues.Add(namecrv)
                billnof.CurrentValues.Add(billnov)
                chnof.CurrentValues.Add(chnov)
                chdtf.CurrentValues.Add(chdtv)
                oubnof.CurrentValues.Add(oubnov)
                gramtf.CurrentValues.Add(gramtv)
                netamtf.CurrentValues.Add(netamtv)
                shiptof.CurrentValues.Add(shiptov)
                worknof.CurrentValues.Add(worknov)
                billdtf.CurrentValues.Add(billdtv)
                purtypef.CurrentValues.Add(purtypev)
                pcsf.CurrentValues.Add(pcsv)
                qtyf.CurrentValues.Add(qtyv)
                grp1f.CurrentValues.Add(grp1v)
                detailf.CurrentValues.Add(detailv)
                sum1f.CurrentValues.Add(sum1v)
                sum2f.CurrentValues.Add(sum2v)
                grphed1f.CurrentValues.Add(grphed1v)
                grphed2f.CurrentValues.Add(grphed2v)
                monthf.CurrentValues.Add(monthv)
                dayf.CurrentValues.Add(dayv)
                monthsf.CurrentValues.Add(monthsv)
                daysf.CurrentValues.Add(daysv)
                finalf.CurrentValues.Add(finalv)
                boldf.CurrentValues.Add(boldv)
                fontf.CurrentValues.Add(fontv)
                groupheader1f.CurrentValues.Add(groupheader1v)
                groupheader2f.CurrentValues.Add(groupheader2v)
                month1f.CurrentValues.Add(month1v)
                month2f.CurrentValues.Add(month2v)
                date1f.CurrentValues.Add(date1v)
                date2f.CurrentValues.Add(date2v)
                final1f.CurrentValues.Add(final1v)
                summary1f.CurrentValues.Add(summary1v)
                summary2f.CurrentValues.Add(summary2v)
                p1.Add(bknamef)
                p1.Add(vrnof)
                p1.Add(chnof)
                p1.Add(chdtf)
                p1.Add(billdtf)
                p1.Add(billnof)
                p1.Add(oubnof)
                p1.Add(gramtf)
                p1.Add(netamtf)
                p1.Add(shiptof)
                p1.Add(worknof)
                p1.Add(purtypef)
                p1.Add(namef)
                p1.Add(namecrf)
                p1.Add(pcsf)
                p1.Add(qtyf)
                p1.Add(grp1f)
                p1.Add(detailf)
                p1.Add(sum1f)
                p1.Add(sum2f)
                p1.Add(grphed1f)
                p1.Add(grphed2f)
                p1.Add(monthf)
                p1.Add(dayf)
                p1.Add(monthsf)
                p1.Add(daysf)
                p1.Add(finalf)
                p1.Add(boldf)
                p1.Add(fontf)
                p1.Add(groupheader1f)
                p1.Add(groupheader2f)
                p1.Add(month1f)
                p1.Add(month2f)
                p1.Add(final1f)
                p1.Add(date1f)
                p1.Add(date2f)
                p1.Add(summary1f)
                p1.Add(summary2f)
            End With
            Return p1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class