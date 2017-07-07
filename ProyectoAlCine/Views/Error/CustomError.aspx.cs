using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pluspetrol.Contratistas.UI.UICode.Helper;
using Pluspetrol.Siga.ServiceInterface.DTO;
using Pluspetrol.Siga.Business.Helper;
using Pluspetrol.Core;

namespace Pluspetrol.Siga.UI.WebUserControls.Error
{
    public partial class CustomError1 : System.Web.UI.Page
    {

        private IList<RoleUserRelationshipDTO> listRoleUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            //ToolbarHelper.LoadMenuItems(colleft);
            //Pluspetrol.Core.UI2.Toolbar.ToolbarManager.LoadMenuItems(Menu1);
            this.lblUser.InnerText = DefaultSecurityHelper.CurrentUserName;

            string roles = String.Empty;
            listRoleUser = SessionHelper.USER_ROLES;
            foreach (RoleUserRelationshipDTO role in listRoleUser)
            {
                roles += role.RoleTypeNameDescription as string + " ";
            }
            if (listRoleUser.Count > 0)
                this.lblGroup.InnerText = listRoleUser[0].RoleTypeNameDescription as string + "...";

            lblGroup.Attributes["title"] = roles;
        }

        protected void btnHome_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.Authority);
        }

        protected void btnHelp_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Redirect("default.aspx?pid=500");
        }

        protected void btnGoHome_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("~/default.aspx");
        }
    }
}