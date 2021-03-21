﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryRoomWatcher.Models;
using DeliveryRoomWatcher.Parameters;
using DeliveryRoomWatcher.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryRoomWatcher.Controllers
{
    [ApiController]
    public class NewsController : ControllerBase
    {
        NewsRepository _news = new NewsRepository();
        [HttpPost]
        [Route("api/news/getallnews")]
        public ActionResult getallnews(PNews.PGetNews news)
        {
            return Ok(_news.getallnews(news));
        }
        [HttpPost]
        [Route("api/news/getallnewsinfo")]
        public ActionResult getallnewsinfo(PNews.PGetNewsInfo news)
        {
            return Ok(_news.getallnewsinfo(news));
        } [HttpPost]
        [Route("api/news/getallnewscoment")]
        public ActionResult getallnewscoment(mdlNewsComment.getallcomment comment)
        {
            return Ok(_news.getallnewscoment(comment));
        }
        [HttpPost]
        [Route("api/news/getallnewsreaction")]
        public ActionResult getallnewsreaction(mdlNewsReaction.getallReaction reaction)
        {
            return Ok(_news.getallnewsreaction(reaction));
        }
        [HttpPost]
        [Route("api/news/getallnewsbyweek")]
        public ActionResult getallnewsbyweek(PNews.PGetNewsWeek newsweek)
        {
            return Ok(_news.getallnewsbyweek(newsweek));
        }
        [HttpPost]
        [Route("api/news/getallnewstoday")]
        public ActionResult getalgetallnewstodaylnews(PNews.PGetNewsToday newsToday)
        {
            return Ok(_news.getallnewstoday(newsToday));
        }  
        [HttpPost]
        [Route("api/news/InsertReactionNews")]
        public ActionResult InsertReactionNews(mdlNewsReaction.addReaction addReaction)
        {
            return Ok(_news.InsertReactionNews(addReaction));
        }
        [HttpPost]
        [Route("api/news/InsertCommentNews")]
        public ActionResult InsertCommentNews(mdlNewsComment.addcomment addcomment)
        {
            return Ok(_news.InsertCommentNews(addcomment));
        }
    }
}