Imports BankBankApp.BO
Imports BankBankApp.Interfaces

Public Class BillerDAL
    Implements IBiller

    Public Function Create(entity As Biller) As Integer Implements ICrud(Of Biller).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Delete(id As Integer) As Integer Implements ICrud(Of Biller).Delete
        Throw New NotImplementedException()
    End Function

    Public Function GetAll() As List(Of Biller) Implements ICrud(Of Biller).GetAll
        Throw New NotImplementedException()
    End Function

    Public Function GetById(id As Integer) As Biller Implements ICrud(Of Biller).GetById
        Throw New NotImplementedException()
    End Function

    Public Function Update(entity As Biller) As Integer Implements ICrud(Of Biller).Update
        Throw New NotImplementedException()
    End Function

End Class
