using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstPakWebApi.IService;
using FirstPakWebApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstPakWebApi.Controllers
{
    public class PostionsController : BaseController
    {
        private readonly IPostionsService _postionsService;
        public PostionsController(IPostionsService postionsService)
        {
            this._postionsService = postionsService;
        }
        /// <summary>
        /// 获取职位
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetPostions(ViewPage page)
        {
            return Ok(_postionsService.GetPostions(page.page, page.limit));
        }
        /// <summary>
        /// 获取职位名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPostionName()
        {
            return Ok(_postionsService.GetPostionName());
        }
        /// <summary>
        /// 根据Id获取职位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPostionById(int id)
        {
            return Ok(_postionsService.GetPostionById(id));
        }
        /// <summary>
        /// 添加新职位信息
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAddPostion(ViewPosition position)
        {
            return Ok(_postionsService.AddPostion(position));
        }
        /// <summary>
        /// 更新职位信息
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult GetUpdatePostion(ViewPosition position)
        {
            return Ok(_postionsService.UpdatePostion(position));
        }
        /// <summary>
        /// 删除职位信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult GetDeletePostion(params int[] ids)
        {
            return Ok(_postionsService.DeletePostion(ids));
        }
    }
}