Imports System.Data.OleDb
Public Class Form1
    Private Sub button_cari_Click(sender As Object, e As EventArgs) Handles button_cari.Click
        Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\MuhammadSaifulloh\Downloads\folder onedrive\KULIAH\GANJIL 2023_2024\PEMROGRAMAN VISUAL\UAS\database_mahasiswa.accdb")
        conn.Open()
        Dim cmd As New OleDbCommand("select * from Sheet1 where NIM=@parm1", conn)
        cmd.Parameters.AddWithValue("parm1", nim_search.Text)
        Dim myreader As OleDbDataReader
        myreader = cmd.ExecuteReader
        If myreader.Read Then
            Dim mystatus As String
            Dim combinedtext As String
            If myreader("Nilai") > 70 Then
                mystatus = "Lulus"
            Else
                mystatus = "Gagal"
            End If
            combinedtext = String.Concat(myreader("NIM").ToString, " - ", myreader("nama_mahasiswa").ToString, " - ", myreader("kelas").ToString, " - ", myreader("Mata_kuliah").ToString, " - ", "nilai: ", myreader("Nilai"), " - ", "status: ", mystatus)
            ListBox1.Items.Add(combinedtext)
            nim_search.Text = ""
            nim_search.Focus()
        Else
            MessageBox.Show("data tidak ditemukan")
        End If
        conn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        nim_search.Text = ""
        nim_search.Focus()
    End Sub
End Class
