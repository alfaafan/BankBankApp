Public Interface ICrud(Of T)
    Function GetAll() As List(Of T)
    Function GetById(id As Integer) As T
    Function Insert(entity As T) As Integer
    Function Update(entity As T) As Integer
    Function Delete(id As Integer) As Integer

End Interface
