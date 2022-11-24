using DataAccess.Dao;
using DataAccess.Dao.Memory;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DaoFactory
    {
        public static IDao<TEntity> Create<TEntity>()
        {
            var dao = new EncryptedUserDao() as IDao<TEntity>;
            if (dao == null)
                throw new Exception("Could not instantiate dao");
            return dao;
        }
    }
}
