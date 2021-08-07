Imports System.Data.OleDb
Public Class frmEdit2
    Dim cmd As New OleDbCommand
    Dim da As New OleDbDataAdapter
    Dim ds As New DataSet
    Dim dr As OleDbDataReader
    'Variables for webcam
    Private CamFrameRate As Integer = 15
    Private OutputHeight As Integer = 240
    Private OutputWidth As Integer = 360
    Public iRunning As Boolean

    Dim mycam As New iCam
    Private Sub focus(ByVal sender As Object, ByVal e As EventArgs) Handles txtAdd.GotFocus, txtCourse.GotFocus, txtDateOfBirthday.GotFocus, txtDateOfEntry.GotFocus, txtDiv.GotFocus, txtDuration.GotFocus, txtEmail.GotFocus, txtHome.GotFocus, txtMob.GotFocus, txtNative.GotFocus, txtS_FName.GotFocus, txtS_SName.GotFocus, txtS_MName.GotFocus, txtSName.GotFocus, txtStandard.GotFocus, txtStudentId.GotFocus, txtTenth.GotFocus, txtTenth.GotFocus, txtYear.GotFocus, TextBox1.GotFocus, TextBox2.GotFocus, TextBox3.GotFocus, cmdSem.GotFocus, cmdStandard.GotFocus
        sender.BackColor = Color.Pink
    End Sub
    Private Sub lofocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtAdd.LostFocus, txtCourse.LostFocus, txtDateOfBirthday.LostFocus, txtDateOfEntry.LostFocus, txtDiv.LostFocus, txtDuration.LostFocus, txtEmail.LostFocus, txtHome.LostFocus, txtMob.LostFocus, txtNative.LostFocus, txtS_FName.LostFocus, txtS_SName.LostFocus, txtS_MName.LostFocus, txtSName.LostFocus, txtStandard.LostFocus, txtStudentId.LostFocus, txtTenth.LostFocus, txtTenth.LostFocus, txtYear.LostFocus, TextBox1.LostFocus, TextBox2.LostFocus, TextBox3.LostFocus, cmdSem.LostFocus, cmdStandard.LostFocus
        sender.BackColor = Color.White
    End Sub

    Private Sub frmEdit2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmEdit2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Edit Detail"
        PictureBox1.SendToBack()
        Connect()
        cmd = New OleDbCommand("Select * from tblStudentInfo where ID=" & frmEdit.ID, cn)
        dr = cmd.ExecuteReader
        While dr.Read
            txtAdd.Text = dr.Item("Address")
            txtCourse.Text = dr.Item("Course")
            txtDateOfBirthday.Text = Format(dr.Item("DateOfBirthday"), "dd-MM-yyyy")
            txtDateOfEntry.Text = Format(dr.Item("DateOfEntry"), "dd-MM-yyyy")
            txtDiv.Text = dr.Item("Div")
            txtDuration.Text = dr.Item("Duration")
            txtEmail.Text = dr.Item("Email")
            txtHome.Text = dr.Item("HomePhone")
            txtMob.Text = dr.Item("MobileNo")
            txtNative.Text = dr.Item("NetivePlace")
            txtS_FName.Text = dr.Item("St_FName")
            txtS_MName.Text = dr.Item("St_MName")
            txtS_SName.Text = dr.Item("St_SName")
            txtStudentId.Text = dr.Item("ID")
            txtSName.Text = dr.Item("SchoolName")
            txtYear.Text = dr.Item("Year1")
            cmdSem.Text = dr.Item("Sem")
            cmdStandard.Text = dr.Item("ProposedStandardEntry")
            txtTenth.Text = dr.Item("Tenth")
            txtStandard.Text = dr.Item("Standard")
            TextBox1.Text = dr.Item("Batch")
            TextBox2.Text = dr.Item("RollNo")
            TextBox3.Text = dr.Item("Fee")
            If dr.Item("Gender").Equals("Male") Then
                radMale.Checked = True
            Else
                radFemale.Checked = True
            End If
            pbS_Image.BringToFront()
            pbS_Image.Load("C:\ITSoftware\Images\" & dr.Item("ID"))
        End While
        dr.Close()
        Close1()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmParentEdit.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PictureBox1.BringToFront()
        mycam.initCam(Me.PictureBox1.Handle.ToInt32)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.pbS_Image.Image = mycam.copyFrame(Me.PictureBox1, New RectangleF(0, 0, Me.pbS_Image.Width, Me.pbS_Image.Height))
        PictureBox1.SendToBack()
    End Sub
End Class
Public Class iCam
#Region "Api/constants"

    Private Const WS_CHILD As Integer = &H40000000
    Private Const WS_VISIBLE As Integer = &H10000000
    Private Const SWP_NOMOVE As Short = &H2S
    Private Const SWP_NOZORDER As Short = &H4S
    Private Const WM_USER As Short = &H400S
    Private Const WM_CAP_DRIVER_CONNECT As Integer = WM_USER + 10
    Private Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_USER + 11
    Private Const WM_CAP_SET_VIDEOFORMAT As Integer = WM_USER + 45
    Private Const WM_CAP_SET_PREVIEW As Integer = WM_USER + 50
    Private Const WM_CAP_SET_PREVIEWRATE As Integer = WM_USER + 52
    Private Const WM_CAP_GET_FRAME As Long = 1084
    Private Const WM_CAP_COPY As Long = 1054
    Private Const WM_CAP_START As Long = WM_USER
    Private Const WM_CAP_STOP As Long = (WM_CAP_START + 68)
    Private Const WM_CAP_SEQUENCE As Long = (WM_CAP_START + 62)
    Private Const WM_CAP_SET_SEQUENCE_SETUP As Long = (WM_CAP_START + 64)
    Private Const WM_CAP_FILE_SET_CAPTURE_FILEA As Long = (WM_CAP_START + 20)

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Short, ByVal lParam As String) As Integer
    Private Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWndParent As Integer, ByVal nID As Integer) As Integer
    Private Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean
    Private Declare Function BitBlt Lib "GDI32.DLL" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Int32) As Boolean

#End Region

    Private iDevice As String
    Private hHwnd As Integer
    Private lwndC As Integer

    Public iRunning As Boolean

    Private CamFrameRate As Integer = 15
    Private OutputHeight As Integer = 240
    Private OutputWidth As Integer = 360

    Public Sub resetCam()
        'resets the camera after setting change
        If iRunning Then
            closeCam()
            Application.DoEvents()

            If setCam() = False Then
                MessageBox.Show("Errror Setting/Re-Setting Camera")
            End If
        End If

    End Sub

    Public Sub initCam(ByVal parentH As Integer)
        Try
            'Gets the handle and initiates camera setup
            If Me.iRunning = True Then
                MessageBox.Show("Camera Is Already Running")
                Exit Sub
            Else

                hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, OutputWidth, CShort(OutputHeight), parentH, 0)


                If setCam() = False Then
                    MessageBox.Show("Error setting Up Camera")
                End If
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Public Sub setFrameRate(ByVal iRate As Long)
        'sets the frame rate of the camera
        CamFrameRate = CInt(1000 / iRate)

        resetCam()

    End Sub

    Private Function setCam() As Boolean
        'Sets all the camera up
        Try
            If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, CShort(iDevice), CType(0, String)) = 1 Then
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, CShort(CamFrameRate), CType(0, String))
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, 1, CType(0, String))
                Me.iRunning = True
                Return True
            Else
                Me.iRunning = False
                Return False
            End If

        Catch ex As Exception

        End Try
      End Function

    Public Function closeCam() As Boolean
        'Closes the camera
        If Me.iRunning Then
            closeCam = CBool(SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, 0, CType(0, String)))
            Me.iRunning = False
        End If
    End Function

    Public Function copyFrame(ByVal src As PictureBox, ByVal rect As RectangleF) As Bitmap
        If iRunning Then
            Dim srcPic As Graphics = src.CreateGraphics
            Dim srcBmp As New Bitmap(src.Width, src.Height, srcPic)
            Dim srcMem As Graphics = Graphics.FromImage(srcBmp)
            Dim HDC1 As IntPtr = srcPic.GetHdc
            Dim HDC2 As IntPtr = srcMem.GetHdc
            BitBlt(HDC2, 0, 0, CInt(rect.Width), _
              CInt(rect.Height), HDC1, CInt(rect.X), CInt(rect.Y), 13369376)
            copyFrame = CType(srcBmp.Clone(), Bitmap)
            'Clean Up 
            srcPic.ReleaseHdc(HDC1)
            srcMem.ReleaseHdc(HDC2)
            srcPic.Dispose()
            srcMem.Dispose()
        Else
            MessageBox.Show("Camera Is Not Running!")
        End If
    End Function

    Public Function FPS() As Integer
        Return CInt(1000 / (CamFrameRate))
    End Function

End Class