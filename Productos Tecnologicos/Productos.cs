using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Productos
{
    public class Producto
    {
        public int id { get; set; }
        public string titulo { get; set; }

        public string descripcion { get; set; }

        public float precio { get; set; }

        public float porcentajeDeDescuento { get; set; }

        public float rating { get; set; }

        public int stock { get; set; }

        public string marca { get; set; }

        public string categoria { get; set; }

        public float precioConDescuento(float precio, float porcentajeDeDescuento) =>
            precio * (1 - porcentajeDeDescuento / 100);

    }

    public class llamadoJson
    {

        public List<Producto> LeerProductos(string json)
        {
            return JsonSerializer.Deserialize<List<Producto>>(json);
        }
    }

    public class ProcesamientoDeDatos
    {
        public int contarProductos(List<Producto> productos)
        {
            return productos.Count;
        }

        public int contarProductosPor(List<Producto> productos, string marca, string categoria)
        {
            return productos.Count(p => p.marca == marca && p.categoria == categoria);
        }

        public double precioPromedio(List<Producto> productos, string marca, string categoria)
        {
            var filtrados = productos.Where(p => p.marca == marca && p.categoria == categoria);
            return filtrados.Any() ? filtrados.Average(p => p.precio) : 0;
        }

        public List<Producto> productosReponer(List<Producto> productos, int stock)
        {
            var filtrados = productos.Where(p => p.stock <= stock).ToList();
            return filtrados;
        }

        public Producto GetProducto(List<Producto> productos, int id)
        {
            return productos.FirstOrDefault(p => p.id == id);
        }

        public void GuardarInforme(Informe informe, String NombreArchivo)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(informe, opciones);
            File.WriteAllText(NombreArchivo, json);
        }
    }

    public class Informe
    {
        public int CantidadDeProductos { get; set; }
        public int ProductosSmartphoneApple { get; set; }

        public double PrecioPromedioLaptop { get; set; }

        public double PrecioPromedioSmartphone { get; set; }

        public List<Producto> bajosStock { get; set; }

        public string NombreProducto { get; set; }
    }
}


// a.  Un Método llamado ContarProductos que reciba un listado de productos de 
// entrada y devuelva un entero que indique la cantidad de elementos que 
// tiene la lista. 
// b.  Un Método llamado ContarProductosPor que reciba una lista de productos y 
// dos strings: la marca y la categoría respectivamente. Debe  devolver un 
// entero que indica la cantidad de elementos que cumplen con esa condición.  
// c.  Un Método llamado PrecioPromedio  que reciba una lista de productos y 
// dos strings: la marca y la categoría respectivamente. Debe  devolver un 
// double que indica el precio promedio de la categoría seleccionada  
// d.  Un Método llamado ProductosAReponer que reciba una lista de productos y 
// un entero indicando el Stock. Debe  devolver una lista de productos con los 
// elementos que tengan un stock menor o igual al pasado por parámetro.  
// e.  Un Método llamado GetProducto que reciba una lista de productos y un int 
// que representa el Id buscado. Debe devolver el producto correspondiente al id ingresado