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
	public class HoaDonsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly ILogger<HoaDonsController> _logger;
		public HoaDonsController(ApplicationDbContext context, ILogger<HoaDonsController> logger)
		{
			_context = context;
			_logger = logger;
		}
		


		[HttpGet(Name = "GetHoaDons")]
		[ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
		public async Task<RestDTO<HoaDon[]>> Get(
		int pageIndex = 0,
		int pageSize = 10,
		string? sortColumn = "MAHD",
		string? sortOrder = "ASC",
		string? filterQuery = null)
		{
			var query = _context.HoaDons.AsQueryable();
			if (!string.IsNullOrEmpty(filterQuery))
				query = query.Where(b => b.MAHD.ToString().Contains(filterQuery));
			var recordCount = await query.CountAsync();
			query = query
			.OrderBy($"{sortColumn} {sortOrder}")
			.Skip(pageIndex * pageSize)
			.Take(pageSize);
			return new RestDTO<HoaDon[]>()
			{
				Data = await query.ToArrayAsync(),
				PageIndex = pageIndex,
				PageSize = pageSize,
				RecordCount = recordCount,
				Links = new List<LinkDTO> {
				new LinkDTO(
				Url.Action(
				null,
				"HoaDons",
				new { pageIndex, pageSize },
				Request.Scheme)!,
				"self",
				"GET"),
				}
			};

		}

		[HttpPost( Name = "AddHoaDon")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<HoaDon>> Add(HoaDonDTO model)
		{
			if (model.MAHD != null && model.MAKH_id != null && model.GIABAN != null && model.NGAYHD != null && !string.IsNullOrEmpty(model.LOAIHD))
			{
				var newHoaDon = new HoaDon
				{
					MAKH_id = model.MAKH_id,
					GIABAN = model.GIABAN,
					NGAYHD = model.NGAYHD,
					LOAIHD = model.LOAIHD
				};

				await _context.HoaDons.AddAsync(newHoaDon);
				await _context.SaveChangesAsync();

				return new RestDTO<HoaDon>
				{
					Data = newHoaDon,
					Links = new List<LinkDTO>
			{
				new LinkDTO(
					Url.Action(null, "HoaDons", model, Request.Scheme)!,
					"self",
					"POST"
				)
			}
				};
			}
				return null;
			// Handle invalid model data
			// Return appropriate response or error message
		}

		[HttpPut(Name = "UpdateHoaDon")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<HoaDon?>> Post(HoaDonDTO model)
		{
			var HoaDon = await _context.HoaDons
			.Where(b => b.MAHD == model.MAHD)
			.FirstOrDefaultAsync();
			if (HoaDon != null)
			{
				if(model?.MAKH_id != null && model?.MAKH_id is long)
					HoaDon.MAKH_id = model.MAKH_id;
				if (model?.GIABAN != null && model?.GIABAN is decimal)
					HoaDon.GIABAN = model.GIABAN;
				if (model.NGAYHD != null)
					HoaDon.NGAYHD = model.NGAYHD;
				if (!string.IsNullOrEmpty(model.LOAIHD))
					HoaDon.LOAIHD = model.LOAIHD;
				_context.HoaDons.Update(HoaDon);
				await _context.SaveChangesAsync();
				return new RestDTO<HoaDon?>()
				{
					Data = HoaDon,
					Links = new List<LinkDTO>
			{
			new LinkDTO(
			Url.Action( null,"HoaDons", model, Request.Scheme)!,"self","PUT"),
			}
				};
			}
			return null;
		}


		[HttpDelete(Name = "DeleteHoaDon")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<HoaDon?>> Delete(long mahd)
		{
			var HoaDon = await _context.HoaDons
			.Where(b => b.MAHD == mahd)
			.FirstOrDefaultAsync();
			if (HoaDon != null)
			{
				_context.HoaDons.Remove(HoaDon);
				await _context.SaveChangesAsync();
			};
			return new RestDTO<HoaDon?>()
			{
				Data = HoaDon,
				Links = new List<LinkDTO>
			{
			new LinkDTO(Url.Action(null, "HoaDons", mahd,Request.Scheme)!, "self","DELETE"),
			}
			};
		}

	}
}