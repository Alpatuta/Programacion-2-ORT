using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Sistema
    {
        private List<Categoria>_categorias = new List<Categoria>();
        private List<Empleado>_empleados = new List<Empleado>();
        private List<Cargo> _cargos = new List<Cargo>();
        //Primer punto de patron singleton 
        private static Sistema _instancia;

        //Segundo punto de patron singleton 
        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }

        public List<Categoria> Categorias
        {
            get { return _categorias; }
        }
        public List<Cargo> Cargos
        {
            get { return _cargos; }
        }
        public List<Empleado> Empleados
        {
            get { return _empleados; }
        }

        //Tercer punto de patron singleton 
        private Sistema()
        {
            PrecargarJornalero();
            PrecargarCargos();
            PrecargarCategorias();
        }
        private void PrecargarCargos()
        {
            AltaCargo(new Cargo("RRHH"));
        }
        private void PrecargarCategorias()
        {
            AltaCategoria(new Categoria(1,"Tecnología"));
            AltaCategoria(new Categoria(2, "Relaciones públicas"));

        }
        private void PrecargarJornalero()
        {
            AltaEmpleadoJornalero(new Jornalero("Liliana", "Pino", "12345678", TipoDocumento.Cedula, new DateTime(2023, 12, 12), new DateTime(2018, 05, 05), 1000));
            AltaEmpleadoMensual(new Mensual("Joaquin", "Sosa", "2345678", TipoDocumento.Cedula, new DateTime(2022, 08, 08), new DateTime(2022, 08, 08), 50000));
            
        }
        /// <summary>
        /// Permite agregar una nueva categoria a la lista de categorias
        /// </summary>
        /// <param name="categoria"></param>
        public void AltaCategoria(Categoria categoria)
        {
            categoria.Validar();
            if (!_categorias.Contains(categoria))
            {
                _categorias.Add(categoria);
            }
            else
            {
                throw new Exception("Ya existe una categoria con ese código");
            }
        }
        /// <summary>
        /// Permite devolver como cadena de texto los datos de cada categoria.
        /// Se utiliza desde Program
        /// </summary>
        /// <returns></returns>
        public string DatosCategorias()
        {
            string datosCategorias = "";
            foreach(Categoria categoria in _categorias)
            {
                datosCategorias += categoria + "\n";
            }
            return datosCategorias; 
        }
        /// <summary>
        /// Permite agregar un nuevo empleado mensual a lista de empleados 
        /// </summary>
        /// <param name="mensual"></param>
        public void AltaEmpleadoMensual(Mensual mensual)
        {
            mensual.Validar();
            if (!_empleados.Contains(mensual))
            {
                _empleados.Add(mensual);
            }
        }
        /// <summary>
        /// Permite agregar un empleado de tipo jornalero a la lista de empleados 
        /// </summary>
        /// <param name="jornalero"></param>
        public void AltaEmpleadoJornalero(Jornalero jornalero)
        {
            jornalero.Validar();
            if (!_empleados.Contains(jornalero))
            {
                _empleados.Add(jornalero);
            }
        }

        /// <summary>
        /// Permite agregar un cargo a la lista de cargos
        /// </summary>
        /// <param name="cargo"></param>
        /// <exception cref="Exception"></exception>
        public void AltaCargo(Cargo cargo)
        {
            cargo.Validar();
            if(!_cargos.Contains(cargo)){
                _cargos.Add(cargo);
            }
            else
            {
                throw new Exception("Ya existe un cargo con esa descripción");
            }
        }

        /// <summary>
        /// Permite agregar un cargo a una categoria
        /// Esto se hace dentro del metodo que permite agregar un cargo ya que existe una restriccion que 
        /// indica que los cargos tienen que tener obligatoriamente una categoria
        /// </summary>
        /// <param name="codCategoria"></param>
        /// <param name="cargo"></param>
        /// <exception cref="Exception"></exception>
        public void AsignarCargoACategoria(int codCategoria,Cargo cargo)
        {
            //Buscar la categoria que se corresponde a ese codigo
            //Si la encuentro , le voy a pedir a la categoria que agregue ese cargo 
            //a su lista
            Categoria categoriaBuscada = BuscarCategoria(codCategoria);
            if (categoriaBuscada != null)
            {
                Cargo cargoBuscado = BuscarCargo(cargo.Codigo);
                if (cargoBuscado != null)
                {
                    categoriaBuscada.AgregarCargo(cargoBuscado);
                }
                
            }
            else
            {
                throw new Exception("No existe la categorìa con ese código");
            }
        }
        /// <summary>
        /// Permite buscar una categoria dentro de la lista de categorias
        /// La busqueda se hace por codigo de categoria
        /// </summary>
        /// <param name="codCategoria"></param>
        /// <returns></returns>
        private Categoria BuscarCategoria(int codCategoria)
        {
            Categoria categoriaBuscada = null;
            int i = 0;
            while(i<_categorias.Count  && categoriaBuscada == null)
            {
                if (_categorias[i].Codigo == codCategoria)
                {
                    categoriaBuscada = _categorias[i];
                }
                i++;
            }
            return categoriaBuscada;
        }
        /// <summary>
        /// Permite obtener los cargos que pertenecen a la categoria de la cual se recibe el codigo por parametro
        /// </summary>
        /// <param name="codCategoria"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Cargo>CargosDeCategoria(int codCategoria)
        {
            Categoria categoriaBuscada = BuscarCategoria(codCategoria);

            if (categoriaBuscada != null)
            {
                return categoriaBuscada.Cargos;
            }
            else
            {
                throw new Exception("No existe una categoria con ese còdigo");
            }
        }
        /// <summary>
        /// Permite obtener los empleados cuya fecha de ingreso este comprendida en las fechas recibidas 
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>
        public List<Empleado>EmpleadosFiltradoFechaIngreso(DateTime fechaDesde,
            DateTime fechaHasta)
        {
            List<Empleado> empleadosFiltrados = new List<Empleado>();
            foreach(Empleado empleado in _empleados)
            {
                if(empleado.FechaIngreso<=fechaHasta && empleado.FechaIngreso >= fechaDesde)
                {
                    empleadosFiltrados.Add(empleado);
                }
            }
            return empleadosFiltrados;
        }
        /// <summary>
        /// Permite asignar un cargo a un empleado 
        /// </summary>
        /// <param name="codCargo"></param>
        /// <param name="documentoEmpleado"></param>
        /// <exception cref="Exception"></exception>
        public void AsignarCargoAEmpleado(int codCargo, string documentoEmpleado)
        {
            Cargo cargo = BuscarCargo(codCargo);
            if (cargo != null)
            {
                Empleado empleado = BuscarEmpleado(documentoEmpleado);
                if(empleado != null)
                {
                    empleado.AgregarCargo(cargo);
                }
                else
                {
                    throw new Exception("No existe empleado con ese documento");
                }
                
            }
            else
            {
                 throw new Exception("No existe cargo con el codigo recibido");
            }
           
        }
        /// <summary>
        /// Permite buscar un cargo dentro de la lista de cargos
        /// La busqueda se hace por codigo de cargo 
        /// </summary>
        /// <param name="codCargo"></param>
        /// <returns></returns>
        public Cargo BuscarCargo(int codCargo)
        {
            int i = 0;
            Cargo cargoBuscado = null;
            while (i<_cargos.Count && cargoBuscado == null)
            {
                if (_cargos[i].Codigo == codCargo)
                {
                    cargoBuscado = _cargos[i];
                }
                i++;
            }
            return cargoBuscado;
        }
        /// <summary>
        /// Permite buscar un empleado dentro de la lista de empleados
        /// Para la busqueda se usa el documento 
        /// </summary>
        /// <param name="documento"></param>
        /// <returns></returns>
        public Empleado BuscarEmpleado(string documento)
        {
            int i = 0;
            Empleado empleadoBuscado= null;
            while(i<_empleados.Count && empleadoBuscado == null)
            {
                if (_empleados[i].Documento.Trim().ToUpper() == documento.Trim().ToUpper())
                {
                    empleadoBuscado= _empleados[i];
                }
                i++;
            }
            return empleadoBuscado;
        }
        public List<Empleado>EmpleadosSueldoMayorAImporte(double importe, int mes)
        {
            List<Empleado> empleadosSueldosMayorImporte = new List<Empleado>();
            foreach(Empleado empleado in _empleados)
            {
                empleado.Mes = mes;
                if (empleado.CalcularSalario(mes) > importe)
                {
                    empleadosSueldosMayorImporte.Add(empleado);
                }
            }
            empleadosSueldosMayorImporte.Sort();
            return empleadosSueldosMayorImporte;
        }
    }
}
