Imports BankBankApp.BO
Imports BankBankApp.Interfaces

Public Class BillDAL
    Implements IBill

    Public Function Create(entity As Bill) As Integer Implements ICrud(Of Bill).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Delete(id As Integer) As Integer Implements ICrud(Of Bill).Delete
        Throw New NotImplementedException()
    End Function

    Public Function GetAll() As List(Of Bill) Implements ICrud(Of Bill).GetAll
        Throw New NotImplementedException()
    End Function

    Public Function GetById(id As Integer) As Bill Implements ICrud(Of Bill).GetById
        Throw New NotImplementedException()
    End Function

    Public Function Update(entity As Bill) As Integer Implements ICrud(Of Bill).Update
        Throw New NotImplementedException()
    End Function

    Public Function GetByUserID(userID As Integer) As List(Of Bill) Implements IBill.GetByUserID
        Throw New NotImplementedException()
    End Function
End Class
