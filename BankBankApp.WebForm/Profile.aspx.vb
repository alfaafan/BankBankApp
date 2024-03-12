Imports BankBankApp.BLL

Public Class Profile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Username") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If

        Dim UserID = Session("UserID")
        Try
            Dim _cardBLL As New CardBLL()
            Dim _cardDetails = _cardBLL.GetByUserID(UserID)
            If _cardDetails IsNot Nothing Then
                Session("cardNumber") = _cardDetails.CardNumber
            End If

        Catch ex As Exception

        End Try

    End Sub

End Class