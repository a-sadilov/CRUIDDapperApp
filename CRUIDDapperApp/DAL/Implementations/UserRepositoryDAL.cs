using CRUIDDapperApp.DAL.Interfaces;
using CRUIDDapperApp.DAL.Models;
using System.Data;
using System.Collections.Generic;
using Dapper;
using System;
using System.Data.SqlTypes;

namespace CRUIDDapperApp.DAL.Implementations
{
    public class UserRepositoryDAL : IUserRepository
    {
        public void AddUser(User user)
        {

            using (var connection = DBConnection.CreateConnection())
            {
                connection.Query<User>("insert into reestr_users (Id, FirstName, LastName, FatherName, " +
                    "Inn, OrgName, OrgInn, OrgAdress) values (@Id, @FirstName, @LastName, @FatherName, " +
                    "@Inn, @OrgName, @OrgInn, @OrgAdress)",
                    new
                    {
                        Id = user.UserId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        FatherName = user.FatherName,
                        Inn = user.Inn,
                        OrgName = user.OrgName,
                        OrgInn = user.OrgInn,
                        OrgAdress = user.OrgAdress
                    });
            }
        }

        public void DeleteUser(Guid userId)
        {
            using (var connection = DBConnection.CreateConnection())
            {
                connection.Query("delete from reestr_users where Id = @id",
                    new { id = userId });
            }
        }

        public User GetUserById(Guid userId)
        {
            using (var connection = DBConnection.CreateConnection())
            {
                return (User)connection.Query<User>("select * from reestr_users where Id = @id",
                    new { id = userId });
            }


        }

        public Guid GetUserIdByContext(User user)
        {
            using (var connection = DBConnection.CreateConnection())
            {
                User us = new User();
                us = connection.QueryFirstOrDefault<User>("select * from reestr_users where FirstName = @FirstName AND LastName = @LastName AND FatherName = @FatherName AND " +
                    "Inn = @Inn AND OrgName = @OrgName AND OrgInn = @OrgInn AND OrgAdress = @OrgAdress",
                    new
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        FatherName = user.FatherName,
                        Inn = user.Inn,
                        OrgName = user.OrgName,
                        OrgInn = user.OrgInn,
                        OrgAdress = user.OrgAdress
                    });
                return us.UserId;
            }
        }
        public IEnumerable<User> GetUsers(User user)
        {
            
            using (var connection = DBConnection.CreateConnection())
            {
                return connection.Query<User>("select * from reestr_users where FirstName = @FirstName AND LastName = @LastName AND FatherName = @FatherName AND " +
                    "Inn = @Inn AND OrgName = @OrgName AND OrgInn = @OrgInn AND OrgAdress = @OrgAdress",
                    new
                    {
                        user.FirstName,
                        user.LastName,
                        user.FatherName,
                        user.Inn,
                        user.OrgName,
                        user.OrgInn,
                        user.OrgAdress
                    });
            }
        }
        public IEnumerable<User> GetUsers()
        {
            using (var connection = DBConnection.CreateConnection())
            {
                return connection.Query<User>("select * from reestr_users");
            }
        }

        public void UpdateUser(User user)
        {
            using (var connection = DBConnection.CreateConnection())
            {
                connection.Query("update reestr_users set FirstName = @FirstName, LastName = @LastName, FatherName = @FatherName, " +
                    "Inn = @Inn, OrgName = @OrgName, OrgInn = @OrgInn, OrgAdress = @OrgAdress",
                    new
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        FatherName = user.FatherName,
                        Inn = user.Inn,
                        OrgName = user.OrgName,
                        OrgInn = user.OrgInn,
                        OrgAdress = user.OrgAdress
                    });
            }
        }
    }
}
