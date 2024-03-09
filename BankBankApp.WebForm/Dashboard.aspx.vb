Public Class Dashboard
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("firstName") IsNot Nothing Then
            ltGreetings.Text = "Hello, " & Session("firstName") & "!"
        Else
            ltGreetings.Text = "Hello, Guest!"
        End If
    End Sub

End Class