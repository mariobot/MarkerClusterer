using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MarkerClusterer.Helpers
{
    public class Excel
    {
        public class Export
        {
            public static void ToExcel(HttpResponseBase Response, object dataSource)
            {
                var grid = new System.Web.UI.WebControls.GridView();
                grid.DataSource = dataSource;
                grid.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=Reporte.xls");
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grid.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }
        }
    }
}