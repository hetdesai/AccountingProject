<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSchoolMaster
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
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(46, 100)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(212, 100)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label1.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label1.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label1.Location = New System.Drawing.Point(19, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "School Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.TutionApplication.My.MySettings.Default, "Lblfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label2.Font = Global.TutionApplication.My.MySettings.Default.Lblfont
        Me.Label2.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label2.Location = New System.Drawing.Point(19, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "School Name"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(103, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(40, 20)
        Me.TextBox1.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(103, 51)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(106, 20)
        Me.TextBox2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(351, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "School Master"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(127, 100)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Add New"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(409, 37)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(288, 354)
        Me.DataGridView1.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(353, 144)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'frmSchoolMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.TutionApplication.My.MySettings.Default.backcolor
        Me.ClientSize = New System.Drawing.Size(802, 537)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label3)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.TutionApplication.My.MySettings.Default, "backcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Name = "frmSchoolMaster"
        Me.Text = " "
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
