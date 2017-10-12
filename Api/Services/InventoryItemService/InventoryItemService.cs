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
using Microsoft.Extensions.Logging;

namespace Api.Services
{
    public class InventoryItemService : IInventoryItemService
	{
		private readonly IMapper _mapper;
		private readonly ApplicationDbContext _db;
		private readonly IJwtService _jwtService;
        private readonly ILogger _logger;

		public InventoryItemService(IMapper mapper, ApplicationDbContext db, IJwtService jwtService, ILogger<InventoryItemService> logger)
		{
			this._mapper = mapper;
			this._db = db;
			this._jwtService = jwtService;
            this._logger = logger;
		}

        public async Task<InventoryItemStatus> AdvanceWorkflow(int id)
        {
            throw new NotImplementedException();
        }

		public async Task<List<InventoryItem>> Collection(InventoryItemFilter filter)
		{
			var query = _db.InventoryItems.AsQueryable().Filter(filter);

            return await Task.FromResult(query.ToList());
		}

        public async Task<InventoryItem> Create(InventoryItem model)
		{
            var item = _mapper.Map<InventoryItem>(model);

			await _db.InventoryItems.AddAsync(item);
			await _db.SaveChangesAsync();

			return item;
		}

		public async Task<bool> Disable(int id)
		{
			var item = await Single(id);
			if (item == null)
			{
				_logger.LogWarning("No matching inventory item to disable with the following id: " + id.ToString());
                return false;
			}

			item.IsActive = false;

			return await _db.SaveChangesAsync() == 1;
		}

        public async Task<InventoryItem> Single(int id)
		{
			return await _db.InventoryItems.SingleOrDefaultAsync(a => a.Id == id);
		}

        public async Task<InventoryItem> Update(InventoryItem model)
		{
			var item = await Single(model.Id);
			if (item == null)
			{
				_logger.LogWarning("No matching inventory item to update with the following id: " + model.Id.ToString());
				return null;
			}

            item = _mapper.Map<InventoryItem>(model);

            await _db.SaveChangesAsync();

            return item;
		}
	}
}
