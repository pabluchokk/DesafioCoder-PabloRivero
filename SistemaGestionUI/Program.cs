using System;
using System.Collections.Generic;
using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionUI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Gestión ===");
                Console.WriteLine("1. Gestión de Usuarios");
                Console.WriteLine("2. Gestión de Productos");
                Console.WriteLine("3. Gestión de Ventas");
                Console.WriteLine("4. Gestión de Productos Vendidos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        GestionUsuarios();
                        break;
                    case "2":
                        GestionProductos();
                        break;
                    case "3":
                        GestionVentas();
                        break;
                    case "4":
                        GestionProductosVendidos();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void GestionUsuarios()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Usuarios ===");
                Console.WriteLine("1. Listar Usuarios");
                Console.WriteLine("2. Dar de Alta Usuario");
                Console.WriteLine("3. Dar de Baja Usuario");
                Console.WriteLine("4. Modificar Usuario");
                Console.WriteLine("5. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarUsuarios();
                        break;
                    case "2":
                        CrearUsuario();
                        break;
                    case "3":
                        EliminarUsuario();
                        break;
                    case "4":
                        ModificarUsuario();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ListarUsuarios()
        {
            List<Usuario> usuarios = UsuarioBusiness.ListarUsuarios();
            Console.Clear();
            Console.WriteLine("=== Lista de Usuarios ===");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"ID: {usuario.Id}, Nombre: {usuario.Nombre} {usuario.Apellido}, Username: {usuario.NombreUsuario}, Email: {usuario.Mail}");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void CrearUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== Dar de Alta Usuario ===");
            Usuario usuario = new Usuario();

            Console.Write("Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            usuario.Apellido = Console.ReadLine();

            Console.Write("Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();

            Console.Write("Contraseña: ");
            usuario.Contraseña = Console.ReadLine();

            Console.Write("Email: ");
            usuario.Mail = Console.ReadLine();

            UsuarioBusiness.CrearUsuario(usuario);
            Console.WriteLine($"\nUsuario creado con ID: {usuario.Id}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void EliminarUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== Dar de Baja Usuario ===");
            Console.Write("Ingrese el ID del usuario a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                UsuarioBusiness.EliminarUsuario(id);
                Console.WriteLine($"Usuario con ID {id} eliminado (si existía).");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void ModificarUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== Modificar Usuario ===");
            Console.Write("Ingrese el ID del usuario a modificar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Usuario usuario = UsuarioBusiness.ObtenerUsuario(id);
                if (usuario != null)
                {
                    Console.WriteLine($"Modificando Usuario ID: {usuario.Id}");
                    Console.Write($"Nombre ({usuario.Nombre}): ");
                    string nombre = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nombre)) usuario.Nombre = nombre;

                    Console.Write($"Apellido ({usuario.Apellido}): ");
                    string apellido = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(apellido)) usuario.Apellido = apellido;

                    Console.Write($"Nombre de Usuario ({usuario.NombreUsuario}): ");
                    string nombreUsuario = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nombreUsuario)) usuario.NombreUsuario = nombreUsuario;

                    Console.Write($"Contraseña: ");
                    string contraseña = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(contraseña)) usuario.Contraseña = contraseña;

                    Console.Write($"Email ({usuario.Mail}): ");
                    string mail = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(mail)) usuario.Mail = mail;

                    UsuarioBusiness.ModificarUsuario(id, usuario);
                    Console.WriteLine("Usuario modificado correctamente.");
                }
                else
                {
                    Console.WriteLine($"No se encontró un usuario con ID {id}.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void GestionProductos()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Productos ===");
                Console.WriteLine("1. Listar Productos");
                Console.WriteLine("2. Dar de Alta Producto");
                Console.WriteLine("3. Dar de Baja Producto");
                Console.WriteLine("4. Modificar Producto");
                Console.WriteLine("5. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarProductos();
                        break;
                    case "2":
                        CrearProducto();
                        break;
                    case "3":
                        EliminarProducto();
                        break;
                    case "4":
                        ModificarProducto();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ListarProductos()
        {
            List<Producto> productos = ProductoBusiness.ListarProductos();
            Console.Clear();
            Console.WriteLine("=== Lista de Productos ===");
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.Id}, Descripción: {producto.Descripcion}, Precio Venta: {producto.PrecioVenta}, Stock: {producto.Stock}, ID Usuario: {producto.IdUsuario}");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void CrearProducto()
        {
            Console.Clear();
            Console.WriteLine("=== Dar de Alta Producto ===");
            Producto producto = new Producto();

            Console.Write("Descripción: ");
            producto.Descripcion = Console.ReadLine();

            Console.Write("Costo: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal costo))
            {
                producto.Costo = costo;
            }
            else
            {
                Console.WriteLine("Costo inválido.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Precio de Venta: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal precioVenta))
            {
                producto.PrecioVenta = precioVenta;
            }
            else
            {
                Console.WriteLine("Precio de Venta inválido.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Stock: ");
            if (int.TryParse(Console.ReadLine(), out int stock))
            {
                producto.Stock = stock;
            }
            else
            {
                Console.WriteLine("Stock inválido.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("ID del Usuario (creado previamente): ");
            if (int.TryParse(Console.ReadLine(), out int idUsuario))
            {
                producto.IdUsuario = idUsuario;
            }
            else
            {
                Console.WriteLine("ID de Usuario inválido.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            ProductoBusiness.CrearProducto(producto);
            Console.WriteLine($"\nProducto creado con ID: {producto.Id}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void EliminarProducto()
        {
            Console.Clear();
            Console.WriteLine("=== Dar de Baja Producto ===");
            Console.Write("Ingrese el ID del producto a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                ProductoBusiness.EliminarProducto(id);
                Console.WriteLine($"Producto con ID {id} eliminado (si existía).");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void ModificarProducto()
        {
            Console.Clear();
            Console.WriteLine("=== Modificar Producto ===");
            Console.Write("Ingrese el ID del producto a modificar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Producto producto = ProductoBusiness.ObtenerProducto(id);
                if (producto != null)
                {
                    Console.WriteLine($"Modificando Producto ID: {producto.Id}");
                    Console.Write($"Descripción ({producto.Descripcion}): ");
                    string descripcion = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(descripcion)) producto.Descripcion = descripcion;

                    Console.Write($"Costo ({producto.Costo}): ");
                    string costoInput = Console.ReadLine();
                    if (decimal.TryParse(costoInput, out decimal costo)) producto.Costo = costo;

                    Console.Write($"Precio de Venta ({producto.PrecioVenta}): ");
                    string precioVentaInput = Console.ReadLine();
                    if (decimal.TryParse(precioVentaInput, out decimal precioVenta)) producto.PrecioVenta = precioVenta;

                    Console.Write($"Stock ({producto.Stock}): ");
                    string stockInput = Console.ReadLine();
                    if (int.TryParse(stockInput, out int stock)) producto.Stock = stock;

                    Console.Write($"ID del Usuario ({producto.IdUsuario}): ");
                    string idUsuarioInput = Console.ReadLine();
                    if (int.TryParse(idUsuarioInput, out int idUsuario)) producto.IdUsuario = idUsuario;

                    ProductoBusiness.ModificarProducto(producto);
                    Console.WriteLine("Producto modificado correctamente.");
                }
                else
                {
                    Console.WriteLine($"No se encontró un producto con ID {id}.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void GestionVentas()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Ventas ===");
                Console.WriteLine("1. Listar Ventas");
                Console.WriteLine("2. Dar de Alta Venta");
                Console.WriteLine("3. Dar de Baja Venta");
                Console.WriteLine("4. Modificar Venta");
                Console.WriteLine("5. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarVentas();
                        break;
                    case "2":
                        CrearVenta();
                        break;
                    case "3":
                        EliminarVenta();
                        break;
                    case "4":
                        ModificarVenta();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ListarVentas()
        {
            List<Venta> ventas = VentaBusiness.ListarVentas();
            Console.Clear();
            Console.WriteLine("=== Lista de Ventas ===");
            foreach (var venta in ventas)
            {
                Console.WriteLine($"ID: {venta.Id}, Comentarios: {venta.Comentarios}, ID Usuario: {venta.IdUsuario}");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void CrearVenta()
        {
            Console.Clear();
            Console.WriteLine("=== Dar de Alta Venta ===");
            Venta venta = new Venta();

            Console.Write("Comentarios: ");
            venta.Comentarios = Console.ReadLine();

            Console.Write("ID del Usuario (creado previamente): ");
            if (int.TryParse(Console.ReadLine(), out int idUsuario))
            {
                venta.IdUsuario = idUsuario;
            }
            else
            {
                Console.WriteLine("ID de Usuario inválido.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            VentaBusiness.CrearVenta(venta);
            Console.WriteLine($"\nVenta creada con ID: {venta.Id}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void EliminarVenta()
        {
            Console.Clear();
            Console.WriteLine("=== Dar de Baja Venta ===");
            Console.Write("Ingrese el ID de la venta a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                VentaBusiness.EliminarVenta(id);
                Console.WriteLine($"Venta con ID {id} eliminada (si existía).");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void ModificarVenta()
        {
            Console.Clear();
            Console.WriteLine("=== Modificar Venta ===");
            Console.Write("Ingrese el ID de la venta a modificar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Venta venta = VentaBusiness.ObtenerVenta(id);
                if (venta != null)
                {
                    Console.WriteLine($"Modificando Venta ID: {venta.Id}");
                    Console.Write($"Comentarios ({venta.Comentarios}): ");
                    string comentarios = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(comentarios)) venta.Comentarios = comentarios;

                    Console.Write($"ID del Usuario ({venta.IdUsuario}): ");
                    string idUsuarioInput = Console.ReadLine();
                    if (int.TryParse(idUsuarioInput, out int idUsuario)) venta.IdUsuario = idUsuario;

                    VentaBusiness.ModificarVenta(venta);
                    Console.WriteLine("Venta modificada correctamente.");
                }
                else
                {
                    Console.WriteLine($"No se encontró una venta con ID {id}.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void GestionProductosVendidos()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Productos Vendidos ===");
                Console.WriteLine("1. Listar Productos Vendidos");
                Console.WriteLine("2. Agregar Producto a Venta");
                Console.WriteLine("3. Quitar Producto de Venta");
                Console.WriteLine("4. Modificar Producto de Venta");
                Console.WriteLine("5. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarProductosVendidos();
                        break;
                    case "2":
                        CrearProductoVendido();
                        break;
                    case "3":
                        EliminarProductoVendido();
                        break;
                    case "4":
                        ModificarProductoVendido();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ListarProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = ProductoVendidoBusiness.ListarProductosVendidos();
            Console.Clear();
            Console.WriteLine("=== Lista de Productos Vendidos ===");
            foreach (var pv in productosVendidos)
            {
                Console.WriteLine($"ID: {pv.Id}, Producto ID: {pv.ProductoId}, Cantidad: {pv.Cantidad}, Precio: {pv.Precio}");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void CrearProductoVendido()
        {
            Console.Clear();
            Console.WriteLine("=== Agregar Producto a Venta ===");
            ProductoVendido productoVendido = new ProductoVendido();

            Console.Write("ID del Producto Vendido (Producto existente): ");
            if (int.TryParse(Console.ReadLine(), out int productoId))
            {
                productoVendido.ProductoId = productoId;
            }
            else
            {
                Console.WriteLine("ID de Producto inválido.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Cantidad: ");
            if (int.TryParse(Console.ReadLine(), out int cantidad))
            {
                productoVendido.Cantidad = cantidad;
            }
            else
            {
                Console.WriteLine("Cantidad inválida.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Precio: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal precio))
            {
                productoVendido.Precio = precio;
            }
            else
            {
                Console.WriteLine("Precio inválido.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            ProductoVendidoBusiness.CrearProductoVendido(productoVendido);
            Console.WriteLine($"\nProducto Vendido creado con ID: {productoVendido.Id}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void EliminarProductoVendido()
        {
            Console.Clear();
            Console.WriteLine("=== Quitar Producto de Venta ===");
            Console.Write("Ingrese el ID del producto vendido a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                ProductoVendidoBusiness.EliminarProductoVendido(id);
                Console.WriteLine($"Producto Vendido con ID {id} eliminado (si existía).");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void ModificarProductoVendido()
        {
            Console.Clear();
            Console.WriteLine("=== Modificar Producto de Venta ===");
            Console.Write("Ingrese el ID del producto vendido a modificar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                ProductoVendido pv = ProductoVendidoBusiness.ObtenerProductoVendido(id);
                if (pv != null)
                {
                    Console.WriteLine($"Modificando Producto Vendido ID: {pv.Id}");
                    Console.Write($"Producto ID ({pv.ProductoId}): ");
                    string productoIdInput = Console.ReadLine();
                    if (int.TryParse(productoIdInput, out int productoId)) pv.ProductoId = productoId;

                    Console.Write($"Cantidad ({pv.Cantidad}): ");
                    string cantidadInput = Console.ReadLine();
                    if (int.TryParse(cantidadInput, out int cantidad)) pv.Cantidad = cantidad;

                    Console.Write($"Precio ({pv.Precio}): ");
                    string precioInput = Console.ReadLine();
                    if (decimal.TryParse(precioInput, out decimal precio)) pv.Precio = precio;

                    ProductoVendidoBusiness.ModificarProductoVendido(pv);
                    Console.WriteLine("Producto Vendido modificado correctamente.");
                }
                else
                {
                    Console.WriteLine($"No se encontró un producto vendido con ID {id}.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
