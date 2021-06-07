
Public Class ModelBarang
    Dim koneksi As New Koneksi
    Dim sqlQuery As String

    Public Sub addBarang(nama As String, stok As String, harga As String)
        If koneksi.koneksi() Then
            sqlQuery = "INSERT into barang values ('', '" + nama + "', '" + stok + "', '" + harga + "')"
            Try
                koneksi.getData(sqlQuery)
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            Finally
                koneksi.sqlRead.Close()
                koneksi.sqlKoneksi.Close()
            End Try
        End If

    End Sub

    Public Function getStok(idbarang As String)
        Dim result As Integer
        If koneksi.koneksi() Then
            sqlQuery = "SELECT stok FROM barang where id_barang ='" + idbarang + "'"
            Try
                result = koneksi.getSingle(sqlQuery)
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            Finally
                koneksi.sqlKoneksi.Close()
            End Try
        End If
        Return result
    End Function
    Public Sub updateStok(newStok As String, idbarang As String)
        If koneksi.koneksi() Then
            sqlQuery = "UPDATE barang set stok = '" + newStok + "' where id_barang = '" + idbarang + "'"
            Try
                koneksi.getData(sqlQuery)
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            Finally
                koneksi.sqlRead.Close()
                koneksi.sqlKoneksi.Close()
            End Try
        End If
    End Sub

    Public Sub deleteBarang(idBarang As String)
        If koneksi.koneksi() Then
            sqlQuery = "DELETE from barang where id_barang = '" + idBarang + "'"
            Try
                koneksi.getData(sqlQuery)
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            Finally

                koneksi.sqlKoneksi.Close()
            End Try
        End If
    End Sub


    Public Function search(namabarang As String)
        Dim index As Integer
        index = False
        If koneksi.koneksi() Then
            sqlQuery = "select id_barang from barang where namabarang = '" + namabarang + "'"
            Try
                index = koneksi.getSingle(sqlQuery)

            Catch ex As Exception
                Console.WriteLine(ex.ToString())
                index = 0
            Finally
                koneksi.sqlKoneksi.Close()
            End Try
        End If
        Return index
    End Function


End Class
