Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private Property LastIndex() As Integer
        Get
            If Session("LastIndex") Is Nothing Then
                Session("LastIndex") = 0
            End If
            Return DirectCast(Session("LastIndex"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("LastIndex") = value
        End Set
    End Property
    Private Property OpenTabPagesCollection() As SortedDictionary(Of Integer, String)
        Get
            If Session("TabPages") Is Nothing Then
                Session("TabPages") = New SortedDictionary(Of Integer, String)()
            End If
            Return DirectCast(Session("TabPages"), SortedDictionary(Of Integer, String))
        End Get
        Set(ByVal value As SortedDictionary(Of Integer, String))
            Session("TabPages") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not Page.IsPostBack Then
            Session.Clear()
            OpenTabPagesCollection.Add(0, "Tab0")
        End If
        CreatePages()
        ASPxCallbackPanel1.Controls.Add(page_ctrl)
    End Sub
    Private Sub CreatePages()
        For Each tabPage As KeyValuePair(Of Integer, String) In OpenTabPagesCollection
            CreateTabPage(tabPage.Key, tabPage.Value)
        Next tabPage
    End Sub
    Private Sub CreateTabPage(ByVal index As Integer, ByVal name As String)
        Dim tp As New TabPage()
        page_ctrl.TabPages.Add(tp)
        tp.Name = name
        tp.TabTemplate = New TabTemplate(tp.Index, OpenTabPagesCollection.Keys.Count)

        If tp.Index = OpenTabPagesCollection.Keys.Count - 1 AndAlso tp.Index <> 0 Then
            page_ctrl.TabPages(tp.Index - 1).TabTemplate = New TabTemplate(tp.Index - 1, OpenTabPagesCollection.Keys.Count)
        End If
        CreateContent(tp)
    End Sub
    Private Sub CreateContent(ByVal tp As TabPage)
        Dim literal As New Literal()
        literal.ID = "literal" & tp.Name
        literal.Text = tp.Name
        tp.Controls.Add(literal)
    End Sub
    Private Sub DeleteTab(ByVal index As Integer)
        Dim dicIndex As Integer = 0
        Dim tabName As String = page_ctrl.TabPages(index).Name
        dicIndex = OpenTabPagesCollection.FirstOrDefault(Function(x) x.Value = tabName).Key
        OpenTabPagesCollection.Remove(dicIndex)
        page_ctrl.TabPages.RemoveAt(index)
    End Sub
    Protected Sub Callback_panel_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.CallbackEventArgsBase)
        If e.Parameter = "new" Then
            Dim newIndex As Integer = LastIndex + 1
            Dim newTabName As String = "Tab" & newIndex
            OpenTabPagesCollection.Add(newIndex, newTabName)
            CreateTabPage(newIndex, newTabName)
            LastIndex += 1
        Else
            DeleteTab(Convert.ToInt32(e.Parameter))
        End If
    End Sub
End Class