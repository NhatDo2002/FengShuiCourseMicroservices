using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Models
{
    public class Role : Aggregate<RoleId>
    {
        public RoleName Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        private Role(RoleId id, RoleName name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static Role Create(RoleId id, RoleName name, string description)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id), "Role ID cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(name.Value))
            {
                throw new ArgumentNullException("Role name cannot be empty.");
            }
            var role = new Role(id, name, description);
            return role;
        }

        public void UpdateRole(RoleName name, string description)
        {
            if (string.IsNullOrWhiteSpace(name.Value))
            {
                throw new ArgumentNullException("Role name cannot be empty.");
            }
            Name = name;
            Description = description;
        }
    }
}
