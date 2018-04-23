<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASPxPageControl: How to Create a Custom TabTemplate for TabPages and Place Open/Close Buttons inside the Template (TabPages are Recreated in Page_Load only)</title>
    <script type="text/javascript">
        function closeActiveTab() {
            if (page_ctrl.GetTabCount() > 1)
                ASPxCallbackPanel1.PerformCallback(page_ctrl.GetActiveTabIndex());
        }
        function createNewTab() {
            ASPxCallbackPanel1.PerformCallback("new");
        }    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Height="160px" Width="237px"
            OnCallback="Callback_panel_Callback">
            <PanelCollection>
                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxPageControl ID="page_ctrl" runat="server" ActivateTabPageAction="MouseOver"
                        ClientInstanceName="page_ctrl" Height="337px" Width="402px">
                        <TabStyle>
                            <Paddings Padding="0" />
                        </TabStyle>
                    </dx:ASPxPageControl>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>
    </form>
</body>
</html>