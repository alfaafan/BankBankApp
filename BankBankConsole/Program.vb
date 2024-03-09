Imports System
Imports BankBankApp.BO
Imports BankBankApp.DAL

Module Program
    Sub Main(args As String())
        Console.WriteLine("Welcome to BankBank App")
        Console.WriteLine("Please enter your UserID")
        Dim userID As String = Console.ReadLine()
        'Get user's transaction history by userID
        Dim transactionDAL As New TransactionDAL()
        Dim unused As New List(Of Transaction)
        'Dim transactions As List(Of Transaction) = transactionDAL.GetByUserID(Convert.ToInt32(userID))
        'For Each transaction As Transaction In transactions
        '    Console.WriteLine("TransactionID: " & transaction.TransactionID)
        '    Console.WriteLine("TransactionCategoryID: " & transaction.TransactionCategoryID)
        '    Console.WriteLine("SourceAccountID: " & transaction.SourceAccountID)
        '    Console.WriteLine("ReceiverAccountID: " & transaction.ReceiverAccountID)
        '    Console.WriteLine("BillID: " & transaction.BillID)
        '    Console.WriteLine("Amount: " & transaction.Amount)
        '    Console.WriteLine("Description: " & transaction.Description)
        '    Console.WriteLine("TransactionDate: " & transaction.TransactionDate)
        '    Console.WriteLine("Status: " & transaction.Status)
        '    Console.WriteLine("------------------------------------------------")
        'Next

    End Sub
End Module
