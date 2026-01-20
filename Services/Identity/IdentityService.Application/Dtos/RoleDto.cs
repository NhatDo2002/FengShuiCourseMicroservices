using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Dtos
{
    public class RoleDto
    {
        public Guid Id { get; set; } = default;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
