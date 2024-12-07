Imports System.Data.SqlClient

Public Class REPORT
    Private Sub REPORT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using con As New SqlConnection("Data Source=MUNDANE\FOODMANAGE;Initial Catalog=Foodmanagement;Integrated Security=True;Encrypt=False")
            Dim dt As New DataTable

            con.Open()
            Using cmd As New SqlCommand("Select * from MANAGETRANSACT", con)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd

                da.Fill(dt)
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "C:\Users\Jugeric Gatmin\Desktop\FoodManagement\FoodManagement\Report.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
            End With

        End Using
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Transac.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using con As New SqlConnection("Data Source=MUNDANE\FOODMANAGE;Initial Catalog=Foodmanagement;Integrated Security=True;Encrypt=False")
            Dim dt As New DataTable

            con.Open()
            Using cmd As New SqlCommand("Select * from MANAGETRANSACT", con)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd

                da.Fill(dt)
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "C:\Users\Jugeric Gatmin\Desktop\FoodManagement\FoodManagement\Report.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
            End With

        End Using
        Me.ReportViewer1.RefreshReport()
    End Sub

  
End Class