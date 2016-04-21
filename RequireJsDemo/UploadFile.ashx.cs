using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace RequireJsDemo
{
    /// <summary>
    /// Summary description for UploadFile
    /// </summary>
    public class UploadFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            try
            {
                var postedFile = context.Request.Files["Filedata"];

                string savepath = "";
                string tempPath = "";

                //tempPath = context.Request["folder"];

                //If you prefer to use web.config for folder path, uncomment below line:
                tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];

                savepath = context.Server.MapPath(tempPath);
                string filename = postedFile.FileName;
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }

                postedFile.SaveAs(savepath + @"\" + filename);
                context.Response.Write(tempPath + "/" + filename);
                context.Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                context.Response.Write("Error: " + ex.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}