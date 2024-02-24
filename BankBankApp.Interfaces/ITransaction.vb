Imports BankBankApp.BO

Public Interface ITransaction
    Inherits ICrud(Of Transaction)

    Function GetByUserID(userID As Integer) As List(Of Transaction)

    Sub CreateBillTransaction(accountID As Integer, billID As Integer, amount As Decimal, description As String)

    Sub CreateTransferTransaction(sourceAccountID As Integer, receiverAccountID As Integer, amount As Decimal, description As String)

    Sub CreateWithdrawTransaction(accountID As Integer, amount As Decimal, description As String)

End Interface
