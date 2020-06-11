using Microsoft.EntityFrameworkCore;
using PrimerParcialBlazor.DAL;
using PrimerParcialBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimerParcialBlazor.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            if (!Existe(articulos.ArticuloId))
            {
                return Insertar(articulos);
            }
            else
            {
                return Modificar(articulos);
            }
        }

        private static bool Insertar(Articulos articulos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Articulos.Add(articulos);
                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Articulos articulos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(articulos).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        private static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var eliminado = db.Articulos.Find(id);

                db.Articulos.Remove(eliminado);

                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        private static Articulos Buscar(int id)
        {
            Contexto db = new Contexto();
            Articulos articulos;

            try
            {
                articulos = db.Articulos.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return articulos;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> articulos)
        {
            List<Articulos> Lista = new List<Articulos>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Articulos.Where(articulos).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return Lista;
        }

        private static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Articulos.Any(a => a.ArticuloId == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return encontrado;
        }
    }
}
