<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFee
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.TextBox12 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextBox13 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(381, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FEE DETAILS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label2.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label2.Location = New System.Drawing.Point(301, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "FirstName"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label3.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label3.Location = New System.Drawing.Point(91, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Surname"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label4.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label4.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label4.Location = New System.Drawing.Point(533, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "MiddleName"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label5.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label5.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label5.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label5.Location = New System.Drawing.Point(35, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Type"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RadioButton1.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RadioButton1.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.RadioButton1.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.RadioButton1.Location = New System.Drawing.Point(122, 224)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(67, 17)
        Me.RadioButton1.TabIndex = 5
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Deposite"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RadioButton2.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RadioButton2.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.RadioButton2.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.RadioButton2.Location = New System.Drawing.Point(122, 247)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(70, 17)
        Me.RadioButton2.TabIndex = 6
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Withdraw"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label6.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label6.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label6.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label6.Location = New System.Drawing.Point(35, 286)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Amount"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label7.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label7.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label7.Location = New System.Drawing.Point(35, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Fee Remainig"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(257, 114)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(155, 20)
        Me.TextBox1.TabIndex = 9
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(37, 114)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(155, 20)
        Me.TextBox2.TabIndex = 10
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(494, 114)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(155, 20)
        Me.TextBox3.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label8.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label8.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label8.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label8.Location = New System.Drawing.Point(35, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "IT Id"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(104, 69)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(36, 20)
        Me.TextBox4.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label9.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label9.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label9.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label9.Location = New System.Drawing.Point(432, 151)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Standard"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(503, 148)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(54, 20)
        Me.TextBox5.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label10.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label10.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label10.Location = New System.Drawing.Point(563, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Div"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label11.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label11.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label11.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label11.Location = New System.Drawing.Point(35, 151)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "School"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(607, 146)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(62, 20)
        Me.TextBox6.TabIndex = 18
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(122, 146)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(261, 20)
        Me.TextBox7.TabIndex = 19
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(122, 179)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(128, 20)
        Me.TextBox8.TabIndex = 20
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(122, 283)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(102, 20)
        Me.TextBox9.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(363, 423)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 30)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "&OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(455, 423)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(76, 30)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "EXIT"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label12.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label12.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label12.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label12.Location = New System.Drawing.Point(161, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Roll No"
        Me.Label12.Visible = False
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(223, 69)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(36, 20)
        Me.TextBox10.TabIndex = 25
        Me.TextBox10.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label13.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label13.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label13.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label13.Location = New System.Drawing.Point(276, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Batch"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(319, 69)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(36, 20)
        Me.TextBox11.TabIndex = 27
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(281, 423)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(76, 30)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "&FIND"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label14.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label14.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label14.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label14.Location = New System.Drawing.Point(35, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Recipt No"
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(104, 44)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(36, 20)
        Me.TextBox12.TabIndex = 30
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label15.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label15.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label15.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label15.Location = New System.Drawing.Point(161, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(28, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Sem"
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(223, 44)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(36, 20)
        Me.TextBox13.TabIndex = 32
        '
        'frmFee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.TutionApplication.My.MySettings.Default.backcolor
        Me.ClientSize = New System.Drawing.Size(813, 543)
        Me.Controls.Add(Me.TextBox13)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TextBox12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox11)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextBox10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.TutionApplication.My.MySettings.Default, "backcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Name = "frmFee"
        Me.Text = "frmFee"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
End Class
