using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class InMemoryUserRepository : IUserRepository
    {
        private IList<User> _users;

        public InMemoryUserRepository()
        {
            _users = new List<User>();
        }

        public void Save(User user)
        {
            var existing = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                _users.Remove(existing);
            }
            _users.Add(user);
        }

        public void DeleteAll()
        {
            _users.Clear();
        }

        public User Get(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void Delete(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                _users.Remove(user);
        }

        public IEnumerable<User> Get(UserTypes? userType = null, string name = null, string email = null, string tag = null)
        {
            return _users.Where(user =>
        (userType == null || user.Type == userType) &&
        (name == null || user.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) &&
        (email == null || user.Email.Equals(email, StringComparison.OrdinalIgnoreCase)));
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }
    }
}
