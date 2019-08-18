using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            // 点数を表示する。
            string score = Request.QueryString[ "score" ];
            ScoreLabel.Text = score;

            // キャプチャーした写真と、解析結果画像を表示する。
            string directoryPath = ConfigurationManager.AppSettings[ "RelativeDirectoryPath" ];
            OriginalImage.ImageUrl = directoryPath + "kyain.jpg";
        }

        protected void Button1_Click( object sender, EventArgs e )
        {
            Response.Redirect( "WebForm1.aspx" );
        }
    }
}