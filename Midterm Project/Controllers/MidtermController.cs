using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using Midterm.Models;

namespace Midterm.Controllers
{
    public class MidtermController : Controller
    {
        public List<TestQuestion> GetQuestions()
        {
            List<TestQuestion> questions = null;
            string dir = System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "Midterm.json");
            using (StreamReader sr = new StreamReader(dir))
            {
                string jsonContent = sr.ReadToEnd();
                questions = new List<TestQuestion>(JsonConvert.DeserializeObject<List<TestQuestion>>(jsonContent));
            }

            for (int i = 0; i < questions.Count; i++)
            {
                switch (questions[i].Type)
                {
                    case "TrueFalseQuestion":
                        questions[i] = new TrueFalseQuestion(questions[i]);
                        break;
                    case "ShortAnswerQuestion":
                        questions[i] = new ShortAnswerQuestion(questions[i]);
                        break;
                    case "LongAnswerQuestion":
                        questions[i] = new LongAnswerQuestion(questions[i]);
                        break;
                    case "MultipleChoiceQuestion":
                        questions[i] = new MultipleChoiceQuestion(questions[i]);
                        break;
                    default:
                        break;
                }
            }

            return questions;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TakeTest()
        {
            return View(GetQuestions());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TakeTest(List<TestQuestion> model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //foreach (var question in model)
            //{
            //    if (question is TrueFalseQuestion)
            //    {
            //        if (question.Answer != "True" || question.Answer != "False")
            //        {
            //            return View(model);
            //        }
            //    }
            //    else if (question is ShortAnswerQuestion)
            //    {
            //        if (question.Answer.Length > 100)
            //        {
            //            return View(model);
            //        }
            //    }
            //}

            return View("DisplayResults", model);
        }
    }
}