Partial Class DataSet3
    Partial Class DataTable1DataTable

        Private Sub DataTable1DataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DateColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
