using System;
using System.Collections.Generic;
using System.Linq;

namespace IndentityServerTest.BusinessLayer
{
    public class UserRepository
    {
        private List<UserModel> users;

        public UserRepository()
        {
            users = new List<UserModel>()
            {
                new UserModel {
                    ID = 1,
                    FirstName = "Dealer",
                    LastName = "User",
                    Username = "dealer",
                    Password = "dealer",
                    Role = "dealer"
                },
                new UserModel {
                    ID = 2,
                    FirstName = "Bob",
                    OtherNames = "Kofi",
                    LastName = "Marley",
                    Username = "bob",
                    Password = "bob",
                    Role = "subscriber"
                }
            };
        }

        public IEnumerable<UserModel> GetAll()
        {
            return users;
        }

        public UserModel GetById(int id)
        {
            return users.SingleOrDefault(i => i.ID == id);
        }
    }
}
