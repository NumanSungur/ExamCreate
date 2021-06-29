using Business.Manager;
using Entities.Concrete;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using WebUI.Models;
using Microsoft.AspNetCore.Http;

namespace WebUI.Controllers
{
    public class ExamController : Controller
    {
        private readonly ExamManager examBll;
        public ExamController(ExamManager _examBll)
        {
            examBll = _examBll;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
            {
                return RedirectToAction("Index", "Login");

            }
            List<Exam> list = examBll.GetList();
            return View(list);

        }

        [HttpPost]
        public IActionResult GetExamCreateView(string title)
        {

            List<RssModel> list = GetListRss();
            RssModel rss = list.Where(x => x.Title == title).FirstOrDefault();
            ViewBag.Rss = rss;
            ViewBag.RssContent = GetRssContent(rss);
            return PartialView("/Views/Shared/_PartialExam.cshtml", new Exam());


        }


        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
            {
                return RedirectToAction("Index", "Login");

            }
            ViewBag.RSSFeed = GetListRss();

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create(Exam exam)
        {
            if (exam != null)
            {
                examBll.SaveExam(exam);

                return RedirectToAction("Index", "Exam");
            }
            return null;
        }
        public List<RssModel> GetListRss()
        {
            List<RssModel> rssList = new List<RssModel>();

            string url = "https://www.wired.com/feed/rss";

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            XmlNodeList itemNodes = xmlDoc.SelectNodes("//item");
            var list = itemNodes.Cast<XmlNode>().Take(5);
            foreach (XmlNode itemNode in list)
            {
                RssModel rss = new RssModel();
                XmlNode titleNode = itemNode.SelectSingleNode("title");
                XmlNode descriptionNode = itemNode.SelectSingleNode("description");
                XmlNode urlNode = itemNode.SelectSingleNode("link");
                rss.Title = titleNode.InnerText;
                rss.Description = descriptionNode.InnerText;
                rss.URL = urlNode.InnerText;
                rssList.Add(rss);
            }
            return rssList;
        }
        public RssModel GetRssContent(RssModel rssModel)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(rssModel.URL);

            HtmlNode[] nodes = document.DocumentNode.SelectNodes("//p").ToArray();
            for (var i = 0; i < nodes.Count<HtmlNode>(); i++)
            {
                HtmlNode htmlNote = nodes[i];

                if (i < nodes.Count<HtmlNode>() - 5)
                {
                    rssModel.Description += "<br>" + htmlNote.InnerHtml;

                }

            }

            return rssModel;

        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            bool result = examBll.Delete(ID);
            if (result)
            {
                return RedirectToAction("Index", "Exam");
            }
            return null;

        }

        [HttpGet]
        public IActionResult StartExam(int ID)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
            {
                return RedirectToAction("Index", "Login");

            }
            
            var exam = examBll.Get(ID);
            


           
                foreach (var question in exam.Questions)
                {
                    foreach (var answer in question.Answers)
                    {
                        answer.IsRight = null;
                    }
                }
            
           

            

            ViewBag.RssTitle = examBll.GetArticle(ID).Title;
            ViewBag.RssContent = examBll.GetArticle(ID).Content != null ? examBll.GetArticle(ID).Content : null;


            return View("StartExam");
        }
        [HttpPost]

        public IActionResult CheckAnswer(int id, bool IsRight)
        {
            Answer answer = examBll.GetAnswer(id);
            if (answer.IsRight == IsRight)
            {
                return Json("true", new Newtonsoft.Json.JsonSerializerSettings());
            }
            if (answer.IsRight != IsRight)
            {
                return Json("false", new Newtonsoft.Json.JsonSerializerSettings());
            }


            return Json("null", new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
