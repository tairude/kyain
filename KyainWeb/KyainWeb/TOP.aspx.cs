using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Runtime.Serialization;

namespace KyainWeb
{
    public partial class TOP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
    //    private void JudgeButton_Click(object sender, System.EventArgs e)
    //        {
    //            HttpPostedFile posted = Request.Files["FileUpload"];

    //            if (posted.FileName != "")
    //            {
    //                posted.SaveAs(
    //                //"c:\\UploadedFiles\\"
    //                "c:\\Users\\sato\\Desktop\\"
    //                  + System.IO.Path.GetFileName(posted.FileName));

    //                //Decimal OriginalScore = Deserialize<Decimal>(json);
    //                //String Score = (OriginalScore * 100).ToString;
    //                //ScoreBoX.Text = Score + "点";
    //            }
    //        }
    //    //public T Deserialize<T>(string json)
    //    //{
    //    //    T result;

    //    //    System.Runtime.Serialization.Json.DataContractJsonSerializer serializer
    //    //                = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));

    //    //    using (System.IO.MemoryStream stream
    //    //        = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
    //    //    {
    //    //        result = (T)serializer.ReadObject(stream);
    //    //    }

    //    //    return result;

    //    //}
    //}
}
