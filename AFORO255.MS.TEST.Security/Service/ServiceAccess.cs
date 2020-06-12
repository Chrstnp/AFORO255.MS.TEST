using AFORO255.MS.TEST.Security.Model;
using AFORO255.MS.TEST.Security.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AFORO255.MS.TEST.Security.Service
{
    public class ServiceAccess : IServiceAccess
    {
        private readonly IRepositoryAccess _repositoryAccess;

        public ServiceAccess(IRepositoryAccess repositoryAccess)
        {
            _repositoryAccess = repositoryAccess;
        }

        public IEnumerable<Access> GetAll()
        {
            return _repositoryAccess.GetAll();
        }

        public bool Validate(string userName, string password)
        {
            var list = _repositoryAccess.GetAll();
            var access = list.Where(x => x.username == userName && x.password == password).FirstOrDefault();
            if (access != null)
                return true;
            return false;

        }
    }
}
