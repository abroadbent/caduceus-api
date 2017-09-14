using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain.AppUser;
using Api.Models.Domain.General;
using Api.Models.Domain.Inventory;
using Api.Models.System;
using Api.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class InventoryItemService : ICrudService<InventoryItem, CreateInventoryItemViewModel, EditableInventoryItemViewModel, InventoryItemFilter>
	{
		private readonly IMapper _mapper;
		private readonly ApplicationDbContext _db;
		private readonly IJwtService _jwtService;

		public InventoryItemService(IMapper mapper, ApplicationDbContext db, IJwtService jwtService)
		{
			this._mapper = mapper;
			this._db = db;
			this._jwtService = jwtService;
		}

		public async Task<ICollection<InventoryItem>> Collection(InventoryItemFilter filter)
		{
			var query = _db.InventoryItems.AsQueryable().Filter(filter);

			return await query.ToListAsync();
		}

        public async Task<InventoryItem> Create(CreateInventoryItemViewModel model)
		{
            var item = _mapper.Map<InventoryItem>(model);

			await _db.InventoryItems.AddAsync(item);
			await _db.SaveChangesAsync();

			return item;
		}

		public async Task<bool> Disable(int id)
		{
			var item = await Single(id);
			item.IsActive = false;

			return await _db.SaveChangesAsync() == 1;
		}

        public async Task<InventoryItem> Single(int id)
		{
			return await _db.InventoryItems.SingleOrDefaultAsync(a => a.Id == id);
		}

        public async Task<InventoryItem> Update(EditableInventoryItemViewModel model)
		{
			var item = await Single(model.Id);
            item = _mapper.Map<InventoryItem>(model);

            await _db.SaveChangesAsync();

            return item;
		}
	}
}
