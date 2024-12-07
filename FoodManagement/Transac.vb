Public Class Transac
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        DASHBOARD.Show()

    End Sub
    Sub readdataclient()
        DataGridView1.Rows.Clear()
        str = "Select * from MANAGETRANSACT"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("TID"), dr("FNAME"), dr("MNAME"), dr("LNAME"), dr("AMOUNTDUE"), dr("PAYMENT"), dr("CHANGE"), dr("PAYMENT_STATUS"), dr("DATE"))


        End While
        dr.Close()
        cmd.Dispose()

    End Sub
    Private Sub Transac_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        readdataclient()
    End Sub

    Sub Deleteclient(ByVal CID As String)
        query = "Delete from MANAGETRANSACT where TID = @TID"
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@TID", CID)







        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer = DataGridView1.CurrentRow.Index
        Deleteclient(DataGridView1.Item(0, i).Value)
        readdataclient()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        REPORT.Show()
    End Sub
End Class