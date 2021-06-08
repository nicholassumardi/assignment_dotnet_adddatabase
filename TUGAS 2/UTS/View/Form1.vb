Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32
Imports System.Data.SqlClient
Public Class Form1
    Dim ModelBarang As New ModelBarang
    Dim ModelDetail As New ModelDetailPembelian
    Dim ModelPesanan As New ModelPesanan
    Dim ModelPembayaran As New ModelPembayaran
    Dim koneksi As New Koneksi
    Dim idPesanan As Integer
    Dim idPembayaran As Integer
    Dim idBarang As Integer
    Dim namaBarang As String
    Dim hargaBarang As Integer
    Dim jumlahBarang As Integer
    Dim uangPembeli As Integer
    Dim totalHarga As Integer
    Dim stokBarang As Integer
    Dim sqlQuery As String
    Dim sqlQuery2 As String

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        idBarang = Integer.Parse(TextBox1.Text)
        hargaBarang = Integer.Parse(TextBox3.Text)
        jumlahBarang = Integer.Parse(TextBox4.Text)

        Dim totalHagraKeseluruhan As Integer
        totalHagraKeseluruhan = jumlahBarang * hargaBarang
        Dim newstok As Integer
        newstok = Integer.Parse(ModelBarang.getStok(idBarang)) - jumlahBarang

        ModelBarang.updateStok(newstok, idBarang)
        ModelPesanan.addPesanan()
        idPesanan = Integer.Parse(ModelPesanan.getID())


        ModelDetail.insertData(idPesanan, idBarang, jumlahBarang, totalHagraKeseluruhan)

        updateTable()
        updatetable2()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Index As Integer
        namaBarang = TextBox8.Text
        Index = ModelBarang.search(namaBarang)
        If Index > 0 Then
            MsgBox("DATA DITEMUKAN", MessageBoxButtons.OK, "SEARCHING")
        Else
            MsgBox("TIDAK DITEMUKAN", MessageBoxButtons.OK, "SEARCHING")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        idBarang = Integer.Parse(TextBox7.Text)
        ModelDetail.nullBarang(idBarang)
        ModelBarang.deleteBarang(idBarang)

        updateTable()
        updatetable2()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        namaBarang = TextBox8.Text
        hargaBarang = TextBox9.Text
        stokBarang = TextBox10.Text

        ModelBarang.addBarang(namaBarang, stokBarang, hargaBarang)


        updateTable()
        updatetable2()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Index As Integer
        namaBarang = TextBox8.Text
        Index = ModelBarang.search(namaBarang)
        If Index > 0 Then
            MsgBox("DATA DITEMUKAN", MessageBoxButtons.OK, "SEARCHING")
        Else
            MsgBox("TIDAK DITEMUKAN", MessageBoxButtons.OK, "SEARCHING")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox13.Enabled = False
        TextBox7.Enabled = False
        updateTable()
        updatetable2()

    End Sub
    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow = DataGridView1.Rows(index)
        TextBox11.Text() = selectedrow.Cells(0).Value.ToString
        TextBox13.Text() = selectedrow.Cells(3).Value.ToString

    End Sub
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow = DataGridView1.Rows(index)
        TextBox7.Text = selectedrow.Cells(0).Value.ToString
        TextBox8.Text = selectedrow.Cells(1).Value.ToString
        TextBox9.Text = selectedrow.Cells(2).Value.ToString
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow = DataGridView1.Rows(index)
        TextBox1.Text = selectedrow.Cells(0).Value.ToString
        TextBox2.Text = selectedrow.Cells(1).Value.ToString
        TextBox3.Text = selectedrow.Cells(3).Value.ToString
    End Sub

    Public Sub updateTable()

        Dim conn As New MySqlConnection("server=localhost;user id=root;database=dotnet")

        Dim adapter As New MySqlDataAdapter("select * from barang", conn)
        Dim table As New DataTable
        adapter.Fill(table)
        DataGridView1.DataSource = table
        DataGridView2.DataSource = table

    End Sub

    Public Sub updatetable2()
        Dim conn As New MySqlConnection("server=localhost;user id=root;database=dotnet")

        Dim adapter As New MySqlDataAdapter("select a.id_pesanan, c.namabarang, a.qtytotal, a.totalharga
                             from detailpembelian a
                             inner Join pesanan b on a.id_pesanan = b.id_pesanan
                             inner Join barang c on a.id_barang = c.id_barang
                             ORDER BY id_pesanan ASC", conn)
        Dim table As New DataTable
        adapter.Fill(table)
        DataGridView3.DataSource = table
    End Sub

    Public Sub empty()
        DataGridView1.DataSource = Nothing
        DataGridView2.DataSource = Nothing
        DataGridView3.DataSource = Nothing
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        uangPembeli = Integer.Parse(TextBox12.Text)
        totalHarga = Integer.Parse(TextBox13.Text)
        idPesanan = Integer.Parse(ModelPesanan.getID())
        idPembayaran = Integer.Parse(ModelPembayaran.getID())
        Dim Kembalian As Integer
        Kembalian = uangPembeli - totalHarga
        ModelPembayaran.addPembayaran(uangPembeli, Kembalian, idPesanan)
        ModelPesanan.insertIdBayar(idPesanan, idPembayaran)
        MsgBox("Kembalian = " & Kembalian)


    End Sub


End Class
