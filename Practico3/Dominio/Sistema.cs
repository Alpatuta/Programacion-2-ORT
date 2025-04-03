using Practico3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
  public class Sistema
  {
        private List<Deporte> _deportes = new List<Deporte>();
        private List<Socio> _socios = new List<Socio>();

        private bool ExisteDeporte(string nombre)
        {
            bool existe = false;

            int i = 0;

            while (i< _deportes.Count && !existe)
            {
                if (_deportes[i].Nombre.Trim().ToUpper() == nombre.Trim().ToUpper())
                {
                    existe = true;
                }
                i++;
            }
            return existe;
        }

        public void AgregarDeporte(Deporte deporte)
        {
            deporte.ValidarDatos();

            if (!ExisteDeporte(deporte.Nombre))
            {
                _deportes.Add(deporte);
            }else
            {
                throw new Exception("Ya existe el deporte con el mismo nombre");
            }

        }
        
        private bool ExisteSocio(string cedula)
        {
            bool existe = false;

            int i = 0;

            while(i < _socios.Count && !existe)
            {
                if (_socios[i].Cedula.Trim() == cedula.Trim())
                {
                    existe = true;
                }
                i++;
            }

            return existe;
        }

        public void AgregarSocio(Socio socio)
        {
            socio.ValidarDatosSocio();

            if (!ExisteSocio(socio.Cedula))
            {
                _socios.Add(socio);
            }
            else
            {
                throw new Exception("Ya existe el socio con esa misma cedula");
            }

        }



    }
}
