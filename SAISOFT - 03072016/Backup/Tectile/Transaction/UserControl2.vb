Public Class UserControl2

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If (e.KeyChar > "0" And e.KeyChar < "9") Or e.KeyChar = "." Then
            If TextBox1.Text.Length = TextBox1.MaxLength Then
                TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.SelectionStart) & e.KeyChar & TextBox1.Text.Substring(TextBox1.SelectionStart)
            End If
        Else
            e.Handled = True
        End If
        
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
    Dim c1 As Integer

    Property q() As Integer
        Get
            q = c1
        End Get
        Set(ByVal value As Integer)
            c1 = value
        End Set
    End Property
    Dim c2 As Integer
    Property q1() As Integer
        Get
            q1 = c2
        End Get
        Set(ByVal value As Integer)
            c2 = value
        End Set
    End Property

    Private Sub UserControl2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        Dim str As String = ""
        Dim k As Integer
        For k = 0 To Me.q - 1
            str = str & "0"
        Next
        Me.TextBox1.Text = Format(Val(Me.TextBox1.Text), "0." & str)
        Dim str2 As String = ""
        For k = 0 To (Me.TextBox1.MaxLength - Me.TextBox1.Text.Length - 1)
            str2 = str2 & " "
        Next
        Me.TextBox1.Text = str2 & Me.TextBox1.Text
    End Sub

    Private Sub UserControl2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.MaxLength = q1
    End Sub
End Class
