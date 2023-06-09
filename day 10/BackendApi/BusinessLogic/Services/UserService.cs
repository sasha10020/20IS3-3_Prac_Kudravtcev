﻿using Domain.Interfaces;
using Domain.Models;
namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<User>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }
        public async Task<User> GetById(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.IdUser == id);
            return user.First();
        }
        public async Task Create(User model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if(string.IsNullOrEmpty(model.UserLogin)) 
            {
                throw new ArgumentException(nameof(model.UserLogin));
            }
            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(User model)
        {
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.IdUser == id);
            _repositoryWrapper.User.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}
