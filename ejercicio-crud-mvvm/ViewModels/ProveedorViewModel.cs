using Ejercicio_CRUD_Mvvm.Models;
using Ejercicio_CRUD_Mvvm.Services;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ejercicio_CRUD_Mvvm.ViewModels
{
    public class ProveedorViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;
        public ObservableCollection<Proveedor> Proveedores { get; set; }

        public Proveedor NuevoProveedor { get; set; }

        public ICommand GuardarProveedorCommand { get; }
        public ICommand EliminarProveedorCommand { get; }

        public ProveedorViewModel()
        {
            _databaseService = new DatabaseService();
            Proveedores = new ObservableCollection<Proveedor>();
            NuevoProveedor = new Proveedor();

            GuardarProveedorCommand = new Command(async () => await GuardarProveedor());
            EliminarProveedorCommand = new Command<Proveedor>(async (proveedor) => await EliminarProveedor(proveedor));

            CargarProveedores();
        }

        private async Task CargarProveedores()
        {
            Proveedores.Clear();
            var proveedores = await _databaseService.GetProveedoresAsync();
            foreach (var proveedor in proveedores)
                Proveedores.Add(proveedor);
        }

        private async Task GuardarProveedor()
        {
            if (string.IsNullOrWhiteSpace(NuevoProveedor.Nombre) || string.IsNullOrWhiteSpace(NuevoProveedor.Direccion) ||
                string.IsNullOrWhiteSpace(NuevoProveedor.Telefono) || string.IsNullOrWhiteSpace(NuevoProveedor.Email) ||
                string.IsNullOrWhiteSpace(NuevoProveedor.Empresa))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            if (NuevoProveedor.Id == 0)
                await _databaseService.SaveProveedorAsync(NuevoProveedor);
            else
                await _databaseService.UpdateProveedorAsync(NuevoProveedor);

            NuevoProveedor = new Proveedor();
            await CargarProveedores();
        }

        private async Task EliminarProveedor(Proveedor proveedor)
        {
            await _databaseService.DeleteProveedorAsync(proveedor);
            await CargarProveedores();
        }
    }
}