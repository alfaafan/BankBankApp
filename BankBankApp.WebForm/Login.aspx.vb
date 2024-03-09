Imports BankBankApp.BLL
Imports BankBankApp.BLL.DTOs

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtUsername.Text) Or
            String.IsNullOrEmpty(txtPassword.Text) Then
            ltMessage.Text = "<span class='alert alert-danger'>Username and Password are required</span><br/><br/>"
            Return
        End If
        Try
            Dim _userBLL As New UserBLL()
            Dim _userDTO As New UserLoginDTO()
            _userDTO.Username = txtUsername.Text
            _userDTO.Password = txtPassword.Text

            Dim _user = _userBLL.Login(_userDTO.Username, _userDTO.Password)

            If _user IsNot Nothing Then
                Session("Username") = _user.Username
                Session("FirstName") = _user.FirstName
                Session("LastName") = _user.LastName
                Session("Email") = _user.Email
                Session("Phone") = _user.Phone
                Session("DateOfBirth") = _user.DateOfBirth

                Dim returnUrl = Request.QueryString("ReturnUrl")
                If String.IsNullOrEmpty(returnUrl) Then
                    Response.Redirect("~/" & returnUrl)
                Else
                    Response.Redirect("~/Default.aspx")
                End If
            Else
                ltMessage.Text = "<span class='alert alert-danger'>Invalid Username or Password</span><br/><br/>"
            End If
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try

    End Sub
End Class