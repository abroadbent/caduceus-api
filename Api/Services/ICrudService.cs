using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models.Domain.General;

namespace Api.Services
{
    public interface ICrudService<T, CreateModel, UpdateModel, FilterModel>
    {
		Task<List<T>> Collection(FilterModel filter);
		Task<T> Create(CreateModel model);
		Task<bool> Disable(int id);
		Task<T> Single(int id);
		Task<T> Update(UpdateModel model);
    }
}
