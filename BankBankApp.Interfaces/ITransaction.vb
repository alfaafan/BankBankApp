Imports BankBankApp.BO

Public Interface ITransaction
    Inherits ICrud(Of Transaction)

    Function GetByUserID(userID As Integer) As List(Of Transaction)

End Interface
