using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IPuestosService
    {
        Task<DBEntity> Create(PuestosEntity entity);
        Task<DBEntity> Delete(PuestosEntity entity);
        Task<IEnumerable<PuestosEntity>> Get();
        Task<PuestosEntity> GetById(PuestosEntity entity);
        Task<DBEntity> Update(PuestosEntity entity);
    }

    public class PuestosService : IPuestosService
    {
        private readonly IDataAccess sql;

        public PuestosService(IDataAccess _sql)
        {
            sql = _sql;
        }


        public async Task<IEnumerable<PuestosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<PuestosEntity>("PuestoObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }



        }


        public async Task<PuestosEntity> GetById(PuestosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<PuestosEntity>("PuestoObtener", new
                {

                    entity.Id_Puesto

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }



        }


        public async Task<DBEntity> Create(PuestosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PuestoInsertar", new
                {
                    
                    entity.Nombre,
                    entity.Salario,
                    entity.Estado

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public async Task<DBEntity> Update(PuestosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PuestoActualizar", new
                {
                    entity.Id_Puesto,
                    entity.Nombre,
                    entity.Salario,
                    entity.Estado

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public async Task<DBEntity> Delete(PuestosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PuestoEliminar", new
                {
                    entity.Id_Puesto,


                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }



        }

    }
}
