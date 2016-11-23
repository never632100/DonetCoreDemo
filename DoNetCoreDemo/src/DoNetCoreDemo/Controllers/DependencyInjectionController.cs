using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DependencyInjection;
using Model.DependencyInjection;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DoNetCoreDemo.Controllers
{
    public class DependencyInjectionController : Controller
    {
        #region 构造函数注入
        private ITodoRepository _todoRepository;
        public DependencyInjectionController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        #endregion

        //#region 属性注入
        //[FromServices]
        //public ITodoRepository TodoRepository { get; set; }

        //public IEnumerable<TodoItem> GetAll()
        //{
        //    return TodoRepository.AllItems;
        //}
        //#endregion

        #region 视图注入
        #endregion
        // GET: /<controller>/
        public IActionResult Index()
        {
            var list = _todoRepository.AllItems;
            return View(list);
        }

    }
}
