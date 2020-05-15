using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Web.UI.HtmlControls;
using menu.Class;

namespace menu
{
    public partial class SiteMaster : MasterPage
    {
        private TestMenu _Menu;
      
        protected void Page_Load(object sender, EventArgs e)
        {

            //      < li class="nav-item" runat="server">
            //  <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseBootstrap" aria-expanded="false" aria-controls="collapseBootstrap">
            //    <i class="far fa-fw fa-window-maximize"></i>
            //    <span>Bootstrap UI</span>
            //  </a>

            //  <div id = "collapseBootstrap" class="collapse" aria-labelledby="headingBootstrap" data-parent="#accordionSidebar" style="">
            //    <div class="bg-white py-2 collapse-inner rounded">
            //      <h6 class="collapse-header">Bootstrap UI</h6>
            //      <a class="collapse-item" href="alerts.html">Alerts</a>
            //      <a class="collapse-item" href="buttons.html">Buttons</a>
            //      <a class="collapse-item" href="dropdowns.html">Dropdowns</a>
            //      <a class="collapse-item" href="modals.html">Modals</a>
            //      <a class="collapse-item" href="popovers.html">Popovers</a>
            //      <a class="collapse-item" href="progress-bar.html">Progress Bars</a>
            //    </div>
            //  </div>
            //</li>
            if (!IsPostBack)
            {
                this._Menu = new TestMenu();
                DataTable _dtMainMenu = new DataTable();
                _dtMainMenu = _Menu.Select_MainMenu();

                name.InnerText = _dtMainMenu.Rows[0]["MMName"].ToString();


                for (int i = 0; i < _dtMainMenu.Rows.Count; i++)
                {
                    string Main_Name = _dtMainMenu.Rows[i]["MMName"].ToString();
                    HtmlGenericControl for_li = new HtmlGenericControl();
                    HtmlGenericControl for_a = new HtmlGenericControl();
                    HtmlGenericControl for_span = new HtmlGenericControl();
                    HtmlGenericControl for_div1 = new HtmlGenericControl();
                    HtmlGenericControl for_div2 = new HtmlGenericControl();

                    HtmlGenericControl for_i = new HtmlGenericControl();
                    //li
                    for_li.Attributes["id"] = "li_" + i;
                    for_li.Attributes["class"] = "nav-item";
                    for_li.Attributes["raunt"] = "server";
                    for_li.TagName = "li";
                    accordionSidebar.Controls.Add(for_li); //accordionSidebar id ul

                    //<a>
                    for_a.Attributes["id"] = "a_" + i;
                    for_a.Attributes["class"] = "nav-link collapsed";
                    for_a.Attributes["href"] = "#";
                    for_a.Attributes["data-toggle"] = "collapse";
                    for_a.Attributes["data-target"] = "#collapseBootstrap" + i;
                    for_a.Attributes["aria-expanded"] = "false";
                    for_a.Attributes["aria-controls"] = "collapseBootstrap";
                    for_a.TagName = "a";
                    for_li.Controls.Add(for_a);

                    //i
                    for_i.Attributes["id"] = "i_" + i;
                    for_i.Attributes["class"] = "far fa-fw fa-window-maximize";
                    for_i.Attributes["raunt"] = "server";
                    for_i.TagName = "i";
                    for_a.Controls.Add(for_i);

                    //span
                    for_span.Attributes["id"] = "span_" + i;
                    for_span.InnerText = Main_Name;
                    for_span.TagName = "span";
                    for_a.Controls.Add(for_span);

                    //</a>

                    for_div1.Attributes["id"] = "collapseBootstrap" + i;
                    for_div1.Attributes["class"] = "collapse";
                    for_div1.Attributes["data-parent"] = "#accordionSidebar";
                    for_div1.Attributes["aria-labelledby"] = "headingBootstrap";
                    for_div1.TagName = "div";
                    for_li.Controls.Add(for_div1);

                    for_div2.Attributes["class"] = "bg-white py-2 collapse-inner rounded";
                    for_div2.TagName = "div";
                    for_div1.Controls.Add(for_div2);

                    DataTable _dtMenu = new DataTable();
                    _dtMenu = _Menu.Select_Menu(Main_Name);
                    int count = 1;
                    foreach (DataRow sub_menu in _dtMenu.Rows)
                    {
                        HtmlGenericControl for_a2 = new HtmlGenericControl();
                        string Sub_Name = sub_menu["MenuName"].ToString();
                        string Sub_Url = sub_menu["MenuPath"].ToString();

                        // ---------------------------- <a> 2 ----------------------------
                        for_a2.Attributes["class"] = "collapse-item";
                        for_a2.Attributes["href"] = Sub_Url;
                        for_a2.InnerText = Sub_Name;
                        for_a2.TagName = "a";
                        for_div2.Controls.Add(for_a2);
                        count++;
                    }
                }
            }
                }
            }
    }

       
 

