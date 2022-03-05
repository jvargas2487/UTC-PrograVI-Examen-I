using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IInstitucionService
    {
        Task<DBEntity> Create(InstitucionEntity entity);
        Task<DBEntity> Delete(InstitucionEntity entity);
        Task<IEnumerable<InstitucionEntity>> Get();
        Task<InstitucionEntity> GetById(InstitucionEntity entity);
        Task<DBEntity> Update(InstitucionEntity entity);
    }

    public class InstitucionService : IInstitucionService
    {
        private readonly IDataAccess _sql;

        public InstitucionService(IDataAccess sql)
        {
            _sql = sql;
        }

        public async Task<IEnumerable<InstitucionEntity>> Get()
        {
            try
            {
                return await _sql.QueryAsync<InstitucionEntity>("InstitucionObtener");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<InstitucionEntity> GetById(InstitucionEntity entity)
        {
            try
            {
                return await _sql.QueryFirstAsync<InstitucionEntity>("InstitucionObtener", new { entity.Id_Institucion });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Create(InstitucionEntity entity)
        {
            try
            {
                return await _sql.ExecuteAsync("InstitucionInsertar", new
                {
                    entity.Id_Institucion,
                    entity.Nombre,
                    entity.Telefono,
                    entity.Estado
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Update(InstitucionEntity entity)
        {
            try
            {
                return await _sql.ExecuteAsync("InstitucionActualizar", entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(InstitucionEntity entity)
        {
            try
            {
                return await _sql.ExecuteAsync("InstitucionEliminar", new { entity.Id_Institucion });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
