﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankRec
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.butOK = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DG1 = New System.Windows.Forms.DataGridView()
        Me.dgacm = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dateyl1 = New System.Windows.Forms.Label()
        Me.companyname1 = New System.Windows.Forms.Label()
        Me.dateyf1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.butAdd = New System.Windows.Forms.Button()
        Me.butEdit = New System.Windows.Forms.Button()
        Me.butFind = New System.Windows.Forms.Button()
        Me.butSave = New System.Windows.Forms.Button()
        Me.butDelete = New System.Windows.Forms.Button()
        Me.butExit = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtAcName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVrNosec = New System.Windows.Forms.TextBox()
        Me.txtVrnofirst = New System.Windows.Forms.TextBox()
        Me.maskdate = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRefBank = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAccode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtChqno = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.txtBkName = New System.Windows.Forms.TextBox()
        Me.txtBKCode = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtJvvrno = New System.Windows.Forms.TextBox()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgacm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteCustomSource.AddRange(New String() {"TRUE", "FALSE"})
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"DR", "CR"})
        Me.ComboBox1.Location = New System.Drawing.Point(496, 166)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(85, 21)
        Me.ComboBox1.TabIndex = 56
        '
        'txtFind
        '
        Me.txtFind.Location = New System.Drawing.Point(53, 24)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(261, 20)
        Me.txtFind.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Search"
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(93, 52)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(75, 23)
        Me.butOK.TabIndex = 0
        Me.butOK.Text = "OK"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label14.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label14.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label14.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label14.Location = New System.Drawing.Point(432, 169)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 15)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "DR/CR"
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Location = New System.Drawing.Point(6, 19)
        Me.DG1.MultiSelect = False
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(363, 473)
        Me.DG1.TabIndex = 48
        '
        'dgacm
        '
        Me.dgacm.AllowUserToAddRows = False
        Me.dgacm.AllowUserToDeleteRows = False
        Me.dgacm.AllowUserToOrderColumns = True
        Me.dgacm.AllowUserToResizeColumns = False
        Me.dgacm.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgacm.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Indigo
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgacm.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgacm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgacm.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgacm.Location = New System.Drawing.Point(390, 169)
        Me.dgacm.MultiSelect = False
        Me.dgacm.Name = "dgacm"
        Me.dgacm.ReadOnly = True
        Me.dgacm.RowHeadersVisible = False
        Me.dgacm.Size = New System.Drawing.Size(778, 242)
        Me.dgacm.TabIndex = 54
        Me.dgacm.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Purple
        Me.Panel1.Controls.Add(Me.dateyl1)
        Me.Panel1.Controls.Add(Me.companyname1)
        Me.Panel1.Controls.Add(Me.dateyf1)
        Me.Panel1.Location = New System.Drawing.Point(4, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1103, 28)
        Me.Panel1.TabIndex = 61
        '
        'dateyl1
        '
        Me.dateyl1.AutoSize = True
        Me.dateyl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateyl1.ForeColor = System.Drawing.Color.White
        Me.dateyl1.Location = New System.Drawing.Point(1019, 8)
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
        Me.companyname1.Location = New System.Drawing.Point(494, 8)
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label11.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label11.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label11.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label11.Location = New System.Drawing.Point(984, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 15)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "VrNo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFind)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.butOK)
        Me.GroupBox2.Location = New System.Drawing.Point(666, 417)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 81)
        Me.GroupBox2.TabIndex = 57
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FIND"
        Me.GroupBox2.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.Panel2.Controls.Add(Me.butAdd)
        Me.Panel2.Controls.Add(Me.butEdit)
        Me.Panel2.Controls.Add(Me.butFind)
        Me.Panel2.Controls.Add(Me.butSave)
        Me.Panel2.Controls.Add(Me.butDelete)
        Me.Panel2.Controls.Add(Me.butExit)
        Me.Panel2.Location = New System.Drawing.Point(16, 600)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1059, 46)
        Me.Panel2.TabIndex = 64
        '
        'butAdd
        '
        Me.butAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.butAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.butAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butAdd.Image = Global.Tectile.My.Resources.Resources.ADD
        Me.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butAdd.Location = New System.Drawing.Point(34, 3)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(108, 34)
        Me.butAdd.TabIndex = 43
        Me.butAdd.Text = "&ADD"
        Me.butAdd.UseVisualStyleBackColor = False
        '
        'butEdit
        '
        Me.butEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.butEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butEdit.Image = Global.Tectile.My.Resources.Resources.edit
        Me.butEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butEdit.Location = New System.Drawing.Point(206, 3)
        Me.butEdit.Name = "butEdit"
        Me.butEdit.Size = New System.Drawing.Size(108, 34)
        Me.butEdit.TabIndex = 44
        Me.butEdit.Text = "&EDIT"
        Me.butEdit.UseVisualStyleBackColor = False
        '
        'butFind
        '
        Me.butFind.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.butFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butFind.Image = Global.Tectile.My.Resources.Resources.Find
        Me.butFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butFind.Location = New System.Drawing.Point(378, 3)
        Me.butFind.Name = "butFind"
        Me.butFind.Size = New System.Drawing.Size(108, 34)
        Me.butFind.TabIndex = 45
        Me.butFind.Text = "&FIND"
        Me.butFind.UseVisualStyleBackColor = False
        '
        'butSave
        '
        Me.butSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.butSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSave.Image = Global.Tectile.My.Resources.Resources.SAVE
        Me.butSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butSave.Location = New System.Drawing.Point(550, 3)
        Me.butSave.Name = "butSave"
        Me.butSave.Size = New System.Drawing.Size(108, 34)
        Me.butSave.TabIndex = 48
        Me.butSave.Text = "SAVE"
        Me.butSave.UseVisualStyleBackColor = False
        '
        'butDelete
        '
        Me.butDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.butDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butDelete.Image = Global.Tectile.My.Resources.Resources.DELETE
        Me.butDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butDelete.Location = New System.Drawing.Point(722, 3)
        Me.butDelete.Name = "butDelete"
        Me.butDelete.Size = New System.Drawing.Size(108, 34)
        Me.butDelete.TabIndex = 49
        Me.butDelete.Text = "&DELETE"
        Me.butDelete.UseVisualStyleBackColor = False
        '
        'butExit
        '
        Me.butExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.butExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butExit.Image = Global.Tectile.My.Resources.Resources._Exit
        Me.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butExit.Location = New System.Drawing.Point(894, 3)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(108, 34)
        Me.butExit.TabIndex = 46
        Me.butExit.Text = "E&XIT"
        Me.butExit.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(17, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(301, 25)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "PRESS F9 FOR FULL GRID"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = Global.Tectile.My.MySettings.Default.tranbkcolor
        Me.GroupBox1.Controls.Add(Me.txtJvvrno)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtAcName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtVrNosec)
        Me.GroupBox1.Controls.Add(Me.txtVrnofirst)
        Me.GroupBox1.Controls.Add(Me.maskdate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtRefBank)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtAccode)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtChqno)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtAmount)
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.txtBkName)
        Me.GroupBox1.Controls.Add(Me.txtBKCode)
        Me.GroupBox1.Controls.Add(Me.DG1)
        Me.GroupBox1.Controls.Add(Me.dgacm)
        Me.GroupBox1.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tectile.My.MySettings.Default, "tranbkcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(16, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1091, 547)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        '
        'txtAcName
        '
        Me.txtAcName.Location = New System.Drawing.Point(490, 97)
        Me.txtAcName.MaxLength = 40
        Me.txtAcName.Name = "txtAcName"
        Me.txtAcName.Size = New System.Drawing.Size(401, 20)
        Me.txtAcName.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label1.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label1.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label1.Location = New System.Drawing.Point(877, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "VrNo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label2.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label2.Location = New System.Drawing.Point(435, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 15)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label3.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label3.Location = New System.Drawing.Point(435, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "BKName"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label4.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label4.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label4.Location = New System.Drawing.Point(782, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "BKCode"
        '
        'txtVrNosec
        '
        Me.txtVrNosec.Location = New System.Drawing.Point(953, 19)
        Me.txtVrNosec.Name = "txtVrNosec"
        Me.txtVrNosec.ReadOnly = True
        Me.txtVrNosec.Size = New System.Drawing.Size(33, 20)
        Me.txtVrNosec.TabIndex = 34
        '
        'txtVrnofirst
        '
        Me.txtVrnofirst.Location = New System.Drawing.Point(914, 19)
        Me.txtVrnofirst.Name = "txtVrnofirst"
        Me.txtVrnofirst.ReadOnly = True
        Me.txtVrnofirst.Size = New System.Drawing.Size(33, 20)
        Me.txtVrnofirst.TabIndex = 41
        '
        'maskdate
        '
        Me.maskdate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.maskdate.Location = New System.Drawing.Point(492, 58)
        Me.maskdate.Mask = "00/00/0000"
        Me.maskdate.Name = "maskdate"
        Me.maskdate.Size = New System.Drawing.Size(102, 20)
        Me.maskdate.TabIndex = 42
        Me.maskdate.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label5.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label5.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label5.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label5.Location = New System.Drawing.Point(897, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "ACCode"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label6.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label6.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label6.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label6.Location = New System.Drawing.Point(435, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "ACName"
        '
        'txtRefBank
        '
        Me.txtRefBank.Location = New System.Drawing.Point(798, 131)
        Me.txtRefBank.MaxLength = 10
        Me.txtRefBank.Name = "txtRefBank"
        Me.txtRefBank.Size = New System.Drawing.Size(188, 20)
        Me.txtRefBank.TabIndex = 45
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label7.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label7.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label7.Location = New System.Drawing.Point(435, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 15)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "ChqNo"
        '
        'txtAccode
        '
        Me.txtAccode.Enabled = False
        Me.txtAccode.Location = New System.Drawing.Point(953, 97)
        Me.txtAccode.Name = "txtAccode"
        Me.txtAccode.ReadOnly = True
        Me.txtAccode.Size = New System.Drawing.Size(75, 20)
        Me.txtAccode.TabIndex = 39
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label8.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label8.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label8.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label8.Location = New System.Drawing.Point(727, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 15)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "RefBank"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label9.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label9.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label9.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label9.Location = New System.Drawing.Point(435, 200)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 15)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Amount"
        '
        'txtChqno
        '
        Me.txtChqno.Location = New System.Drawing.Point(490, 130)
        Me.txtChqno.MaxLength = 15
        Me.txtChqno.Name = "txtChqno"
        Me.txtChqno.Size = New System.Drawing.Size(188, 20)
        Me.txtChqno.TabIndex = 44
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label10.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label10.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label10.Location = New System.Drawing.Point(435, 239)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 15)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Remark"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(490, 197)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(188, 20)
        Me.txtAmount.TabIndex = 46
        Me.txtAmount.Text = "0.00"
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(490, 236)
        Me.txtRemark.MaxLength = 5000
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(512, 20)
        Me.txtRemark.TabIndex = 47
        '
        'txtBkName
        '
        Me.txtBkName.Location = New System.Drawing.Point(490, 23)
        Me.txtBkName.Name = "txtBkName"
        Me.txtBkName.ReadOnly = True
        Me.txtBkName.Size = New System.Drawing.Size(286, 20)
        Me.txtBkName.TabIndex = 32
        '
        'txtBKCode
        '
        Me.txtBKCode.Location = New System.Drawing.Point(834, 19)
        Me.txtBKCode.Name = "txtBKCode"
        Me.txtBKCode.ReadOnly = True
        Me.txtBKCode.Size = New System.Drawing.Size(37, 20)
        Me.txtBKCode.TabIndex = 33
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "tranfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label15.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "tranfocolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label15.Font = Global.Tectile.My.MySettings.Default.tranfont
        Me.Label15.ForeColor = Global.Tectile.My.MySettings.Default.tranfocolor
        Me.Label15.Location = New System.Drawing.Point(778, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 15)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "JVVRNO"
        '
        'txtJvvrno
        '
        Me.txtJvvrno.Location = New System.Drawing.Point(844, 44)
        Me.txtJvvrno.Name = "txtJvvrno"
        Me.txtJvvrno.ReadOnly = True
        Me.txtJvvrno.Size = New System.Drawing.Size(69, 20)
        Me.txtJvvrno.TabIndex = 59
        '
        'frmBankRec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1111, 674)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmBankRec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bank Reconciliation"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgacm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgacm As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dateyl1 As System.Windows.Forms.Label
    Friend WithEvents companyname1 As System.Windows.Forms.Label
    Friend WithEvents dateyf1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents butEdit As System.Windows.Forms.Button
    Friend WithEvents butFind As System.Windows.Forms.Button
    Friend WithEvents butSave As System.Windows.Forms.Button
    Friend WithEvents butDelete As System.Windows.Forms.Button
    Friend WithEvents butExit As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAcName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVrNosec As System.Windows.Forms.TextBox
    Friend WithEvents txtVrnofirst As System.Windows.Forms.TextBox
    Friend WithEvents maskdate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRefBank As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAccode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtChqno As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents txtBkName As System.Windows.Forms.TextBox
    Friend WithEvents txtBKCode As System.Windows.Forms.TextBox
    Friend WithEvents txtJvvrno As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class