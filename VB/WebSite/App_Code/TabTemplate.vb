Imports System.Web.UI
Imports DevExpress.Web.ASPxEditors

Public Class TabTemplate
    Implements ITemplate

    Private index As Integer
    Private tabCount As Integer
    Public Sub New(ByVal index As Integer, ByVal tabCount As Integer)
        Me.index = index
        Me.tabCount = tabCount
    End Sub
    Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements ITemplate.InstantiateIn
        If index = tabCount - 1 Then
            Dim new_btn As New ASPxButton()
            new_btn.ID = "newBtn" & container.ID
            container.Controls.Add(new_btn)
            new_btn.Width = 100
            new_btn.Height = 25
            new_btn.Text = "Open New Tab"
            new_btn.AutoPostBack = False
            new_btn.ClientSideEvents.Click = "function(s, e) { createNewTab(); }"
        Else
            Dim close_btn As New ASPxButton()
            close_btn.ID = "closeBtn" & container.ID
            container.Controls.Add(close_btn)
            close_btn.ImageUrl = "~/Images/Close.png"
            close_btn.ImagePosition = DevExpress.Web.ASPxClasses.ImagePosition.Right
            close_btn.AutoPostBack = False
            close_btn.ClientSideEvents.Click = "function(s, e) { closeActiveTab(); }"
        End If
    End Sub
End Class