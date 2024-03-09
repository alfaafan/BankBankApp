Imports BankBankApp.BLL
Imports BankBankApp.BLL.DTOs

Public Class Register
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegistration_Click(sender As Object, e As EventArgs)
        Try
            Dim _userBLL As New UserBLL()
            Dim _userDTO As New UserCreateDTO()
            _userDTO.FirstName = txtFirstName.Text
            _userDTO.LastName = txtLastName.Text
            _userDTO.Username = txtUsername.Text
            _userDTO.Email = txtEmail.Text
            _userDTO.Password = txtPassword.Text
            _userDTO.RepeatPassword = txtRepassword.Text
            _userDTO.Phone = txtPhone.Text
            _userDTO.DateOfBirth = txtDateOfBirth.Text

            _userBLL.Create(_userDTO)

            ltMessage.Text = "<span class='alert alert-success'>User Registration Success</span><br/><br/>"
            Response.Redirect("~/Login.aspx")
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
End Class