Imports System.Data
Imports System.Data.SqlClient


Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conStr As String
        Dim id As String = TextBox1.Text
        Dim found As Boolean = True

        conStr = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=D:\Northwind.mdf"
        Dim conn As New SqlConnection(conStr)
        conn.Open()

        Dim sql As String = "SELECT CompanyName , ContactName,Address , City , Phone 
                             FROM Customers
                             where CustomerID = '" & id.ToUpper & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        While reader.Read()
            lblcompanyname.Text = reader("companyname")
            lblcontactname.Text = reader("contactname")
            lbladdress.Text = reader("address")
            lblcity.Text = reader("city")
            lblphone.Text = reader("phone")
            found = False
        End While

        If found = True Then
            MessageBox.Show(id.ToUpper & " not found...")
            lbladdress.Text = ""
            lblcontactname.Text = ""
            lblcity.Text = ""
            lblphone.Text = ""
            lblcompanyname.Text = ""
        End If

        reader.Close()
        conn.Close()

    End Sub
End Class
