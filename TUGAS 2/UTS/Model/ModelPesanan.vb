Public Class ModelPesanan
    Dim koneksi As New Koneksi
    Dim sqlQuery As String

    Public Sub addPesanan()
        If koneksi.koneksi() Then
            sqlQuery = "insert into pesanan (id_pesanan) values ('')"
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

    Public Function getID()
        Dim result As Integer
        If koneksi.koneksi() Then
            sqlQuery = "select MAX(id_pesanan) FROM pesanan"
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
    Public Sub insertIdBayar(idPesanan As String, idPembayaran As String)
        If koneksi.koneksi() Then
            sqlQuery = "UPDATE pesanan set id_pembayaran = '" + idPembayaran + "' where id_pesanan = '" + idPesanan + "'"
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
End Class
