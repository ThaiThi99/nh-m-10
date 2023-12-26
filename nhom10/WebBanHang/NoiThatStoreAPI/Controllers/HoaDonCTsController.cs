using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using NoiThatStoreAPI.DTO;
using NoiThatStoreAPI.Models;

namespace NoiThatStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HoaDonCTsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HoaDonCTsController> _logger;
        public HoaDonCTsController(ApplicationDbContext context, ILogger<HoaDonCTsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        


        [HttpGet(Name = "GetHoaDonCTs")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
        public async Task<RestDTO<HoaDonCT[]>> Get(
        int pageIndex = 0,
        int pageSize = 10,
        string? sortColumn = "MAHD",
        string? sortOrder = "ASC",
        string? filterQuery = null)
        {
            var query = _context.HoaDonCTs.AsQueryable();
            if (!string.IsNullOrEmpty(filterQuery))
                query = query.Where(b => b.MAHD.ToString().Contains(filterQuery) && b.MASP.ToString().Contains(filterQuery));
            var recordCount = await query.CountAsync();
            query = query
            .OrderBy($"{sortColumn} {sortOrder}")
            .Skip(pageIndex * pageSize)
            .Take(pageSize);
            return new RestDTO<HoaDonCT[]>()
            {
                Data = await query.ToArrayAsync(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                RecordCount = recordCount,
                Links = new List<LinkDTO> {
                new LinkDTO(
                Url.Action(
                null,
                "HoaDonCTs",
                new { pageIndex, pageSize },
                Request.Scheme)!,
                "self",
                "GET"),
                }
            };

        }
		//[HttpPost(Name = "AddHoaDonCT")]
		//[ResponseCache(NoStore = true)]
		//public async Task<RestDTO<HoaDonCT>> Add(HoaDonCTDTO model)
		//{
		//	if (model.MAHD != null && model.SL != null && model.MASP != null && model.DONGIA != null)
		//	{
		//		var hoadonct = new HoaDonCT
		//		{
		//			MAHD = model.MAHD,
		//			MASP = model.MASP,
		//			SL = model.SL,
		//			DONGIA = model.DONGIA
		//		};

		//		await _context.HoaDonCTs.AddAsync(hoadonct);
		//		await _context.SaveChangesAsync();

		//		return new RestDTO<HoaDonCT>()
		//		{
		//			Data = hoadonct,
		//			Links = new List<LinkDTO>
		//	{
		//		new LinkDTO(
		//			Url.Action(null, "Admins", new { model }, Request.Scheme)!,
		//			"self",
		//			"POST")
		//	}
		//		};
		//	}

		//	return null;
		//}


		[HttpPost(Name = "AddHoaDonCT")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<HoaDonCT>> Add(HoaDonCTDTO model)
		{
			if (model.MAHD != null && model.MASP != null && model.SL != null && model.DONGIA != null)
			{
				var newHoaDonCT = new HoaDonCT
				{
					MAHD = model.MAHD,
					MASP = model.MASP,
					SL = model.SL,
					DONGIA = model.DONGIA
				};

				await _context.HoaDonCTs.AddAsync(newHoaDonCT);
				await _context.SaveChangesAsync();

				return new RestDTO<HoaDonCT>
				{
					Data = newHoaDonCT,
					Links = new List<LinkDTO>
			{
				new LinkDTO(
					Url.Action(null, "HoaDonCTs", model, Request.Scheme)!,
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

		[HttpPut(Name = "UpdateHoaDonCT")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<HoaDonCT?>> UpdateHoaDonCT(HoaDonCTDTO model)
		{
			var hoadonct = await _context.HoaDonCTs
				.FirstOrDefaultAsync(b => b.id == model.id);

			if (hoadonct != null)
			{
				if (model.MAHD != null && model.MAHD is long)
					hoadonct.MAHD = model.MAHD;
				if (model.MASP != null && model.MASP is long)
					hoadonct.MASP = model.MASP;
				if (model.SL != null && model.SL is int)
					hoadonct.SL = model.SL;

				if (model.DONGIA != null && model.DONGIA is decimal)
					hoadonct.DONGIA = model.DONGIA;

				await _context.SaveChangesAsync();

				return new RestDTO<HoaDonCT?>()
				{
					Data = hoadonct,
					Links = new List<LinkDTO>
			{
				new LinkDTO(
					Url.Action(null, "HoaDonCTs", model, Request.Scheme)!,
					"self",
					"PUT"
				)
			}
				};
			}
			return null;
		}


		[HttpDelete(Name = "DeleteHoaDonCT")]
        [ResponseCache(NoStore = true)]
        public async Task<RestDTO<HoaDonCT?>> Delete(long ma1)
        {
            var HoaDonCT = await _context.HoaDonCTs
            .Where(b => b.MAHD == ma1)
            .FirstOrDefaultAsync();
            if (HoaDonCT != null)
            {
                _context.HoaDonCTs.Remove(HoaDonCT);
                await _context.SaveChangesAsync();
            };
            return new RestDTO<HoaDonCT?>()
            {
                Data = HoaDonCT,
                Links = new List<LinkDTO>
            {
            new LinkDTO(Url.Action(null, "HoaDonCTs", ma1, Request.Scheme)!, "self","DELETE"),
            }
            };
        }
    }
}
