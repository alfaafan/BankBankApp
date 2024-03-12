Imports BankBankApp.BLL
Imports BankBankApp.BLL.DTOs

Public Class Transfer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnTransfer_Click(sender As Object, e As EventArgs)
        Dim receiverAccountNumber As String = txtReceiverAccountNumber.Text
        Dim amount As String = txtAmount.Text
        Dim description As String = txtDescription.Text

        If String.IsNullOrEmpty(receiverAccountNumber) Or
            String.IsNullOrEmpty(amount) Then
            ltMessage.Text = "<span class='alert alert-danger'>Receiver Account Number and Amount are required</span><br/><br/>"
            Return
        End If

        Session("ReceiverAccountNumber") = receiverAccountNumber
        Session("Amount") = amount
        Session("Description") = description

        Response.Redirect("~/TransferConfirmation.aspx")
    End Sub
End Class