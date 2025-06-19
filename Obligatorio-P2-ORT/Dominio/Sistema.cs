using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Pasaje> _pasajes = new List<Pasaje>();
        private List<Vuelo> _vuelos = new List<Vuelo>();
        private List<Ruta> _rutas = new List<Ruta>();
        private List<Avion> _aviones = new List<Avion>();
        private List<Aeropuerto> _aeropuertos = new List<Aeropuerto>();

        public Sistema()
        {
            PrecargaGeneral();
        }
        // ALTAS DE OBJETOS
        public void AltaAviones(Avion avion)
        {
            avion.ValidarAvion();
            if (!_aviones.Contains(avion))
            {
                _aviones.Add(avion);
            }
        }

        public void AltaAeropuertos(Aeropuerto aeropuerto)
        {
            aeropuerto.ValidarAeropuerto();
            if (!_aeropuertos.Contains(aeropuerto))
            {
                _aeropuertos.Add(aeropuerto);
            }
            else
            {
                throw new Exception("Ya existe un aeropuerto con este codigo IATA");
            }
        }

        public void AltaRutas(Ruta ruta)
        {
            ruta.ValidarRuta();
            if (!_rutas.Contains(ruta))
            {
                _rutas.Add(ruta);
            }
            else
            {
                throw new Exception("Ya existe una ruta con ese id");
            }
        }

        public void AltaVuelos(Vuelo vuelo)
        {
            vuelo.ValidarVuelo();
            if (!_vuelos.Contains(vuelo))
            {
                _vuelos.Add(vuelo);
            }
            else
            {
                throw new Exception("Ya existe un vuelo con ese numero de vuelo");
            }
        }

        public void AltaPasajes(Pasaje pasaje)
        {
            pasaje.ValidarPasaje();
            if (!_pasajes.Contains(pasaje))
            {
                _pasajes.Add(pasaje);
            }
            else
            {
                throw new Exception("Ya existe un pasaje con ese Id");
            }
        }

        public void AltaUsuarioClientePremium(Premium premium)
        {
            premium.Validar();
            if (!_usuarios.Contains(premium))
            {
                _usuarios.Add(premium);
            }
            else
            {
                throw new Exception("Ya existe ese cliente premium");
            }
        }

        public void AltaUsuarioClienteOcasional(Ocasional ocasional)
        {
            ocasional.Validar();
            if (!_usuarios.Contains(ocasional))
            {
                _usuarios.Add(ocasional);
                
            }
            else
            {
                throw new Exception("Ya existe ese cliente ocasional");
            }
        }

        public void AltaUsuarioAdministrador(Administrador admin)
        {
            admin.ValidarAdmin();
            if (!_usuarios.Contains(admin))
            {
                _usuarios.Add(admin);
            }
            else
            {
                throw new Exception("Ya existe ese usuario administrador");
            }
        }

        // BUSQUEDAS DE OBJETOS
        public Aeropuerto BuscarAeropuerto(string codigoIata)
        {
            Aeropuerto aeropuerto = null;
            int i = 0;

            while (i < _aeropuertos.Count && aeropuerto == null)
            {
                if (_aeropuertos[i].CodigoIata == codigoIata)
                {
                    aeropuerto = _aeropuertos[i];
                }

                i++;
            }

            return aeropuerto;
        }

        public Avion BuscarAvion(int id) 
        { 
            Avion avion = null;
            int i = 0;

            while (i < _aviones.Count && avion == null)
            {
                if (_aviones[i].Id == id)
                {
                    avion = _aviones[i];
                }

                i++;
            }

            return avion;
        }

        public Ruta BuscarRuta(int idRuta)
        {
            Ruta ruta = null;
            int i = 0;

            while (i < _rutas.Count && ruta == null)
            {
                if (_rutas[i].IdRuta == idRuta)
                {
                    ruta = _rutas[i];
                }
                i++;
            }

            return ruta;
        }

        public Vuelo BuscarVuelo(string numVuelo)
        {
            Vuelo vuelo = null;
            int i = 0;

            while (i < _vuelos.Count && vuelo == null)
            {
                if ( _vuelos[i].NumeroVuelo == numVuelo)
                {
                    vuelo = _vuelos[i];
                }

                i++;
            }

            return vuelo;
        }

        public Usuario BuscarUsuario (string mail)
        {
            Usuario usuario = null;
            int i = 0;

            while (i < _usuarios.Count && usuario == null)
            {
                if (_usuarios[i].Mail == mail)
                {
                    usuario = _usuarios[i];
                }

                i++;
            }

            return usuario;
        }

        public Cliente BuscarCliente(string mail)
        {
            Cliente cliente = null;
            Usuario usuario = BuscarUsuario(mail);

            if (usuario != null && usuario is Cliente)
            {
                cliente = (Cliente)usuario;
            }

            return cliente;
        }

        // PRECARGAS

        public void PrecargaGeneral()
        {
            PrecargaUsuario();
            PrecargaAviones();
            PrecargaAeropuertos();
            PrecargaRutas();
            PrecargaVuelos();
            PrecargasPasajes();
        }
        private void PrecargaUsuario()
        {
            PrecargaUsuariosAdmin();
            PrecargaUsuarioClientePremium();
            PrecargaUsuarioClienteOcasional();
        }

        private void PrecargaUsuariosAdmin()
        {
            AltaUsuarioAdministrador(new Administrador("admin1@gmail.com", "1234", "admin1"));
            AltaUsuarioAdministrador(new Administrador("admin2@gmail.com", "1234", "admin2"));
        }

        private void PrecargaUsuarioClientePremium()
        {
            AltaUsuarioClientePremium(new Premium("premium1@gmail.com", "1234", "premium1", "12345678", "Uruguay"));
            AltaUsuarioClientePremium(new Premium("premium2@gmail.com", "1234", "premium2", "23456789", "España"));
            AltaUsuarioClientePremium(new Premium("premium3@gmail.com", "1234", "premium3", "34567890", "España"));
            AltaUsuarioClientePremium(new Premium("premium4@gmail.com", "1234", "premium4", "45678901", "Japon"));
            AltaUsuarioClientePremium(new Premium("premium5@gmail.com", "1234", "premium5", "56789012", "Uruguay"));
        }

        private void PrecargaUsuarioClienteOcasional()
        {
            AltaUsuarioClienteOcasional(new Ocasional("ocasional1@gmail.com", "1234", "ocasional1", "67890123", "Uruguay", true));
            AltaUsuarioClienteOcasional(new Ocasional("ocasional2@gmail.com", "1234", "ocasional2", "78901234", "Uruguay", false));
            AltaUsuarioClienteOcasional(new Ocasional("ocasional3@gmail.com", "1234", "ocasional3", "89012345", "Uruguay", true));
            AltaUsuarioClienteOcasional(new Ocasional("ocasional4@gmail.com", "1234", "ocasional4", "90123456", "Uruguay", false));
            AltaUsuarioClienteOcasional(new Ocasional("ocasional5@gmail.com", "1234", "ocasional5", "01234567", "Uruguay", false));
        }

        private void PrecargaAviones()
        {
            AltaAviones(new Avion("Boeing", "737MAX8", 178, 6570, 2600.50));
            AltaAviones(new Avion("Airbus", "A320neo", 180, 6300, 2500.75));
            AltaAviones(new Avion("Embraer", "E195-E2", 132, 4815, 2100.00));
            AltaAviones(new Avion("Bombardier", "CRJ900", 90, 2956, 1800.35));
        }

        private void PrecargaAeropuertos()
        {
            AltaAeropuertos(new Aeropuerto("JFK", "New York", 3500.00, 150.00));
            AltaAeropuertos(new Aeropuerto("LAX", "Los Angeles", 3400.00, 145.00));
            AltaAeropuertos(new Aeropuerto("LHR", "London", 4100.00, 180.00));
            AltaAeropuertos(new Aeropuerto("CDG", "Paris", 3900.00, 170.00));
            AltaAeropuertos(new Aeropuerto("FRA", "Frankfurt", 3700.00, 160.00));
            AltaAeropuertos(new Aeropuerto("NRT", "Tokyo", 4300.00, 190.00));
            AltaAeropuertos(new Aeropuerto("SYD", "Sydney", 3200.00, 140.00));
            AltaAeropuertos(new Aeropuerto("GRU", "São Paulo", 2800.00, 130.00));
            AltaAeropuertos(new Aeropuerto("EZE", "Buenos Aires", 2600.00, 120.00));
            AltaAeropuertos(new Aeropuerto("MEX", "Mexico City", 3000.00, 125.00));
            AltaAeropuertos(new Aeropuerto("MAD", "Madrid", 3300.00, 150.00));
            AltaAeropuertos(new Aeropuerto("FCO", "Rome", 3100.00, 145.00));
            AltaAeropuertos(new Aeropuerto("AMS", "Amsterdam", 3500.00, 160.00));
            AltaAeropuertos(new Aeropuerto("BCN", "Barcelona", 3200.00, 140.00));
            AltaAeropuertos(new Aeropuerto("YYZ", "Toronto", 3400.00, 155.00));
            AltaAeropuertos(new Aeropuerto("ATL", "Atlanta", 3600.00, 150.00));
            AltaAeropuertos(new Aeropuerto("DXB", "Dubai", 4500.00, 200.00));
            AltaAeropuertos(new Aeropuerto("SIN", "Singapore", 4300.00, 185.00));
            AltaAeropuertos(new Aeropuerto("SCL", "Santiago", 2700.00, 120.00));
            AltaAeropuertos(new Aeropuerto("MVD", "Montevideo", 2200.00, 110.00));
        }

        private void PrecargaRutas()
        {
            AltaRutas(new Ruta(BuscarAeropuerto("JFK"), BuscarAeropuerto("LAX"), 3983));
            AltaRutas(new Ruta(BuscarAeropuerto("JFK"), BuscarAeropuerto("MEX"), 3365));
            AltaRutas(new Ruta(BuscarAeropuerto("LAX"), BuscarAeropuerto("YYZ"), 3491));
            AltaRutas(new Ruta(BuscarAeropuerto("EZE"), BuscarAeropuerto("GRU"), 1673));
            AltaRutas(new Ruta(BuscarAeropuerto("EZE"), BuscarAeropuerto("SCL"), 1136));
            AltaRutas(new Ruta(BuscarAeropuerto("SCL"), BuscarAeropuerto("GRU"), 2621));
            AltaRutas(new Ruta(BuscarAeropuerto("MVD"), BuscarAeropuerto("GRU"), 1585));
            AltaRutas(new Ruta(BuscarAeropuerto("MVD"), BuscarAeropuerto("EZE"), 228));
            AltaRutas(new Ruta(BuscarAeropuerto("MVD"), BuscarAeropuerto("SCL"), 1370));
            AltaRutas(new Ruta(BuscarAeropuerto("MAD"), BuscarAeropuerto("CDG"), 1053));
            AltaRutas(new Ruta(BuscarAeropuerto("FCO"), BuscarAeropuerto("CDG"), 1105));
            AltaRutas(new Ruta(BuscarAeropuerto("FCO"), BuscarAeropuerto("MAD"), 1364));
            AltaRutas(new Ruta(BuscarAeropuerto("BCN"), BuscarAeropuerto("FRA"), 1136));
            AltaRutas(new Ruta(BuscarAeropuerto("AMS"), BuscarAeropuerto("CDG"), 430));
            AltaRutas(new Ruta(BuscarAeropuerto("AMS"), BuscarAeropuerto("LHR"), 370));
            AltaRutas(new Ruta(BuscarAeropuerto("LHR"), BuscarAeropuerto("FRA"), 656));
            AltaRutas(new Ruta(BuscarAeropuerto("LHR"), BuscarAeropuerto("MAD"), 1264));
            AltaRutas(new Ruta(BuscarAeropuerto("CDG"), BuscarAeropuerto("MEX"), 5680));
            AltaRutas(new Ruta(BuscarAeropuerto("GRU"), BuscarAeropuerto("MEX"), 738));
            AltaRutas(new Ruta(BuscarAeropuerto("MEX"), BuscarAeropuerto("ATL"), 2147));
            AltaRutas(new Ruta(BuscarAeropuerto("ATL"), BuscarAeropuerto("JFK"), 1221));
            AltaRutas(new Ruta(BuscarAeropuerto("ATL"), BuscarAeropuerto("YYZ"), 1203));
            AltaRutas(new Ruta(BuscarAeropuerto("YYZ"), BuscarAeropuerto("LHR"), 5700));
            AltaRutas(new Ruta(BuscarAeropuerto("CDG"), BuscarAeropuerto("FRA"), 478));
            AltaRutas(new Ruta(BuscarAeropuerto("SIN"), BuscarAeropuerto("NRT"), 5320));
            AltaRutas(new Ruta(BuscarAeropuerto("DXB"), BuscarAeropuerto("FCO"), 4342));
            AltaRutas(new Ruta(BuscarAeropuerto("DXB"), BuscarAeropuerto("AMS"), 5160));
            AltaRutas(new Ruta(BuscarAeropuerto("JFK"), BuscarAeropuerto("YYZ"), 574));
            AltaRutas(new Ruta(BuscarAeropuerto("SYD"), BuscarAeropuerto("SIN"), 6300));
            AltaRutas(new Ruta(BuscarAeropuerto("MEX"), BuscarAeropuerto("EZE"), 738)); 
            AltaRutas(new Ruta(BuscarAeropuerto("GRU"), BuscarAeropuerto("MAD"), 5220));

        }

        private void PrecargaVuelos()
        {
            AltaVuelos(new Vuelo("AA1001", Frecuencia.Lunes, BuscarRuta(0), BuscarAvion(0)));
            AltaVuelos(new Vuelo("AM2342", Frecuencia.Martes, BuscarRuta(1), BuscarAvion(1)));
            AltaVuelos(new Vuelo("AC9982", Frecuencia.Miércoles, BuscarRuta(2), BuscarAvion(2)));
            AltaVuelos(new Vuelo("AR7821", Frecuencia.Jueves, BuscarRuta(3), BuscarAvion(3)));
            AltaVuelos(new Vuelo("LA1023", Frecuencia.Viernes, BuscarRuta(4), BuscarAvion(0)));
            AltaVuelos(new Vuelo("LA1234", Frecuencia.Sábado, BuscarRuta(5), BuscarAvion(1)));
            AltaVuelos(new Vuelo("G36012", Frecuencia.Domingo, BuscarRuta(6), BuscarAvion(2)));
            AltaVuelos(new Vuelo("UY5678", Frecuencia.Lunes, BuscarRuta(7), BuscarAvion(3)));
            AltaVuelos(new Vuelo("UY3421", Frecuencia.Martes, BuscarRuta(8), BuscarAvion(0)));
            AltaVuelos(new Vuelo("IB3000", Frecuencia.Miércoles, BuscarRuta(9), BuscarAvion(1)));
            AltaVuelos(new Vuelo("AF1024", Frecuencia.Jueves, BuscarRuta(10), BuscarAvion(2)));
            AltaVuelos(new Vuelo("AZ4500", Frecuencia.Viernes, BuscarRuta(11), BuscarAvion(3)));
            AltaVuelos(new Vuelo("IB3210", Frecuencia.Sábado, BuscarRuta(12), BuscarAvion(0)));
            AltaVuelos(new Vuelo("KL2100", Frecuencia.Domingo, BuscarRuta(13), BuscarAvion(1)));
            AltaVuelos(new Vuelo("KL2190", Frecuencia.Lunes, BuscarRuta(14), BuscarAvion(2)));
            AltaVuelos(new Vuelo("BA1102", Frecuencia.Martes, BuscarRuta(15), BuscarAvion(3)));
            AltaVuelos(new Vuelo("BA1203", Frecuencia.Miércoles, BuscarRuta(16), BuscarAvion(0)));
            AltaVuelos(new Vuelo("AF4530", Frecuencia.Jueves, BuscarRuta(17), BuscarAvion(1)));
            AltaVuelos(new Vuelo("LA2201", Frecuencia.Viernes, BuscarRuta(18), BuscarAvion(2)));
            AltaVuelos(new Vuelo("AM9999", Frecuencia.Sábado, BuscarRuta(19), BuscarAvion(3)));
            AltaVuelos(new Vuelo("DL5670", Frecuencia.Domingo, BuscarRuta(20), BuscarAvion(0)));
            AltaVuelos(new Vuelo("DL9087", Frecuencia.Lunes, BuscarRuta(21), BuscarAvion(1)));
            AltaVuelos(new Vuelo("AC3388", Frecuencia.Martes, BuscarRuta(22), BuscarAvion(1)));
            AltaVuelos(new Vuelo("LH6742", Frecuencia.Miércoles, BuscarRuta(23), BuscarAvion(3)));
            AltaVuelos(new Vuelo("SQ9001", Frecuencia.Jueves, BuscarRuta(24), BuscarAvion(0)));
            AltaVuelos(new Vuelo("EK3021", Frecuencia.Viernes, BuscarRuta(25), BuscarAvion(1)));
            AltaVuelos(new Vuelo("EK5000", Frecuencia.Sábado, BuscarRuta(26), BuscarAvion(0)));
            AltaVuelos(new Vuelo("AA4321", Frecuencia.Domingo, BuscarRuta(27), BuscarAvion(3)));
            AltaVuelos(new Vuelo("QF9988", Frecuencia.Lunes, BuscarRuta(28), BuscarAvion(0)));
            AltaVuelos(new Vuelo("AM8800", Frecuencia.Martes, BuscarRuta(29), BuscarAvion(1)));

        }

        private void PrecargasPasajes()
        {
            AltaPasajes(new Pasaje(BuscarVuelo("AA1001"), new DateTime(2025, 05, 12), BuscarCliente("premium1@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("AM2342"), new DateTime(2025, 05, 13), BuscarCliente("premium2@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("AC9982"), new DateTime(2025, 05, 14), BuscarCliente("premium3@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("AR7821"), new DateTime(2025, 05, 15), BuscarCliente("premium4@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("LA1023"), new DateTime(2025, 05, 16), BuscarCliente("premium5@gmail.com"), Equipaje.Cabina));

            AltaPasajes(new Pasaje(BuscarVuelo("LA1234"), new DateTime(2025, 05, 17), BuscarCliente("ocasional1@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("G36012"), new DateTime(2025, 05, 18), BuscarCliente("ocasional2@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("UY5678"), new DateTime(2025, 05, 19), BuscarCliente("ocasional3@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("UY3421"), new DateTime(2025, 05, 20), BuscarCliente("ocasional4@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("IB3000"), new DateTime(2025, 05, 21), BuscarCliente("ocasional5@gmail.com"), Equipaje.Light));

            AltaPasajes(new Pasaje(BuscarVuelo("AF1024"), new DateTime(2025, 05, 22), BuscarCliente("premium1@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("AZ4500"), new DateTime(2025, 05, 23), BuscarCliente("premium2@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("IB3210"), new DateTime(2025, 05, 24), BuscarCliente("premium3@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("KL2100"), new DateTime(2025, 05, 25), BuscarCliente("premium4@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("KL2190"), new DateTime(2025, 05, 26), BuscarCliente("premium5@gmail.com"), Equipaje.Bodega));

            AltaPasajes(new Pasaje(BuscarVuelo("BA1102"), new DateTime(2025, 05, 27), BuscarCliente("ocasional1@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("BA1203"), new DateTime(2025, 05, 28), BuscarCliente("ocasional2@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("AF4530"), new DateTime(2025, 05, 29), BuscarCliente("ocasional3@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("LA2201"), new DateTime(2025, 05, 30), BuscarCliente("ocasional4@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("AM9999"), new DateTime(2025, 05, 31), BuscarCliente("ocasional5@gmail.com"), Equipaje.Cabina));

            AltaPasajes(new Pasaje(BuscarVuelo("DL5670"), new DateTime(2025, 06, 1), BuscarCliente("premium1@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("DL9087"), new DateTime(2025, 06, 2), BuscarCliente("premium2@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("AC3388"), new DateTime(2025, 06, 3), BuscarCliente("premium3@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("LH6742"), new DateTime(2025, 06, 4), BuscarCliente("premium4@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("SQ9001"), new DateTime(2025, 06, 5), BuscarCliente("premium5@gmail.com"), Equipaje.Light));

            AltaPasajes(new Pasaje(BuscarVuelo("EK3021"), new DateTime(2025, 06, 6), BuscarCliente("ocasional1@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("EK5000"), new DateTime(2025, 06, 7), BuscarCliente("ocasional2@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("AA4321"), new DateTime(2025, 06, 8), BuscarCliente("ocasional3@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("QF9988"), new DateTime(2025, 06, 9), BuscarCliente("ocasional4@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("AM8800"), new DateTime(2025, 06, 10), BuscarCliente("ocasional5@gmail.com"), Equipaje.Bodega));

        }


        //Mostrar clientes
        public string ClientesString()
        {
            string datosCliente = "";

            foreach(Usuario usu in _usuarios)
            {
                if(usu is Cliente)
                {
                    datosCliente += usu.ToString();
                }
            }

            return datosCliente;
        }

        //Mostrar vuelos determinados
        public string ListadoVuelosIATA(string codigo)
        {
            string vuelosIATA = "";

            if(codigo.Length == 3 && BuscarAeropuerto(codigo) != null)
            {
                foreach (Vuelo vuelo in _vuelos)
                {
                    if (vuelo.PerteneceRuta(codigo))
                    {
                        vuelosIATA += vuelo.ToString();
                    }
                }
            }
            else
            {
                throw new Exception("Codigo IATA invalido");
            }

            return vuelosIATA;
        }

        public bool LaPrimeraFechaEsMayor(DateTime fechaUno, DateTime fechaDos)
        {
            bool esMayor = false;
            if (fechaUno > fechaDos)
            {
                esMayor = true;
            }
            return esMayor;
        }

        public string PasajesEntreFechas(DateTime fechaUno, DateTime fechaDos)
        {
            string datosPasajes = "";

            foreach (Pasaje pasaje in _pasajes)
            {
                if (!LaPrimeraFechaEsMayor(fechaUno, fechaDos))
                {
                    if (pasaje.Fecha >= fechaUno && pasaje.Fecha <= fechaDos)
                    {
                        datosPasajes += pasaje.ToString();
                    }
                }
                else
                {
                    if (pasaje.Fecha <= fechaUno && pasaje.Fecha >= fechaDos)
                    {
                        datosPasajes += pasaje.ToString();
                    }
                }   
            }
            return datosPasajes;
        }
    }
}


