
Partial Class DataSet2
    Partial Class sale1DataTable

        Private Sub sale1DataTable_sale1RowChanging(sender As Object, e As sale1RowChangeEvent) Handles Me.sale1RowChanging

        End Sub

    End Class

    Partial Class tblLotRtDataTable

        Private Sub tblLotRtDataTable_tblLotRtRowChanging(sender As Object, e As tblLotRtRowChangeEvent) Handles Me.tblLotRtRowChanging

        End Sub

    End Class

    Partial Class tblLedgDataTable

        Private Sub tblLedgDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.RefColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class DataTable3DataTable

        Private Sub DataTable3DataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.shiptoColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class tblStockSumDataTable

        Private Sub tblStockSumDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging

        End Sub

    End Class

    Partial Class tblStockDataTable

        Private Sub tblStockDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging

        End Sub

    End Class

    Partial Class DataTable1DataTable

    End Class

End Class
