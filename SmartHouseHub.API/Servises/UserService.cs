using AutoMapper;
using SmartHouseHub.API.DTOs;
using SmartHouseHub.API.Helpers;
using SmartHouseHub.API.Interfaces;
using SmartHouseHub.API.Model;

namespace SmartHouseHub.API.Servises
{
    public class UserService : IUserService
    {
        private readonly LiteDbHelper _databaseHelper;
        private readonly IMapper _mapper;

        public UserService(LiteDbHelper databaseHeler, IMapper mapper)
        {
            _databaseHelper = databaseHeler;
            _mapper = mapper;
        }

        public UserDto Insert(UserDto obj)
        {
            var model = _mapper.Map<User>(obj);

            if (obj.Id == Guid.Empty || !_databaseHelper.Users.Exists(x => x.Id == obj.Id))
            {
                if (obj.Id == Guid.Empty)
                {
					obj.Id = Guid.NewGuid();
				}

                _databaseHelper.Users.Insert(model);
            }

            return obj;
        }

        public UserDto Update(UserDto obj)
        {
            var model = _mapper.Map<User>(obj);

            if (obj.Id != Guid.Empty)
            {
                _databaseHelper.Users.Update(model);
                return obj;
            }
            else
            {
                throw new ArgumentNullException("Id can`t be null");
            }
        }
    }
}
