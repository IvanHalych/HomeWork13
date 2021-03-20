using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepsWebApp.Db;
using DepsWebApp.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DepsWebApp.Authentication
{
    public class AccountServiceDB:IAccountService
    {
        private readonly UserContext _context;

        public AccountServiceDB(UserContext _context)
        {
            this._context = _context;
        }

        public async Task<int?> RegisterAsync(string login, string password)
        {
            if (login == null) throw new ArgumentNullException(nameof(login));
            if (password == null) throw new ArgumentNullException(nameof(password));
            var hash = Hash(password);
            if( await _context.Users.AnyAsync(u=>u.Login == login))
            {
                return -1;
            }
            else
            {
                await _context.Users.AddAsync(new User(login, Hash(password)));
                await _context.SaveChangesAsync();
                return (await _context.Users.FirstAsync(u => u.Login == login)).Id;
            }
        }

        public async Task<int?> LoginAsync(string login, string password)
        {
            if (login == null || password == null) return -1;
            if (await _context.Users.AnyAsync(u => u.Login == login && (u.Hash_Password == Hash(password))))
            {
                return (await _context.Users.FirstAsync(u => u.Login == login)).Id;
            }

            return null;
        }

        public async Task<bool> RemoveAsync(int accountId)
        {
            var user = await _context.Users.FirstAsync(u => u.Id == accountId);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return !(await _context.Users.AnyAsync(u => u.Id == accountId));
        }

        public string Hash(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }  
    }
}
