using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2_P1Tarea1_3.Controllers
{
    public class Personas
    {
        readonly SQLiteAsyncConnection _connection;
        public Personas ( string dbpath)
        {
            _connection = new SQLiteAsyncConnection (dbpath);
            _connection.CreateTableAsync<Models.Persona>().Wait();

        }

        public Task<int> StorePersonas(Models.Persona person)
        {
            if (person.Id != 0)
            {
                return _connection.UpdateAsync(person);
            }
            else
            {
                return _connection.InsertAsync(person);
            }
        }

        public Task<List<Models.Persona>> ListaPersonas()
        {
            return _connection.Table<Models.Persona>().ToListAsync();
        }


        public Task<Models.Persona> ObtenerPersonas(int pid)
        {
            return _connection.Table<Models.Persona>()
                .Where(i => i.Id == pid)
                .FirstOrDefaultAsync();
        }

        public Task<int> DeletePersonas(Models.Persona person)
        {
            return _connection.DeleteAsync(person);
        }

    }
}
