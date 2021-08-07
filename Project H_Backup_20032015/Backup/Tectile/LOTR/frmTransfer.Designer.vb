<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransfer
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
        Me.maskbill1 = New System.Windows.Forms.MaskedTextBox
        Me.maskbill2 = New System.Windows.Forms.MaskedTextBox
        Me.txtBKNAME1 = New System.Windows.Forms.TextBox
        Me.txtMaxBill = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtREGCODE1 = New System.Windows.Forms.TextBox
        Me.maskbill3 = New System.Windows.Forms.MaskedTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.maskbill4 = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(21, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(18, 197)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "No Of Detail Entry Per Bill"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(508, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "BKCODE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(18, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "BKName"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(174, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "To"
        '
        'maskbill1
        '
        Me.maskbill1.Culture = New System.Globalization.CultureInfo("")
        Me.maskbill1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.maskbill1.Location = New System.Drawing.Point(66, 57)
        Me.maskbill1.Mask = "00/00/0000"
        Me.maskbill1.Name = "maskbill1"
        Me.maskbill1.Size = New System.Drawing.Size(92, 20)
        Me.maskbill1.TabIndex = 5
        Me.maskbill1.ValidatingType = GetType(Date)
        '
        'maskbill2
        '
        Me.maskbill2.Culture = New System.Globalization.CultureInfo("")
        Me.maskbill2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.maskbill2.Location = New System.Drawing.Point(211, 57)
        Me.maskbill2.Mask = "00/00/0000"
        Me.maskbill2.Name = "maskbill2"
        Me.maskbill2.Size = New System.Drawing.Size(92, 20)
        Me.maskbill2.TabIndex = 6
        Me.maskbill2.ValidatingType = GetType(Date)
        '
        'txtBKNAME1
        '
        Me.txtBKNAME1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtBKNAME1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtBKNAME1.Location = New System.Drawing.Point(151, 157)
        Me.txtBKNAME1.Name = "txtBKNAME1"
        Me.txtBKNAME1.Size = New System.Drawing.Size(351, 20)
        Me.txtBKNAME1.TabIndex = 7
        '
        'txtMaxBill
        '
        Me.txtMaxBill.Location = New System.Drawing.Point(151, 194)
        Me.txtMaxBill.Name = "txtMaxBill"
        Me.txtMaxBill.Size = New System.Drawing.Size(351, 20)
        Me.txtMaxBill.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(255, 402)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(395, 34)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtREGCODE1
        '
        Me.txtREGCODE1.Location = New System.Drawing.Point(565, 157)
        Me.txtREGCODE1.Name = "txtREGCODE1"
        Me.txtREGCODE1.Size = New System.Drawing.Size(187, 20)
        Me.txtREGCODE1.TabIndex = 10
        '
        'maskbill3
        '
        Me.maskbill3.Culture = New System.Globalization.CultureInfo("")
        Me.maskbill3.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.maskbill3.Location = New System.Drawing.Point(482, 57)
        Me.maskbill3.Mask = "00/00/0000"
        Me.maskbill3.Name = "maskbill3"
        Me.maskbill3.Size = New System.Drawing.Size(92, 20)
        Me.maskbill3.TabIndex = 11
        Me.maskbill3.ValidatingType = GetType(Date)
        Me.maskbill3.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(319, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Bill DT"
        '
        'maskbill4
        '
        Me.maskbill4.Culture = New System.Globalization.CultureInfo("")
        Me.maskbill4.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.maskbill4.Location = New System.Drawing.Point(364, 57)
        Me.maskbill4.Mask = "00/00/0000"
        Me.maskbill4.Name = "maskbill4"
        Me.maskbill4.Size = New System.Drawing.Size(92, 20)
        Me.maskbill4.TabIndex = 13
        Me.maskbill4.ValidatingType = GetType(Date)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(21, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "From Invoice"
        '
        'TextBox1
        '
        Me.TextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox1.Location = New System.Drawing.Point(95, 98)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(99, 20)
        Me.TextBox1.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(208, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "To Invoice"
        '
        'TextBox2
        '
        Me.TextBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TextBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox2.Location = New System.Drawing.Point(272, 98)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(99, 20)
        Me.TextBox2.TabIndex = 17
        '
        'frmTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Tectile.My.Resources.Resources.image1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(816, 570)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.maskbill4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.maskbill3)
        Me.Controls.Add(Me.txtREGCODE1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtMaxBill)
        Me.Controls.Add(Me.txtBKNAME1)
        Me.Controls.Add(Me.maskbill2)
        Me.Controls.Add(Me.maskbill1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.name = "frmTransfer"
        Me.Text = "frmTransfer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents maskbill1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskbill2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtBKNAME1 As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxBill As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtREGCODE1 As System.Windows.Forms.TextBox
    Friend WithEvents maskbill3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents maskbill4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
End Class
