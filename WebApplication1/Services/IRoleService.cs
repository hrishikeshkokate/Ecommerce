﻿using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IRoleService
    {
        IEnumerable<Role> GetRoles();
    }
}
