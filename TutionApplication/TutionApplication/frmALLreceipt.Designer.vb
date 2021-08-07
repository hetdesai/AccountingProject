<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmALLreceipt
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Receipt1 = New TutionApplication.Receipt
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = 0
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 84)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ReportSource = Me.Receipt1
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1276, 692)
        Me.CrystalReportViewer1.TabIndex = 7
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(98, 58)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(51, 20)
        Me.TextBox1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.TutionApplication.My.MySettings.Default, "lblcol", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label1.ForeColor = Global.TutionApplication.My.MySettings.Default.lblcol
        Me.Label1.Location = New System.Drawing.Point(23, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Receipt No"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(168, 50)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 28)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmALLreceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.TutionApplication.My.MySettings.Default.backcolor
        Me.ClientSize = New System.Drawing.Size(1276, 776)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.TutionApplication.My.MySettings.Default, "backcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Name = "frmALLreceipt"
        Me.Text = "frmALLreceipt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Receipt1 As TutionApplication.Receipt
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
