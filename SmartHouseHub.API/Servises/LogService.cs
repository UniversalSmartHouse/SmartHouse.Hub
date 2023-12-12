using Affiliates.API.DTOs;
using SmartHouseHub.API.DTOs;
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

        /// <summary>
        /// Delete all documents inside collection. Returns how many documents was deleted.
        /// </summary>
        /// <returns></returns>
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

            deleteDto.Id = id;
            deleteDto.IsDeleted = true;

            return deleteDto;
        }

        public async Task<List<LogDto>> GetAll()
        {
            return _databaseHelper.Log.FindAll().ToList();
        }

        public async Task<LogDto> Insert(LogDto obj)
        {
            if (obj.Id == Guid.Empty || !_databaseHelper.Log.Exists(x => x.Id == obj.Id))
            {
                if (obj.Id == Guid.Empty)
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
