using Sporteredmenyek.Core.Models;
using Sporteredmenyek.Dto;
using Sporteredmenyek.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sporteredmenyek.Services
{
    public class UserService
    {
        private readonly List<User> _users = new();
        private readonly string _path;

        public UserService(string path)
        {
            this._path = path;
            LoadUsers();
        }
        public async Task AddUser(User user) {
            _users.Add(user);
            await SaveUsers();
        }


        public async Task SaveUsers()
        {
            try
            {
                var dtos = _users.Select(user => user.ToDto()).ToList();
                var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(_path, json);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Hiba a felhasználók mentésekor: "+ex.Message);
            }
        }
        public void LoadUsers() 
        {
            try
            {
                if (File.Exists(_path))
                {
                    var json = File.ReadAllText(_path);
                    var dtos = JsonSerializer.Deserialize<List<JsonUserDto>>(json);
                    if (dtos != null)
                    {
                        _users.AddRange(dtos.Select(dto => dto.ToDomainObject()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a felhasználók betöltésekor: "+ ex.Message);
            }
        }

        public List<User> getUsers() { return _users; }

        public bool EmailExists(string email)
        {
            var matchingEmails = _users
                .Where(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                .Select(u => u.Email)
                .ToList();

            return matchingEmails.Any();
        }
    }
}
