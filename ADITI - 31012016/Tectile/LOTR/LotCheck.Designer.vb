<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LotCheck
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
        Me.dginward = New System.Windows.Forms.DataGridView()
        Me.colVrNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coldate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colACNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMarka = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colitem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colgpcs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGMTR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colgbalpcs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colgbalmtr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colweight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgoutward = New System.Windows.Forms.DataGridView()
        Me.col2vrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colsr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colchno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col2date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col2acname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col2item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col2gpcs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col2gmtr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFPCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFmtr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtlotno = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtloty = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dginwarddetail = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgoutwarddetail = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        CType(Me.dginward, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgoutward, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dginwarddetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgoutwarddetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dginward
        '
        Me.dginward.AllowUserToAddRows = False
        Me.dginward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dginward.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVrNo, Me.coldate, Me.colACNAME, Me.colMarka, Me.colitem, Me.colgpcs, Me.colGMTR, Me.colgbalpcs, Me.colgbalmtr, Me.collrno, Me.colweight})
        Me.dginward.Location = New System.Drawing.Point(8, 70)
        Me.dginward.Name = "dginward"
        Me.dginward.RowHeadersVisible = False
        Me.dginward.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dginward.Size = New System.Drawing.Size(1212, 71)
        Me.dginward.TabIndex = 0
        '
        'colVrNo
        '
        Me.colVrNo.HeaderText = "VrNo"
        Me.colVrNo.Name = "colVrNo"
        Me.colVrNo.ReadOnly = True
        Me.colVrNo.Visible = False
        Me.colVrNo.Width = 50
        '
        'coldate
        '
        Me.coldate.HeaderText = "Date"
        Me.coldate.Name = "coldate"
        Me.coldate.ReadOnly = True
        Me.coldate.Width = 80
        '
        'colACNAME
        '
        Me.colACNAME.HeaderText = "ACNAME"
        Me.colACNAME.Name = "colACNAME"
        Me.colACNAME.ReadOnly = True
        Me.colACNAME.Width = 300
        '
        'colMarka
        '
        Me.colMarka.HeaderText = "Marka"
        Me.colMarka.Name = "colMarka"
        Me.colMarka.ReadOnly = True
        Me.colMarka.Width = 50
        '
        'colitem
        '
        Me.colitem.HeaderText = "Item"
        Me.colitem.Name = "colitem"
        Me.colitem.ReadOnly = True
        Me.colitem.Width = 200
        '
        'colgpcs
        '
        Me.colgpcs.HeaderText = "GPCS"
        Me.colgpcs.Name = "colgpcs"
        Me.colgpcs.ReadOnly = True
        Me.colgpcs.Width = 50
        '
        'colGMTR
        '
        Me.colGMTR.HeaderText = "Gmtr"
        Me.colGMTR.Name = "colGMTR"
        Me.colGMTR.ReadOnly = True
        '
        'colgbalpcs
        '
        Me.colgbalpcs.HeaderText = "GbalPcs"
        Me.colgbalpcs.Name = "colgbalpcs"
        Me.colgbalpcs.ReadOnly = True
        Me.colgbalpcs.Width = 50
        '
        'colgbalmtr
        '
        Me.colgbalmtr.HeaderText = "GbalMtr"
        Me.colgbalmtr.Name = "colgbalmtr"
        Me.colgbalmtr.ReadOnly = True
        '
        'collrno
        '
        Me.collrno.HeaderText = "Lrno"
        Me.collrno.Name = "collrno"
        '
        'colweight
        '
        Me.colweight.HeaderText = "Weight"
        Me.colweight.Name = "colweight"
        Me.colweight.Width = 70
        '
        'dgoutward
        '
        Me.dgoutward.AllowUserToAddRows = False
        Me.dgoutward.AllowUserToDeleteRows = False
        Me.dgoutward.AllowUserToOrderColumns = True
        Me.dgoutward.AllowUserToResizeColumns = False
        Me.dgoutward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgoutward.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col2vrno, Me.colsr, Me.colchno, Me.col2date, Me.col2acname, Me.col2item, Me.col2gpcs, Me.col2gmtr, Me.colFPCS, Me.colFmtr, Me.colRate, Me.colAmount})
        Me.dgoutward.Location = New System.Drawing.Point(8, 186)
        Me.dgoutward.Name = "dgoutward"
        Me.dgoutward.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgoutward.RowHeadersVisible = False
        Me.dgoutward.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgoutward.Size = New System.Drawing.Size(1212, 107)
        Me.dgoutward.TabIndex = 1
        '
        'col2vrno
        '
        Me.col2vrno.HeaderText = "VrNo"
        Me.col2vrno.Name = "col2vrno"
        Me.col2vrno.ReadOnly = True
        Me.col2vrno.Visible = False
        Me.col2vrno.Width = 70
        '
        'colsr
        '
        Me.colsr.HeaderText = "SR"
        Me.colsr.Name = "colsr"
        Me.colsr.ReadOnly = True
        Me.colsr.Width = 30
        '
        'colchno
        '
        Me.colchno.HeaderText = "InvoiceNo"
        Me.colchno.Name = "colchno"
        Me.colchno.ReadOnly = True
        '
        'col2date
        '
        Me.col2date.HeaderText = "Date"
        Me.col2date.Name = "col2date"
        Me.col2date.ReadOnly = True
        '
        'col2acname
        '
        Me.col2acname.HeaderText = "ACNAME"
        Me.col2acname.Name = "col2acname"
        Me.col2acname.ReadOnly = True
        Me.col2acname.Width = 300
        '
        'col2item
        '
        Me.col2item.HeaderText = "Item"
        Me.col2item.Name = "col2item"
        '
        'col2gpcs
        '
        Me.col2gpcs.HeaderText = "GPCS"
        Me.col2gpcs.Name = "col2gpcs"
        Me.col2gpcs.ReadOnly = True
        Me.col2gpcs.Width = 50
        '
        'col2gmtr
        '
        Me.col2gmtr.HeaderText = "Gmtr"
        Me.col2gmtr.Name = "col2gmtr"
        Me.col2gmtr.ReadOnly = True
        '
        'colFPCS
        '
        Me.colFPCS.HeaderText = "FPcs"
        Me.colFPCS.Name = "colFPCS"
        Me.colFPCS.ReadOnly = True
        Me.colFPCS.Width = 50
        '
        'colFmtr
        '
        Me.colFmtr.HeaderText = "colFmtr"
        Me.colFmtr.Name = "colFmtr"
        Me.colFmtr.ReadOnly = True
        '
        'colRate
        '
        Me.colRate.HeaderText = "Rate"
        Me.colRate.Name = "colRate"
        Me.colRate.ReadOnly = True
        Me.colRate.Width = 80
        '
        'colAmount
        '
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(685, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtlotno
        '
        Me.txtlotno.Location = New System.Drawing.Point(1061, 33)
        Me.txtlotno.Name = "txtlotno"
        Me.txtlotno.Size = New System.Drawing.Size(100, 20)
        Me.txtlotno.TabIndex = 3
        Me.txtlotno.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(958, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Lotno"
        Me.Label1.Visible = False
        '
        'txtloty
        '
        Me.txtloty.Location = New System.Drawing.Point(1007, 33)
        Me.txtloty.Name = "txtloty"
        Me.txtloty.Size = New System.Drawing.Size(48, 20)
        Me.txtloty.TabIndex = 5
        Me.txtloty.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 18)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Inward"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 18)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Dispatch"
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(70, 6)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(272, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "ACNAME"
        '
        'ComboBox2
        '
        Me.ComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(520, 6)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(142, 21)
        Me.ComboBox2.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(470, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "LOTNO"
        '
        'dginwarddetail
        '
        Me.dginwarddetail.AllowUserToAddRows = False
        Me.dginwarddetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dginwarddetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn9})
        Me.dginwarddetail.Location = New System.Drawing.Point(1, 330)
        Me.dginwarddetail.Name = "dginwarddetail"
        Me.dginwarddetail.RowHeadersVisible = False
        Me.dginwarddetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dginwarddetail.Size = New System.Drawing.Size(350, 358)
        Me.dginwarddetail.TabIndex = 12
        '
        'Column1
        '
        Me.Column1.HeaderText = "SrNo"
        Me.Column1.Name = "Column1"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Gmtr"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "GbalMtr"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 309)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 18)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Inward Detail"
        '
        'dgoutwarddetail
        '
        Me.dgoutwarddetail.AllowUserToAddRows = False
        Me.dgoutwarddetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgoutwarddetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn5})
        Me.dgoutwarddetail.Location = New System.Drawing.Point(451, 330)
        Me.dgoutwarddetail.Name = "dgoutwarddetail"
        Me.dgoutwarddetail.RowHeadersVisible = False
        Me.dgoutwarddetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgoutwarddetail.Size = New System.Drawing.Size(346, 358)
        Me.dgoutwarddetail.TabIndex = 14
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "SrNo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Gmtr"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Qty"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(97, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(437, 18)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "(Select any row and press enter to view full inward detail)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(97, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(448, 18)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "(Select any row and press enter to view full outward detail)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(448, 309)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 18)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Outward Detail"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(348, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "YEAR"
        '
        'ComboBox3
        '
        Me.ComboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(390, 6)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(74, 21)
        Me.ComboBox3.TabIndex = 19
        '
        'LotCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = Global.Tectile.My.MySettings.Default.tranbkcolor
        Me.ClientSize = New System.Drawing.Size(1224, 731)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgoutwarddetail)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dginwarddetail)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtloty)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtlotno)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgoutward)
        Me.Controls.Add(Me.dginward)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tectile.My.MySettings.Default, "tranbkcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Name = "LotCheck"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lot Check"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dginward, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgoutward, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dginwarddetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgoutwarddetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dginward As System.Windows.Forms.DataGridView
    Friend WithEvents dgoutward As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtlotno As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtloty As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dginwarddetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgoutwarddetail As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents col2vrno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colsr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colchno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2acname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2gpcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2gmtr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFPCS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFmtr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVrNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coldate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colACNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMarka As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colitem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colgpcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGMTR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colgbalpcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colgbalmtr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collrno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colweight As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
