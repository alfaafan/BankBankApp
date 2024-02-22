Imports BankBankApp.BO

Public Interface IUser
    Inherits ICrud(Of User)

    Function GetByUsername(username As String) As User
    Function GetByEmail(email As String) As User
    Function Register(user As User) As Integer
End Interface
