using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.Controllers
{
    public class BoardController : Controller
    {
        public static List<Board> boards = new List<Board>(); 
        // GET: /<controller>/
        public IActionResult Index()
        {
            boards.Add(new Board()
            {
                id = 1,
                title = "지금 이순간",
                content = "마법 처럼\r\n 저\t하늘을 날아가도...",
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            });

            var result = boards.Select(item =>
            {
                item.content = item.content.Replace("\r", "").Replace("\n", "").Replace("\t", " ");
                item.content = item.content.Substring(0, Math.Min(item.content.Length, 20));
                return item;
            })
            .ToList();

            return View(result);
        }
    }
}
