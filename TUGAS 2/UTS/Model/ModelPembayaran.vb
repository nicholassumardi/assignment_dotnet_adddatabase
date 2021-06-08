Public Class ModelPembayaran
    Dim koneksi As New Koneksi
    Dim sqlQuery As String

    Public Sub addPembayaran(bayar As String, kembalian As String, id_pesanan As String)
        If koneksi.koneksi() Then
            sqlQuery = "INSERT into pembayaran (id_pembayaran, bayar, kembalian, id_pesanan) values ('', '" + bayar + "', '" + kembalian + "','" + id_pesanan + "')"
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
            sqlQuery = "select MAX(id_pembayaran) FROM pembayaran"
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

End Class
