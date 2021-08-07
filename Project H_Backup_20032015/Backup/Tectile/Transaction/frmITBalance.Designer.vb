<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmITBalance
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.butAdd = New System.Windows.Forms.Button
        Me.butFind = New System.Windows.Forms.Button
        Me.txtUnit = New System.Windows.Forms.TextBox
        Me.txtRate = New System.Windows.Forms.TextBox
        Me.butExit = New System.Windows.Forms.Button
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.txtItcode = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtItName = New System.Windows.Forms.TextBox
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.txtVrNo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.txtDate = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.butEdit = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dateyl1 = New System.Windows.Forms.Label
        Me.companyname1 = New System.Windows.Forms.Label
        Me.dateyf1 = New System.Windows.Forms.Label
        Me.butDelete = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.butPrint = New System.Windows.Forms.Button
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'butAdd
        '
        Me.butAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.butAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butAdd.ForeColor = System.Drawing.Color.White
        Me.butAdd.Location = New System.Drawing.Point(327, 662)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(78, 32)
        Me.butAdd.TabIndex = 47
        Me.butAdd.Text = "&ADD"
        Me.butAdd.UseVisualStyleBackColor = False
        '
        'butFind
        '
        Me.butFind.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.butFind.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butFind.ForeColor = System.Drawing.Color.Black
        Me.butFind.Location = New System.Drawing.Point(515, 662)
        Me.butFind.Name = "butFind"
        Me.butFind.Size = New System.Drawing.Size(78, 32)
        Me.butFind.TabIndex = 45
        Me.butFind.Text = "&FIND"
        Me.butFind.UseVisualStyleBackColor = False
        '
        'txtUnit
        '
        Me.txtUnit.Location = New System.Drawing.Point(120, 166)
        Me.txtUnit.MaxLength = 6
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(123, 20)
        Me.txtUnit.TabIndex = 29
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(120, 141)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(123, 20)
        Me.txtRate.TabIndex = 28
        Me.txtRate.Text = "0.00"
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'butExit
        '
        Me.butExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.butExit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butExit.ForeColor = System.Drawing.Color.White
        Me.butExit.Location = New System.Drawing.Point(793, 662)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(78, 32)
        Me.butExit.TabIndex = 48
        Me.butExit.Text = "EXIT"
        Me.butExit.UseVisualStyleBackColor = False
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(120, 116)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(123, 20)
        Me.txtQty.TabIndex = 27
        Me.txtQty.Text = "0.000"
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtItcode
        '
        Me.txtItcode.Enabled = False
        Me.txtItcode.Location = New System.Drawing.Point(413, 90)
        Me.txtItcode.Name = "txtItcode"
        Me.txtItcode.ReadOnly = True
        Me.txtItcode.Size = New System.Drawing.Size(76, 20)
        Me.txtItcode.TabIndex = 40
        '
        'Timer1
        '
        '
        'txtItName
        '
        Me.txtItName.Location = New System.Drawing.Point(120, 91)
        Me.txtItName.MaxLength = 200
        Me.txtItName.Name = "txtItName"
        Me.txtItName.Size = New System.Drawing.Size(277, 20)
        Me.txtItName.TabIndex = 26
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DG1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Indigo
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DG1.Location = New System.Drawing.Point(21, 64)
        Me.DG1.MultiSelect = False
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.RowHeadersVisible = False
        Me.DG1.Size = New System.Drawing.Size(502, 420)
        Me.DG1.TabIndex = 49
        '
        'txtVrNo
        '
        Me.txtVrNo.Location = New System.Drawing.Point(120, 41)
        Me.txtVrNo.Name = "txtVrNo"
        Me.txtVrNo.ReadOnly = True
        Me.txtVrNo.Size = New System.Drawing.Size(112, 20)
        Me.txtVrNo.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label6.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label6.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label6.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label6.Location = New System.Drawing.Point(15, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 15)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Qty"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "titlefont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "Titlecolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label4.Font = Global.Tectile.My.MySettings.Default.titlefont
        Me.Label4.ForeColor = Global.Tectile.My.MySettings.Default.Titlecolor
        Me.Label4.Location = New System.Drawing.Point(487, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 24)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Item Opening" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = Global.Tectile.My.MySettings.Default.tranbkcolor
        Me.GroupBox1.Controls.Add(Me.TextBox9)
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Controls.Add(Me.txtDate)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtUnit)
        Me.GroupBox1.Controls.Add(Me.txtRate)
        Me.GroupBox1.Controls.Add(Me.txtQty)
        Me.GroupBox1.Controls.Add(Me.txtItcode)
        Me.GroupBox1.Controls.Add(Me.txtItName)
        Me.GroupBox1.Controls.Add(Me.txtVrNo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tectile.My.MySettings.Default, "tranbkcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(589, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(495, 420)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(120, 220)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(183, 20)
        Me.TextBox9.TabIndex = 48
        Me.TextBox9.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(14, 286)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(140, 121)
        Me.ListBox1.TabIndex = 47
        Me.ListBox1.Visible = False
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(120, 66)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(112, 20)
        Me.txtDate.TabIndex = 46
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label10.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label10.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label10.Location = New System.Drawing.Point(15, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 15)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label9.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label9.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label9.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label9.Location = New System.Drawing.Point(15, 195)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 15)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Remark"
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(120, 194)
        Me.txtRemark.MaxLength = 20
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(277, 20)
        Me.txtRemark.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label7.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label7.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label7.Location = New System.Drawing.Point(15, 167)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 15)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Unit"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label8.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label8.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label8.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label8.Location = New System.Drawing.Point(15, 142)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 15)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Rate"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(166, 356)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 33)
        Me.Label2.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label5.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label5.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label5.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label5.Location = New System.Drawing.Point(305, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Label5"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label1.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label1.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label1.Location = New System.Drawing.Point(15, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Item"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label3.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label3.Location = New System.Drawing.Point(15, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "VR No"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DarkRed
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(172, 274)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(86, 40)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "SAVE"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'butEdit
        '
        Me.butEdit.BackColor = System.Drawing.Color.Lime
        Me.butEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butEdit.ForeColor = System.Drawing.Color.White
        Me.butEdit.Location = New System.Drawing.Point(420, 662)
        Me.butEdit.Name = "butEdit"
        Me.butEdit.Size = New System.Drawing.Size(78, 32)
        Me.butEdit.TabIndex = 46
        Me.butEdit.Text = "&EDIT"
        Me.butEdit.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = Global.Tectile.My.MySettings.Default.Comcolor
        Me.Panel1.Controls.Add(Me.dateyl1)
        Me.Panel1.Controls.Add(Me.companyname1)
        Me.Panel1.Controls.Add(Me.dateyf1)
        Me.Panel1.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tectile.My.MySettings.Default, "Comcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1109, 28)
        Me.Panel1.TabIndex = 50
        '
        'dateyl1
        '
        Me.dateyl1.AutoSize = True
        Me.dateyl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateyl1.ForeColor = System.Drawing.Color.White
        Me.dateyl1.Location = New System.Drawing.Point(1008, 8)
        Me.dateyl1.Name = "dateyl1"
        Me.dateyl1.Size = New System.Drawing.Size(52, 13)
        Me.dateyl1.TabIndex = 2
        Me.dateyl1.Text = "Label10"
        '
        'companyname1
        '
        Me.companyname1.AutoSize = True
        Me.companyname1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyname1.ForeColor = System.Drawing.Color.White
        Me.companyname1.Location = New System.Drawing.Point(532, 8)
        Me.companyname1.Name = "companyname1"
        Me.companyname1.Size = New System.Drawing.Size(45, 13)
        Me.companyname1.TabIndex = 1
        Me.companyname1.Text = "Label9"
        '
        'dateyf1
        '
        Me.dateyf1.AutoSize = True
        Me.dateyf1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateyf1.ForeColor = System.Drawing.Color.White
        Me.dateyf1.Location = New System.Drawing.Point(8, 8)
        Me.dateyf1.Name = "dateyf1"
        Me.dateyf1.Size = New System.Drawing.Size(45, 13)
        Me.dateyf1.TabIndex = 0
        Me.dateyf1.Text = "Label8"
        '
        'butDelete
        '
        Me.butDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.butDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butDelete.ForeColor = System.Drawing.Color.White
        Me.butDelete.Location = New System.Drawing.Point(610, 662)
        Me.butDelete.Name = "butDelete"
        Me.butDelete.Size = New System.Drawing.Size(78, 32)
        Me.butDelete.TabIndex = 51
        Me.butDelete.Text = "&DELETE"
        Me.butDelete.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TextBox10)
        Me.GroupBox2.Location = New System.Drawing.Point(435, 501)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(357, 109)
        Me.GroupBox2.TabIndex = 54
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FIND"
        Me.GroupBox2.Visible = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(187, 45)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(78, 32)
        Me.Button4.TabIndex = 55
        Me.Button4.Text = "&CANCEL"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(103, 45)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(78, 32)
        Me.Button2.TabIndex = 54
        Me.Button2.Text = "&OK"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label11.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label11.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label11.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label11.Location = New System.Drawing.Point(6, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 15)
        Me.Label11.TabIndex = 54
        Me.Label11.Text = "WORD"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(60, 19)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(288, 20)
        Me.TextBox10.TabIndex = 54
        '
        'butPrint
        '
        Me.butPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.butPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butPrint.ForeColor = System.Drawing.Color.White
        Me.butPrint.Location = New System.Drawing.Point(705, 662)
        Me.butPrint.Name = "butPrint"
        Me.butPrint.Size = New System.Drawing.Size(78, 32)
        Me.butPrint.TabIndex = 55
        Me.butPrint.Text = "&PRINT"
        Me.butPrint.UseVisualStyleBackColor = False
        '
        'frmITBalance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.Tectile.My.MySettings.Default.tranbkcolor
        Me.ClientSize = New System.Drawing.Size(1111, 717)
        Me.Controls.Add(Me.butPrint)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.butDelete)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.butAdd)
        Me.Controls.Add(Me.butFind)
        Me.Controls.Add(Me.butExit)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.butEdit)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tectile.My.MySettings.Default, "tranbkcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.KeyPreview = True
        Me.Name = "frmITBalance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmITBalance"
        Me.TopMost = True
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents butFind As System.Windows.Forms.Button
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents butExit As System.Windows.Forms.Button
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents txtItcode As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtItName As System.Windows.Forms.TextBox
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtVrNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents butEdit As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dateyl1 As System.Windows.Forms.Label
    Friend WithEvents companyname1 As System.Windows.Forms.Label
    Friend WithEvents dateyf1 As System.Windows.Forms.Label
    Friend WithEvents butDelete As System.Windows.Forms.Button
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents butPrint As System.Windows.Forms.Button
End Class
