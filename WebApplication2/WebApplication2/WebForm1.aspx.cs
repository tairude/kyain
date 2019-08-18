using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        [JsonObject( "kyain" )]
        internal class KyainResponse
        {
            [JsonProperty( "prediction" )]
            public decimal Prediction { get; set; }

            [JsonProperty( "success" )]
            public bool Success { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void JudgeButton_Click1(object sender, EventArgs e)
        {
            HttpPostedFile posted = Request.Files["FileUpload"];

            if (posted.FileName != "")
            {
                String directoryPath = ConfigurationManager.AppSettings[ "RelativeDirectoryPath" ];
                string rootPath = MapPath("./");
                posted.SaveAs(
                    rootPath + directoryPath //Webサーバを指定
                    + System.IO.Path.GetFileName( posted.FileName )
                );
                
                var score = GetScore( posted.FileName );
                string value = HttpUtility.UrlEncode( Math.Floor( score * 100 ).ToString() );
                Response.Redirect( "Result.aspx?score=" + value );
            }
            else
            {
                // ファイル未選択時
            }
        }

        /// <summary>
        /// スコアを取得する
        /// </summary>
        /// <param name="fileName">評価対象のファイル名</param>
        /// <returns></returns>
        private decimal GetScore(string fileName )
        {
            if( ConfigurationManager.AppSettings[ "UsingStub" ].Equals(bool.TrueString) )
            {
                return (decimal)0.987654321;
            }

            using( HttpClient client = new HttpClient() )
            {
                string endpointRoot = ConfigurationManager.AppSettings[ "EndpointRoot" ];

                // API呼び出し
                client.BaseAddress = new Uri( endpointRoot );
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );
                
                HttpResponseMessage response = client.GetAsync( "predict" ).Result;
                
                if( response.IsSuccessStatusCode )
                {
                    var resJson = response.Content.ReadAsStringAsync().Result;
                    var kyainResponse = JsonConvert.DeserializeObject<KyainResponse>( resJson );
                    response.Dispose();
                    return kyainResponse.Prediction;
                }
                else
                {
                    // API呼び出し失敗時は -1 返す
                    response.Dispose();
                    return -1;
                }

                //// ポストする場合
                //JsonUser newData = new JsonUser
                //{
                //    ID = -1,
                //    Name = "New Data",
                //    Email = "hello@test.jp",
                //    Telephone = "111-222-333"
                //};
                //response = client.PostAsJsonAsync( "api/user", newData ).Result;
                //if( response.IsSuccessStatusCode )
                //{
                //    Label1.Text = response.Headers.Location.ToString();
                //}
                //else
                //{
                //    ErrorLabel1.Text = response.ReasonPhrase;
                //}
                //response.Dispose();
            }
        }
        public T Deserialize<T>( string json )
        {
            T result;

            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer
                        = new System.Runtime.Serialization.Json.DataContractJsonSerializer( typeof( T ) );

            using( System.IO.MemoryStream stream
                = new System.IO.MemoryStream( System.Text.Encoding.UTF8.GetBytes( json ) ) )
            {
                result = ( T )serializer.ReadObject( stream );
            }

            return result;

        }

        private string test()
        {
            return "0.01";
        }

    }
}
