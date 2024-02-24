Public Class SampleViewState
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnIncrement_Click(sender As Object, e As EventArgs) Handles btnIncrement.Click
        Dim count As Integer = 0
        If ViewState("Count") IsNot Nothing Then
            count = CInt(ViewState("Count"))
        End If
        count += 1
        ViewState("Count") = count
        lblCounter.Text = count.ToString()
    End Sub

    Protected Sub btnDecrement_Click(sender As Object, e As EventArgs)
        Dim count As Integer = 0
        If ViewState("Count") IsNot Nothing Then
            count = CInt(ViewState("Count"))
        End If
        count -= 1
        ViewState("Count") = count
        lblCounter.Text = count.ToString()
    End Sub
End Class