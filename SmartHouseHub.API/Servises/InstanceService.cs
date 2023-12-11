using Affiliates.API.DTOs;
using LiteDB;
using SmartHouseHub.API.DTOs;
using SmartHouseHub.API.Helpers;
using SmartHouseHub.API.Interfaces;

namespace SmartHouseHub.API.Servises
{
    public class InstanceService : IInstanceService
    {
        private readonly LiteDbHelper _databaseHelper;

        public InstanceService(LiteDbHelper databaseHeler)
        {
            _databaseHelper = databaseHeler;
        }

        /// <summary>
        /// Delete all documents inside collection. Returns how many documents was deleted.
        /// </summary>
        /// <returns></returns>
        public async Task<int> DeleteAll()
        {
            return _databaseHelper.Instances.DeleteAll();
        }

        public async Task<DeleteDto> DeleteById(Guid id)
        {
            var model = _databaseHelper.Instances.Delete(id);
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

        public async Task<List<InstanceDto>> GetAll()
        {
            return _databaseHelper.Instances.FindAll().ToList();
        }

        public async Task<InstanceDto> GetById(Guid id)
        {
            return _databaseHelper.Instances.FindById(id);
        }

        public async Task<InstanceDto> Insert(InstanceDto obj)
        {
            if (obj.Id == null || !_databaseHelper.Instances.Exists(x => x.Id == obj.Id))
            {
                if (obj.Id == null)
                {
                    obj.Id = Guid.NewGuid();
                }

                _databaseHelper.Instances.Insert(obj);
            }
            else
            {
                _databaseHelper.Instances.Update(obj);
            }

            return obj;
        }
    }
}
