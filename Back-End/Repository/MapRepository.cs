using Back_End.DbContexts;
using Back_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.Repository
{
    public class MapRepository
    {
        ProjectDbContext context;
        private readonly IQueryable<MapModel> _source;

        public MapRepository(ProjectDbContext context)
        {
            this.context = context;
            this._source = context.MapModel;
        }

        public async Task<IEnumerable<MapModel>> AsyncGetMaps(int index, int count, Expression<Func<MapModel, int>> orderLambda)
        {
            return _source.Skip(index * count).Take(count).OrderBy(orderLambda);
        }

        public async Task AsyncInsert(MapModel entity)
        {
            context.MapModel.Add(entity);
            await context.SaveChangesAsync();
        }
    }
}
