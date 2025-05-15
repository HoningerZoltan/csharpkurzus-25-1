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
        public void AddUser(User user) {
            _users.Add(user);
            SaveUsers();
        }


        public void SaveUsers()
        {
            try
            {
                var dtos = _users.Select(user => user.ToDto()).ToList();
                var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_path, json);
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
    }
}
