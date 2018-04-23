using System.Web.UI;
using DevExpress.Web.ASPxEditors;

public class TabTemplate : ITemplate {
    private int index;
    private int tabCount;
    public TabTemplate(int index, int tabCount) {
        this.index = index;
        this.tabCount = tabCount;
    }
    public void InstantiateIn(System.Web.UI.Control container) {
        if (index == tabCount - 1) {
            ASPxButton new_btn = new ASPxButton();
            new_btn.ID = "newBtn" + container.ID;
            container.Controls.Add(new_btn);
            new_btn.Width = 100;
            new_btn.Height = 25;
            new_btn.Text = "Open New Tab";
            new_btn.AutoPostBack = false;
            new_btn.ClientSideEvents.Click = "function(s, e) { createNewTab(); }";
        }
        else {
            ASPxButton close_btn = new ASPxButton();
            close_btn.ID = "closeBtn" + container.ID;
            container.Controls.Add(close_btn);
            close_btn.ImageUrl = "~/Images/Close.png";
            close_btn.ImagePosition = DevExpress.Web.ASPxClasses.ImagePosition.Right;
            close_btn.AutoPostBack = false;
            close_btn.ClientSideEvents.Click = "function(s, e) { closeActiveTab(); }";
        }
    }
}