Imports System.IO
Imports System.Reflection.Emit

Public Class Registrationvb
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Managecus.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg"

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = System.Drawing.Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Registrationvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SUBJECT()
        connect()


    End Sub

    Sub SUBJECT()
        Dim autoORDERID As Integer
        str = "SELECT COUNT(*) as MID FROM MANAGECUSTOMER"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            autoORDERID = CInt(dr("MID")) + 1
        End While
        dr.Close()


        Dim formattedID As String = autoORDERID

        TextBox1.Text = formattedID

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox9.Text = "" Then
            MsgBox("please input RFID", MsgBoxStyle.Critical)

        Else

            REGISTER()
            Me.Close()
            Managecus.Close()
            Managecus.Show()
        End If

    End Sub

    Sub REGISTER()

        Dim cntun, cntflb As String
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)

        str = "Select COUNT(MID) as cntun from MANAGECUSTOMER where FNAME = '" & TextBox2.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            cntun = dr.GetValue(0)
        End While
        dr.Close()
        cmd.Dispose()

        If cntun = "1" Then
            MsgBox("Username Already Exist")
        End If
        str = "Select COUNT(MID) as cntflb from MANAGECUSTOMER where MNAME = '" & TextBox3.Text & "' and LNAME = '" & TextBox4.Text & "' and AGE = '" & TextBox5.Text & "' and GENDER = '" & ComboBox2.SelectedItem & "' and CONTACT = '" & TextBox7.Text & "' and EMAIL = '" & TextBox8.Text & "' and STATUS = '" & ComboBox1.SelectedItem & "' and TIME_IN_DATE = '" & Label11.Text & "' and TIME_IN = '" & Label12.Text & "' and RFID_TAGS = '" & TextBox9.Text & "' and BALANCE = '" & TextBox6.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            cntflb = dr.GetValue(0)
        End While
        dr.Close()
        cmd.Dispose()
        If cntflb = "1" Then
            MsgBox("User Already Exist")
        End If
        If cntun = "0" And cntflb = "0" Then
            query = "insert into MANAGECUSTOMER (MID,FNAME,MNAME,LNAME,AGE,GENDER,CONTACT,EMAIL,STATUS,TIME_IN_DATE,TIME_IN,RFID_TAGS,IMAGE,BALANCE) values (@MID,@FNAME,@MNAME,@LNAME,@AGE,@GENDER,@CONTACT,@EMAIL,@STATUS,@TIME_IN_DATE,@TIME_IN,@RFID_TAGS,@IMAGE,@BALANCE)"
            cmd = New SqlClient.SqlCommand(query, sqlconn)
            With cmd
                .Parameters.AddWithValue("@MID", TextBox1.Text)
                .Parameters.AddWithValue("@FNAME", TextBox2.Text)
                .Parameters.AddWithValue("@MNAME", TextBox3.Text)
                .Parameters.AddWithValue("@LNAME", TextBox4.Text)
                .Parameters.AddWithValue("@AGE", TextBox5.Text)
                .Parameters.AddWithValue("@GENDER", ComboBox2.SelectedItem)
                .Parameters.AddWithValue("@CONTACT", TextBox7.Text)
                .Parameters.AddWithValue("@EMAIL", TextBox8.Text)
                .Parameters.AddWithValue("@STATUS", ComboBox1.SelectedItem)
                .Parameters.AddWithValue("@TIME_IN_DATE", Label11.Text)
                .Parameters.AddWithValue("@TIME_IN", Label12.Text)
                .Parameters.AddWithValue("@RFID_TAGS", TextBox9.Text)
                .Parameters.AddWithValue("@IMAGE", ms.ToArray)
                .Parameters.AddWithValue("@BALANCE", TextBox6.Text)




            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End If
        dr.Close()
        cmd.Dispose()
    End Sub
End Class