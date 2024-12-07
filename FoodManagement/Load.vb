Imports System.IO
Imports System.Reflection.Emit

Public Class cusLoad
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length > 9 Then

            searchMENU()







            If DataGridView1.Rows.Count = 0 Then

                Panel2.Hide()
                ' MsgBox("not exist", MsgBoxStyle.Exclamation, "FUNCTION")
                Panel1.Show()
                '  Timer2.Enabled = True
                TextBox1.Clear()




            Else
                MsgBox("TENANT RFID ACCESS", MsgBoxStyle.Exclamation, "FUNCTION")
                TextBox1.Clear()
                Panel2.Show()
                Panel1.Hide()
                Dim i As Integer = DataGridView1.CurrentRow.Index
                Label11.Text = DataGridView1.Item(0, i).Value    ''// ID
                Label14.Text = DataGridView1.Item(1, i).Value   ''  //FIRST NAME
                Label17.Text = DataGridView1.Item(2, i).Value   ''// MIDDLE NAME
                Label16.Text = DataGridView1.Item(3, i).Value  '' // LAST NAME
                Label12.Text = DataGridView1.Item(11, i).Value  ''// RFID
                Label13.Text = DataGridView1.Item(6, i).Value   ''// CONTACT

                viewimage()


            End If
        End If
    End Sub
    Sub viewimage()
        Dim img() As Byte
        str = "Select * from MANAGECUSTOMER where MID = '" & Label11.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            img = dr("IMAGE")
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)
            PAYMENT.PictureBox1.Image = Image.FromStream(ms)


        End While
        dr.Close()
        cmd.Dispose()
    End Sub
    Sub searchMENU()
        Dim i As Integer
        DataGridView1.Rows.Clear()
        str = "Select * from MANAGECUSTOMER where RFID_TAGS like '%" & TextBox1.Text & "%' "
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("MID"), dr("FNAME"), dr("MNAME"), dr("LNAME"), dr("AGE"), dr("GENDER"), dr("CONTACT"), dr("EMAIL"), dr("STATUS"), dr("TIME_IN_DATE"), dr("TIME_IN"), dr("RFID_TAGS"), dr("BALANCE"))
        End While
    End Sub

    Sub balance()
        Dim i As Integer
        DataGridView1.Rows.Clear()
        str = "Select * from MANAGECUSTOMER where RFID_TAGS like '%" & TextBox2.Text & "%' "
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("MID"), dr("FNAME"), dr("MNAME"), dr("LNAME"), dr("AGE"), dr("GENDER"), dr("CONTACT"), dr("EMAIL"), dr("STATUS"), dr("TIME_IN_DATE"), dr("TIME_IN"), dr("RFID_TAGS"), dr("BALANCE"))
        End While
    End Sub

    Private Sub Load_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        TextBox1.Focus()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Hide()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        PAYMENT.Label13.Text = "1000"
        indicate()
        viewimage()
        PAYMENT.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Sub indicate()
        Dim i As Integer = DataGridView1.CurrentRow.Index
        PAYMENT.Label18.Text = DataGridView1.Item(0, i).Value    ''// ID
        PAYMENT.Label9.Text = DataGridView1.Item(1, i).Value   ''  //FIRST NAME
        PAYMENT.Label11.Text = DataGridView1.Item(2, i).Value   ''// MIDDLE NAME
        PAYMENT.Label12.Text = DataGridView1.Item(3, i).Value  '' // LAST NAME

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PAYMENT.Label13.Text = "100"
        indicate()
        viewimage()
        PAYMENT.Show()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        PAYMENT.Label13.Text = "300"
        indicate()
        viewimage()
        PAYMENT.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Panel3.Hide()
    End Sub



    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Panel3.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        PAYMENT.Label13.Text = "500"
        indicate()
        viewimage()
        PAYMENT.Show()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Panel2.Hide()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        PAYMENT.Label13.Text = "2000"
        indicate()
        viewimage()
        PAYMENT.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        PAYMENT.Label13.Text = "5000"
        indicate()
        viewimage()
        PAYMENT.Show()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        PAYMENT.Label13.Text = "10000"
        indicate()
        viewimage()
        PAYMENT.Show()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        PAYMENT.Label13.Text = "15000"
        viewimage()
        PAYMENT.Show()
        Panel3.Hide()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        PAYMENT.Label13.Text = "20000"
        indicate()
        viewimage()
        PAYMENT.Show()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        PAYMENT.Label13.Text = "30000"
        indicate()
        viewimage()
        PAYMENT.Show()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        PAYMENT.Label13.Text = "35000"
        indicate()
        viewimage()
        PAYMENT.Show()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        PAYMENT.Label13.Text = "40000"
        indicate()
        viewimage()
        PAYMENT.Show()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        PAYMENT.Label13.Text = "50000"
        indicate()
        viewimage()
        PAYMENT.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel4.Show()
        TextBox2.Focus()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Panel4.Hide()
        TextBox1.Focus()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text.Length > 9 Then

            balance()







            If DataGridView1.Rows.Count = 0 Then

                Panel4.Hide()
                Panel3.Hide()
                Panel2.Hide()

                Panel1.Show()
                '  Timer2.Enabled = True
                TextBox2.Clear()




            Else

                TextBox2.Clear()

                Dim i As Integer = DataGridView1.CurrentRow.Index
                Label21.Visible = True
                Label21.Text = DataGridView1.Item(12, i).Value  ''// RFID
                Label20.Text = "Your Current Balance"



            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DASHBOARD.Show()
        Me.Hide()
    End Sub
End Class