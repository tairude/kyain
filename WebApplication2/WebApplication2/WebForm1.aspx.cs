using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void JudgeButton_Click1(object sender, EventArgs e)
        {
            //HttpPostedFile posted = Request.Files["FileUpload"];

            //if (posted.FileName != "")
            //{
            //    posted.SaveAs(
            //    //"c:\\UploadedFiles\\"
            //    "c:\\Users\\sato\\Desktop\\" //Webサーバを指定
            //      + System.IO.Path.GetFileName(posted.FileName));

            //    String OriginalScore = Deserialize<string>(json);
            //    Decimal CalculationScore = Convert.ToDecimal(OriginalScore);
            //String Score = Convert.ToString(Math.Floor(CalculationScore * 100));
            //    ScoreBoX.Text = Score + "点";
            //}
            String Score = Convert.ToString(Math.Floor(0.0999888888888888* 100));
            ScoreBox.Text = Score + "点";
        }
        //public T Deserialize<T>(string json)
        //{
        //    T result;

        //    System.Runtime.Serialization.Json.DataContractJsonSerializer serializer
        //                = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));

        //    using (System.IO.MemoryStream stream
        //        = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
        //    {
        //        result = (T)serializer.ReadObject(stream);
        //    }

        //    return result;

        //}
    }
}
