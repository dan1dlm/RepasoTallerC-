// See https://aka.ms/new-console-template for more information
using System;
using Productos;

var llamado = new llamadoJson();

string json = File.ReadAllText("Productos.json");

List<Producto> productos = llamado.LeerProductos(json);

var informe = new Informe();

var procesamiento = new ProcesamientoDeDatos();

informe.CantidadDeProductos = procesamiento.contarProductos(productos);

informe.ProductosSmartphoneApple = procesamiento.contarProductosPor(productos, "Apple", "smartphones");

informe.PrecioPromedioLaptop = procesamiento.precioPromedio(productos, "Samsung", "laptops");

informe.PrecioPromedioSmartphone = procesamiento.precioPromedio(productos, "Samsung", "smartphones");

informe.bajosStock = procesamiento.productosReponer(productos, 50);

informe.NombreProducto = procesamiento.GetProducto(productos, 5).titulo;

procesamiento.GuardarInforme(informe, "informe.json");