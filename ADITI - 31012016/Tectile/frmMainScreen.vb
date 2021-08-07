Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging

Public Class frmMainScreen
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim WithEvents a As New ToolStripMenuItem
    Dim WithEvents c As New ToolStripMenuItem
    Dim WithEvents d As New ToolStripMenuItem
    Dim WithEvents f As New ToolStripMenuItem
    Dim WithEvents g As New ToolStripMenuItem
    Dim i As Integer
    Public bkname As String
    Public bankname As String
    Public sbkname As String
    Public bankrnam As String
    Public rptname As String
    Public rptsname As String
    Public report As String
    Public bankreport As String
    Public discolor As String '
    Public inwardrpt As String = ""
    Public pending As String = ""
    Public outward As String = ""
    Public process As String = ""
    Public outtype As String = ""
    Private Sub MainSchedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainSchedToolStripMenuItem.Click
        frmMHMaster.Show()
    End Sub
    Private Sub frmMainScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            cn.Close()
        Catch ex As Exception

        End Try


        '  MsgBox(MenuStrip1.Items(0).GetCurrentParent.ToString)
        Try
            i = 0
            Timer1.Enabled = True
            ' dateyf = frmcomdis.acfrom
            'dateyf = dateyf.Day & dateyf.Month & dateyf.Year
            'dateyl = frmcomdis.acto
            MsgBox(dateyf)
            '   MsgBox(dateyf.Year.ToString.Length)
            acycode = dateyf.Year.ToString.Chars(dateyf.Year.ToString.Length - 2) & dateyf.Year.ToString.Chars(dateyf.Year.ToString.Length - 1)
            acyear = dateyf.Year.ToString & "-" & dateyl.Year.ToString.Chars(dateyl.Year.ToString.Length - 2) & dateyl.Year.ToString.Chars(dateyl.Year.ToString.Length - 1)
            '    MsgBox(acyear.ToString)
            vcomp = comname
            Label1.Text = vcomp & "         " & acyear
            Label1.Text = Label1.Text.ToUpper.ToString()
            connect()
            cmd = New SqlCommand("Select * from tblAccount where Book='purchase'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                a = New System.Windows.Forms.ToolStripMenuItem
                a.Text = dr.Item(1).ToString
                AddHandler a.Click, AddressOf x
                Me.PurchaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {a})
            End While
            dr.Close()
            cmd = New SqlCommand("Select * from tblAccount where Book='Bank' or Book='CASH'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                c = New System.Windows.Forms.ToolStripMenuItem
                c.Text = dr.Item(1).ToString
                AddHandler c.Click, AddressOf y
                Me.BankCashPaymentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {c})
            End While
            dr.Close()
            cmd = New SqlCommand("Select * from tblAccount where Book='Sales'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                f = New System.Windows.Forms.ToolStripMenuItem
                f.Text = dr.Item(1).ToString
                AddHandler f.Click, AddressOf z
                Me.SalesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {f})
            End While
            dr.Close()
            cmd = New SqlCommand("Select * from tblAccount where Book='Bank' or Book='CASH'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                g = New System.Windows.Forms.ToolStripMenuItem
                g.Text = dr.Item(1).ToString
                AddHandler g.Click, AddressOf w
                Me.BankReciptToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {g})
            End While
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Button1.Text = comname
    End Sub

    Private Sub ScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScheduleToolStripMenuItem.Click
        frmSHMaster.Show()
    End Sub

    Private Sub AccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountToolStripMenuItem.Click
        frmACMaster.Hide()
        frmACMaster.Show()
        frmACMaster.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemToolStripMenuItem.Click
        frmITMaster.Show()
    End Sub

    Private Sub TransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionToolStripMenuItem.Click
    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseToolStripMenuItem.Click

    End Sub
    Private Sub x(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a.Click
        ' frmITMaster.Show()
        bkname = sender.ToString
        Form3.Show()

    End Sub
    Private Sub y(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c.Click
        ' frmITMaster.Show()
        bankname = sender.ToString
        frmBank.Show()

    End Sub
    Private Sub z(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f.Click
        ' frmITMaster.Show()
        sbkname = sender.ToString
        frmSale.Show()
    End Sub
    Private Sub w(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles g.Click
        ' frmITMaster.Show()
        bankrnam = sender.ToString
        frmBankRecipt.Show()
    End Sub

    Private Sub StateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StateToolStripMenuItem.Click
        frmStateMaster.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        frmPlaceMaster.Show()
    End Sub

    Private Sub BrokerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrokerToolStripMenuItem.Click
        frmBrokerMaster.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If i = 0 Then
        'Label1.Visible = False
        'i = 1
        'Else
        'i = 0
        'Label1.Visible = True
        'End If
    End Sub

    Private Sub OpeningBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpeningBalanceToolStripMenuItem.Click
        frmOpeningMaster.Show()
    End Sub

    Private Sub ItemOpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemOpenToolStripMenuItem.Click
        frmITBalance.Show()
    End Sub

    Private Sub ItemTypeMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemTypeMasterToolStripMenuItem.Click
        frmItemTypeMaster.Show()
    End Sub

    Private Sub UnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnitToolStripMenuItem.Click
        frmUnitMaster.Show()
    End Sub

    Private Sub BankReciptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankReciptToolStripMenuItem.Click
    End Sub
    Private Sub ZOOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZOOMToolStripMenuItem.Click
      
    End Sub

    Private Sub JournalVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalVoucherToolStripMenuItem.Click
        frmJour.Show()
    End Sub

    Private Sub GroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupToolStripMenuItem.Click
        frmGroupMaster.Show()
    End Sub

    Private Sub SalesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem1.Click

    End Sub

    Private Sub BankCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankCToolStripMenuItem.Click

    End Sub

    Private Sub RegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MonthelyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rptname = "Register Summary"

    End Sub

    Private Sub RegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rptname = "Register"


    End Sub

    Private Sub MonthlyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rptname = "Monthly"

    End Sub

    Private Sub RegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rptsname = "Register"

    End Sub

    Private Sub SummaryRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rptsname = "Register Summary"

    End Sub

    Private Sub MonthlyToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rptsname = "Monthly"

    End Sub

    Private Sub HeaderReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailToolStripMenuItem.Click
        report = "Register Detail"
        frmpurrpt.Show()

    End Sub

    Private Sub MonthlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem.Click
        report = "Register Monthly"
        frmpurrpt.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem.Click
        report = "Register Summary"
        frmpurrpt.Show()

    End Sub

    Private Sub DetailToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailToolStripMenuItem1.Click
        report = "Group Detail"
        frmpurrpt.Show()
    End Sub

    Private Sub BillWiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillWiseToolStripMenuItem.Click
        report = "Group Bill Wise"
        frmpurrpt.Show()
    End Sub

    Private Sub MonthlyToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem1.Click
        report = "Group Monthly"
        frmpurrpt.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem1.Click
        report = "Group Summary"
        frmpurrpt.Show()
    End Sub

    Private Sub DetailToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailToolStripMenuItem2.Click
        report = "Party Detail"
        frmpurrpt.Show()
    End Sub

    Private Sub MonthlyToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem3.Click
        report = "Party Monthly"
        frmpurrpt.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem2.Click
        report = "Party Summary"
        frmpurrpt.Show()
    End Sub

    Private Sub BillWiseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillWiseToolStripMenuItem1.Click
        report = "Party Bill Wise"
        frmpurrpt.Show()
    End Sub

    Private Sub DetailToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailToolStripMenuItem3.Click
        report = "Item Detail"
        frmpurrpt.Show()
    End Sub

    Private Sub MonthlyToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem4.Click
        report = "Item Monthly"
        frmpurrpt.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem3.Click
        report = "Item Summary"
        frmpurrpt.Show()
    End Sub

    Private Sub DetailToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailToolStripMenuItem4.Click
        report = "Group Party Detail"
        frmpurrpt.Show()
    End Sub

    Private Sub BillWiseToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillWiseToolStripMenuItem2.Click
        report = "Group Party Bill Wise"
        frmpurrpt.Show()
    End Sub

    Private Sub MonthlyToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem5.Click
        report = "Group Party Monthly"
        frmpurrpt.Show()

    End Sub

    Private Sub SummaryToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem4.Click
        report = "Group Party Summary"
        frmpurrpt.Show()

    End Sub

    Private Sub DetailToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailToolStripMenuItem5.Click
        report = "Party Item Detail"
        frmpurrpt.Show()

    End Sub

    Private Sub MonthlyToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem6.Click
        report = "Party Item Monthly"
        frmpurrpt.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem5.Click
        report = "Party Item Summary"
        frmpurrpt.Show()
    End Sub

    Private Sub DetailToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailToolStripMenuItem6.Click
        report = "SRegister Detail"
        frmpurrpt.Show()
    End Sub

    Private Sub MonthlyToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem2.Click
        report = "SRegister Monthly"
        frmpurrpt.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem6.Click
        report = "SRegister Summary"
        frmpurrpt.Show()

    End Sub

    Private Sub DetailToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailToolStripMenuItem7.Click
        report = "SGroup Detail"
        frmpurrpt.Show()

    End Sub

    Private Sub BillWiseToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillWiseToolStripMenuItem3.Click
        report = "SGroup Bill Wise"
        frmpurrpt.Show()

    End Sub

    Private Sub MonthlyToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem7.Click
        report = "SGroup Monthly"
        frmpurrpt.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem7.Click
        report = "SGroup Summary"
        frmpurrpt.Show()
    End Sub

    Private Sub DetailToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailToolStripMenuItem8.Click
        report = "SParty Detail"
        frmpurrpt.Show()
    End Sub

    Private Sub BillWiseToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillWiseToolStripMenuItem4.Click
        report = "SParty Bill Wise"
        frmpurrpt.Show()
    End Sub

    Private Sub MonthlyToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem8.Click
        report = "SParty Monthly"
        frmpurrpt.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem8.Click
        report = "SParty Summary"
        frmpurrpt.Show()
    End Sub

    Private Sub DetailToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailToolStripMenuItem9.Click
        report = "SItem Detail"
        frmpurrpt.Show()
    End Sub

    Private Sub MonthlyToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem9.Click
        report = "SItem Monthly"
        frmpurrpt.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem9.Click
        report = "SItem Summary"
        frmpurrpt.Show()
    End Sub

    Private Sub DetailToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailToolStripMenuItem10.Click
        report = "SGroup Party Detail"
        frmpurrpt.Show()
    End Sub

    Private Sub BillWiseToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillWiseToolStripMenuItem5.Click
        report = "SGroup Party Bill Wise"
        frmpurrpt.Show()
    End Sub

    Private Sub MonthlyToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem10.Click
        report = "SGroup Party Monthly"
        frmpurrpt.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem10.Click
        report = "SGroup Party Summary"
        frmpurrpt.Show()
    End Sub

    Private Sub DetailToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailToolStripMenuItem11.Click
        report = "SParty Item Detail"
        frmpurrpt.Show()
    End Sub

    Private Sub MonthlyToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem11.Click
        report = "SParty Item Monthly"
        frmpurrpt.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem11.Click
        report = "SParty Item Summary"
        frmpurrpt.Show()
    End Sub

    Private Sub DailyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyToolStripMenuItem.Click
        bankreport = "Entry to Entry"
        frmbankselection.Show()
    End Sub

    Private Sub EntryToEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntryToEntryToolStripMenuItem.Click
        bankreport = "Daily"
        frmbankselection.Show()
    End Sub

    Private Sub MonthlyToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem12.Click
        bankreport = "Monthly"
        frmbankselection.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem12.Click
        bankreport = "Summary"
        frmbankselection.Show()
    End Sub

    Private Sub LedgerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'disledg.Show()
    End Sub

    Private Sub TrialBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrialBalanceToolStripMenuItem.Click

    End Sub

    Private Sub SimpleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TaxSetupToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxSetupToolStripMenuItem1.Click
        frmtaxmst.Show()
    End Sub

    Private Sub PreviousYearBillEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousYearBillEntryToolStripMenuItem.Click
        frmOub.Show()
    End Sub

    Private Sub BillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillToolStripMenuItem.Click
        'frmbill.Show()
        frmbillfilter.Show()
    End Sub

    Private Sub StockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem.Click
        frmStocksum.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' frmcomdis.Close()
        frmcomdis.Show()
    End Sub



    Private Sub StockSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockSummaryToolStripMenuItem.Click
        frmSelecteditemLedg.Show()
    End Sub

    Private Sub StockLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockLedgerToolStripMenuItem.Click
        frmStockledg.Show()
    End Sub

    Private Sub StockStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockStatementToolStripMenuItem.Click
        frmStocksum.Show()
    End Sub

    Private Sub NormaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NormaToolStripMenuItem.Click
        frmtb.Show()
    End Sub

    Private Sub TtypeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TtypeToolStripMenuItem1.Click
        frmttypetbvb.Show()
    End Sub

    Private Sub TradingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TradingToolStripMenuItem.Click
        frmtradingdis.Show()
    End Sub

    Private Sub ProfitLossToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfitLossToolStripMenuItem.Click
        frmP2.Show()
    End Sub

    Private Sub OLDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OLDToolStripMenuItem.Click
        zoomfrom = "Main"
        frmzoom2.Show()
    End Sub

    Private Sub NEWToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEWToolStripMenuItem.Click
        frmnewzoom2.Close()
        frmnewzoom1.Close()
        frmnewZoom3.Close()
        frmnewzoom4.Close()
        frmnewzoom2.a = ""
        frmnewZoom3.b = ""
        frmnewzoom4.month = 0
        frmnewzoom1.Show()
    End Sub

    Private Sub BrowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowToolStripMenuItem.Click
        frmbrow.Show()
    End Sub

    Private Sub AutoJVMSTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoJVMSTToolStripMenuItem.Click
        frmAutojvmst.Show()
    End Sub

    Private Sub MasterFormsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterFormsToolStripMenuItem.Click
        frmdisplaystyle.Show()
    End Sub

    Private Sub TransactionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionToolStripMenuItem1.Click
        frmtrndis.Show()
    End Sub

    Private Sub NEWBLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEWBLToolStripMenuItem.Click
        frmnewmainscreen.Show()
    End Sub

    Private Sub LotEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LotEntryToolStripMenuItem.Click
        'frmlotr.Show()
        frmLotNew.Show()

    End Sub

    Private Sub MstToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MstToolStripMenuItem.Click
        frmMst.Show()
    End Sub

    Private Sub BalanceSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceSheetToolStripMenuItem.Click
        frmBSdis.Show()
    End Sub

    Private Sub DetailToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        disledg.Show()
    End Sub

    Private Sub PrticularToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrticularToolStripMenuItem.Click
        disledg.Show()
    End Sub

    Private Sub TransactionSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionSettingsToolStripMenuItem.Click
        frmsetup.Show()
    End Sub
    Private Sub PrintBarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBarcodeToolStripMenuItem.Click
        'frmprintbarcode.Show()
        frmselectitem.Show()
    End Sub

    Private Sub ReciptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReciptToolStripMenuItem.Click
        outtype = "SALE"
        FRMOUTSELE.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
       
    End Sub

    Private Sub MailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MailToolStripMenuItem.Click
        mailform.Show()
    End Sub

    Private Sub SaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleToolStripMenuItem.Click
        frmVatSelection.Show()
    End Sub

    Private Sub TaxTypeSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxTypeSetupToolStripMenuItem.Click
        FRMTAXSET2.Show()
    End Sub

    Private Sub RedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub DispatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DispatchToolStripMenuItem.Click
        'FRMDISPATCH.Show()
        'frmbilldis.Show()
        frmdispatchnew.Show()

    End Sub

    Private Sub ProcessToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessToolStripMenuItem.Click
        frmProcess.Show()
    End Sub

    Private Sub StyleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StyleToolStripMenuItem.Click
        frmstyle.Show()
    End Sub

    Private Sub MarkaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkaToolStripMenuItem.Click
        frmMarko.Show()
    End Sub

    Private Sub JobCardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobCardToolStripMenuItem.Click
        frmjobcarddis.FROMWHERE = "LOTR"
        FRMJOBCARDSELE.Show()
        'frmjobcarddis.Show()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        'frmbilldis.Show()
        frmupdate.Show()
        '  update1(ProgressBar1)
    End Sub

    Private Sub ChalanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChalanToolStripMenuItem.Click
        frmlotselection.Show()
        'frmchlnprint.Show()
    End Sub

    Private Sub LotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LotToolStripMenuItem.Click
        inwardrpt = "Lot"
        frmInwardsele.Show()
    End Sub

    Private Sub PartyToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyToolStripMenuItem2.Click
        inwardrpt = "Group"
        frmInwardsele.Show()
    End Sub

    Private Sub PartyItemToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyItemToolStripMenuItem1.Click
        inwardrpt = "Group + Party"
        frmInwardsele.Show()
    End Sub

    Private Sub GroupItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupItemToolStripMenuItem.Click
        inwardrpt = "Group + Item"
        frmInwardsele.Show()
    End Sub

    Private Sub PartyToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyToolStripMenuItem3.Click
        inwardrpt = "Party"
        frmInwardsele.Show()
    End Sub

    Private Sub PartyItemToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyItemToolStripMenuItem2.Click
        inwardrpt = "Party + Item"
        frmInwardsele.Show()
    End Sub

    Private Sub ItemToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemToolStripMenuItem3.Click
        inwardrpt = "Item"
        frmInwardsele.Show()
    End Sub

    Private Sub ItemGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemGroupToolStripMenuItem.Click
        inwardrpt = "Item + Group"
        frmInwardsele.Show()
    End Sub

    Private Sub ItePartyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItePartyToolStripMenuItem.Click
        inwardrpt = "Item + Party"
        frmInwardsele.Show()
    End Sub

    Private Sub GroupPartyItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPartyItemToolStripMenuItem.Click
        inwardrpt = "Group + Party + Item"
        frmInwardsele.Show()
    End Sub

    Private Sub PendingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendingToolStripMenuItem.Click
        '  frmpenlotsele.Show()
    End Sub

    Private Sub LotToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LotToolStripMenuItem1.Click
        pending = "Lot"
        frmpenlotsele.Show()
    End Sub

    Private Sub GroupToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupToolStripMenuItem4.Click
        pending = "Group"
        frmpenlotsele.Show()
    End Sub

    Private Sub GroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroToolStripMenuItem.Click
        pending = "Group + Party"
        frmpenlotsele.Show()
    End Sub

    Private Sub GroupItemToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupItemToolStripMenuItem1.Click
        pending = "Group + Item"
        frmpenlotsele.Show()
    End Sub

    Private Sub PartyToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyToolStripMenuItem4.Click
        pending = "Party"
        frmpenlotsele.Show()
    End Sub

    Private Sub PartyItemToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyItemToolStripMenuItem3.Click
        pending = "Party + Item"
        frmpenlotsele.Show()
    End Sub

    Private Sub ItemToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemToolStripMenuItem4.Click
        pending = "Item"
        frmpenlotsele.Show()
    End Sub

    Private Sub ItemToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemToolStripMenuItem5.Click
        pending = "Item + Group"
        frmpenlotsele.Show()
    End Sub

    Private Sub ItemPartyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemPartyToolStripMenuItem.Click
        pending = "Item + Party"
        frmpenlotsele.Show()
    End Sub

    Private Sub GroupPartyItemToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPartyItemToolStripMenuItem1.Click
        pending = "Group + Party + Item"
        frmpenlotsele.Show()
    End Sub

    Private Sub LotToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LotToolStripMenuItem2.Click
        outward = "Lot"
        frmoutward.Show()

    End Sub

    Private Sub GroupToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupToolStripMenuItem5.Click
        outward = "Group"
        frmoutward.Show()
    End Sub

    Private Sub GroupPartyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPartyToolStripMenuItem1.Click
        outward = "Group + Party"
        frmoutward.Show()
    End Sub

    Private Sub GroupItemToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupItemToolStripMenuItem2.Click
        outward = "Group + Item"
        frmoutward.Show()
    End Sub

    Private Sub PartyToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyToolStripMenuItem5.Click
        outward = "Party"
        frmoutward.Show()
    End Sub

    Private Sub PartyItemToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyItemToolStripMenuItem4.Click
        outward = "Party + Item"
        frmoutward.Show()
    End Sub

    Private Sub ItemToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemToolStripMenuItem6.Click
        outward = "Item"
        frmoutward.Show()
    End Sub

    Private Sub ItemGroupToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemGroupToolStripMenuItem1.Click
        outward = "Item + Group"
        frmoutward.Show()
    End Sub

    Private Sub ItemPartyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemPartyToolStripMenuItem1.Click
        outward = "Item + Party"
        frmoutward.Show()
    End Sub

    Private Sub GroupPartyItemToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPartyItemToolStripMenuItem2.Click
        outward = "Group + Party + Item"
        frmoutward.Show()
    End Sub
    Private Sub ProcessMonthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessMonthToolStripMenuItem.Click
        process = "Process Month"
        frmprocesssele.Show()
    End Sub
    Private Sub MonthProcessToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthProcessToolStripMenuItem.Click
        process = "Month Process"
        frmprocesssele.Show()
    End Sub
    Private Sub It2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles It2ToolStripMenuItem.Click
        frmit2.Show()
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
    End Sub
    Private Sub PackingItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PackingItemToolStripMenuItem.Click
        frmitEM3.Show()
    End Sub
    Private Sub AccountTransferToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub AccountMeargeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountMeargeToolStripMenuItem.Click
        frmAccountMearge.Show()
    End Sub
    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmbackup.Show()
    End Sub

    Private Sub ITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITToolStripMenuItem.Click
        frmitemMearge.Show()
    End Sub

    Private Sub PurchaseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseToolStripMenuItem1.Click
        frmopeningfilter.Show()
    End Sub

    Private Sub SelectFieldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectFieldToolStripMenuItem.Click
        frmselectfield.Show()
    End Sub

    Private Sub MainScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainScheduleToolStripMenuItem.Click
        frmprintmh.Show()
    End Sub

    Private Sub ScheduleToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScheduleToolStripMenuItem2.Click
        frmprintsh.Show()
    End Sub

    Private Sub AccountToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountToolStripMenuItem1.Click
        frmprintaccount.Show()
    End Sub

    Private Sub ItemToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemToolStripMenuItem7.Click
        FRMPRINTITEMForm2.Show()
    End Sub

    Private Sub StateToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PlaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlaceToolStripMenuItem.Click
        frmprintplace.Show()
    End Sub

    Private Sub ItemTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemTypeToolStripMenuItem.Click
        FRMPRINTITEMTYPE.Show()
    End Sub

    Private Sub UnitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupToolStripMenuItem6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupToolStripMenuItem6.Click
        FRMPRINTGROUP.Show()
    End Sub

    Private Sub AdvanceSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceSearchToolStripMenuItem.Click
        frmadvsearch.Show()
    End Sub

    Private Sub ManualPostingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualPostingToolStripMenuItem.Click
        frmmanualposting.Show()
    End Sub

    Private Sub LostVrNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LostVrNoToolStripMenuItem.Click
        frmlostvrno.Show()
    End Sub

    Private Sub ChalanToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChalanToolStripMenuItem1.Click
        FRMChalan.Show()
    End Sub

    Private Sub ChalanToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChalanToolStripMenuItem2.Click
        FRMCHALLANFILTER.Show()
    End Sub

    Private Sub BankReconcilationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankReconcilationToolStripMenuItem.Click
        frmbankre.show()

    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        outtype = "PURCHASE"
        FRMOUTSELE.Show()
    End Sub

    Private Sub MastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MastersToolStripMenuItem.Click

    End Sub

    Private Sub ADMINTOOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADMINTOOLToolStripMenuItem.Click
        Dim A As New frmadmin
        A.Show()
    End Sub

    Private Sub CUSTOMEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUSTOMEToolStripMenuItem.Click
        FRMCUSTOMESALE.Show()
    End Sub

    Private Sub SaleListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleListToolStripMenuItem.Click
        frmbilldis.Show()
    End Sub

    Private Sub RateMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RateMasterToolStripMenuItem.Click
        frmRateMst.Show()
    End Sub

    Private Sub TransferToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferToolStripMenuItem.Click
        ' MsgBox("het")
        frmTransfer.Show()
    End Sub

    Private Sub BillToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillToolStripMenuItem1.Click
        ' frmlotbill.Show()
        frmlotbillselection.Show()
    End Sub

    Private Sub SendSMSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendSMSToolStripMenuItem.Click
        frmSendSMS.Show()
    End Sub

    Private Sub LotCheckToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotCheckToolStripMenuItem.Click
        LotCheck.Show()
    End Sub

    Private Sub LotEntryDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotEntryDetailToolStripMenuItem.Click
        frmlotr.Show()
    End Sub

    Private Sub DispatchDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DispatchDetailToolStripMenuItem.Click
        FRMDISPATCH.Show()
    End Sub

    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click

    End Sub

    Private Sub ClearDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearDataToolStripMenuItem.Click
        frmClearAll.Show()
    End Sub

    Private Sub ShadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShadeToolStripMenuItem.Click
        frmShade.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmlotr.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FRMDISPATCH.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmACMaster.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        frmITMaster.Show()
    End Sub

    Private Sub DesignToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesignToolStripMenuItem.Click
        frmDesgMst.Show()
    End Sub

    Private Sub MachineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MachineToolStripMenuItem.Click
        frmMachineMaster.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        frmratemasterselection.Show()
    End Sub

    Private Sub RegisterToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles RegisterToolStripMenuItem1.Click

    End Sub

    Private Sub CustomeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CustomeToolStripMenuItem1.Click
        'frmCustomeOutward.Show()
        frmOutwordCustomeSelection.Show()
    End Sub

    Private Sub VerifyDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerifyDataToolStripMenuItem.Click
        frmVerify.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        frmRateMst.Show()
    End Sub
End Class
