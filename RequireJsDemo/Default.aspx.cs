using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedisMode.Repository.News;
using RedisMode.Repository.RedisKey;

namespace RequireJsDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RedisKeyService redisKeyService = new RedisKeyService();

            NewsService newsService=new NewsService();

            newsService.Add(new NewsEntity
            {
                Id = 123,
                Title = "Demo title",
                Status = 1
            });
            newsService.Add(new NewsEntity
            {
                Id = 1234,
                Title = "Demo title",
                Status = 1
            });

            redisKeyService.Add(new RedisKeyEntity
            {
                Id = 123567,
                Name = "Nguyễn Văn A",
                Status = 1
            });            

            var obj = redisKeyService.Get(typeof(RedisKeyEntity).Name);

            var obj2 = newsService.GetList(typeof(NewsEntity).Name);

            //Response.Write(obj2[0].Title + "<br/>"+obj.Name);

        }
    }
}