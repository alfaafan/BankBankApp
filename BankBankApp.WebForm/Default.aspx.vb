Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Username") IsNot Nothing Then
            Response.Redirect("~/Dashboard")
        End If
    End Sub

End Class