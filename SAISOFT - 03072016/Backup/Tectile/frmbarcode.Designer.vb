<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmbarcode
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
        Me.ctrBarcode = New BarcodeLib.Barcode.Linear.LinearWinForm
        Me.ctrSymbology = New System.Windows.Forms.ComboBox
        Me.ctrUOM = New System.Windows.Forms.ComboBox
        Me.ctrData = New System.Windows.Forms.TextBox
        Me.ctrSData = New System.Windows.Forms.TextBox
        Me.ctrAddCheckSum = New System.Windows.Forms.ComboBox
        Me.ctrRotate = New System.Windows.Forms.ComboBox
        Me.ctrFormat = New System.Windows.Forms.ComboBox
        Me.ctrCodabarStart = New System.Windows.Forms.ComboBox
        Me.ctrCodabarStop = New System.Windows.Forms.ComboBox
        Me.ctrUPCENumber = New System.Windows.Forms.ComboBox
        Me.ctrBearerBars = New System.Windows.Forms.ComboBox
        Me.ctrShowText = New System.Windows.Forms.ComboBox
        Me.ctrDrawBarcode = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.ctrBarWidth = New System.Windows.Forms.TextBox
        Me.ctrBarHeight = New System.Windows.Forms.TextBox
        Me.ctrLeftMargin = New System.Windows.Forms.TextBox
        Me.ctrTopMargin = New System.Windows.Forms.TextBox
        Me.ctrResolution = New System.Windows.Forms.TextBox
        Me.ctrTextFontBrowse = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.ctrTextFont = New System.Windows.Forms.TextBox
        Me.ctlFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ctrSaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.ctrFontDialog = New System.Windows.Forms.FontDialog
        Me.SuspendLayout()
        '
        'ctrBarcode
        '
        Me.ctrBarcode.AddCheckSum = False
        Me.ctrBarcode.BarHeight = 80.0!
        Me.ctrBarcode.BarWidth = 1.0!
        Me.ctrBarcode.BearerBars = BarcodeLib.Barcode.Linear.BearerBar.None
        Me.ctrBarcode.CodabarStartChar = BarcodeLib.Barcode.Linear.CodabarStartStopChar.A
        Me.ctrBarcode.CodabarStopChar = BarcodeLib.Barcode.Linear.CodabarStartStopChar.A
        Me.ctrBarcode.Data = ""
        Me.ctrBarcode.Format = System.Drawing.Imaging.ImageFormat.Png
        Me.ctrBarcode.LeftMargin = 10.0!
        Me.ctrBarcode.Location = New System.Drawing.Point(71, 31)
        Me.ctrBarcode.N = 2.0!
        Me.ctrBarcode.Name = "ctrBarcode"
        Me.ctrBarcode.Resolution = 96
        Me.ctrBarcode.Rotate = BarcodeLib.Barcode.Linear.RotateOrientation.BottomFacingDown
        Me.ctrBarcode.SData = ""
        Me.ctrBarcode.ShowText = True
        Me.ctrBarcode.Size = New System.Drawing.Size(274, 140)
        Me.ctrBarcode.TabIndex = 0
        Me.ctrBarcode.TextFont = New System.Drawing.Font("Arial", 9.0!)
        Me.ctrBarcode.TopMargin = 10.0!
        Me.ctrBarcode.Type = BarcodeLib.Barcode.Linear.BarcodeType.CODE128
        Me.ctrBarcode.UOM = BarcodeLib.Barcode.Linear.UnitOfMeasure.Pixel
        Me.ctrBarcode.UPCENumberSystem = 0
        '
        'ctrSymbology
        '
        Me.ctrSymbology.FormattingEnabled = True
        Me.ctrSymbology.Location = New System.Drawing.Point(135, 215)
        Me.ctrSymbology.Name = "ctrSymbology"
        Me.ctrSymbology.Size = New System.Drawing.Size(250, 21)
        Me.ctrSymbology.TabIndex = 1
        '
        'ctrUOM
        '
        Me.ctrUOM.FormattingEnabled = True
        Me.ctrUOM.Location = New System.Drawing.Point(480, 188)
        Me.ctrUOM.Name = "ctrUOM"
        Me.ctrUOM.Size = New System.Drawing.Size(207, 21)
        Me.ctrUOM.TabIndex = 2
        '
        'ctrData
        '
        Me.ctrData.Location = New System.Drawing.Point(135, 242)
        Me.ctrData.Name = "ctrData"
        Me.ctrData.Size = New System.Drawing.Size(250, 20)
        Me.ctrData.TabIndex = 3
        '
        'ctrSData
        '
        Me.ctrSData.Location = New System.Drawing.Point(135, 268)
        Me.ctrSData.Name = "ctrSData"
        Me.ctrSData.Size = New System.Drawing.Size(250, 20)
        Me.ctrSData.TabIndex = 4
        '
        'ctrAddCheckSum
        '
        Me.ctrAddCheckSum.FormattingEnabled = True
        Me.ctrAddCheckSum.Location = New System.Drawing.Point(135, 294)
        Me.ctrAddCheckSum.Name = "ctrAddCheckSum"
        Me.ctrAddCheckSum.Size = New System.Drawing.Size(250, 21)
        Me.ctrAddCheckSum.TabIndex = 5
        '
        'ctrRotate
        '
        Me.ctrRotate.FormattingEnabled = True
        Me.ctrRotate.Location = New System.Drawing.Point(135, 321)
        Me.ctrRotate.Name = "ctrRotate"
        Me.ctrRotate.Size = New System.Drawing.Size(250, 21)
        Me.ctrRotate.TabIndex = 6
        '
        'ctrFormat
        '
        Me.ctrFormat.FormattingEnabled = True
        Me.ctrFormat.Location = New System.Drawing.Point(135, 353)
        Me.ctrFormat.Name = "ctrFormat"
        Me.ctrFormat.Size = New System.Drawing.Size(250, 21)
        Me.ctrFormat.TabIndex = 7
        '
        'ctrCodabarStart
        '
        Me.ctrCodabarStart.FormattingEnabled = True
        Me.ctrCodabarStart.Location = New System.Drawing.Point(135, 491)
        Me.ctrCodabarStart.Name = "ctrCodabarStart"
        Me.ctrCodabarStart.Size = New System.Drawing.Size(250, 21)
        Me.ctrCodabarStart.TabIndex = 8
        '
        'ctrCodabarStop
        '
        Me.ctrCodabarStop.FormattingEnabled = True
        Me.ctrCodabarStop.Location = New System.Drawing.Point(135, 518)
        Me.ctrCodabarStop.Name = "ctrCodabarStop"
        Me.ctrCodabarStop.Size = New System.Drawing.Size(250, 21)
        Me.ctrCodabarStop.TabIndex = 9
        '
        'ctrUPCENumber
        '
        Me.ctrUPCENumber.FormattingEnabled = True
        Me.ctrUPCENumber.Location = New System.Drawing.Point(135, 545)
        Me.ctrUPCENumber.Name = "ctrUPCENumber"
        Me.ctrUPCENumber.Size = New System.Drawing.Size(250, 21)
        Me.ctrUPCENumber.TabIndex = 10
        '
        'ctrBearerBars
        '
        Me.ctrBearerBars.FormattingEnabled = True
        Me.ctrBearerBars.Location = New System.Drawing.Point(480, 358)
        Me.ctrBearerBars.Name = "ctrBearerBars"
        Me.ctrBearerBars.Size = New System.Drawing.Size(207, 21)
        Me.ctrBearerBars.TabIndex = 11
        '
        'ctrShowText
        '
        Me.ctrShowText.FormattingEnabled = True
        Me.ctrShowText.Location = New System.Drawing.Point(480, 385)
        Me.ctrShowText.Name = "ctrShowText"
        Me.ctrShowText.Size = New System.Drawing.Size(207, 21)
        Me.ctrShowText.TabIndex = 12
        '
        'ctrDrawBarcode
        '
        Me.ctrDrawBarcode.Location = New System.Drawing.Point(519, 64)
        Me.ctrDrawBarcode.Name = "ctrDrawBarcode"
        Me.ctrDrawBarcode.Size = New System.Drawing.Size(132, 27)
        Me.ctrDrawBarcode.TabIndex = 13
        Me.ctrDrawBarcode.Text = "ctrDrawBarcode"
        Me.ctrDrawBarcode.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(519, 104)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(132, 27)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(519, 144)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(132, 27)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ctrBarWidth
        '
        Me.ctrBarWidth.Location = New System.Drawing.Point(480, 226)
        Me.ctrBarWidth.Name = "ctrBarWidth"
        Me.ctrBarWidth.Size = New System.Drawing.Size(207, 20)
        Me.ctrBarWidth.TabIndex = 16
        '
        'ctrBarHeight
        '
        Me.ctrBarHeight.Location = New System.Drawing.Point(480, 252)
        Me.ctrBarHeight.Name = "ctrBarHeight"
        Me.ctrBarHeight.Size = New System.Drawing.Size(207, 20)
        Me.ctrBarHeight.TabIndex = 17
        '
        'ctrLeftMargin
        '
        Me.ctrLeftMargin.Location = New System.Drawing.Point(480, 279)
        Me.ctrLeftMargin.Name = "ctrLeftMargin"
        Me.ctrLeftMargin.Size = New System.Drawing.Size(207, 20)
        Me.ctrLeftMargin.TabIndex = 18
        '
        'ctrTopMargin
        '
        Me.ctrTopMargin.Location = New System.Drawing.Point(480, 306)
        Me.ctrTopMargin.Name = "ctrTopMargin"
        Me.ctrTopMargin.Size = New System.Drawing.Size(207, 20)
        Me.ctrTopMargin.TabIndex = 19
        '
        'ctrResolution
        '
        Me.ctrResolution.Location = New System.Drawing.Point(480, 332)
        Me.ctrResolution.Name = "ctrResolution"
        Me.ctrResolution.Size = New System.Drawing.Size(207, 20)
        Me.ctrResolution.TabIndex = 20
        '
        'ctrTextFontBrowse
        '
        Me.ctrTextFontBrowse.Location = New System.Drawing.Point(638, 423)
        Me.ctrTextFontBrowse.Name = "ctrTextFontBrowse"
        Me.ctrTextFontBrowse.Size = New System.Drawing.Size(49, 27)
        Me.ctrTextFontBrowse.TabIndex = 21
        Me.ctrTextFontBrowse.Text = "Button4"
        Me.ctrTextFontBrowse.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(74, 222)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(420, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Label3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(74, 271)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(74, 302)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Label5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(74, 324)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(74, 356)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Label7"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(420, 309)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Label8"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(420, 335)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Label9"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(420, 361)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Label10"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(420, 388)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Label11"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(420, 282)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Label12"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(420, 255)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Label13"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(420, 229)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Label14"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(68, 548)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Label15"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(68, 521)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 13)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Label16"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(68, 494)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Label17"
        '
        'ctrTextFont
        '
        Me.ctrTextFont.Location = New System.Drawing.Point(480, 430)
        Me.ctrTextFont.Name = "ctrTextFont"
        Me.ctrTextFont.Size = New System.Drawing.Size(152, 20)
        Me.ctrTextFont.TabIndex = 39
        '
        'ctlFileDialog
        '
        Me.ctlFileDialog.FileName = "OpenFileDialog1"
        '
        'ctrSaveFileDialog
        '
        '
        'frmbarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 572)
        Me.Controls.Add(Me.ctrTextFont)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ctrTextFontBrowse)
        Me.Controls.Add(Me.ctrResolution)
        Me.Controls.Add(Me.ctrTopMargin)
        Me.Controls.Add(Me.ctrLeftMargin)
        Me.Controls.Add(Me.ctrBarHeight)
        Me.Controls.Add(Me.ctrBarWidth)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ctrDrawBarcode)
        Me.Controls.Add(Me.ctrShowText)
        Me.Controls.Add(Me.ctrBearerBars)
        Me.Controls.Add(Me.ctrUPCENumber)
        Me.Controls.Add(Me.ctrCodabarStop)
        Me.Controls.Add(Me.ctrCodabarStart)
        Me.Controls.Add(Me.ctrFormat)
        Me.Controls.Add(Me.ctrRotate)
        Me.Controls.Add(Me.ctrAddCheckSum)
        Me.Controls.Add(Me.ctrSData)
        Me.Controls.Add(Me.ctrData)
        Me.Controls.Add(Me.ctrUOM)
        Me.Controls.Add(Me.ctrSymbology)
        Me.Controls.Add(Me.ctrBarcode)
        Me.Name = "frmbarcode"
        Me.Text = "frmbarcode"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ctrBarcode As BarcodeLib.Barcode.Linear.LinearWinForm
    Friend WithEvents ctrSymbology As System.Windows.Forms.ComboBox
    Friend WithEvents ctrUOM As System.Windows.Forms.ComboBox
    Friend WithEvents ctrData As System.Windows.Forms.TextBox
    Friend WithEvents ctrSData As System.Windows.Forms.TextBox
    Friend WithEvents ctrAddCheckSum As System.Windows.Forms.ComboBox
    Friend WithEvents ctrRotate As System.Windows.Forms.ComboBox
    Friend WithEvents ctrFormat As System.Windows.Forms.ComboBox
    Friend WithEvents ctrCodabarStart As System.Windows.Forms.ComboBox
    Friend WithEvents ctrCodabarStop As System.Windows.Forms.ComboBox
    Friend WithEvents ctrUPCENumber As System.Windows.Forms.ComboBox
    Friend WithEvents ctrBearerBars As System.Windows.Forms.ComboBox
    Friend WithEvents ctrShowText As System.Windows.Forms.ComboBox
    Friend WithEvents ctrDrawBarcode As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ctrBarWidth As System.Windows.Forms.TextBox
    Friend WithEvents ctrBarHeight As System.Windows.Forms.TextBox
    Friend WithEvents ctrLeftMargin As System.Windows.Forms.TextBox
    Friend WithEvents ctrTopMargin As System.Windows.Forms.TextBox
    Friend WithEvents ctrResolution As System.Windows.Forms.TextBox
    Friend WithEvents ctrTextFontBrowse As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ctrTextFont As System.Windows.Forms.TextBox
    Friend WithEvents ctlFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ctrSaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ctrFontDialog As System.Windows.Forms.FontDialog
End Class
