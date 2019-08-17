using System;
using System.Collections.Generic;
using System.Configuration;
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
            HttpPostedFile posted = Request.Files["FileUpload"];

            if (posted.FileName != "")
            {
                String Value = ConfigurationManager.AppSettings["URL"];
                string path = MapPath("./");
                posted.SaveAs(
                //"c:\\UploadedFiles\\"
                path + Value //Webサーバを指定
                + System.IO.Path.GetFileName(posted.FileName));

                //String OriginalScore = Deserialize<string>(json);
                //Decimal CalculationScore = Convert.ToDecimal(OriginalScore);
                //String Score = Convert.ToString(Math.Floor(CalculationScore * 100));
                //ScoreBoX.Text = Score + "点";
            }
            String json = test();
            String OriginalScore = Deserialize<string>(json);
            Decimal CalculationScore = Convert.ToDecimal(OriginalScore);
            String Score = Convert.ToString(Math.Floor(CalculationScore * 100));
            ScoreBox.Text = Score + "点";
        }
        public T Deserialize<T>(string json)
        {
            T result;

            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer
                        = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));

            using (System.IO.MemoryStream stream
                = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                result = (T)serializer.ReadObject(stream);
            }

            return result;

        }

        private string test()
        {
            return "0.01";
        }

    }
}
