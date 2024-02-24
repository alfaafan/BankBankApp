Public Class SimpleCalc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Add_Click()
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim result As Integer = 0
        If Integer.TryParse(txtNum1.Text, num1) AndAlso Integer.TryParse(txtNum2.Text, num2) Then
            result = num1 + num2
            lblResult.Text = result.ToString()
        Else
            lblResult.Text = "Invalid input"
        End If
    End Sub

    Protected Sub Subtract_Click()
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim result As Integer = 0
        If Integer.TryParse(txtNum1.Text, num1) AndAlso Integer.TryParse(txtNum2.Text, num2) Then
            result = num1 - num2
            lblResult.Text = result.ToString()
        Else
            lblResult.Text = "Invalid input"
        End If
    End Sub

    Protected Sub Multiply_Click()
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim result As Integer = 0
        If Integer.TryParse(txtNum1.Text, num1) AndAlso Integer.TryParse(txtNum2.Text, num2) Then
            result = num1 * num2
            lblResult.Text = result.ToString()
        Else
            lblResult.Text = "Invalid input"
        End If
    End Sub

    Protected Sub Divide_Click()
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim result As Integer = 0
        If Integer.TryParse(txtNum1.Text, num1) AndAlso Integer.TryParse(txtNum2.Text, num2) Then
            If num2 = 0 Then
                lblResult.Text = "Cannot divide by zero"
            Else
                result = num1 / num2
                lblResult.Text = result.ToString()
            End If
        Else
            lblResult.Text = "Invalid input"
        End If
    End Sub
End Class