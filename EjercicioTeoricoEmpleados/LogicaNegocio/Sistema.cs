using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Sistema
    {
        private List<Categoria>_categorias = new List<Categoria>();
        private List<Empleado>_empleados = new List<Empleado>();

        public List<Categoria> Categorias
        {
            get { return _categorias; }
        }

        public void AltaCategoria(Categoria categoria)
        {
            categoria.Validar();
            if (!_categorias.Contains(categoria))
            {
                _categorias.Add(categoria);
            }
        }
        public string DatosCategorias()
        {
            string datosCategorias = "";
            foreach(Categoria categoria in _categorias)
            {
                datosCategorias += categoria + "\n";
            }
            return datosCategorias; 
        }

        public void AltaEmpleadoMensual(Mensual mensual)
        {
            mensual.Validar();
            if (!_empleados.Contains(mensual))
            {
                _empleados.Add(mensual);
            }
        }
        public void AltaEmpleadoJornalero(Jornalero jornalero)
        {
            jornalero.Validar();
            if (!_empleados.Contains(jornalero))
            {
                _empleados.Add(jornalero);
            }
        }

    }
}
