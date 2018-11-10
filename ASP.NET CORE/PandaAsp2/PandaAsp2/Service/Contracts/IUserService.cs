using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PandaAsp2.Data.Models;

namespace PandaAsp2.Service.Contracts
{
    public interface IUserService
    {
        User GetUser(string username);

        void AddUser(User user);

        bool IsAnyUserInContext();
    }
}
