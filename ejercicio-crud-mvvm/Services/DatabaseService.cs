using Ejercicio_CRUD_Mvvm.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Ejercicio_CRUD_Mvvm.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedores.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Proveedor>().Wait();
        }

        public Task<List<Proveedor>> GetProveedoresAsync() => _database.Table<Proveedor>().ToListAsync();

        public Task<int> SaveProveedorAsync(Proveedor proveedor) => _database.InsertAsync(proveedor);

        public Task<int> UpdateProveedorAsync(Proveedor proveedor) => _database.UpdateAsync(proveedor);

        public Task<int> DeleteProveedorAsync(Proveedor proveedor) => _database.DeleteAsync(proveedor);
    }
}