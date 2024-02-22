Imports System.Data
Imports System.Data.SqlClient
Imports BankBankApp.BO
Imports BankBankApp.Interfaces

Public Class TransactionDAL
    Implements ITransaction

    Private strConn As String = "Server=.\BSISQLEXPRESS;Database=BankBank;Trusted_Connection=True;TrustServerCertificate=True;"
    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader

    Public Sub New()
        conn = New SqlConnection(strConn)
    End Sub

    Public Function GetByUserID(userID As Integer) As List(Of Transaction) Implements ITransaction.GetByUserID
        Dim transactions As New List(Of Transaction)
        Try
            cmd = New SqlCommand("Transactions.GetUserTransactionHistory", conn) With {
            .CommandType = CommandType.StoredProcedure
        }
            cmd.Parameters.AddWithValue("@UserID", userID)
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Dim transaction As New Transaction()
                    transaction.TransactionID = GetNullableInt32(dr, "TransactionID")
                    transaction.TransactionCategoryID = GetNullableInt32(dr, "TransactionCategoryID")
                    transaction.SourceAccountID = GetNullableInt32(dr, "SourceAccountID")
                    transaction.ReceiverAccountID = GetNullableInt32(dr, "ReceiverAccountID")
                    transaction.BillID = GetNullableInt32(dr, "BillID")
                    transaction.Amount = GetNullableDecimal(dr, "Amount")
                    transaction.Description = GetString(dr, "Description")
                    transaction.TransactionDate = dr.GetDateTime(dr.GetOrdinal("TransactionDate"))
                    transaction.Status = GetString(dr, "Status")
                    transactions.Add(transaction)
                End While
            End If
            dr.Close()

            Return transactions
        Catch sqlEx As SqlException
            Throw New Exception("SQL Error: " & sqlEx.Message)
        Catch ex As Exception
            Throw New Exception("Error: " & ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Function

    Private Function GetNullableInt32(dr As SqlDataReader, fieldName As String) As Integer?
        Dim ordinal As Integer = dr.GetOrdinal(fieldName)
        If Not dr.IsDBNull(ordinal) Then
            Return dr.GetInt32(ordinal)
        Else
            Return Nothing
        End If
    End Function

    Private Function GetNullableDecimal(dr As SqlDataReader, fieldName As String) As Decimal?
        Dim ordinal As Integer = dr.GetOrdinal(fieldName)
        If Not dr.IsDBNull(ordinal) Then
            Return dr.GetDecimal(ordinal)
        Else
            Return Nothing
        End If
    End Function

    Private Function GetString(dr As SqlDataReader, fieldName As String) As String
        Dim ordinal As Integer = dr.GetOrdinal(fieldName)
        If Not dr.IsDBNull(ordinal) Then
            Return dr.GetString(ordinal)
        Else
            Return Nothing
        End If
    End Function


    Public Function GetAll() As List(Of Transaction) Implements ICrud(Of Transaction).GetAll
        Throw New NotImplementedException()
    End Function

    Public Function GetById(id As Integer) As Transaction Implements ICrud(Of Transaction).GetById
        Throw New NotImplementedException()
    End Function

    Public Function Insert(entity As Transaction) As Integer Implements ICrud(Of Transaction).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(entity As Transaction) As Integer Implements ICrud(Of Transaction).Update
        Throw New NotImplementedException()
    End Function

    Public Function Delete(id As Integer) As Integer Implements ICrud(Of Transaction).Delete
        Throw New NotImplementedException()
    End Function
End Class
