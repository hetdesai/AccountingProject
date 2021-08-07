Public Class CustomeChecklistbox

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If (CheckBox1.Checked = True) Then
                CheckBox1.Text = "Uncheck All"
            Else
                CheckBox1.Text = "Check All"
            End If
            Dim i As Integer
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, CheckBox1.Checked)
            Next
            ' End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub CustomeChecklistbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Next Then
            e.Handled = True
            Me.NextControl.Focus()
        End If

    End Sub

    Private Sub CustomeChecklistbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CustomeChecklistbox_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        CheckedListBox1.Height = Me.Height - 70
        CheckedListBox1.Width = Me.Width
        '   CheckedListBox1.Top = Me.Top + 10
    End Sub
    Public Function getItems(ByVal index As Object) As Object
        Return CheckedListBox1.Items(index)
    End Function
    Public Function getSelectedItems(ByVal index As Object) As Object
        Return CheckedListBox1.SelectedItem(index)
    End Function
    Public Function getCheckedItems(ByVal index As Object) As Object
        Return CheckedListBox1.CheckedItems(index)
    End Function
    Public Function AddItem(ByVal value As Object)

        CheckedListBox1.Items.Add(value)
    End Function
    Public Sub SetSelected(ByVal index As Integer, ByVal bool As Boolean)
        CheckedListBox1.SetSelected(index, bool)
    End Sub
    Public Sub SetChecked(ByVal index As Integer, ByVal bool As Boolean)
        CheckedListBox1.SetItemChecked(index, bool)
    End Sub
    Public Function ItemsCount() As Integer
        Return CheckedListBox1.Items.Count
    End Function
    Public Function SelectedItemsCount() As Integer
        Return CheckedListBox1.SelectedItems.Count
    End Function
    Public Function CheckedItemsCount() As Integer
        Return CheckedListBox1.CheckedItems.Count
    End Function

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                If CheckedListBox1.GetItemChecked(CheckedListBox1.SelectedIndex) Then
                    CheckedListBox1.SetItemChecked(CheckedListBox1.SelectedIndex, False)
                Else
                    CheckedListBox1.SetItemChecked(CheckedListBox1.SelectedIndex, True)

                End If
            ElseIf (e.KeyCode = Keys.Home) Then

                TextBox1.Clear()
            ElseIf e.KeyCode = Keys.Down Then
                Try

                CheckedListBox1.Focus()
                    CheckedListBox1.SelectedIndex = CheckedListBox1.SelectedIndex + 1
                Catch ex As Exception

                End Try
           
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private _control As Control

    Public Property NextControl() As Control
        Get
            Return _control
        End Get
        Set(ByVal value As Control)
            _control = value
        End Set
    End Property


    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        Try
            Dim i As Integer
            For i = 0 To CheckedListBox1.Items.Count - 1
                If (CheckedListBox1.Items(i).ToString.StartsWith(TextBox1.Text, StringComparison.OrdinalIgnoreCase) = True) Then
                    CheckedListBox1.SetSelected(i, True)
                    GoTo en
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
en:
    End Sub

    Private Sub CheckedListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If CheckedListBox1.GetItemChecked(CheckedListBox1.SelectedIndex) Then
                    CheckedListBox1.SetItemChecked(CheckedListBox1.SelectedIndex, False)
                Else
                    CheckedListBox1.SetItemChecked(CheckedListBox1.SelectedIndex, True)

                End If
            ElseIf e.KeyCode = Keys.Home Then
                TextBox1.Focus()
                TextBox1.Clear()
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub CustomeChecklistbox_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        TextBox1.Focus()
    End Sub
End Class
