using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using NoiThatStoreAPI.DTO;
using NoiThatStoreAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace NoiThatStoreAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class NhaCungCapsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly ILogger<NhaCungCapsController> _logger;
		public NhaCungCapsController(ApplicationDbContext context, ILogger<NhaCungCapsController> logger)
		{
			_context = context;
			_logger = logger;
		}
		// continue code
	
		[HttpGet(Name = "GetNhaCungCaps")]
		[ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
		public async Task<RestDTO<NhaCungCap[]>> Get(
		int pageIndex = 0,
		int pageSize = 10,
		string? sortColumn = "NCC_ID",
		string? sortOrder = "ASC",
		string? filterQuery = null)
		{
			var query = _context.NhaCungCaps.AsQueryable();
			if (!string.IsNullOrEmpty(filterQuery))
				query = query.Where(b => b.TEN.Contains(filterQuery));
			var recordCount = await query.CountAsync();
			query = query
			.OrderBy($"{sortColumn} {sortOrder}")
			.Skip(pageIndex * pageSize)
			.Take(pageSize);
			return new RestDTO<NhaCungCap[]>()
			{
				Data = await query.ToArrayAsync(),
				PageIndex = pageIndex,
				PageSize = pageSize,
				RecordCount = recordCount,
				Links = new List<LinkDTO> {
				new LinkDTO(
				Url.Action(
				null,
				"NhaCungCaps",
				new { pageIndex, pageSize },
				Request.Scheme)!,
				"self",
				"GET"),
				}
			};

		}
		[HttpPost(Name = "AddNhaCungCap")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<NhaCungCap?>> AddNhaCungCap(NhaCungCapDTO model)
		{
			if (model.NCC_ID != null && !string.IsNullOrEmpty(model.TEN) && !string.IsNullOrEmpty(model.DIACHI) && model.SDT != null && !string.IsNullOrEmpty(model.EMAIL))
			{
				var newNhaCungCap = new NhaCungCap
				{
					TEN = model.TEN,
					DIACHI = model.DIACHI,
					SDT = model.SDT,
					EMAIL = model.EMAIL
				};

				await _context.NhaCungCaps.AddAsync(newNhaCungCap);
				await _context.SaveChangesAsync();

				return new RestDTO<NhaCungCap?>
				{
					Data = newNhaCungCap,
					Links = new List<LinkDTO>
			{
				new LinkDTO(
					Url.Action(null, "NhaCungCaps", model, Request.Scheme)!,
					"self",
					"POST"
				)
			}
				};
			}

			return new RestDTO<NhaCungCap?>
			{
				Data = null,
				Links = new List<LinkDTO>
		{
			new LinkDTO(
				Url.Action(null, "NhaCungCaps", model, Request.Scheme)!,
				"self",
				"POST"
			)
		}
			};
		}

		[HttpPut(Name = "UpdateNhaCungCap")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<NhaCungCap?>> Post(NhaCungCapDTO model)
		{
			var NhaCungCap = await _context.NhaCungCaps
			.Where(b => b.NCC_ID == model.NCC_ID)
			.FirstOrDefaultAsync();
			if (NhaCungCap != null)
			{
				if (!string.IsNullOrEmpty(model.TEN))
					NhaCungCap.TEN = model.TEN;
				if (!string.IsNullOrEmpty(model.DIACHI))
					NhaCungCap.DIACHI = model.DIACHI;
				if (model?.SDT != null && model?.SDT is int)
					NhaCungCap.SDT = model.SDT;
				if (!string.IsNullOrEmpty(model?.EMAIL))
					NhaCungCap.EMAIL = model.EMAIL;


				_context.NhaCungCaps.Update(NhaCungCap);
				await _context.SaveChangesAsync();
				return new RestDTO<NhaCungCap?>()
				{
					Data = NhaCungCap,
					Links = new List<LinkDTO>
			{
			new LinkDTO(
			Url.Action( null,"NhaCungCaps", model, Request.Scheme)!,"self","PUT"),
			}
				};
			}
			return null;
		}


		[HttpDelete(Name = "DeleteNhaCungCap")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<NhaCungCap?>> Delete(long id)
		{
			var NhaCungCap = await _context.NhaCungCaps
			.Where(b => b.NCC_ID == id)
			.FirstOrDefaultAsync();
			if (NhaCungCap != null)
			{
				_context.NhaCungCaps.Remove(NhaCungCap);
				await _context.SaveChangesAsync();
			};
			return new RestDTO<NhaCungCap?>()
			{
				Data = NhaCungCap,
				Links = new List<LinkDTO>
			{
			new LinkDTO(Url.Action(null, "NhaCungCaps", id, Request.Scheme)!, "self","DELETE"),
			}
			};
		}

	}
}