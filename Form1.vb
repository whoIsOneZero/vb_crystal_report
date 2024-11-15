Public Class Form1
    Private Sub form_crystalReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
    End Sub

    Sub loadData()
        DataGridView1.Rows.Clear()
        conn.Open()
        cmd = New MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM student_tbl", conn)
        dr = cmd.ExecuteReader

        While dr.Read
            DataGridView1.Rows.Add(dr.Item("ID").ToString, dr.Item("fullname").ToString, dr.Item("subject").ToString, dr.Item("gender").ToString, dr.Item("address").ToString)
        End While

        dr.Dispose()
        conn.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim column As String = DataGridView1.Columns(e.ColumnIndex).Name

        If column = "Column6" Then
            Try
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                form_printForm.info = row.Cells("Column1").Value
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btn_loadData_Click(sender As Object, e As EventArgs) Handles btn_loadData.Click
        loadData()
        lbl_countRowNum.Text = DataGridView1.RowCount
    End Sub
End Class
