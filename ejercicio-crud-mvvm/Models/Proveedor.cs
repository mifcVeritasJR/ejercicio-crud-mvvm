﻿using SQLite;

namespace Ejercicio_CRUD_Mvvm.Models
{
    public class Proveedor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }
    }
}