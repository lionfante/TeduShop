using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IVisitorStagisticRepository : IRepository<VisitorStagistic>
    {
    }
    public class VisitorStagisticRepository : RepositoryBase<VisitorStagistic> , IVisitorStagisticRepository
    {
        public VisitorStagisticRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
