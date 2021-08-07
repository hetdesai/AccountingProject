<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmtaxmst
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmtaxmst))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.comtax = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dateyl1 = New System.Windows.Forms.Label()
        Me.companyname1 = New System.Windows.Forms.Label()
        Me.dateyf1 = New System.Windows.Forms.Label()
        Me.combktype = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTaxNara = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.comchange = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.comPoAccount = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPoCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.comAddLess = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.comTaxIndex = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.comOnWhich = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.comPosting = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.comOperation = New System.Windows.Forms.ComboBox()
        Me.butAdd = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.butEdit = New System.Windows.Forms.Button()
        Me.butRemve = New System.Windows.Forms.Button()
        Me.butSave = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dg1 = New Tectile.MyDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TAX"
        '
        'comtax
        '
        Me.comtax.FormattingEnabled = True
        Me.comtax.Location = New System.Drawing.Point(95, 60)
        Me.comtax.Name = "comtax"
        Me.comtax.Size = New System.Drawing.Size(121, 21)
        Me.comtax.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(323, 598)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 28)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1023, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(268, 460)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Purple
        Me.Panel2.Controls.Add(Me.dateyl1)
        Me.Panel2.Controls.Add(Me.companyname1)
        Me.Panel2.Controls.Add(Me.dateyf1)
        Me.Panel2.Location = New System.Drawing.Point(3, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1274, 28)
        Me.Panel2.TabIndex = 36
        '
        'dateyl1
        '
        Me.dateyl1.AutoSize = True
        Me.dateyl1.ForeColor = System.Drawing.Color.White
        Me.dateyl1.Location = New System.Drawing.Point(1202, 8)
        Me.dateyl1.Name = "dateyl1"
        Me.dateyl1.Size = New System.Drawing.Size(39, 13)
        Me.dateyl1.TabIndex = 2
        Me.dateyl1.Text = "Label9"
        '
        'companyname1
        '
        Me.companyname1.AutoSize = True
        Me.companyname1.ForeColor = System.Drawing.Color.White
        Me.companyname1.Location = New System.Drawing.Point(618, 8)
        Me.companyname1.Name = "companyname1"
        Me.companyname1.Size = New System.Drawing.Size(0, 13)
        Me.companyname1.TabIndex = 1
        Me.companyname1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dateyf1
        '
        Me.dateyf1.AutoSize = True
        Me.dateyf1.ForeColor = System.Drawing.Color.White
        Me.dateyf1.Location = New System.Drawing.Point(23, 8)
        Me.dateyf1.Name = "dateyf1"
        Me.dateyf1.Size = New System.Drawing.Size(39, 13)
        Me.dateyf1.TabIndex = 0
        Me.dateyf1.Text = "Label7"
        '
        'combktype
        '
        Me.combktype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combktype.FormattingEnabled = True
        Me.combktype.Items.AddRange(New Object() {"Purchase", "Sale"})
        Me.combktype.Location = New System.Drawing.Point(95, 35)
        Me.combktype.Name = "combktype"
        Me.combktype.Size = New System.Drawing.Size(121, 21)
        Me.combktype.TabIndex = 37
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(415, 598)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 28)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "Delete"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "BKTYPE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "TAXNARA"
        '
        'txtTaxNara
        '
        Me.txtTaxNara.Location = New System.Drawing.Point(95, 87)
        Me.txtTaxNara.Name = "txtTaxNara"
        Me.txtTaxNara.Size = New System.Drawing.Size(403, 20)
        Me.txtTaxNara.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "CHANGABLE"
        '
        'comchange
        '
        Me.comchange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comchange.FormattingEnabled = True
        Me.comchange.Items.AddRange(New Object() {"True", "False"})
        Me.comchange.Location = New System.Drawing.Point(95, 112)
        Me.comchange.Name = "comchange"
        Me.comchange.Size = New System.Drawing.Size(121, 21)
        Me.comchange.TabIndex = 43
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "PONAME"
        '
        'comPoAccount
        '
        Me.comPoAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.comPoAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.comPoAccount.FormattingEnabled = True
        Me.comPoAccount.Location = New System.Drawing.Point(95, 163)
        Me.comPoAccount.Name = "comPoAccount"
        Me.comPoAccount.Size = New System.Drawing.Size(403, 21)
        Me.comPoAccount.TabIndex = 45
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 194)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "POCODE"
        '
        'txtPoCode
        '
        Me.txtPoCode.Location = New System.Drawing.Point(95, 189)
        Me.txtPoCode.Name = "txtPoCode"
        Me.txtPoCode.ReadOnly = True
        Me.txtPoCode.Size = New System.Drawing.Size(121, 20)
        Me.txtPoCode.TabIndex = 47
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 220)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "ADD/LESS"
        '
        'comAddLess
        '
        Me.comAddLess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comAddLess.FormattingEnabled = True
        Me.comAddLess.Items.AddRange(New Object() {"ADD", "Less"})
        Me.comAddLess.Location = New System.Drawing.Point(95, 214)
        Me.comAddLess.Name = "comAddLess"
        Me.comAddLess.Size = New System.Drawing.Size(121, 21)
        Me.comAddLess.TabIndex = 49
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 246)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "TAXINDEX"
        '
        'comTaxIndex
        '
        Me.comTaxIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comTaxIndex.FormattingEnabled = True
        Me.comTaxIndex.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ""})
        Me.comTaxIndex.Location = New System.Drawing.Point(95, 240)
        Me.comTaxIndex.Name = "comTaxIndex"
        Me.comTaxIndex.Size = New System.Drawing.Size(121, 21)
        Me.comTaxIndex.TabIndex = 51
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 272)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "ONWHICH"
        '
        'comOnWhich
        '
        Me.comOnWhich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comOnWhich.FormattingEnabled = True
        Me.comOnWhich.Items.AddRange(New Object() {"Gr", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ""})
        Me.comOnWhich.Location = New System.Drawing.Point(95, 266)
        Me.comOnWhich.Name = "comOnWhich"
        Me.comOnWhich.Size = New System.Drawing.Size(121, 21)
        Me.comOnWhich.TabIndex = 53
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 298)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 54
        Me.Label11.Text = "POSTING"
        '
        'comPosting
        '
        Me.comPosting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comPosting.FormattingEnabled = True
        Me.comPosting.Items.AddRange(New Object() {"f", "t"})
        Me.comPosting.Location = New System.Drawing.Point(95, 292)
        Me.comPosting.Name = "comPosting"
        Me.comPosting.Size = New System.Drawing.Size(121, 21)
        Me.comPosting.TabIndex = 55
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 324)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 56
        Me.Label12.Text = "OPERATION"
        '
        'comOperation
        '
        Me.comOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comOperation.FormattingEnabled = True
        Me.comOperation.Items.AddRange(New Object() {"Per", "Fixed"})
        Me.comOperation.Location = New System.Drawing.Point(95, 318)
        Me.comOperation.Name = "comOperation"
        Me.comOperation.Size = New System.Drawing.Size(121, 21)
        Me.comOperation.TabIndex = 57
        '
        'butAdd
        '
        Me.butAdd.Location = New System.Drawing.Point(323, 342)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(75, 26)
        Me.butAdd.TabIndex = 58
        Me.butAdd.Text = "&ADD"
        Me.butAdd.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 142)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 59
        Me.Label13.Text = "VALUE"
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(95, 138)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(86, 20)
        Me.txtValue.TabIndex = 60
        Me.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'butEdit
        '
        Me.butEdit.Location = New System.Drawing.Point(404, 342)
        Me.butEdit.Name = "butEdit"
        Me.butEdit.Size = New System.Drawing.Size(75, 26)
        Me.butEdit.TabIndex = 61
        Me.butEdit.Text = "&EDIT"
        Me.butEdit.UseVisualStyleBackColor = True
        '
        'butRemve
        '
        Me.butRemve.Location = New System.Drawing.Point(485, 342)
        Me.butRemve.Name = "butRemve"
        Me.butRemve.Size = New System.Drawing.Size(75, 26)
        Me.butRemve.TabIndex = 62
        Me.butRemve.Text = "&REMOVE"
        Me.butRemve.UseVisualStyleBackColor = True
        '
        'butSave
        '
        Me.butSave.Location = New System.Drawing.Point(566, 342)
        Me.butSave.Name = "butSave"
        Me.butSave.Size = New System.Drawing.Size(75, 26)
        Me.butSave.TabIndex = 63
        Me.butSave.Text = "&SAVE"
        Me.butSave.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(599, 52)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "OPERATION"
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15})
        Me.dg1.Location = New System.Drawing.Point(12, 374)
        Me.dg1.Name = "dg1"
        Me.dg1.Size = New System.Drawing.Size(990, 199)
        Me.dg1.TabIndex = 3
        '
        'Column1
        '
        Me.Column1.HeaderText = "BKType"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "Tax"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 50
        '
        'Column3
        '
        Me.Column3.HeaderText = "Tax Nara"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Changable"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 40
        '
        'Column5
        '
        Me.Column5.HeaderText = "Value"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Poname"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Pocode"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 50
        '
        'Column8
        '
        Me.Column8.HeaderText = "Add/Less"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 50
        '
        'Column9
        '
        Me.Column9.HeaderText = "Onwhich"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 50
        '
        'Column10
        '
        Me.Column10.HeaderText = "Optype"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 50
        '
        'Column11
        '
        Me.Column11.HeaderText = "Amt"
        Me.Column11.Name = "Column11"
        '
        'Column12
        '
        Me.Column12.HeaderText = "TaxIndex"
        Me.Column12.Name = "Column12"
        Me.Column12.Width = 60
        '
        'Column13
        '
        Me.Column13.HeaderText = "Ispost"
        Me.Column13.Name = "Column13"
        Me.Column13.Width = 40
        '
        'Column14
        '
        Me.Column14.HeaderText = "Serialno"
        Me.Column14.Name = "Column14"
        '
        'Column15
        '
        Me.Column15.HeaderText = "TotalAmt"
        Me.Column15.Name = "Column15"
        '
        'frmtaxmst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1276, 737)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.butSave)
        Me.Controls.Add(Me.butRemve)
        Me.Controls.Add(Me.butEdit)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.butAdd)
        Me.Controls.Add(Me.comOperation)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.comPosting)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.comOnWhich)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.comTaxIndex)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.comAddLess)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPoCode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.comPoAccount)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.comchange)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTaxNara)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.combktype)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.comtax)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.KeyPreview = True
        Me.Name = "frmtaxmst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TAX Setup Master"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents comtax As System.Windows.Forms.ComboBox
    Friend WithEvents dg1 As Tectile.MyDataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dateyl1 As System.Windows.Forms.Label
    Friend WithEvents companyname1 As System.Windows.Forms.Label
    Friend WithEvents dateyf1 As System.Windows.Forms.Label
    Friend WithEvents combktype As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTaxNara As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents comchange As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents comPoAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPoCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents comAddLess As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents comTaxIndex As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents comOnWhich As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents comPosting As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents comOperation As System.Windows.Forms.ComboBox
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents butEdit As System.Windows.Forms.Button
    Friend WithEvents butRemve As System.Windows.Forms.Button
    Friend WithEvents butSave As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
