using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Extensions
{
    public static class RoleExtension
    {
        public static IEnumerable<RoleDto> ToRoleDtoList(this List<Role> roles)
        {
            if(roles == null)
            {
                return new List<RoleDto>();
            }
            var roleDtos = roles.Select(r => new RoleDto()
                                {
                                    Id = r.Id.Value,
                                    Name = r.Name.Value,
                                    Description = r.Description
                                })
                              .ToList();
            return roleDtos;
        }

        public static RoleDto ToRoleDto(this Role role)
        {
            var roleDto = new RoleDto()
            {
                Id = role.Id.Value,
                Name = role.Name.Value,
                Description = role.Description
            };

            return roleDto;
        }
    }
}
