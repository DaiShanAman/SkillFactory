using Module_19_Social_Network.BLL.Exceptions;
using Module_19_Social_Network.BLL.Models;
using Module_19_Social_Network.DAL.Entities;
using Module_19_Social_Network.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Module_19_Social_Network.BLL.Services
{
    /// <summary>
    /// файлик получился великоват как по мне
    /// я бы попилил его на пару более конкретных модулей для расширения в будующем
    /// но это если б это был реальный проект))
    /// Просто очевидно что каждая из базовых фич тут - должна в проекте вырасти сильно)
    /// Как пример message тоже относится к юзеру, но отпилен, в идеале сделать юзера посредником/цепочкой
    /// Юзер будет направлять уже в класс реализации той же реги/входа/переписки/друзей
    /// А они уже будут заниматься логикой
    /// Буду честен это уже проектирование архитектурное, тут я не то чтобы силен, но чую что такой хаб сервисом не является
    /// А значит тут лежать не должен, но он и не модель и не представление, мб в хелперы, но тут бы не помешал совет)))
    /// </summary>
    public class UserService
    {
        readonly MessageService messageService;
        readonly IUserRepository userRepository;
        readonly IFriendRepository friendRepository;

        public UserService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
            messageService = new MessageService();
        }

        public void Register(UserRegistrationData userRegistrationData)
        {
            Console.WriteLine(userRegistrationData);
            if (String.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new NullFieldException("FirstName");

            if (String.IsNullOrEmpty(userRegistrationData.LastName))
                throw new NullFieldException("LastName");

            if (String.IsNullOrEmpty(userRegistrationData.Password))
                throw new NullFieldException("Password");

            if (String.IsNullOrEmpty(userRegistrationData.Email))
                throw new NullFieldException("Email");

            if (userRegistrationData.Password.Length < 8)
                throw new ShortPasswordException();

            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new EmailValidException(userRegistrationData.Email);

            if (userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new EmailExistsException(userRegistrationData.Email);

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };

            if (this.userRepository.Create(userEntity) == 0)
                throw new Exception();
        }

        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
            if (findUserEntity is null) throw new UserNotFoundException();

            if (findUserEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindByEmail(string email)
        {
            var findUserEntity = userRepository.FindByEmail(email);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindById(int id)
        {
            var findUserEntity = userRepository.FindById(id);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        public void Update(User user)
        {
            var updatableUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };

            if (this.userRepository.Update(updatableUserEntity) == 0)
                throw new Exception();
        }

        public IEnumerable<User> GetFriendsByUserId(int userId)
        {
            return friendRepository.FindAllByUserId(userId)
                    .Select(friendsEntity => FindById(friendsEntity.friend_id));
        }

        public void AddFriend(UserAddingFriendData userAddingFriendData)
        {
            var findUserEntity = userRepository.FindByEmail(userAddingFriendData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = userAddingFriendData.UserId,
                friend_id = findUserEntity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        private User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessages = messageService.GetIncomingMessagesByUserId(userEntity.id);
            var outgoingMessages = messageService.GetOutcomingMessagesByUserId(userEntity.id);
            var friends = GetFriendsByUserId(userEntity.id);

            return new User(userEntity.id,
                          userEntity.firstname,
                          userEntity.lastname,
                          userEntity.password,
                          userEntity.email,
                          userEntity.photo,
                          userEntity.favorite_movie,
                          userEntity.favorite_book,
                          incomingMessages,
                          outgoingMessages,
                          friends
                          );
        }
    }
}
