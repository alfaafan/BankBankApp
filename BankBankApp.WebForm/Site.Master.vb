Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim sb As New StringBuilder

        If Not Page.IsPostBack Then
            Dim user = Session("Username")
            Dim firstName = Session("FirstName")
            Dim lastName = Session("LastName")
            If user IsNot Nothing Then
                ltUsername.Text = UCase(firstName + " " + lastName)
                pnlLoggedIn.Visible = True
                pnlAnonymous.Visible = False
            Else
                ltUsername.Text = "Guest"
                pnlLoggedIn.Visible = False
                pnlAnonymous.Visible = True
            End If
        End If
    End Sub

    Function IsActive(ByVal pageName As String) As Boolean
        Return Request.Url.AbsolutePath.ToLower().Contains(pageName.ToLower())
    End Function
End Class