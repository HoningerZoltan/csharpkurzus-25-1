using Sporteredmenyek.Core.Models;
using Sporteredmenyek.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Mappers
{
    public static class UserMapper
    {
        public static JsonUserDto ToDto(this User user)
        {
            return new JsonUserDto
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
        }

        public static User ToDomainObject(this JsonUserDto dto)
        {
            return new User(dto.Name, dto.Email, dto.Password);
        }
    }
}
