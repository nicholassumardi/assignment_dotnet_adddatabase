Public Class ModelDetailPembelian
    Dim koneksi As New Koneksi
    Dim sqlQuery As String


    Public Sub insertData(idPesanan As String, idbarang As String, qty As String, total As String)
        If koneksi.koneksi() Then
            sqlQuery = "INSERT into detailpembelian (id_pesanan, id_barang, qtytotal, totalharga) values ('" + idPesanan + "', '" + idbarang + "', '" + qty + "', '" + total + "')"
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

    Public Sub nullBarang(idbarang As String)
        If koneksi.koneksi() Then
            sqlQuery = "UPDATE detailpembelian set id_barang = null where id_barang = '" + idbarang + "'"
            Try
                koneksi.getData(sqlQuery)
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            Finally

                koneksi.sqlKoneksi.Close()
            End Try
        End If
    End Sub


End Class
