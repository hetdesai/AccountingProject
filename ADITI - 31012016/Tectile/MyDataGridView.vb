Public Class MyDataGridView
    Inherits DataGridView
    Protected Overloads Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        If keyData = Keys.Enter Then
            MyBase.ProcessTabKey(Keys.Tab)
            Return True
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function
    Protected Overloads Overrides Function ProcessDataGridViewKey(ByVal e As KeyEventArgs) As Boolean
        If e.KeyCode = Keys.Enter Then
            MyBase.ProcessTabKey(Keys.Tab)
            Return True
        End If
        'MsgBox(MyBase.ProcessDataGridViewKey(e))
        Return MyBase.ProcessDataGridViewKey(e)
    End Function
End Class
