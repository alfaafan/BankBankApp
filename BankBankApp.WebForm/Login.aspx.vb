Imports System.Globalization
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
                Session("UserID") = _user.UserID
                Session("Username") = _user.Username
                Session("FirstName") = _user.FirstName
                Session("LastName") = _user.LastName
                Session("Email") = _user.Email
                Session("Phone") = _user.Phone
                Session("DateOfBirth") = _user.DateOfBirth
                Session("AccountNumber") = _user.AccountNumber
                Session("CardNumber") = SeparateStringWithHyphens(_user.CardNumber)
                Session("Balance") = ConvertToMoneyFormat(_user.Balance, "IDR")

                Dim returnUrl = Request.QueryString("ReturnUrl")
                If String.IsNullOrEmpty(returnUrl) Then
                    Response.Redirect("~/Dashboard.aspx")
                Else
                    Response.Redirect("~/" & returnUrl)
                End If
            Else
                ltMessage.Text = "<span class='alert alert-danger'>Invalid Username or Password</span><br/><br/>"
            End If
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try

    End Sub

    Function ConvertToMoneyFormat(ByVal number As Double, ByVal currencyCode As String) As String
        Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture("id-ID")
        Dim formatInfo As NumberFormatInfo = CType(culture.NumberFormat.Clone(), NumberFormatInfo)
        formatInfo.CurrencySymbol = GetCurrencySymbol(currencyCode)

        Return number.ToString("C2", formatInfo)
    End Function

    Function GetCurrencySymbol(ByVal currencyCode As String) As String
        Select Case currencyCode.ToUpper()
            Case "IDR"
                Return "Rp"
                ' Add more cases for other currency codes if needed
            Case Else
                Throw New ArgumentException("Unsupported currency code")
        End Select
    End Function

    Public Function SeparateStringWithHyphens(text As String) As String
        If String.IsNullOrEmpty(text) Then
            Return "No Card"
        End If

        Dim chunkSize As Integer = 4
        Dim parts As List(Of String) = New List(Of String)()

        For i As Integer = 0 To text.Length - 1 Step chunkSize
            Dim chunkLength As Integer = Math.Min(chunkSize, text.Length - i)
            parts.Add(text.Substring(i, chunkLength))
        Next

        Return String.Join(" ", parts)
    End Function

End Class