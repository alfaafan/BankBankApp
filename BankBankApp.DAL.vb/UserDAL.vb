Imports BankBankApp.BO
Imports BankBankApp.Interfaces

Public Class UserDAL
    Implements IUser

    Public Function GetByUsername(username As String) As User Implements IUser.GetByUsername
        Throw New NotImplementedException()
    End Function

    Public Function GetByEmail(email As String) As User Implements IUser.GetByEmail
        Throw New NotImplementedException()
    End Function

    Public Function Register(user As User) As Integer Implements IUser.Register
        Throw New NotImplementedException()
    End Function

    Public Function GetAll() As List(Of User) Implements ICrud(Of User).GetAll
        Throw New NotImplementedException()
    End Function

    Public Function GetById(id As Integer) As User Implements ICrud(Of User).GetById
        Throw New NotImplementedException()
    End Function

    Public Function Insert(entity As User) As Integer Implements ICrud(Of User).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(entity As User) As Integer Implements ICrud(Of User).Update
        Throw New NotImplementedException()
    End Function

    Public Function Delete(id As Integer) As Integer Implements ICrud(Of User).Delete
        Throw New NotImplementedException()
    End Function
End Class
