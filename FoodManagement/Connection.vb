Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO
Imports System.Text

Module globalization
    Public startpath As String = Application.StartupPath
    Public SR As StreamReader
    Public srvr As String
    Public loc As String = (startpath + "\Connection.ini")
    Public sqlconn As New SqlConnection
    Public cmd As New SqlCommand
    Public dr As SqlDataReader
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public dt As New DataTable
    Public str As String
    Public query As String
    Public userid, fname, lname, mname, usertype, userlevel, uid, oldpass, imageE, password, username, BIO, RFID As String


    Public Function encrypt(Encryption As String) As String
        Dim pw As String = String.Empty
        Dim encode As Byte() = New Byte(Encryption.Length - 1) {}
        encode = Encoding.UTF8.GetBytes(Encryption)
        pw = Convert.ToBase64String(encode)
        Return pw

    End Function
    Sub connect()
        If Not File.Exists(loc) Then
            MsgBox("Server Connection not Found", MsgBoxStyle.Exclamation, "error in Connection")
        Else
            Try
                SR = File.OpenText(loc)
                While SR.Peek <> -1
                    srvr = SR.ReadLine()
                End While
                SR.Close()
                If sqlconn.State = ConnectionState.Open Then sqlconn.Close()
                sqlconn.ConnectionString = srvr + ";Trusted_Connection = true; MultipleActiveResultsets = true;"

                sqlconn.Open()

            Catch ex As Exception
                MsgBox("Error in Connection please contact Administrator", MsgBoxStyle.Exclamation.MsgBoxHelp, "Error in connection")

            End Try
        End If
    End Sub






End Module