using InyeccionDependencias.Contratos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace InyeccionDependencias.Models.Repositorios
{
    public class RepositorioGenerico<TContexto, TEntity> : IRepositorioGenerico<TEntity> where TContexto : DbContext, new() where TEntity : class
    {
        private TContexto contexto = new TContexto();

        public TContexto Contexto { get => contexto; set => contexto = value; }

        public virtual bool Agregar(TEntity entity)
        {
            try
            {
                this.contexto.Set<TEntity>().Add(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public virtual bool Editar(TEntity entity)
        {
            try
            {
                this.contexto.Entry<TEntity>(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public virtual bool Eliminar(TEntity entity)
        {
            try
            {
                this.contexto.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public virtual void Guardar()
        {
            this.contexto.SaveChanges();
        }

        public virtual IEnumerable<TEntity> ObtenerPor(Expression<Func<TEntity, bool>> predicate)
        {
            return this.contexto.Set<TEntity>().Where(predicate);
        }

        public virtual IEnumerable<TEntity> ObtenerTodos()
        {
            return this.contexto.Set<TEntity>().ToList();
        }
    }
}