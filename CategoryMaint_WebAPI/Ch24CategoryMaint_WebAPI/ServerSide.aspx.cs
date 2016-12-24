using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Data;


namespace Ch24CategoryMaint_WebAPI
{
    public partial class ServerSide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //configure web request object
            string url = "http://localhost:52746/api/categories/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/xml; encoding='utf-8'";

            //send request, get xml response and convert to stream
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            //read stream into a dataset
            DataSet ds = new DataSet();
            ds.ReadXml(stream);

            //bind data set to gridview
            grdCategories.DataSource = ds.Tables[0];
            grdCategories.DataBind();

        }

        protected void grdCategories_PreRender(object sender, EventArgs e)
        {
            grdCategories.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}