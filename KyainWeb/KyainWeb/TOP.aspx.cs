using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KyainWeb
{
    public partial class TOP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void JudgeButton_Click(object sender, System.EventArgs e)
        {
            HttpPostedFile posted = Request.Files["userfile"];

            if (posted.FileName != "")
            {
                posted.SaveAs(
                  "c:\\UploadedFiles\\"
                  + System.IO.Path.GetFileName(posted.FileName));
            }
        }
    }
}