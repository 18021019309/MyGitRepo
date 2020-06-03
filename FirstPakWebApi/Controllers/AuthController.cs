using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FirstPakWebApi.IService;
using FirstPakWebApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FirstPakWebApi.Controllers
{
    public class AuthController : BaseController
    {

        IUserService _userService;
        IJWTService _jwtService;
        public AuthController(IUserService userService, IJWTService jwtService)
        {
            this._userService = userService;
            this._jwtService = jwtService;
        }

        /// <summary>
        /// 登录认证
        /// </summary>
        /// <param name="viewAuth"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]ViewAuth  viewAuth)
        {
            var auth = _userService.GetUser(viewAuth);
            if (auth == null)
                return Ok(new { msg = "用户名或密码不正确!" });

            return Ok(new
            {
                Username = auth.Account,
                Token = _jwtService.GetToken(viewAuth)
            });
        }
        /// <summary>
        /// 获取账号列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAuthList(ViewPage page)
        {
            return Ok(_userService.GetAuthList(page.page,page.limit));
        }
        /// <summary>
        /// 获取账号名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAuthName()
        {
            return Ok(_userService.GetAuthName());
        }
        /// <summary>
        /// 添加新账户,并分配角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateAuth(ViewUser user)
        {
            return Ok(_userService.GetCreateAuth(user));
        }
        /// <summary>
        /// 根据Id获取账号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAuthInfoById(int id)
        {
            return Ok(_userService.GetAuthInfoById(id));
        }
        /// <summary>
        /// 更新账号信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult GetUpdateAuth(ViewUser viewUser)
        {
            return Ok(_userService.UpdateAuthInfo(viewUser));
        }
        /// <summary>
        /// 删除账户信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteAuth(params int[] ids)
        {
            return Ok(_userService.DeleteAuth(ids));
        } 
    }
}