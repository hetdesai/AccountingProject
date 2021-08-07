Public Class UserControl1



    Private Sub textbox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.q.Focus()
            GoTo en
        End If
        If e.KeyCode = Keys.Delete Then
            GoTo en
        End If
        If e.KeyCode = Keys.Right Then

        End If
        If e.KeyCode = Keys.Left Then
            GoTo en
        End If
        If e.KeyCode = Keys.Back Then
            GoTo en
            ' MsgBox("het")
            '  SendKeys.Send("{LEFT}")
            ' SendKeys.Send("{DELETE}")
            'e.Handled = True
        End If
        If TextBox2.SelectionStart = 1 And (TextBox2.Text.Length = 1 Or TextBox2.Text.Length = 2) Then
            TextBox3.Focus()
            TextBox3.SelectionStart = 0
        End If
en:
    End Sub
    Private Sub textbox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.q.Focus()
            GoTo en
        End If
        If e.KeyCode = Keys.Delete Then
            GoTo en
        End If
        If e.KeyCode = Keys.Left And TextBox3.SelectionStart = 0 Then
            TextBox2.Focus()
            GoTo en
        End If
        If e.KeyCode = Keys.Left Then
            GoTo en
        End If
        If e.KeyCode = Keys.Right And TextBox3.SelectionStart = 1 Then
            TextBox4.Focus()
            GoTo en
        End If

        If e.KeyCode = Keys.Back Then
            GoTo en
        End If
        '  If e.KeyCode = Keys.Back Then
        ' ' MsgBox("het")
        ' SendKeys.Send("{LEFT}")
        ' SendKeys.Send("{DELETE}")
        ' e.Handled = True
        ' End If
        If TextBox3.SelectionStart = 1 And (TextBox3.Text.Trim .Length = 1 Or TextBox3.Text.Trim .Length  = 2) Then
            TextBox4.Focus()
            TextBox4.SelectionStart = 0
        End If
en:
    End Sub

    Private Sub textbox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'MsgBox(TextBox2.SelectionStart)
        Dim str As String
        str = TextBox2.Text
        If Asc(e.KeyChar) = 13 Then
            GoTo en
        End If
        If Asc(e.KeyChar) = 8 Then
            'e.Handled = True
            'SendKeys.Send("{LEFT}")
            'SendKeys.Send("{DELETE}")
            'TextBox2.SelectionStart = 0
            GoTo en
        End If
        'MsgBox(TextBox2.Text.Trim.Length & TextBox2.SelectionStart)
        If TextBox2.Text.Trim.Length = 2 And TextBox2.SelectionStart = 0 Then
            TextBox2.Clear()
            TextBox2.Text = e.KeyChar & str.Chars(1)
            SendKeys.Send("{Right}")
        End If

        If TextBox2.Text.Length = 2 And TextBox2.SelectionStart = 1 Then

            TextBox2.Text = TextBox2.Text.Chars(0) & e.KeyChar
        End If
en:
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        'MsgBox(TextBox2.SelectionStart)
        If Asc(e.KeyChar) = 13 Then
            GoTo en
        End If
        Dim str As String
        str = TextBox3.Text
        If Asc(e.KeyChar) = 8 Then
            GoTo en
        End If
        'MsgBox(TextBox2.Text.Trim.Length & TextBox2.SelectionStart)
        If TextBox3.Text.Trim.Length = 2 And TextBox3.SelectionStart = 0 Then
            TextBox3.Clear()
            TextBox3.Text = e.KeyChar & str.Chars(1)
            SendKeys.Send("{Right}")
        End If

        If TextBox3.Text.Length = 2 And TextBox3.SelectionStart = 1 Then
            TextBox3.Text = TextBox3.Text.Chars(0) & e.KeyChar
        End If
en:
    End Sub

    Private Sub UserControl1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        'TextBox2.Focus()
        'TextBox2.SelectionStart = 0
    End Sub

    Private Sub TextBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.Enter
        TextBox3.SelectionStart = 0
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.q.Focus()
        End If
        If e.KeyCode = Keys.Back Then
            GoTo en
        End If
        If e.KeyCode = Keys.Home Then
            TextBox2.Focus()
            TextBox2.SelectionStart = 0
        ElseIf e.KeyCode = Keys.Left And TextBox4.SelectionStart = 0 Then
            TextBox3.Focus()
            TextBox3.SelectionStart = 1
        End If
en:
    End Sub

    Private Sub TextBox3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.Leave

    End Sub

    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus

    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        Dim str As String
        If Asc(e.KeyChar) = 13 Then
            GoTo en
        End If
        If Asc(e.KeyChar) = 8 Then
            GoTo en
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
            GoTo en
        End If
        If TextBox4.SelectionStart = 0 And TextBox4.Text.Trim.Length = 4 Then
            str = TextBox4.Text
            TextBox4.Clear()
            TextBox4.Text = e.KeyChar & str.Substring(1)
            '  MsgBox(TextBox4.Text)
            TextBox4.SelectionStart = 1
            GoTo en
            ' SendKeys.Send("{RIGHT}")
        End If
        If TextBox4.SelectionStart = 1 And TextBox4.Text.Trim.Length = 4 Then
            str = TextBox4.Text
            TextBox4.Clear()
            TextBox4.Text = str.Substring(0, 1) & e.KeyChar & str.Substring(2, 2)
            TextBox4.SelectionStart = 2
            GoTo en
            'SendKeys.Send("{RIGHT}")
        End If
        If TextBox4.SelectionStart = 2 And TextBox4.Text.Trim.Length = 4 Then
            str = TextBox4.Text
            TextBox4.Clear()
            TextBox4.Text = str.Substring(0, 2) & e.KeyChar & str.Substring(3, 1)
            TextBox4.SelectionStart = 3
            GoTo en
            'SendKeys.Send("{RIGHT}")
        End If
        If TextBox4.SelectionStart = 3 And TextBox4.Text.Trim.Length = 4 Then
            str = TextBox4.Text
            TextBox4.Clear()
            TextBox4.Text = str.Substring(0, 3) & e.KeyChar
            TextBox4.SelectionStart = 4
            GoTo en
            '   SendKeys.Send("{RIGHT}")
        End If
en:
    End Sub
    Private c1 As Control
    Property q() As Control
        Get
            q = c1
        End Get
        Set(ByVal value As Control)
            c1 = value
        End Set
    End Property
    Private s1 As String
    Property mydat() As String
        Get
            If TextBox2.Text.Trim.Length = 1 Then
                TextBox2.Text = "0" & TextBox2.Text.Trim.Chars(0)
            End If
            If TextBox3.Text.Trim.Length = 1 Then
                TextBox3.Text = "0" & TextBox3.Text.Trim.Chars(0)
            End If

            mydat = TextBox2.Text & TextBox3.Text & TextBox4.Text
        End Get
        Set(ByVal value As String)
            Try
                Dim dat As New Date
                dat = value.ToString
                s1 = value
                '      Dim dat As New Date
                dat = value.ToString
                TextBox2.Text = dat.Day
                TextBox3.Text = dat.Month
                TextBox4.Text = dat.Year

            Catch ex As Exception

            End Try
            End Set
    End Property
    Private Sub myKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown, TextBox2.KeyDown, TextBox3.KeyDown
        

    End Sub
    Private Sub UserControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UserControl1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        If TextBox2.Text.Trim.Length = 1 Then
            TextBox2.Text = "0" & TextBox2.Text.Trim.Chars(0)
        End If
        If TextBox3.Text.Trim.Length = 1 Then
            TextBox3.Text = "0" & TextBox3.Text.Trim.Chars(0)
        End If
         'If TextBox4 .
        Try
            Dim dat As New Date
            Dim m As New MaskedTextBox
            m.Mask = "00/00/0000"
            m.Text = Me.mydat
            dat = m.Text.ToString
        Catch ex As Exception
            '  MsgBox("Date Not Valid")
            Me.TextBox2.Focus()
            Me.TextBox2.SelectionStart = 0
            Me.TextBox2.SelectionLength = 0
        End Try
         End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub UserControl1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        TextBox2.Focus()
        TextBox2.SelectionStart = 0
    End Sub
End Class
