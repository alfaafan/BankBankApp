Public Class BillPayment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnPay_Click(sender As Object, e As EventArgs)
        If Session("Username") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If
        lblBillAmount.Text = "Bill Amount: 50.000"
    End Sub
End Class