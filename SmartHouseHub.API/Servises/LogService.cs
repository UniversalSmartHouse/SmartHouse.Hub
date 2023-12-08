using Affiliates.API.DTOs;
using SmartHouseHub.API.Dto;
using SmartHouseHub.API.Helpers;
using SmartHouseHub.API.Interfaces;

namespace SmartHouseHub.API.Servises
{
	public class LogService : ILogService
	{
		private readonly LiteDbHelper _databaseHelper;

		public LogService(LiteDbHelper databaseHeler)
		{
			_databaseHelper = databaseHeler;
		}

		public async Task<int> DeleteAll()
		{
			return _databaseHelper.Log.DeleteAll();
		}

		public async Task<DeleteDto> DeleteById(Guid id)
		{
			var model = _databaseHelper.Log.Delete(id);
			var deleteDto = new DeleteDto();

			if (model == false)
			{
				deleteDto.Id = id;
				deleteDto.IsDeleted = false;
				return deleteDto;
			}

			return deleteDto;
		}

		public async Task<List<LogDto>> GetAll()
		{
			return _databaseHelper.Log.FindAll().ToList();
		}

		public async Task<LogDto> Insert(LogDto obj)
		{
			if (obj.Id == null || !_databaseHelper.Log.Exists(x => x.Id == obj.Id))
			{
				if (obj.Id == null)
				{
					obj.Id = Guid.NewGuid();
				}

				_databaseHelper.Log.Insert(obj);
			}
			else
			{
				_databaseHelper.Log.Update(obj);
			}

			return obj;
		}
	}
}
