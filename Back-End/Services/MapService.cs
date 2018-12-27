using Back_End.Models;
using Back_End.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.Services
{
    public class MapService
    {

        MapRepository _mapRepository;

        public MapService(MapRepository mapRepository)
        {
            _mapRepository = mapRepository;
        }

        public async Task<IEnumerable<MapModel>> AsyncGetMaps(int index, int count)
        {
            var data = await _mapRepository.AsyncGetMaps(index, count, p => p.Id);
            return data;
        }

        public async Task AsyncInsert(MapModel entity)
        {
            await _mapRepository.AsyncInsert(entity);
        }
    }
}
