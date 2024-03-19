Imports BankBankApp.BLL
Imports BankBankApp.BLL.DTOs

Public Class EditProfile
    Inherits System.Web.UI.Page

#Region "Binding Data"
    Sub LoadProfile()
        Dim _userBLL = New UserBLL()
        Dim _user = _userBLL.GetByID(Session("UserID"))
        If _user IsNot Nothing Then
            txtFirstName.Text = _user.FirstName
            txtLastName.Text = _user.LastName
            txtEmail.Text = _user.Email
            txtUsername.Text = _user.Username
            txtPhone.Text = _user.Phone
            txtDateOfBirth.Text = _user.DateOfBirth.ToString("yyyy-MM-dd")
        End If
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadProfile()
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)
        Dim _userBLL = New UserBLL()
        Dim _userToUpdate = New UserDTO()
        _userToUpdate.FirstName = txtFirstName.Text
        _userToUpdate.LastName = txtLastName.Text
        _userToUpdate.Email = txtEmail.Text
        _userToUpdate.Username = txtUsername.Text
        _userToUpdate.Phone = txtPhone.Text
        _userToUpdate.DateOfBirth = DateTime.ParseExact(txtDateOfBirth.Text, "yyyy-MM-dd", Nothing)

        Try
            '_userBLL.Update(_userToUpdate, Session("UserID"))
            ltMessage.Text = "<span class='alert alert-success'>Profile updated successfully</span><br/><br/>"
            Response.Redirect("~/Profile.aspx")
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>" & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
End Class