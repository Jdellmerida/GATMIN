Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class Form1
    Dim trynumber As Integer
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
    End Sub

    Sub loginFUNCTION()

        If sqlconn.State <> ConnectionState.Open Then
            sqlconn.Open()
        End If
        Dim da As New SqlDataAdapter("select * from ACCOUNTS ", sqlconn)
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        Dim resultat As Integer
        For i = 0 To dt.Rows.Count - 1
            If TextBox1.Text = Convert.ToString(dt.Rows(i)("USERNAME")) And
                TextBox2.Text = Convert.ToString(dt.Rows(i)("PASSWORD")) Then

                fname = Convert.ToString(dt.Rows(i)("FNAME"))
                lname = Convert.ToString(dt.Rows(i)("LNAME"))
                ' mname = Convert.ToString(dt.Rows(i)("MNAME"))
                userlevel = Convert.ToString(dt.Rows(i)("USERLEVEL"))
                ' uid = Convert.ToString(dt.Rows(i)("uid"))
                'oldpass.Label5.Text = Convert.ToString(dt.Rows(i)("Password"))
                ' username.Label3.Text = Convert.ToString(dt.Rows(i)("Username"))
                uid = Convert.ToString(dt.Rows(i)("UID"))
                imageE = Convert.ToString(dt.Rows(i)("IMAGE"))
                ' BIO = Convert.ToString(dt.Rows(i)("BIO"))
                password = Convert.ToString(dt.Rows(i)("PASSWORD"))
                username = Convert.ToString(dt.Rows(i)("USERNAME"))
                '  RFID = Convert.ToString(dt.Rows(i)("RFID"))
                Me.Hide()


                MsgBox(" You are now logged in", MsgBoxStyle.Exclamation)
                DASHBOARD.Show()
                DASHBOARD.Label6.Text = fname + " " + lname
                ' Personal.Label10.Text = fname
                ' Personal.Label11.Text = mname
                ' Personal.Label12.Text = lname
                ' Personal.TextBox1.Text = password
                ' Personal.Label9.Text = username
                ' Personal.TextBox2.Text = RFID
                'Personal.Label15.Text = password
                ' Form2.Label2.Text = uid


                '  Form2.Label1.Text = (fname + " " + mname + " " + lname)
                ' Form2.Show()
                'Dashboard.Show()
                'Dashboard.Label5.Text = fname + " " + lname
                ' USERMANAGEMENT.Label13.Text = uid
                ' Personal.Label14.Text = uid
                'USERMANAGEMENT.Label14.Text = userlevel
                DASHBOARD.Label5.Text = uid
                DASHBOARD.Label7.Text = userlevel
                ' Settings.Label7.Text = uid
                ' Settings.TextBox1.Text = BIO
                ' Dashboard.TextBox1.Text = BIO
                'Personal.Label17.Text = uid




                resultat = 1

                Try
                    str = "Select * from ACCOUNTS where PASSWORD = @PASSWORD"
                    cmd = New SqlClient.SqlCommand(str, sqlconn)
                    With cmd
                        .Parameters.AddWithValue("@USERNAME", TextBox1.Text)
                        .Parameters.AddWithValue("@PASSWORD", TextBox2.Text)
                    End With

                    dr = cmd.ExecuteReader
                    If (dr.Read()) Then

                    End If
                    cmd.Dispose()
                    dr.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next
        If resultat <> 1 Then

            MsgBox("Invalid Credentials", MsgBoxStyle.Critical)
            trynumber += 1


            If trynumber >= 3 Then
                MsgBox(" You are now Locked! Please Try again", MsgBoxStyle.Critical)
                '
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loginFUNCTION()
    End Sub
End Class
