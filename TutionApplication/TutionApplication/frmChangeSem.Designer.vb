<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeSem
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.ComboBox1.Location = New System.Drawing.Point(98, 22)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(131, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"2", "3", "4"})
        Me.ComboBox2.Location = New System.Drawing.Point(586, 12)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(131, 21)
        Me.ComboBox2.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(391, 220)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 38)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = ">>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(391, 274)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(63, 38)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "<<"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckedListBox2.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckedListBox2.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.CheckedListBox2.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Location = New System.Drawing.Point(493, 67)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(388, 650)
        Me.CheckedListBox2.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label1.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label1.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label1.Location = New System.Drawing.Point(14, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "From Sem"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label2.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label2.Location = New System.Drawing.Point(518, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "To Sem"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(391, 332)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(63, 38)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Trnasfer"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.BackColor = System.Drawing.Color.White
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckedListBox1.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckedListBox1.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.CheckedListBox1.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(12, 67)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(344, 654)
        Me.CheckedListBox1.TabIndex = 10
        '
        'frmChangeSem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.TutionApplication.My.MySettings.Default.backcolor
        Me.ClientSize = New System.Drawing.Size(1276, 776)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckedListBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.TutionApplication.My.MySettings.Default, "backcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Name = "frmChangeSem"
        Me.Text = "frmChangeForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CheckedListBox2 As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
End Class
