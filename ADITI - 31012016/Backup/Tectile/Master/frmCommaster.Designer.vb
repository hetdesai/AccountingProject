<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommaster
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.maskto = New System.Windows.Forms.MaskedTextBox
        Me.maskfrom = New System.Windows.Forms.MaskedTextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.TextBox26 = New System.Windows.Forms.TextBox
        Me.TextBox25 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.txtreportheader2 = New System.Windows.Forms.TextBox
        Me.txtreportHeader1 = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtState = New System.Windows.Forms.TextBox
        Me.txtSortname = New System.Windows.Forms.TextBox
        Me.txtComCode = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtComName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtWebSite = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPhone3 = New System.Windows.Forms.TextBox
        Me.txtPhone2 = New System.Windows.Forms.TextBox
        Me.txtPhone1 = New System.Windows.Forms.TextBox
        Me.txtPincode = New System.Windows.Forms.TextBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.txtAdress3 = New System.Windows.Forms.TextBox
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txttnc = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtJuriCity = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtServiceTax = New System.Windows.Forms.TextBox
        Me.txtEccNo = New System.Windows.Forms.TextBox
        Me.txtTanNo = New System.Windows.Forms.TextBox
        Me.txtPanNo = New System.Windows.Forms.TextBox
        Me.txtCstNo = New System.Windows.Forms.TextBox
        Me.txtTinNo = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.maskto)
        Me.GroupBox1.Controls.Add(Me.maskfrom)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.TextBox26)
        Me.GroupBox1.Controls.Add(Me.TextBox25)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.txtreportheader2)
        Me.GroupBox1.Controls.Add(Me.txtreportHeader1)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.txtState)
        Me.GroupBox1.Controls.Add(Me.txtSortname)
        Me.GroupBox1.Controls.Add(Me.txtComCode)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtComName)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(930, 270)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Company Details"
        '
        'maskto
        '
        Me.maskto.Culture = New System.Globalization.CultureInfo("")
        Me.maskto.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.maskto.Location = New System.Drawing.Point(288, 62)
        Me.maskto.Mask = "00/00/0000"
        Me.maskto.Name = "maskto"
        Me.maskto.Size = New System.Drawing.Size(106, 20)
        Me.maskto.TabIndex = 21
        Me.maskto.ValidatingType = GetType(Date)
        '
        'maskfrom
        '
        Me.maskfrom.Culture = New System.Globalization.CultureInfo("")
        Me.maskfrom.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.maskfrom.Location = New System.Drawing.Point(100, 62)
        Me.maskfrom.Mask = "00/00/0000"
        Me.maskfrom.Name = "maskfrom"
        Me.maskfrom.Size = New System.Drawing.Size(106, 20)
        Me.maskfrom.TabIndex = 20
        Me.maskfrom.ValidatingType = GetType(Date)
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(215, 65)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(66, 13)
        Me.Label23.TabIndex = 19
        Me.Label23.Text = "A/c Year To"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(12, 65)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(76, 13)
        Me.Label22.TabIndex = 18
        Me.Label22.Text = "A/c Year From"
        '
        'TextBox26
        '
        Me.TextBox26.Location = New System.Drawing.Point(450, 197)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(352, 20)
        Me.TextBox26.TabIndex = 17
        Me.TextBox26.Visible = False
        '
        'TextBox25
        '
        Me.TextBox25.Location = New System.Drawing.Point(450, 175)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.ReadOnly = True
        Me.TextBox25.Size = New System.Drawing.Size(352, 20)
        Me.TextBox25.TabIndex = 16
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(297, 119)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(59, 27)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtreportheader2
        '
        Me.txtreportheader2.Location = New System.Drawing.Point(450, 149)
        Me.txtreportheader2.Name = "txtreportheader2"
        Me.txtreportheader2.Size = New System.Drawing.Size(352, 20)
        Me.txtreportheader2.TabIndex = 12
        '
        'txtreportHeader1
        '
        Me.txtreportHeader1.Location = New System.Drawing.Point(450, 123)
        Me.txtreportHeader1.Name = "txtreportHeader1"
        Me.txtreportHeader1.Size = New System.Drawing.Size(352, 20)
        Me.txtreportHeader1.TabIndex = 11
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(100, 121)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(191, 143)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(450, 87)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(176, 20)
        Me.txtState.TabIndex = 9
        '
        'txtSortname
        '
        Me.txtSortname.Location = New System.Drawing.Point(100, 87)
        Me.txtSortname.Name = "txtSortname"
        Me.txtSortname.Size = New System.Drawing.Size(82, 20)
        Me.txtSortname.TabIndex = 8
        '
        'txtComCode
        '
        Me.txtComCode.Location = New System.Drawing.Point(694, 33)
        Me.txtComCode.Name = "txtComCode"
        Me.txtComCode.ReadOnly = True
        Me.txtComCode.Size = New System.Drawing.Size(82, 20)
        Me.txtComCode.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(587, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Company Code"
        '
        'txtComName
        '
        Me.txtComName.Location = New System.Drawing.Point(100, 33)
        Me.txtComName.Name = "txtComName"
        Me.txtComName.Size = New System.Drawing.Size(463, 20)
        Me.txtComName.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(362, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Report Header"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Logo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(362, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "State"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Short Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtWebSite)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtFax)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtPhone3)
        Me.GroupBox2.Controls.Add(Me.txtPhone2)
        Me.GroupBox2.Controls.Add(Me.txtPhone1)
        Me.GroupBox2.Controls.Add(Me.txtPincode)
        Me.GroupBox2.Controls.Add(Me.txtCity)
        Me.GroupBox2.Controls.Add(Me.txtAdress3)
        Me.GroupBox2.Controls.Add(Me.txtAddress2)
        Me.GroupBox2.Controls.Add(Me.txtAddress1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 313)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(478, 323)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Address Details"
        '
        'txtWebSite
        '
        Me.txtWebSite.Location = New System.Drawing.Point(85, 274)
        Me.txtWebSite.Name = "txtWebSite"
        Me.txtWebSite.Size = New System.Drawing.Size(352, 20)
        Me.txtWebSite.TabIndex = 27
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 277)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "WebSite"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(85, 242)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(352, 20)
        Me.txtFax.TabIndex = 25
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 245)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Fax"
        '
        'txtPhone3
        '
        Me.txtPhone3.Location = New System.Drawing.Point(85, 219)
        Me.txtPhone3.Name = "txtPhone3"
        Me.txtPhone3.Size = New System.Drawing.Size(352, 20)
        Me.txtPhone3.TabIndex = 23
        '
        'txtPhone2
        '
        Me.txtPhone2.Location = New System.Drawing.Point(85, 193)
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.Size = New System.Drawing.Size(352, 20)
        Me.txtPhone2.TabIndex = 22
        '
        'txtPhone1
        '
        Me.txtPhone1.Location = New System.Drawing.Point(85, 167)
        Me.txtPhone1.Name = "txtPhone1"
        Me.txtPhone1.Size = New System.Drawing.Size(352, 20)
        Me.txtPhone1.TabIndex = 21
        '
        'txtPincode
        '
        Me.txtPincode.Location = New System.Drawing.Point(85, 141)
        Me.txtPincode.Name = "txtPincode"
        Me.txtPincode.Size = New System.Drawing.Size(352, 20)
        Me.txtPincode.TabIndex = 20
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(85, 110)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(352, 20)
        Me.txtCity.TabIndex = 19
        '
        'txtAdress3
        '
        Me.txtAdress3.Location = New System.Drawing.Point(85, 84)
        Me.txtAdress3.Name = "txtAdress3"
        Me.txtAdress3.Size = New System.Drawing.Size(352, 20)
        Me.txtAdress3.TabIndex = 18
        '
        'txtAddress2
        '
        Me.txtAddress2.Location = New System.Drawing.Point(85, 52)
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(352, 20)
        Me.txtAddress2.TabIndex = 17
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(85, 26)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(352, 20)
        Me.txtAddress1.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 170)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Phone No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Pincode"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 113)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "City"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Address"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txttnc)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.txtJuriCity)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtServiceTax)
        Me.GroupBox3.Controls.Add(Me.txtEccNo)
        Me.GroupBox3.Controls.Add(Me.txtTanNo)
        Me.GroupBox3.Controls.Add(Me.txtPanNo)
        Me.GroupBox3.Controls.Add(Me.txtCstNo)
        Me.GroupBox3.Controls.Add(Me.txtTinNo)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(486, 318)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(444, 317)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Other Detail"
        '
        'txttnc
        '
        Me.txttnc.Location = New System.Drawing.Point(86, 234)
        Me.txttnc.Multiline = True
        Me.txttnc.Name = "txttnc"
        Me.txttnc.Size = New System.Drawing.Size(352, 77)
        Me.txttnc.TabIndex = 42
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 237)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(86, 13)
        Me.Label21.TabIndex = 41
        Me.Label21.Text = "Terms & Condition"
        '
        'txtJuriCity
        '
        Me.txtJuriCity.Location = New System.Drawing.Point(86, 198)
        Me.txtJuriCity.Name = "txtJuriCity"
        Me.txtJuriCity.Size = New System.Drawing.Size(352, 20)
        Me.txtJuriCity.TabIndex = 40
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 205)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(74, 13)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Juridiction City"
        '
        'txtServiceTax
        '
        Me.txtServiceTax.Location = New System.Drawing.Point(86, 169)
        Me.txtServiceTax.Name = "txtServiceTax"
        Me.txtServiceTax.Size = New System.Drawing.Size(352, 20)
        Me.txtServiceTax.TabIndex = 38
        '
        'txtEccNo
        '
        Me.txtEccNo.Location = New System.Drawing.Point(86, 136)
        Me.txtEccNo.Name = "txtEccNo"
        Me.txtEccNo.Size = New System.Drawing.Size(352, 20)
        Me.txtEccNo.TabIndex = 37
        '
        'txtTanNo
        '
        Me.txtTanNo.Location = New System.Drawing.Point(86, 109)
        Me.txtTanNo.Name = "txtTanNo"
        Me.txtTanNo.Size = New System.Drawing.Size(352, 20)
        Me.txtTanNo.TabIndex = 36
        '
        'txtPanNo
        '
        Me.txtPanNo.Location = New System.Drawing.Point(86, 79)
        Me.txtPanNo.Name = "txtPanNo"
        Me.txtPanNo.Size = New System.Drawing.Size(352, 20)
        Me.txtPanNo.TabIndex = 35
        '
        'txtCstNo
        '
        Me.txtCstNo.Location = New System.Drawing.Point(86, 47)
        Me.txtCstNo.Name = "txtCstNo"
        Me.txtCstNo.Size = New System.Drawing.Size(352, 20)
        Me.txtCstNo.TabIndex = 34
        '
        'txtTinNo
        '
        Me.txtTinNo.Location = New System.Drawing.Point(86, 19)
        Me.txtTinNo.Name = "txtTinNo"
        Me.txtTinNo.Size = New System.Drawing.Size(352, 20)
        Me.txtTinNo.TabIndex = 28
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 169)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 13)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "Service Tax No"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 139)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "ECC No"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 112)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "TAN No"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 86)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "PAN No"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 54)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "CST No"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "TIN No"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(416, 654)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 43)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(723, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(79, 13)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "Company Code"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(544, 654)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(122, 43)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "EXIT"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(100, 6)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(471, 21)
        Me.ComboBox1.TabIndex = 15
        Me.ComboBox1.Visible = False
        '
        'frmCommaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(934, 723)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "frmCommaster"
        Me.Text = "frmCommaster"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtreportheader2 As System.Windows.Forms.TextBox
    Friend WithEvents txtreportHeader1 As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents txtSortname As System.Windows.Forms.TextBox
    Friend WithEvents txtComCode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtComName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtWebSite As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPhone3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPincode As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAdress3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtJuriCity As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtServiceTax As System.Windows.Forms.TextBox
    Friend WithEvents txtEccNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTanNo As System.Windows.Forms.TextBox
    Friend WithEvents txtPanNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCstNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTinNo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txttnc As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents maskto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskfrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
