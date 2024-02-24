Imports System.Data
Imports System.Data.SqlClient
Imports BankBankApp.BO
Imports BankBankApp.Interfaces

Public Class AccountDAL
    Implements IAccount

    Private strConn As String = "Server=.\BSISQLEXPRESS;Database=BankBank;Trusted_Connection=True;TrustServerCertificate=True;"

    Public Function Create(entity As Account) As Integer Implements ICrud(Of Account).Insert
        Using conn As New SqlConnection(strConn),
              cmd As New SqlCommand("Accounts.CreateAccount", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@UserID", entity.UserID)
            cmd.Parameters.AddWithValue("@AccountNumber", entity.AccountNumber)
            cmd.Parameters.AddWithValue("@AccountType", entity.AccountTypeID)
            cmd.Parameters.AddWithValue("@Balance", entity.Balance)
            cmd.Parameters.AddWithValue("@Status", entity.Status)
            conn.Open()
            Return cmd.ExecuteNonQuery()
        End Using
    End Function

    Public Function Delete(id As Integer) As Integer Implements ICrud(Of Account).Delete
        Using conn As New SqlConnection(strConn),
              cmd As New SqlCommand("Accounts.DeleteAccount", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@AccountID", id)
            conn.Open()
            Return cmd.ExecuteNonQuery()
        End Using
    End Function

    Public Function GetAll() As List(Of Account) Implements ICrud(Of Account).GetAll
        Dim accounts As New List(Of Account)
        Using conn As New SqlConnection(strConn),
              cmd As New SqlCommand("Accounts.GetAllAccounts", conn)
            cmd.CommandType = CommandType.StoredProcedure
            conn.Open()
            Using dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()
                        Dim account As New Account With {
                            .AccountID = GetNullableInt32(dr, "AccountID"),
                            .UserID = GetNullableInt32(dr, "UserID"),
                            .AccountNumber = GetString(dr, "AccountNumber"),
                            .AccountTypeID = GetString(dr, "AccountType"),
                            .Balance = GetNullableDecimal(dr, "Balance"),
                            .Status = GetString(dr, "Status")
                        }
                        accounts.Add(account)
                    End While
                End If
            End Using
        End Using
        Return accounts
    End Function

    Public Function GetByUserID(userID As Integer) As List(Of Account) Implements IAccount.GetByUserID
        Throw New NotImplementedException()
    End Function

    Public Function GetByAccountNumber(accountNumber As String) As Account Implements IAccount.GetByAccountNumber
        Throw New NotImplementedException()
    End Function

    Public Function GetByCardNumber(cardNumber As String) As Account Implements IAccount.GetByCardNumber
        Throw New NotImplementedException()
    End Function

    Public Function UpdateAccountStatus(accountID As Integer, status As String) As Integer Implements IAccount.UpdateAccountStatus
        Throw New NotImplementedException()
    End Function

    Public Function GetById(id As Integer) As Account Implements ICrud(Of Account).GetById
        Throw New NotImplementedException()
    End Function

    Public Function Update(entity As Account) As Integer Implements ICrud(Of Account).Update
        Throw New NotImplementedException()
    End Function

    Private Function GetNullableInt32(reader As SqlDataReader, columnName As String) As Integer?
        Dim ordinal As Integer = reader.GetOrdinal(columnName)
        If Not reader.IsDBNull(ordinal) Then
            Return reader.GetInt32(ordinal)
        Else
            Return Nothing
        End If
    End Function

    Private Function GetNullableDecimal(reader As SqlDataReader, columnName As String) As Decimal?
        Dim ordinal As Integer = reader.GetOrdinal(columnName)
        If Not reader.IsDBNull(ordinal) Then
            Return reader.GetDecimal(ordinal)
        Else
            Return Nothing
        End If
    End Function

    Private Function GetString(reader As SqlDataReader, columnName As String) As String
        Dim ordinal As Integer = reader.GetOrdinal(columnName)
        If Not reader.IsDBNull(ordinal) Then
            Return reader.GetString(ordinal)
        Else
            Return Nothing
        End If
    End Function
End Class
