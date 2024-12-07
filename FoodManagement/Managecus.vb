Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Managecus
    Private Sub Managecus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        readdataclient()
        rowheight()
    End Sub

    Sub rowheight()
        For i = 0 To DataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 50
        Next
    End Sub

    Sub readdataclient()
        DataGridView1.Rows.Clear()
        str = "Select * from MANAGECUSTOMER"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("MID"), dr("FNAME"), dr("MNAME"), dr("LNAME"), dr("AGE"), dr("GENDER"), dr("CONTACT"), dr("EMAIL"), dr("STATUS"), dr("TIME_IN_DATE"), dr("TIME_IN"), dr("RFID_TAGS"), dr("IMAGE"), dr("BALANCE"))


        End While
        dr.Close()
        cmd.Dispose()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DASHBOARD.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EDITINFO.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Registrationvb.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick


    End Sub
    Sub viewimage()
        Dim img() As Byte
        str = "Select * from MANAGECUSTOMER where MID = '" & Label1.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            img = dr("IMAGE")
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)
            EDITINFO.PictureBox1.Image = Image.FromStream(ms)


        End While
        dr.Close()
        cmd.Dispose()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = DataGridView1.CurrentRow.Index



        Label1.Text = DataGridView1.Item(0, i).Value
        Label11.Text = DataGridView1.Item(1, i).Value
        Label17.Text = DataGridView1.Item(2, i).Value
        Label13.Text = DataGridView1.Item(3, i).Value
        Label16.Text = DataGridView1.Item(4, i).Value
        Label19.Text = DataGridView1.Item(5, i).Value
        Label20.Text = DataGridView1.Item(6, i).Value
        Label21.Text = DataGridView1.Item(7, i).Value
        Label22.Text = DataGridView1.Item(8, i).Value
        Label25.Text = DataGridView1.Item(9, i).Value
        Label26.Text = DataGridView1.Item(10, i).Value
        Label28.Text = DataGridView1.Item(11, i).Value
        viewimage()
        Label31.Text = DataGridView1.Item(13, i).Value







        EDITINFO.TextBox1.Text = DataGridView1.Item(0, i).Value
        EDITINFO.TextBox2.Text = DataGridView1.Item(1, i).Value
        EDITINFO.TextBox3.Text = DataGridView1.Item(2, i).Value
        EDITINFO.TextBox4.Text = DataGridView1.Item(3, i).Value
        EDITINFO.TextBox5.Text = DataGridView1.Item(4, i).Value
        EDITINFO.TextBox6.Text = DataGridView1.Item(5, i).Value
        EDITINFO.TextBox7.Text = DataGridView1.Item(6, i).Value
        EDITINFO.TextBox8.Text = DataGridView1.Item(7, i).Value
        EDITINFO.TextBox9.Text = DataGridView1.Item(8, i).Value
        EDITINFO.TextBox10.Text = DataGridView1.Item(11, i).Value

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub
End Class