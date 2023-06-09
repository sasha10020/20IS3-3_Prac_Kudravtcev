using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;
        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();
            
            repositoryWrapperMoq.Setup(x=>x.User).Returns(userRepositoryMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }
        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));
            //assert
            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x=>x.Create(It.IsAny<User>()),Times.Never);
        }
        //[Fact]
        //public async Task CreateAsyncNewUserShouldNotCreateNewUser()
        //{
        //    //arrange
        //    var newUser = new User()
        //    {

        //        IdUser = 0,
        //        UserLogin = "",
        //        UserPassword = "",
        //        RegDate = DateTime.MaxValue,
        //        IsDeleted = false,
        //        IdRole = 0
        //    };
        //    //act
        //    var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));
        //    //assert
        //    userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        //    Assert.IsType<ArgumentException>(ex);
        //}
        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(User user)
        {
            //arrange
            var newUser = user;
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(()=>service.Create(newUser));
            //assert
            userRepositoryMoq.Verify(x=> x.Create(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] {new User() { IdRole = -3,UserLogin = "",UserPassword="",RegDate = DateTime.MaxValue,IsDeleted = true} },
                 new object[] {new User() { IdRole = 1,UserLogin = "Alx",UserPassword="",RegDate = DateTime.MaxValue,IsDeleted = true} }
            };
        }
        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new User()
            {
                UserLogin = "test",
                UserPassword = "test",
                RegDate = DateTime.Now,
                IsDeleted = false,
                IdRole = 1
            };
            //act 
            await service.Create(newUser);
            //assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }
    }
}
