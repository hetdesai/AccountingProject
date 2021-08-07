<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVatSelection
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
        Me.MaskedTextBox2 = New System.Windows.Forms.MaskedTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dateyl1 = New System.Windows.Forms.Label
        Me.companyname1 = New System.Windows.Forms.Label
        Me.dateyf1 = New System.Windows.Forms.Label
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MaskedTextBox2
        '
        Me.MaskedTextBox2.Culture = New System.Globalization.CultureInfo("")
        Me.MaskedTextBox2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.MaskedTextBox2.Location = New System.Drawing.Point(214, 46)
        Me.MaskedTextBox2.Mask = "00/00/0000"
        Me.MaskedTextBox2.Name = "MaskedTextBox2"
        Me.MaskedTextBox2.Size = New System.Drawing.Size(82, 20)
        Me.MaskedTextBox2.TabIndex = 1
        Me.MaskedTextBox2.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(179, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 18)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "TO"
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Culture = New System.Globalization.CultureInfo("")
        Me.MaskedTextBox1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.MaskedTextBox1.Location = New System.Drawing.Point(84, 46)
        Me.MaskedTextBox1.Mask = "00/00/0000"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(82, 20)
        Me.MaskedTextBox1.TabIndex = 0
        Me.MaskedTextBox1.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 18)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "FROM"
        '
        'Panel1
        '
        Me.Panel1.BackColor = Global.Tectile.My.MySettings.Default.Comcolor
        Me.Panel1.Controls.Add(Me.dateyl1)
        Me.Panel1.Controls.Add(Me.companyname1)
        Me.Panel1.Controls.Add(Me.dateyf1)
        Me.Panel1.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tectile.My.MySettings.Default, "Comcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(810, 28)
        Me.Panel1.TabIndex = 69
        '
        'dateyl1
        '
        Me.dateyl1.AutoSize = True
        Me.dateyl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateyl1.ForeColor = System.Drawing.Color.White
        Me.dateyl1.Location = New System.Drawing.Point(747, 7)
        Me.dateyl1.Name = "dateyl1"
        Me.dateyl1.Size = New System.Drawing.Size(52, 13)
        Me.dateyl1.TabIndex = 2
        Me.dateyl1.Text = "Label10"
        '
        'companyname1
        '
        Me.companyname1.AutoSize = True
        Me.companyname1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyname1.ForeColor = System.Drawing.Color.White
        Me.companyname1.Location = New System.Drawing.Point(383, 5)
        Me.companyname1.Name = "companyname1"
        Me.companyname1.Size = New System.Drawing.Size(45, 13)
        Me.companyname1.TabIndex = 1
        Me.companyname1.Text = "Label9"
        '
        'dateyf1
        '
        Me.dateyf1.AutoSize = True
        Me.dateyf1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateyf1.ForeColor = System.Drawing.Color.White
        Me.dateyf1.Location = New System.Drawing.Point(15, 7)
        Me.dateyf1.Name = "dateyf1"
        Me.dateyf1.Size = New System.Drawing.Size(45, 13)
        Me.dateyf1.TabIndex = 0
        Me.dateyf1.Text = "Label8"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(18, 72)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(328, 379)
        Me.CheckedListBox1.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(408, 478)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 40)
        Me.Button2.TabIndex = 72
        Me.Button2.Text = "EXIT"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(327, 478)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 40)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "&PRINT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Location = New System.Drawing.Point(352, 72)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(328, 379)
        Me.CheckedListBox2.TabIndex = 3
        '
        'frmVatSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 530)
        Me.Controls.Add(Me.CheckedListBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MaskedTextBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MaskedTextBox1)
        Me.Controls.Add(Me.Label4)
        Me.KeyPreview = True
        Me.Name = "frmVatSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmVatSelection"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MaskedTextBox2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dateyl1 As System.Windows.Forms.Label
    Friend WithEvents companyname1 As System.Windows.Forms.Label
    Friend WithEvents dateyf1 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckedListBox2 As System.Windows.Forms.CheckedListBox
End Class
