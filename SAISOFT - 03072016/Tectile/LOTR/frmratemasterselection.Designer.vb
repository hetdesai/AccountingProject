<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmratemasterselection
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CustomeChecklistbox5 = New Tectile.CustomeChecklistbox()
        Me.CustomeChecklistbox2 = New Tectile.CustomeChecklistbox()
        Me.CustomeChecklistbox1 = New Tectile.CustomeChecklistbox()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(818, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(176, 48)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "HOME Key:Clear Search" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ENTER:To Select " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DOWN:To enter list" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(90, 14)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(50, 16)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "Group"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(395, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Account"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(687, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Master"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(252, 512)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 35)
        Me.Button1.TabIndex = 43
        Me.Button1.Text = "&OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(359, 512)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 35)
        Me.Button2.TabIndex = 44
        Me.Button2.Text = "EXIT"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CustomeChecklistbox5
        '
        Me.CustomeChecklistbox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomeChecklistbox5.Location = New System.Drawing.Point(634, 33)
        Me.CustomeChecklistbox5.Name = "CustomeChecklistbox5"
        Me.CustomeChecklistbox5.NextControl = Nothing
        Me.CustomeChecklistbox5.Size = New System.Drawing.Size(178, 461)
        Me.CustomeChecklistbox5.TabIndex = 26
        '
        'CustomeChecklistbox2
        '
        Me.CustomeChecklistbox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomeChecklistbox2.Location = New System.Drawing.Point(252, 33)
        Me.CustomeChecklistbox2.Name = "CustomeChecklistbox2"
        Me.CustomeChecklistbox2.NextControl = Nothing
        Me.CustomeChecklistbox2.Size = New System.Drawing.Size(367, 461)
        Me.CustomeChecklistbox2.TabIndex = 25
        '
        'CustomeChecklistbox1
        '
        Me.CustomeChecklistbox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomeChecklistbox1.Location = New System.Drawing.Point(3, 33)
        Me.CustomeChecklistbox1.Name = "CustomeChecklistbox1"
        Me.CustomeChecklistbox1.NextControl = Nothing
        Me.CustomeChecklistbox1.Size = New System.Drawing.Size(243, 461)
        Me.CustomeChecklistbox1.TabIndex = 24
        '
        'frmratemasterselection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.Tectile.My.MySettings.Default.tranbkcolor
        Me.ClientSize = New System.Drawing.Size(1200, 595)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.CustomeChecklistbox5)
        Me.Controls.Add(Me.CustomeChecklistbox2)
        Me.Controls.Add(Me.CustomeChecklistbox1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tectile.My.MySettings.Default, "tranbkcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.KeyPreview = True
        Me.Name = "frmratemasterselection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rate Master Selection"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CustomeChecklistbox5 As Tectile.CustomeChecklistbox
    Friend WithEvents CustomeChecklistbox2 As Tectile.CustomeChecklistbox
    Friend WithEvents CustomeChecklistbox1 As Tectile.CustomeChecklistbox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
