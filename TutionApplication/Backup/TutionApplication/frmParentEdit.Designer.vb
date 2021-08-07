<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParentEdit
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtFContact = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSuname = New System.Windows.Forms.TextBox
        Me.txtFName = New System.Windows.Forms.TextBox
        Me.txtMName = New System.Windows.Forms.TextBox
        Me.txtMaddress = New System.Windows.Forms.TextBox
        Me.txtMdetail = New System.Windows.Forms.TextBox
        Me.radMService = New System.Windows.Forms.RadioButton
        Me.txtFAddress = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.radMHouse = New System.Windows.Forms.RadioButton
        Me.txtFdetail = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.radMbusiness = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.radService = New System.Windows.Forms.RadioButton
        Me.radBusiness = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSid = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(423, 475)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 66
        Me.Button1.Text = "&SAVE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtFContact
        '
        Me.txtFContact.Location = New System.Drawing.Point(91, 271)
        Me.txtFContact.Name = "txtFContact"
        Me.txtFContact.Size = New System.Drawing.Size(114, 20)
        Me.txtFContact.TabIndex = 65
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label13.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label13.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label13.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label13.Location = New System.Drawing.Point(13, 274)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 18)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "Contact No"
        '
        'txtSuname
        '
        Me.txtSuname.Location = New System.Drawing.Point(555, 1)
        Me.txtSuname.Name = "txtSuname"
        Me.txtSuname.Size = New System.Drawing.Size(235, 20)
        Me.txtSuname.TabIndex = 55
        Me.txtSuname.Visible = False
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(87, 46)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(235, 20)
        Me.txtFName.TabIndex = 54
        '
        'txtMName
        '
        Me.txtMName.Location = New System.Drawing.Point(358, 42)
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Size = New System.Drawing.Size(235, 20)
        Me.txtMName.TabIndex = 55
        '
        'txtMaddress
        '
        Me.txtMaddress.Location = New System.Drawing.Point(358, 196)
        Me.txtMaddress.Multiline = True
        Me.txtMaddress.Name = "txtMaddress"
        Me.txtMaddress.Size = New System.Drawing.Size(235, 58)
        Me.txtMaddress.TabIndex = 64
        '
        'txtMdetail
        '
        Me.txtMdetail.Location = New System.Drawing.Point(358, 153)
        Me.txtMdetail.Name = "txtMdetail"
        Me.txtMdetail.Size = New System.Drawing.Size(232, 20)
        Me.txtMdetail.TabIndex = 62
        '
        'radMService
        '
        Me.radMService.AutoSize = True
        Me.radMService.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.radMService.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.radMService.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.radMService.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.radMService.Location = New System.Drawing.Point(17, 16)
        Me.radMService.Name = "radMService"
        Me.radMService.Size = New System.Drawing.Size(82, 22)
        Me.radMService.TabIndex = 58
        Me.radMService.TabStop = True
        Me.radMService.Text = "Service"
        Me.radMService.UseVisualStyleBackColor = True
        '
        'txtFAddress
        '
        Me.txtFAddress.Location = New System.Drawing.Point(90, 196)
        Me.txtFAddress.Multiline = True
        Me.txtFAddress.Name = "txtFAddress"
        Me.txtFAddress.Size = New System.Drawing.Size(232, 58)
        Me.txtFAddress.TabIndex = 63
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label10.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label10.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label10.Location = New System.Drawing.Point(13, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 18)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Address"
        '
        'radMHouse
        '
        Me.radMHouse.AutoSize = True
        Me.radMHouse.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.radMHouse.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.radMHouse.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.radMHouse.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.radMHouse.Location = New System.Drawing.Point(158, 16)
        Me.radMHouse.Name = "radMHouse"
        Me.radMHouse.Size = New System.Drawing.Size(105, 22)
        Me.radMHouse.TabIndex = 60
        Me.radMHouse.TabStop = True
        Me.radMHouse.Text = "Housewife"
        Me.radMHouse.UseVisualStyleBackColor = True
        '
        'txtFdetail
        '
        Me.txtFdetail.Location = New System.Drawing.Point(90, 157)
        Me.txtFdetail.Name = "txtFdetail"
        Me.txtFdetail.Size = New System.Drawing.Size(232, 20)
        Me.txtFdetail.TabIndex = 61
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(390, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 24)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Parents Detail"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label9.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label9.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label9.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label9.Location = New System.Drawing.Point(13, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 18)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Detail"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(544, 475)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 67
        Me.Button3.Text = "EXIT"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(570, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Surname"
        Me.Label6.Visible = False
        '
        'radMbusiness
        '
        Me.radMbusiness.AutoSize = True
        Me.radMbusiness.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.radMbusiness.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.radMbusiness.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.radMbusiness.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.radMbusiness.Location = New System.Drawing.Point(84, 16)
        Me.radMbusiness.Name = "radMbusiness"
        Me.radMbusiness.Size = New System.Drawing.Size(95, 22)
        Me.radMbusiness.TabIndex = 59
        Me.radMbusiness.TabStop = True
        Me.radMbusiness.Text = "Business"
        Me.radMbusiness.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.radService)
        Me.Panel1.Controls.Add(Me.radBusiness)
        Me.Panel1.Location = New System.Drawing.Point(87, 86)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(235, 49)
        Me.Panel1.TabIndex = 43
        '
        'radService
        '
        Me.radService.AutoSize = True
        Me.radService.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.radService.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.radService.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.radService.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.radService.Location = New System.Drawing.Point(17, 16)
        Me.radService.Name = "radService"
        Me.radService.Size = New System.Drawing.Size(82, 22)
        Me.radService.TabIndex = 56
        Me.radService.TabStop = True
        Me.radService.Text = "Service"
        Me.radService.UseVisualStyleBackColor = True
        '
        'radBusiness
        '
        Me.radBusiness.AutoSize = True
        Me.radBusiness.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.radBusiness.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.radBusiness.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.radBusiness.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.radBusiness.Location = New System.Drawing.Point(84, 16)
        Me.radBusiness.Name = "radBusiness"
        Me.radBusiness.Size = New System.Drawing.Size(95, 22)
        Me.radBusiness.TabIndex = 57
        Me.radBusiness.TabStop = True
        Me.radBusiness.Text = "Business"
        Me.radBusiness.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label7.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label7.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label7.Location = New System.Drawing.Point(13, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 18)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Occupation"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(175, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 18)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Father"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(451, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 18)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Mother"
        '
        'txtSid
        '
        Me.txtSid.Enabled = False
        Me.txtSid.Location = New System.Drawing.Point(114, 67)
        Me.txtSid.Name = "txtSid"
        Me.txtSid.ReadOnly = True
        Me.txtSid.Size = New System.Drawing.Size(52, 20)
        Me.txtSid.TabIndex = 35
        Me.txtSid.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label2.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label2.Location = New System.Drawing.Point(25, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 18)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Student Id"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(301, 475)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 61
        Me.Button4.TabStop = False
        Me.Button4.Text = "&BACK"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label3.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label3.Location = New System.Drawing.Point(13, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 18)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Name"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtFContact)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.txtFName)
        Me.Panel3.Controls.Add(Me.txtMName)
        Me.Panel3.Controls.Add(Me.txtMaddress)
        Me.Panel3.Controls.Add(Me.txtMdetail)
        Me.Panel3.Controls.Add(Me.txtFAddress)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txtFdetail)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(16, 100)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(629, 307)
        Me.Panel3.TabIndex = 68
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.radMHouse)
        Me.Panel2.Controls.Add(Me.radMService)
        Me.Panel2.Controls.Add(Me.radMbusiness)
        Me.Panel2.Location = New System.Drawing.Point(358, 86)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(235, 46)
        Me.Panel2.TabIndex = 44
        '
        'frmParentEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.TutionApplication.My.MySettings.Default.backcolor
        Me.ClientSize = New System.Drawing.Size(921, 627)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtSuname)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSid)
        Me.Controls.Add(Me.Label2)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.TutionApplication.My.MySettings.Default, "backcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.KeyPreview = True
        Me.Name = "frmParentEdit"
        Me.Text = "frmParentEdit"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtFContact As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSuname As System.Windows.Forms.TextBox
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents txtMName As System.Windows.Forms.TextBox
    Friend WithEvents txtMaddress As System.Windows.Forms.TextBox
    Friend WithEvents txtMdetail As System.Windows.Forms.TextBox
    Friend WithEvents radMService As System.Windows.Forms.RadioButton
    Friend WithEvents txtFAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents radMHouse As System.Windows.Forms.RadioButton
    Friend WithEvents txtFdetail As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents radMbusiness As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents radService As System.Windows.Forms.RadioButton
    Friend WithEvents radBusiness As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSid As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
