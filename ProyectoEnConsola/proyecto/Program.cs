using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace proyecto
{
    // Versión de proyecto sin usar listas para las fechas de precios.
    class PrecioFecha
    {
        public DateTime FechaInicio{get; set;}
        public DateTime FechaFinal{get; set;}
        public Decimal Precio{get; set;}

        public PrecioFecha(DateTime f_inicio, DateTime f_final, Decimal prec)
        {
            FechaInicio = f_inicio;
            FechaFinal = f_final;
            Precio = prec;
        }

        public PrecioFecha()
        {
            
        }
    }
    class Producto: IComparable
    {
        public PrecioFecha Precio{get; set;} 
        public string Codigo{get; set;}
        public string Descripcion{get; set;}
        public int Departamento{get; set;}
        public int Likes{get; set;}

        public Producto(PrecioFecha precio, string cod, string desc, int dep, int likes)
        {
            Precio = precio;
            Codigo = cod;
            Descripcion = desc;
            Departamento = dep;
            Likes = likes;
        }

        public Producto()
        {

        }

        public decimal GetPrecio(DateTime fechaingresada)
        {
            // Regresar el precio en la fecha recibida.
            return this.Precio.Precio; // keyword this es referencia a la instancia del objeto.
        }

        public void Get() // Metodo que regresa el precio para la fecha actual.
        {
            decimal precioactual; 
            precioactual =  this.Precio.Precio; 
            Console.WriteLine(precioactual); 
          
        }
        

        public int CompareTo(object obj)
        {
            return Likes.CompareTo(((Producto) obj).Likes); // Casting de objeto a producto.
        }
    }
    
    class ProductoDB 
    {
        public static void Escribir(string direccion, object obj) // Escribe objetos tipo producto
        {
            string flujo = JsonSerializer.Serialize(obj);
            File.WriteAllText(@direccion, flujo);
        }

        public static List<Producto> Leer(string direccion) // Lee objetos tipo producto
        {
            List<Producto> recibidos = new List<Producto>();
            string flujodado = File.ReadAllText(@direccion);
            recibidos = JsonSerializer.Deserialize<List<Producto>>(flujodado);
            return recibidos;
        }

        public static void GetDepartamento(int Depto)
        {
            // Leer productos de archivo, pero muestra en pantalla solo los
            // productos del departamento que se envió como parametro

            Console.WriteLine("Los productos del departamento " + Depto + " son los siguientes:" );
            List<Producto> depa = ProductoDB.Leer("productos.json");

            foreach(Producto d in depa)
            {
                if(d.Departamento == Depto)
                {
                    Console.WriteLine(d.Descripcion);
                }
            }
        }

        public static void OrdenacionPorLikes(string direccion) 
        {
            //Lee los productos de un archivo y los ordena por likes ascendentemente. 

            Console.WriteLine("Productos ordenados por cantidad de likes (Ascendentemente)");
            List<Producto> ordenacion = ProductoDB.Leer(direccion);
            
            ordenacion.Sort();

            foreach(Producto o in ordenacion)
            {
                Console.WriteLine("{0} : {1} likes.",o.Descripcion, o.Likes);
            }

        }

       
    }
    
    class Program
    {
        static void Main(string[] args)
        {
  
            Producto Jabon = new Producto(new PrecioFecha(new DateTime(2019,2,21), new DateTime(2020,2,21), 30),"FMKJX8HR","Jabon",8,50);
            Producto Gel_Antibacterial = new Producto(new PrecioFecha(new DateTime(2020,3,21), new DateTime(2020,12,21), 350),"HCBNYNN7","Gel Antibacterial",8,1200);
            Producto Cubreboca = new Producto(new PrecioFecha(new DateTime(2020,3,20), new DateTime(2020,12,30), 100), "G27QJAE5", "Cubreboca",8,5000);
            Producto Motherboard = new Producto(new PrecioFecha(new DateTime(2018,8,13), new DateTime(2020,7,31), 1000), "MLDUQSJY", "mAtx B450M DSH3",9,1564);
            Producto Graph_card = new Producto(new PrecioFecha(new DateTime(2017,6,12), new DateTime(2018,6,10), 4858), "W73EFK84", "MSI Nvidia Gtx 1650 Super",9,5452);
            Producto Cpu = new Producto(new PrecioFecha(new DateTime(2019,5,15), new DateTime(2020,1,10), 2985), "E3DCXWY3", "AMD Ryzen 5 2600",9,365);
            Producto Pintura = new Producto(new PrecioFecha(new DateTime(2015,5,15), new DateTime(2017,1,18), 541), "2WLUPFAD", "Pintura verde",2,800);
            Producto Destornillador = new Producto(new PrecioFecha(new DateTime(2014,2,15), new DateTime(2016,1,23), 350), "T9ZM2YH4", "Destornillador",2,750);
            Producto Martillo = new Producto(new PrecioFecha(new DateTime(2013,2,12), new DateTime(2017,6,23), 193), "YCPZ39G5", "Martillo",2,2000);
            Producto Ropa_Deportiva = new Producto(new PrecioFecha(new DateTime(2010,12,21), new DateTime(2018,6,14), 200), "YFAHPLGZ", "Ropa deportiva",6,3000);
            Producto Pelota = new Producto(new PrecioFecha(new DateTime(2010,4,27), new DateTime(2016,6,21), 210), "ZB2YWZA5", "Pelota",6,2500);
            Producto Zapato_Deportivo = new Producto(new PrecioFecha(new DateTime(2017,6,28), new DateTime(2018,8,27), 500), "A3WM8ZYF", "Zapato deportivo",6,1400);
            Producto Lavadora = new Producto(new PrecioFecha(new DateTime(2018,4,30), new DateTime(2019,8,21), 1500), "DDJ43J4J", "Lavadora",1,410);
            Producto Tostadora = new Producto(new PrecioFecha(new DateTime(2019,2,24), new DateTime(2020,12,25), 920), "GP8LJJWW", "Tostadora",1,620);
            Producto Licuadora = new Producto(new PrecioFecha(new DateTime(2017,6,1), new DateTime(2018,2,14), 1230), "ZP9LDJCV", "Licuadora",1,700);
            Producto Cuaderno = new Producto(new PrecioFecha(new DateTime(2014,5,10), new DateTime(2020,2,14), 80), "ZP9LDJCV", "Cuaderno",3,9100);
            Producto Lapiz = new Producto(new PrecioFecha(new DateTime(2019,6,10), new DateTime(2020,6,10), 35), "F283KDJB", "Lapiz",3,1200);
            Producto Borrador = new Producto(new PrecioFecha(new DateTime(2014,3,12), new DateTime(2017,3,21), 28), " EE9QCLKG ", "Borrador",3,920);

            List<Producto> productos = new List<Producto>();
            productos.Add(Jabon);
            productos.Add(Gel_Antibacterial);
            productos.Add(Cubreboca);
            productos.Add(Motherboard);
            productos.Add(Graph_card);
            productos.Add(Cpu);
            productos.Add(Pintura);
            productos.Add(Destornillador);
            productos.Add(Martillo);
            productos.Add(Ropa_Deportiva);
            productos.Add(Pelota);
            productos.Add(Zapato_Deportivo);
            productos.Add(Lavadora);
            productos.Add(Tostadora);
            productos.Add(Licuadora);
            productos.Add(Cuaderno);
            productos.Add(Lapiz);
            productos.Add(Borrador);

            ProductoDB.Escribir("productos.json", productos);
            Console.WriteLine("Se ha guardado la lista de productos.");

            Console.WriteLine("A continuación, ingresa una fecha.");

            int year; //= Convert.ToInt32(Console.ReadLine());
            int mes; //=  Convert.ToInt32(Console.ReadLine());
            int dia; //= Convert.ToInt32(Console.ReadLine());

            DateTime fechaingresada = new DateTime();
            try
            {
                Console.Write("Ingresa año: ");
                year = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ingrese mes: ");
                mes = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ingrese día: ");
                dia = Convert.ToInt32(Console.ReadLine());

                fechaingresada = new DateTime(year,mes,dia);

                Console.WriteLine("La fecha ingresada es " + fechaingresada); 
            }
            catch(ArgumentOutOfRangeException outofrange)
            {
                Console.WriteLine("Fecha no válida, el archivo estará vacio.");
                
            }
            catch(OverflowException oe)
            {
                Console.WriteLine("La fecha es demasiado grande, el archivo estará vacio.");
            }
            catch(FormatException fe)
            {
                Console.WriteLine("Solo puedes ingresar números para las fechas, el archivo estará vacio.");
            }

            // Validando que la fecha ingresada coinicida con el intervalo de fecha inicial y final del producto
            
            List<Producto> productoscoincidentes = new List<Producto>();

            foreach(Producto p in productos)
            {
                if(fechaingresada >= p.Precio.FechaInicio && fechaingresada <= p.Precio.FechaFinal)
                {
                    productoscoincidentes.Add(p); // Agrego los productos validados a la lista 
                }

            }

            ProductoDB.Escribir("coincidente.json", productoscoincidentes);
            Console.WriteLine("Se ha guardado el archivo.");
            Console.WriteLine("");

            DateTime tiempoactual = DateTime.Now;
            Console.WriteLine("La fecha del dia de hoy es: " + tiempoactual);
            foreach(Producto p in productos)
            {
                if(tiempoactual >= p.Precio.FechaInicio && tiempoactual <= p.Precio.FechaFinal)
                {
                    Console.Write("Precio actual de " + p.Descripcion + ": ");
                    p.Get(); // Metodo get que regresa el precio para la fecha actual.

                }
            }
            Console.WriteLine("");
            // De manera simple, obteniendo precio de un producto para la fecha ingresada.
            Console.WriteLine("Obteniendo precio de un producto para fecha ingresada.");
            decimal prec = Cpu.GetPrecio(fechaingresada);
            Console.WriteLine("Precio de cpu: " + prec);
            Console.WriteLine("");

            // Ingresando departamento.
            int numDep = 0;
            try
            {
            Console.Write("Ingresa departamento: ");
            numDep = Convert.ToInt32(Console.ReadLine());
            ProductoDB.GetDepartamento(numDep);
            }
            catch(FormatException fe)
            {
                Console.WriteLine("Solo puedes introducir números.");
            }
            catch(OverflowException oe)
            {
                Console.WriteLine("El número es demasiado grande.");
            }
            Console.WriteLine("");

            // Llamada a ordenar por likes ascendentemente.
            ProductoDB.OrdenacionPorLikes("productos.json");

           
        }   
    }
}
