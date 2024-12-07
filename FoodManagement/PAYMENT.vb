Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class PAYMENT
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label16.Text = Date.Now.ToString("dddd, MMMM d, yyyy")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim p As Integer
        Dim sum As Integer
        If TextBox1.Text = "" Then
            MsgBox("PLEASE INPUT AMOUNT!!", vbCritical, "PAYMENT FAILED")
        Else
            p = Val(TextBox1.Text)

            If (p < Label13.Text) Then
                MsgBox("PAYMENT NOT ENOUGH, UNABLE TO PROCESS", vbCritical, "PAYMENT FAILED")

            Else

                sum = TextBox1.Text - Label13.Text
                Label14.Text = sum
                MsgBox("PAYMENT RECEIVED!")
                Label15.Text = "COMPLETE"

                addTRansac()
                cusLoad.Panel3.Hide()
                cusLoad.Panel2.Hide()
                Me.Close()





            End If
        End If

    End Sub


    Sub addTRansac()
        Dim cntun, cntflb As String


        str = "Select COUNT(TID) as cntun from MANAGETRANSACT where FNAME = '" & Label9.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            cntun = dr.GetValue(0)
        End While
        dr.Close()
        cmd.Dispose()



        str = "Select COUNT(TID) as cntflb from MANAGETRANSACT where MNAME = '" & Label11.Text & "' and LNAME = '" & Label12.Text & "' and AMOUNTDUE = '" & Label13.Text & "' and PAYMENT = '" & TextBox1.Text & "' and CHANGE = '" & Label14.Text & "' and PAYMENT_STATUS = '" & Label15.Text & "' and DATE = '" & Label16.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            cntflb = dr.GetValue(0)
        End While
        dr.Close()
        cmd.Dispose()




        query = "insert into MANAGETRANSACT (TID,FNAME,MNAME,LNAME,AMOUNTDUE,PAYMENT,CHANGE,PAYMENT_STATUS,DATE) values (@TID,@FNAME,@MNAME,@LNAME,@AMOUNTDUE,@PAYMENT,@CHANGE,@PAYMENT_STATUS,@DATE)"
        cmd = New SqlClient.SqlCommand(query, sqlconn)

        With cmd


            .Parameters.AddWithValue("@TID", Label18.Text)
            .Parameters.AddWithValue("@FNAME", Label9.Text)
            .Parameters.AddWithValue("@MNAME", Label11.Text)
            .Parameters.AddWithValue("@LNAME", Label12.Text)
            .Parameters.AddWithValue("@AMOUNTDUE", Label13.Text)
            .Parameters.AddWithValue("@PAYMENT", TextBox1.Text)
            .Parameters.AddWithValue("@CHANGE", Label14.Text)
            .Parameters.AddWithValue("@PAYMENT_STATUS", Label15.Text)
            .Parameters.AddWithValue("@DATE", Label16.Text)






        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        dr.Close()
        cmd.Dispose()
    End Sub


End Class