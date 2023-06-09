using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendApi.Contrarcts.User;
using Mapster;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Получение всех данных пользователей 
        /// </summary>       
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {       
            return Ok(await _userService.GetAll());
        }
        /// <summary>
        /// Получение пользователя по Id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        /// id = 15;
        /// }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse()
            {
                idUser = result.IdUser,
                userLogin = result.UserLogin,
                userPassword = result.UserPassword,
                regDate = result.RegDate,
                isDeleted = result.IsDeleted,
                idRole = result.IdRole,
            };
            return Ok(await _userService.GetById(id));
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        ///"idUser": 15,
        ///"userLogin": "Алексанр",
        ///"userPassword": "Stray",
        ///"regDate": "2023-05-26T06:42:07.807Z",
        ///"isDeleted": FALSE,
        ///"idRole": 0
        /// }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = new User()
            {
                IdUser = request.idUser,
                UserLogin = request.userLogin,
                UserPassword = request.userPassword,
                RegDate = request.regDate,
                IsDeleted = request.isDeleted,
                IdRole = request.idRole,
            };
            await _userService.Create(userDto);
            return Ok();
        }
        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        ///"idUser": 15,
        ///"userLogin": "Алексанр",
        ///"userPassword": "Stray",
        ///"regDate": "2023-05-26T06:42:07.807Z",
        ///"isDeleted": FALSE,
        ///"idRole": 0
        /// }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(CreateUserRequest request)
        {
            var userDto = request.Adapt<User>();
            await _userService.Update(userDto);
            return Ok();
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        ///Id = 15
        /// }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
