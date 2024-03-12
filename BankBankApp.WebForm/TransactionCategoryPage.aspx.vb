Imports BankBankApp.BLL
Imports BankBankApp.BLL.DTOs

Public Class TransactionCategoryPage
    Inherits System.Web.UI.Page

#Region "Binding Data"
    Sub LoadCategories()
        Dim _transactionCategoryBLL As New TransactionCategoryBLL
        Dim result = _transactionCategoryBLL.GetAll()
        If result.Count > 0 Then
            lvTransactionCategories.DataSource = result
            lvTransactionCategories.DataBind()
        End If
    End Sub
#End Region

#Region "Initialize"
    Sub InitializeFormAddArticle()
        txtCategoryName.Text = String.Empty
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Username") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If

        If Not IsPostBack Then
            LoadCategories()
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Try
            Dim _transactionCategoryBLL As New TransactionCategoryBLL
            Dim _transactionCategory As New CreateTransactionCategoryDTO

            _transactionCategory.Name = txtCategoryName.Text

            _transactionCategoryBLL.Create(_transactionCategory)

            ltMessage.Text = "<span class='alert alert-success' role='alert'>Category created successfully</span>"
            LoadCategories()
            InitializeFormAddArticle()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub lvTransactionCategories_ItemDeleting(sender As Object, e As ListViewDeleteEventArgs)
        Try
            Dim _transactionCategoryBLL As New TransactionCategoryBLL

            Dim selectedID As Integer = Convert.ToInt32(lvTransactionCategories.DataKeys(e.ItemIndex).Value)

            _transactionCategoryBLL.Delete(selectedID)

            ltMessage.Text = "<span class='alert alert-success' role='alert'>Category deleted successfully</span>"
            LoadCategories()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub lvTransactionCategories_SelectedIndexChanged(sender As Object, e As EventArgs)
        LoadCategories()
    End Sub

    Protected Sub lvTransactionCategories_SelectedIndexChanging(sender As Object, e As ListViewSelectEventArgs)
        LoadCategories()
    End Sub
End Class