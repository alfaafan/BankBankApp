Imports BankBankApp.BLL
Imports BankBankApp.BLL.DTOs

Public Class TransferConfirmation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim receiverAccountNumber As String = Session("ReceiverAccountNumber").ToString()
            Dim amount As String = Session("Amount").ToString()
            Dim description As String = Session("Description").ToString()

            If receiverAccountNumber And amount Is Nothing Then
                Response.Redirect("~/Transfer.aspx")
            End If

            lblRecipientAccountNumber.Text = receiverAccountNumber
            lblAmount.Text = amount
            lblRemarks.Text = description
        End If
    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs)
        Dim _transactionBLL = New TransactionBLL()
        Dim _transaction As New TransferDTO()

        _transaction.SourceAccountNumber = Session("AccountNumber")
        _transaction.ReceiverAccountNumber = Session("ReceiverAccountNumber").ToString()
        _transaction.Amount = Decimal.Parse(Session("Amount"))
        _transaction.Description = Session("Description")

        Try
            _transactionBLL.Transfer(_transaction)
            ltMessage.Text = "<span class='alert alert-success'>Transfer successful</span><br/><br/>"

            Response.Redirect("~/Dashboard.aspx")
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>" & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
End Class