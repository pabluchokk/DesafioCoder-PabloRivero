﻿namespace SistemaGestionEntities
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public int ProductoId { get; set; } 
        public int Cantidad { get; set; } 
        public decimal Precio { get; set; } 
        public int IdVenta { get; set; }
    }
}
