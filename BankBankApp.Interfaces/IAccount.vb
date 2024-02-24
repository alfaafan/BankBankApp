Imports BankBankApp.BO

Public Interface IAccount
    Inherits ICrud(Of Account)

    Function GetByUserID(userID As Integer) As List(Of Account)

    Function GetByAccountNumber(accountNumber As String) As Account

    Function GetByCardNumber(cardNumber As String) As Account

    Function UpdateAccountStatus(accountID As Integer, status As String) As Integer

End Interface
