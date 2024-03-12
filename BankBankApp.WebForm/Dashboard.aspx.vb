Imports System.Globalization
Imports System.Web.Util
Imports BankBankApp.BLL

Public Class Dashboard
    Inherits System.Web.UI.Page

#Region "Binding Data"
    Sub LoadCategories()
        Dim _transactionBLL = New TransactionBLL()
        Dim _transactions = _transactionBLL.GetTransactionHistory(Session("UserID"))
        If _transactions.Count > 0 Then
            rptActivity.DataSource = _transactions
            rptActivity.DataBind()
        End If
    End Sub

    Sub LoadBalance()
        Dim _accountBLL = New AccountBLL()
        Dim _account = _accountBLL.GetByAccountNumber(Session("AccountNumber"))
        If _account IsNot Nothing Then
            Session("Balance") = ConvertToMoneyFormat(_account.Balance, "IDR")
        End If
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Username") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If

        If Not IsPostBack Then
            LoadCategories()
            LoadBalance()
        End If
    End Sub

    Function ConvertToMoneyFormat(ByVal number As Double, ByVal currencyCode As String) As String
        Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture("id-ID")
        Dim formatInfo As NumberFormatInfo = CType(culture.NumberFormat.Clone(), NumberFormatInfo)
        formatInfo.CurrencySymbol = GetCurrencySymbol(currencyCode)

        Return number.ToString("C2", formatInfo)
    End Function

    Function GetCurrencySymbol(ByVal currencyCode As String) As String
        Select Case currencyCode.ToUpper()
            Case "IDR"
                Return "Rp"
                ' Add more cases for other currency codes if needed
            Case Else
                Throw New ArgumentException("Unsupported currency code")
        End Select
    End Function

End Class