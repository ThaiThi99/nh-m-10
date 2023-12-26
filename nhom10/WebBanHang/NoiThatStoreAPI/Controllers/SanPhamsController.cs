

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
	public class SanPhamsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly ILogger<SanPhamsController> _logger;
		public SanPhamsController(ApplicationDbContext context, ILogger<SanPhamsController> logger)
		{
			_context = context;
			_logger = logger;
		}
		// continue code

		[HttpGet(Name = "GetSanPhams")]
		[ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
		public async Task<RestDTO<SanPham[]>> Get(
		int pageIndex = 0,
		int pageSize = 10,
		string? sortColumn = "TENSP",
		string? sortOrder = "ASC",
		string? filterQuery = null)
		{
			var query =  _context.SanPhams.AsQueryable();
			if (!string.IsNullOrEmpty(filterQuery))
				query = query.Where(b => b.TENSP.Contains(filterQuery));
			var recordCount = await query.CountAsync();
			query = query
			.OrderBy($"{sortColumn} {sortOrder}")
			.Skip(pageIndex * pageSize)
			.Take(pageSize);
			return new RestDTO<SanPham[]>()
			{
				Data = await query.ToArrayAsync(),
				PageIndex = pageIndex,
				PageSize = pageSize,
				RecordCount = recordCount,
				Links = new List<LinkDTO> {
				new LinkDTO(
				Url.Action(
				null,
				"SanPhams",
				new { pageIndex, pageSize },
				Request.Scheme)!,
				"self",
				"GET"),
				}
			};

		}

		[HttpPost(Name = "AddSanPham")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<SanPham>> Add(SanPhamDTO model)
		{
			if (model.NCC_ID != null && model.NCC_ID is long && !string.IsNullOrEmpty(model.TENSP) && !string.IsNullOrEmpty(model.LOAI)
				&& !string.IsNullOrEmpty(model.CHATLIEU) && !string.IsNullOrEmpty(model.HINHANH) && !string.IsNullOrEmpty(model.MoTa)
				&& model.TONKHO != null && model.TONKHO is int && model.GiaBan != null && model.GiaBan is double)
			{
				var SanPham = new SanPham
				{
					NCC_ID = model.NCC_ID,
					TENSP = model.TENSP,
					LOAI = model.LOAI,
					CHATLIEU = model.CHATLIEU,
					TONKHO = model.TONKHO,
					GiaBan = model.GiaBan,
					HINHANH = model.HINHANH,
					MoTa = model.MoTa,
				};

				await _context.SanPhams.AddAsync(SanPham);
				await _context.SaveChangesAsync();

				return new RestDTO<SanPham>()
				{
					Data = SanPham,
					Links = new List<LinkDTO>
			{
				new LinkDTO(
					Url.Action(null, "SanPhams", new { id = SanPham.MASP }, Request.Scheme)!,
					"self",
					"POST")
			}
				};
			}

			return null;
		}


		[HttpPut("{id}", Name = "UpdateSanPham")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<SanPham>> Update(long id, SanPhamDTO model)
		{
			var SanPham = await _context.SanPhams.FindAsync(id);
			if (SanPham != null)
			{

				if (model.NCC_ID != null && model.NCC_ID is long && !string.IsNullOrEmpty(model.TENSP) && !string.IsNullOrEmpty(model.LOAI)
			&& !string.IsNullOrEmpty(model.CHATLIEU) && !string.IsNullOrEmpty(model.HINHANH) && !string.IsNullOrEmpty(model.MoTa)
			&& model.TONKHO != null && model.TONKHO is int && model.GiaBan != null && model.GiaBan is double)
				{

					SanPham.NCC_ID = model.NCC_ID;
					SanPham.TENSP = model.TENSP;
					SanPham.LOAI = model.LOAI;
					SanPham.CHATLIEU = model.CHATLIEU;
					SanPham.TONKHO = model.TONKHO;
					SanPham.GiaBan = model.GiaBan;
					SanPham.HINHANH = model.HINHANH;
					SanPham.MoTa = model.MoTa;

				}

				await _context.SaveChangesAsync();

				return new RestDTO<SanPham>()
				{
					Data = SanPham,
					Links = new List<LinkDTO>
			{
				new LinkDTO(
					Url.Action(null, "SanPhams", new { id }, Request.Scheme)!,
					"self",
					"PUT")
			}
				};
			}

			return null;
		}
		


		[HttpDelete(Name = "DeleteSanPham")]
		[ResponseCache(NoStore = true)]
		public async Task<RestDTO<SanPham?>> Delete(long id)
		{
			var SanPham = await _context.SanPhams
			.Where(b => b.MASP == id)
			.FirstOrDefaultAsync();
			if (SanPham != null)
			{
				 _context.SanPhams.Remove(SanPham);
				await _context.SaveChangesAsync();
			};
			return new RestDTO<SanPham?>()
			{
				Data = SanPham,
				Links = new List<LinkDTO>
			{
			new LinkDTO(Url.Action(null, "SanPhams", id, Request.Scheme)!, "self","DELETE"),
			}
			};
		}


	}
}
