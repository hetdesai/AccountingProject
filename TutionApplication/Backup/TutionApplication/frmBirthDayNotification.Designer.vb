<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBirthDayNotification
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.MaskedTextBox2 = New System.Windows.Forms.MaskedTextBox
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(304, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "BirthDay Notification"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.MaskedTextBox2)
        Me.Panel1.Controls.Add(Me.MaskedTextBox1)
        Me.Panel1.Controls.Add(Me.RadioButton4)
        Me.Panel1.Controls.Add(Me.RadioButton3)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(12, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(642, 259)
        Me.Panel1.TabIndex = 1
        '
        'MaskedTextBox2
        '
        Me.MaskedTextBox2.Location = New System.Drawing.Point(253, 185)
        Me.MaskedTextBox2.Mask = "00/00/0000"
        Me.MaskedTextBox2.Name = "MaskedTextBox2"
        Me.MaskedTextBox2.Size = New System.Drawing.Size(100, 26)
        Me.MaskedTextBox2.TabIndex = 6
        Me.MaskedTextBox2.ValidatingType = GetType(Date)
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Location = New System.Drawing.Point(118, 185)
        Me.MaskedTextBox1.Mask = "00/00/0000"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(100, 26)
        Me.MaskedTextBox1.TabIndex = 5
        Me.MaskedTextBox1.ValidatingType = GetType(Date)
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RadioButton4.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.RadioButton4.Location = New System.Drawing.Point(118, 139)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(165, 24)
        Me.RadioButton4.TabIndex = 4
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Betwwen Two Days"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RadioButton3.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.RadioButton3.Location = New System.Drawing.Point(115, 99)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(108, 24)
        Me.RadioButton3.TabIndex = 3
        Me.RadioButton3.Text = "Next Month" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RadioButton2.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.RadioButton2.Location = New System.Drawing.Point(115, 64)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(105, 24)
        Me.RadioButton2.TabIndex = 2
        Me.RadioButton2.Text = "This Month"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RadioButton1.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.RadioButton1.Location = New System.Drawing.Point(115, 27)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(101, 24)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "This Week"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label2.Location = New System.Drawing.Point(13, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Your Choice"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(325, 313)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 29)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmBirthDayNotification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.TutionApplication.My.MySettings.Default.backcolor
        Me.ClientSize = New System.Drawing.Size(805, 353)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.TutionApplication.My.MySettings.Default, "backcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmBirthDayNotification"
        Me.Text = "frmBirthDayNotification"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MaskedTextBox2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
End Class
