Imports BankBankApp.BO

Public Interface IBill
    Inherits ICrud(Of Bill)

    Function GetByUserID(userID As Integer) As List(Of Bill)

End Interface
