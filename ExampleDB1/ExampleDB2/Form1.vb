Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conStr As String
        conStr = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=D:\Northwind.mdf"

        Dim conn As New SqlConnection(conStr)
        conn.Open()
        Dim sql As String = "SELECT categoryname , categoryid FROM Categories"
        Dim cmd As New SqlCommand(sql, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim data As New DataSet()
        adapter.Fill(data, "category")

        'MessageBox.Show(data.Tables("category").Rows.Count)  'Check Rows by Counts
        'MessageBox.Show(data.Tables("category").Columns(1).ToString)  'Check Rows by Counts

        DataGridView1.DataSource = data.Tables("category")
        For i = 0 To data.Tables("category").Rows.Count - 1
            ListBox1.Items.Add(data.Tables("category").Rows(i)("categoryname"))
            ComboBox1.Items.Add(data.Tables("category").Rows(i)("categoryname"))
        Next

        conn.Close()
    End Sub
End Class
