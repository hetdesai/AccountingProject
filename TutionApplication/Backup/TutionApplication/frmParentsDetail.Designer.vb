<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParentsDetail
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSid = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSname = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.radBusiness = New System.Windows.Forms.RadioButton
        Me.radService = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.radMHouse = New System.Windows.Forms.RadioButton
        Me.radMService = New System.Windows.Forms.RadioButton
        Me.radMbusiness = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtFdetail = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtFAddress = New System.Windows.Forms.TextBox
        Me.txtMaddress = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtMdetail = New System.Windows.Forms.TextBox
        Me.txtMName = New System.Windows.Forms.TextBox
        Me.txtFName = New System.Windows.Forms.TextBox
        Me.txtSuname = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtFContact = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(369, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Parents Detail"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label2.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label2.Location = New System.Drawing.Point(24, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Student Id"
        '
        'txtSid
        '
        Me.txtSid.Location = New System.Drawing.Point(102, 52)
        Me.txtSid.Name = "txtSid"
        Me.txtSid.ReadOnly = True
        Me.txtSid.Size = New System.Drawing.Size(52, 20)
        Me.txtSid.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label3.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label3.Location = New System.Drawing.Point(169, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Student Name"
        '
        'txtSname
        '
        Me.txtSname.Location = New System.Drawing.Point(259, 49)
        Me.txtSname.Name = "txtSname"
        Me.txtSname.Size = New System.Drawing.Size(232, 20)
        Me.txtSname.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(417, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Mother"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(180, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 18)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Father"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(534, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Surname"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label7.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label7.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label7.Location = New System.Drawing.Point(12, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 18)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Occupation"
        '
        'radBusiness
        '
        Me.radBusiness.AutoSize = True
        Me.radBusiness.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.radBusiness.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.radBusiness.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.radBusiness.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.radBusiness.Location = New System.Drawing.Point(142, 16)
        Me.radBusiness.Name = "radBusiness"
        Me.radBusiness.Size = New System.Drawing.Size(95, 22)
        Me.radBusiness.TabIndex = 3
        Me.radBusiness.TabStop = True
        Me.radBusiness.Text = "Business"
        Me.radBusiness.UseVisualStyleBackColor = True
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
        Me.radService.TabIndex = 2
        Me.radService.TabStop = True
        Me.radService.Text = "Service"
        Me.radService.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.radService)
        Me.Panel1.Controls.Add(Me.radBusiness)
        Me.Panel1.Location = New System.Drawing.Point(90, 92)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(232, 49)
        Me.Panel1.TabIndex = 15
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.radMHouse)
        Me.Panel2.Controls.Add(Me.radMService)
        Me.Panel2.Controls.Add(Me.radMbusiness)
        Me.Panel2.Location = New System.Drawing.Point(336, 92)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(235, 46)
        Me.Panel2.TabIndex = 16
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
        Me.radMHouse.TabIndex = 6
        Me.radMHouse.TabStop = True
        Me.radMHouse.Text = "Housewife"
        Me.radMHouse.UseVisualStyleBackColor = True
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
        Me.radMService.TabIndex = 4
        Me.radMService.TabStop = True
        Me.radMService.Text = "Service"
        Me.radMService.UseVisualStyleBackColor = True
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
        Me.radMbusiness.TabIndex = 5
        Me.radMbusiness.TabStop = True
        Me.radMbusiness.Text = "Business"
        Me.radMbusiness.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label9.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label9.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label9.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label9.Location = New System.Drawing.Point(12, 166)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 18)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Detail"
        '
        'txtFdetail
        '
        Me.txtFdetail.Location = New System.Drawing.Point(90, 163)
        Me.txtFdetail.Name = "txtFdetail"
        Me.txtFdetail.Size = New System.Drawing.Size(232, 20)
        Me.txtFdetail.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label10.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label10.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label10.Location = New System.Drawing.Point(12, 227)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 18)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Address"
        '
        'txtFAddress
        '
        Me.txtFAddress.Location = New System.Drawing.Point(90, 206)
        Me.txtFAddress.Multiline = True
        Me.txtFAddress.Name = "txtFAddress"
        Me.txtFAddress.Size = New System.Drawing.Size(232, 58)
        Me.txtFAddress.TabIndex = 9
        '
        'txtMaddress
        '
        Me.txtMaddress.Location = New System.Drawing.Point(336, 206)
        Me.txtMaddress.Multiline = True
        Me.txtMaddress.Name = "txtMaddress"
        Me.txtMaddress.Size = New System.Drawing.Size(235, 58)
        Me.txtMaddress.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label11.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label11.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label11.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label11.Location = New System.Drawing.Point(12, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 18)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Name"
        '
        'txtMdetail
        '
        Me.txtMdetail.Location = New System.Drawing.Point(336, 163)
        Me.txtMdetail.Name = "txtMdetail"
        Me.txtMdetail.Size = New System.Drawing.Size(232, 20)
        Me.txtMdetail.TabIndex = 8
        '
        'txtMName
        '
        Me.txtMName.Location = New System.Drawing.Point(336, 46)
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Size = New System.Drawing.Size(235, 20)
        Me.txtMName.TabIndex = 1
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(90, 46)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(235, 20)
        Me.txtFName.TabIndex = 0
        '
        'txtSuname
        '
        Me.txtSuname.Location = New System.Drawing.Point(612, 12)
        Me.txtSuname.Name = "txtSuname"
        Me.txtSuname.Size = New System.Drawing.Size(235, 20)
        Me.txtSuname.TabIndex = 27
        Me.txtSuname.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label13.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label13.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label13.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label13.Location = New System.Drawing.Point(12, 282)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 18)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Contact No"
        '
        'txtFContact
        '
        Me.txtFContact.Location = New System.Drawing.Point(90, 280)
        Me.txtFContact.Name = "txtFContact"
        Me.txtFContact.Size = New System.Drawing.Size(114, 20)
        Me.txtFContact.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(374, 466)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "&SAVE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(536, 466)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "&CANCEL"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(617, 466)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 32
        Me.Button3.Text = "EXIT"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(455, 466)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "&New Entry"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(293, 466)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 51
        Me.Button5.Text = "&BACK"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtFContact)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.txtFName)
        Me.Panel3.Controls.Add(Me.txtMName)
        Me.Panel3.Controls.Add(Me.txtMaddress)
        Me.Panel3.Controls.Add(Me.Label11)
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
        Me.Panel3.Location = New System.Drawing.Point(12, 76)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(622, 366)
        Me.Panel3.TabIndex = 52
        '
        'frmParentsDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.TutionApplication.My.MySettings.Default.backcolor
        Me.ClientSize = New System.Drawing.Size(972, 663)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtSuname)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.TutionApplication.My.MySettings.Default, "backcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.KeyPreview = True
        Me.Name = "frmParentsDetail"
        Me.Text = "frmParentsDetail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSid As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSname As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents radBusiness As System.Windows.Forms.RadioButton
    Friend WithEvents radService As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents radMHouse As System.Windows.Forms.RadioButton
    Friend WithEvents radMService As System.Windows.Forms.RadioButton
    Friend WithEvents radMbusiness As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFdetail As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtFAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtMaddress As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMdetail As System.Windows.Forms.TextBox
    Friend WithEvents txtMName As System.Windows.Forms.TextBox
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents txtSuname As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFContact As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
