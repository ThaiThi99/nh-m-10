

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NoiThatStoreAPI.DTO;
using NoiThatStoreAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace NoiThatStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AdminsController> _logger;
        public AdminsController(ApplicationDbContext context, ILogger<AdminsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // continue code

        [HttpGet(Name = "GetAdmins")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
        public async Task<RestDTO<Admin[]>> Get(
        int pageIndex = 0,
        int pageSize = 10,
        string? sortColumn = "TEN_TK",
        string? sortOrder = "ASC",
        string? filterQuery = null)
        {
            var query = _context.Admins.AsQueryable();
            if (!string.IsNullOrEmpty(filterQuery))
                query = query.Where(b => b.TEN_TK.Contains(filterQuery));
            var recordCount = await query.CountAsync();
            query = query
            .OrderBy($"{sortColumn} {sortOrder}")
            .Skip(pageIndex * pageSize)
            .Take(pageSize);
            return new RestDTO<Admin[]>()
            {
                Data = await query.ToArrayAsync(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                RecordCount = recordCount,
                Links = new List<LinkDTO> {
                new LinkDTO(
                Url.Action(
                null,
                "Admins",
                new { pageIndex, pageSize },
                Request.Scheme)!,
                "self",
                "GET"),
                }
            };

        }


        [HttpPost(Name = "AddAdmin")]
        [ResponseCache(NoStore = true)]
        public async Task<RestDTO<Admin>> Add(AdminDTO model)
        {
            if (!string.IsNullOrEmpty(model.TEN_TK) && !string.IsNullOrEmpty(model.pass))
            {
                var admin = new Admin
                {
                    TEN_TK = model.TEN_TK,
                    PASS = model.pass
                };

				await _context.Admins.AddAsync(admin);
                await _context.SaveChangesAsync();

                return new RestDTO<Admin>()
                {
                    Data = admin,
                    Links = new List<LinkDTO>
            {
                new LinkDTO(
                    Url.Action(null, "Admins", new { id = admin.ADMINID }, Request.Scheme)!,
                    "self",
                    "POST")
            }
                };
            }

            return null;
        }


        [HttpPut("{id}", Name = "UpdateAdmin")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<Admin>> Update(long id, AdminDTO model)
		{
			var admin = await _context.Admins.FindAsync(id);
			if (admin != null)
			{
				if (!string.IsNullOrEmpty(model.TEN_TK))
					admin.TEN_TK = model.TEN_TK;
				if (!string.IsNullOrEmpty(model.pass))
					admin.PASS = model.pass;

				await _context.SaveChangesAsync();

				return new RestDTO<Admin>()
				{
					Data = admin,
					Links = new List<LinkDTO>
			{
				new LinkDTO(
					Url.Action(null, "Admins", new { id }, Request.Scheme)!,
					"self",
					"PUT")
			}
				};
			}

			return null;
		}

        [HttpDelete(Name = "DeleteAdmin")]
        [ResponseCache(NoStore = true)]
        public async Task<RestDTO<Admin?>> Delete(long id)
        {
            var Admin = await _context.Admins
            .Where(b => b.ADMINID == id)
            .FirstOrDefaultAsync();
            if (Admin != null)
            {
                _context.Admins.Remove(Admin);
                await _context.SaveChangesAsync();
            };
            return new RestDTO<Admin?>()
            {
                Data = Admin,
                Links = new List<LinkDTO>
            {
            new LinkDTO(Url.Action(null, "Admins", id, Request.Scheme)!, "self","DELETE"),
            }
            };
        }
    }
}
