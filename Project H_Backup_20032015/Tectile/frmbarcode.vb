Imports System
Imports BarcodeLib.Barcode.Linear
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.IO
Imports System.Text
Imports BarcodeLib.Barcode
Public Class frmbarcode

    Private Sub frmbarcode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  ctrSymbology.SelectedIndex = 3
        '  ctrAddCheckSum.SelectedIndex = 0
        ' ctrRotate.SelectedIndex = 0
        '  ctrFormat.SelectedIndex = 0
        '  ctrBearerBars.SelectedIndex = 0
        '  ctrShowText.SelectedIndex = 0
        '  ctrCodabarStart.SelectedIndex = 0
        '  ctrCodabarStop.SelectedIndex = 0
        '  ctrUPCENumber.SelectedIndex = 0
        '  ctrUOM.SelectedIndex = 0
        Dim validinputs As Boolean = True
        If (validinputs) Then
            drawBarcode()
        End If


    End Sub
    private Function  getBearerBar() As BearerBar 

        If (ctrBearerBars.Text.Equals("None")) Then
            Return BearerBar.None
        ElseIf (ctrBearerBars.Text.Equals("Frame")) Then
            Return BearerBar.Frame
        ElseIf (ctrBearerBars.Text.Equals("TopBottom")) Then
            Return BearerBar.TopBottom
        Else
            Return BearerBar.None
        End If
    End Function
    Private Sub ctrSaveImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click


        ctrSaveFileDialog.Filter = "GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png"
        ctrSaveFileDialog.FilterIndex = 1

        If (ctrSaveFileDialog.ShowDialog() = DialogResult.OK) Then

            drawBarcode()
            Dim imagestream As Stream
            imagestream = ctrSaveFileDialog.OpenFile()
            ctrBarcode.SaveAsImage(imagestream)
            imagestream.Close()
        End If
    End Sub

    Private Sub drawBarcode()

        ctrBarcode.Type = EnumUtil.convertString2BarcodeType(ctrSymbology.Text)
        ctrBarcode.Data = ctrData.Text
        ctrBarcode.SData = ctrSData.Text

        ctrBarcode.ShowText = CBool(ctrShowText.Text)
        ctrBarcode.TextFont = BarcodeUtils.parseFont(ctrTextFont.Text, Linear.DefaultTextFont)

        ctrBarcode.AddCheckSum = CBool(ctrAddCheckSum.Text)
        ctrBarcode.Rotate = EnumUtil.convertString2RotateOrientation(ctrRotate.Text)
        ctrBarcode.Format = BarcodeUtils.convertString2ImageFormat(ctrFormat.Text, Linear.DefaultImageFormat)

        ctrBarcode.UOM = UnitOfMeasure.Pixel
        ctrBarcode.BarWidth = CDec(ctrBarWidth.Text)
        ctrBarcode.BarHeight = CDec(ctrBarHeight.Text)
        ctrBarcode.LeftMargin = CDec(ctrLeftMargin.Text)
        ctrBarcode.TopMargin = CDec(ctrTopMargin.Text)
        '  Add resolution here
        ctrBarcode.Resolution = CInt(ctrResolution.Text)

        ctrBarcode.BearerBars = getBearerBar()

        ctrBarcode.CodabarStartChar = EnumUtil.convertCodabarString2Enum(ctrCodabarStart.Text)
        ctrBarcode.CodabarStopChar = EnumUtil.convertCodabarString2Enum(ctrCodabarStop.Text)
        ctrBarcode.UPCENumberSystem = CInt(ctrUPCENumber.Text)
        ctrBarcode.Refresh()

    End Sub
    Private Sub ctlFileDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctrSaveFileDialog.FileOk

    End Sub
End Class