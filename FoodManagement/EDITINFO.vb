Imports System.IO
Imports System.Reflection.Emit

Public Class EDITINFO
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, Label9.Click, Label8.Click, Label7.Click, Label6.Click, Label5.Click, Label4.Click, Label3.Click, Label2.Click, Label10.Click, Label11.Click

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged, TextBox10.TextChanged
        If TextBox10.Text.Length > 9 Then


            TextBox10.Enabled = False




        End If
        ' MsgBox("F")   ETO YUNBG CODE NG SCAN


        '0425673425     ETO YUNG SAMPLE RFID


    End Sub

    Private Sub EDITINFO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.LimeGreen
        TextBox10.Enabled = True

        TextBox10.Clear()
        TextBox10.Focus()

        Button1.Visible = False
        Button4.Visible = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        TextBox10.Enabled = False
        Button1.Visible = True
        Button4.Visible = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg"

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = System.Drawing.Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Sub update()
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        query = "Update MANAGECUSTOMER set FNAME = @FNAME ,MNAME = @MNAME, LNAME = @LNAME, AGE = @AGE, GENDER = @GENDER, CONTACT = @CONTACT, EMAIL = @EMAIL, STATUS = @STATUS, RFID_TAGS = @RFID_TAGS, IMAGE = @IMAGE where MID = @MID "
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@MID", TextBox1.Text)
            .Parameters.AddWithValue("@FNAME", TextBox2.Text)
            .Parameters.AddWithValue("@MNAME", TextBox3.Text)
            .Parameters.AddWithValue("@LNAME", TextBox4.Text)
            .Parameters.AddWithValue("@AGE", TextBox5.Text)
            .Parameters.AddWithValue("@GENDER", TextBox6.Text)
            .Parameters.AddWithValue("@CONTACT", TextBox7.Text)
            .Parameters.AddWithValue("@EMAIL", TextBox8.Text)
            .Parameters.AddWithValue("@STATUS", TextBox9.Text)
            .Parameters.AddWithValue("@RFID_TAGS", TextBox10.Text)
            .Parameters.AddWithValue("@IMAGE", ms.ToArray)


        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        update()
        MsgBox("SUCCESFULY UPDATE")
        Me.Hide()
        Managecus.readdataclient()
        Managecus.rowheight()
    End Sub
End Class