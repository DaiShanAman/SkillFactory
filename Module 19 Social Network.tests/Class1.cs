using Module_19_Social_Network.BLL.Services;
using Module_19_Social_Network.DAL.Entities;
using Module_19_Social_Network.DAL.Repositories;
using NUnit.Framework;

namespace Module_19_Social_Network.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void UserService_CreateUser_ShouldCreateUserWithData()
        {
            // Arrange
            var userRepository = new UserRepository();
            var userService = new UserService();
            var uzver = new UserEntity
            {
                id = 5, // id
                firstname = "Rick", // name
                lastname = "Rick", // lastname
                password = "asswordpassword", // password
                email = "therick@lol.com", // email
            };



            userRepository.Create(uzver);

            var find = userRepository.FindById(uzver.id);

            // Assert
            Assert.IsTrue(find != null);
        }

    }
}