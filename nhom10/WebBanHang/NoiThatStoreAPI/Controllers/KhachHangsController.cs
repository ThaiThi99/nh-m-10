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
	public class KhachHangsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly ILogger<KhachHangsController> _logger;
		public KhachHangsController(ApplicationDbContext context, ILogger<KhachHangsController> logger)
		{
			_context = context;
			_logger = logger;
		}
		// continue code
		[HttpGet(Name = "GetKhachHangs")]
		[ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
		public async Task<RestDTO<KhachHang[]>> Get(
		int pageIndex = 0,
		int pageSize = 10,
		string? sortColumn = "MAKH_id",
		string? sortOrder = "ASC",
		string? filterQuery = null)
		{
			var query = _context.KhachHangs.AsQueryable();
			if (!string.IsNullOrEmpty(filterQuery))
				query = query.Where(b => b.TEN.Contains(filterQuery) || b.HOLOT.Contains(filterQuery));
			var recordCount = await query.CountAsync();
			query = query
			.OrderBy($"{sortColumn} {sortOrder}")
			.Skip(pageIndex * pageSize)
			.Take(pageSize);
			return new RestDTO<KhachHang[]>()
			{
				Data = await query.ToArrayAsync(),
				PageIndex = pageIndex,
				PageSize = pageSize,
				RecordCount = recordCount,
				Links = new List<LinkDTO> {
				new LinkDTO(
				Url.Action(
				null,
				"KhachHangs",
				new { pageIndex, pageSize },
				Request.Scheme)!,
				"self",
				"GET"),
				}
			};

		}
		[HttpPost(Name = "AddKhachHang")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<KhachHang>> AddKhachHang(KhachHangDTO model)
		{
			if (model.MAKH_id != null && !string.IsNullOrEmpty(model.TEN) && !string.IsNullOrEmpty(model.HOLOT) && !string.IsNullOrEmpty(model.EMAIL) && model.SDT != null && model.GIOITINH != null)
			{
				var newKhachHang = new KhachHang
				{
					TEN = model.TEN,
					HOLOT = model.HOLOT,
					EMAIL = model.EMAIL,
					SDT = model.SDT,
					GIOITINH = model.GIOITINH
				};

				await _context.KhachHangs.AddAsync(newKhachHang);
				await _context.SaveChangesAsync();

				return new RestDTO<KhachHang>
				{
					Data = newKhachHang,
					Links = new List<LinkDTO>
			{
				new LinkDTO(
					Url.Action(null, "KhachHangs", model, Request.Scheme)!,
					"self",
					"POST"
				)
			}
				};
			}
			return null;
		}


		[HttpPut(Name = "UpdateKhachHang")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<KhachHang?>> Post(KhachHangDTO model)
		{
			var KhachHang = await _context.KhachHangs
			.Where(b => b.MAKH_id == model.MAKH_id)
			.FirstOrDefaultAsync();
			if (KhachHang != null)
			{
				if (!string.IsNullOrEmpty(model.TEN))
					KhachHang.TEN = model.TEN;
				if (!string.IsNullOrEmpty(model.HOLOT))
					KhachHang.HOLOT = model.HOLOT;
				if (!string.IsNullOrEmpty(model.EMAIL))
					KhachHang.EMAIL = model.EMAIL;
				if (model?.SDT != null && model?.SDT is int)
					KhachHang.SDT = model.SDT;
				if (model?.GIOITINH != null)
					KhachHang.GIOITINH = model.GIOITINH;
				_context.KhachHangs.Update(KhachHang);
				await _context.SaveChangesAsync();
				return new RestDTO<KhachHang?>()
				{
					Data = KhachHang,
					Links = new List<LinkDTO>
			{
			new LinkDTO(
			Url.Action( null,"KhachHangs", model, Request.Scheme)!,"self","PUT"),
			}
				};
			}
			return null;
			//else
			//{

			//	if (model.MAKH_id != null)
			//	{
			//		if (!string.IsNullOrEmpty(model.TEN))
			//		{
			//			if (!string.IsNullOrEmpty(model.HOLOT))
			//			{
			//				if (!string.IsNullOrEmpty(model.EMAIL))
			//				{
			//					if (model?.SDT != null && model?.SDT is int)
			//					{
			//						if (model?.GIOITINH != null)
			//						{
			//							var ad = new KhachHang
			//							{
			//								MAKH_id = model.MAKH_id,
			//								TEN = model.TEN,
			//								HOLOT = model.HOLOT,
			//								EMAIL = model.EMAIL,
			//								SDT = model.SDT,
			//								GIOITINH = model.GIOITINH
			//							};
			//							_context.KhachHangs.Add(ad);
			//							await _context.SaveChangesAsync();
			//						}
			//					}
			//				}
			//			}

			//		}
			//	}
			//}
			
		}


		[HttpDelete(Name = "DeleteKhachHang")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<KhachHang?>> Delete(long makh)
		{
			var KhachHang = await _context.KhachHangs
			.Where(b => b.MAKH_id == makh)
			.FirstOrDefaultAsync();
			if (KhachHang != null)
			{
				_context.KhachHangs.Remove(KhachHang);
				await _context.SaveChangesAsync();
			};
			return new RestDTO<KhachHang?>()
			{
				Data = KhachHang,
				Links = new List<LinkDTO>
			{
			new LinkDTO(Url.Action(null, "KhachHangs", makh, Request.Scheme)!, "self","DELETE"),
			}
			};
		}

	}
}