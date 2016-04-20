using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RequireJsDemo.Responsive;

namespace RequireJsDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RedisCacheString rc=new RedisCacheString(true);

            RedisCacheSet rc2 = new RedisCacheSet(true);

            //rc.Set("demo",new Empty
            //{
            //    Id = 123456,
            //    Name="Nguyễn Bá Chính",
            //    UserName="chinhnb",
            //    Password="123456",
            //    Status=1
            //}, new TimeSpan(3600));

            //rc2.Set("demo2", new Empty
            //{
            //    Id = 123,
            //    Name = "Nguyễn Văn A",
            //    UserName = "annguyen",
            //    Password = "123456",
            //    Status = 1
            //},new TimeSpan(3600));

            //rc2.Set("demo2", new Empty
            //{
            //    Id = 1234,
            //    Name = "Nguyễn Văn B",
            //    UserName = "bnnguyen",
            //    Password = "123456",
            //    Status = 1
            //}, new TimeSpan(3600));

            //rc2.Set("demo2", new Empty
            //{
            //    Id = 1235,
            //    Name = "Nguyễn Văn C",
            //    UserName = "cnnguyen",
            //    Password = "123456",
            //    Status = 1
            //}, new TimeSpan(3600));

            rc2.Set("demo3", new Empty
            {
                Id = 1235,
                Name = "Nguyễn Văn A",
                UserName = "cnnguyen",
                Password = "123456",
                Status = 1
            }, new TimeSpan(3600));

            //show
            var obj=rc.Get<Empty>("demo");

            var obj2 = rc2.GetList<Empty>("demo3");

            Response.Write(obj.Name+"<br/>"+ obj2[0].Name);
        }
    }
}