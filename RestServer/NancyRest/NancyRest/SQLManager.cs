using System;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace NancyRest
{
    public class SQLManager
    {
        private static string connectionString = "Data Source=LOOP-DESKTOP-8F;Initial Catalog=TECAirlines;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static JObject getVueloConEscalas(string idVuelo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select id,aeropuertoIni as iataSal,nombre as sal,aeropuertoFin as iataDes,(select nombre from Aeropuertos where codigoIATA = aeropuertoFin) as des, fecha from Vuelos join Aeropuertos on Vuelos.aeropuertoIni = Aeropuertos.codigoIATA where abierto = 1 and id = " + idVuelo;
            SqlCommand command;
            SqlDataReader sqlReader;

            string res = null;
            JObject vuelo = new JObject();
            JObject escala;
            JArray escalas = new JArray();

            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        vuelo["id"] = sqlReader["id"].ToString();
                        vuelo["iataSal"] = sqlReader["iataSal"].ToString();
                        vuelo["sal"] = sqlReader["sal"].ToString();
                        vuelo["iataDes"] = sqlReader["iataDes"].ToString();
                        vuelo["des"] = sqlReader["des"].ToString();
                        vuelo["fecha"] = sqlReader["fecha"].ToString();
                    }
                    sqlReader.Close();
                    command.Dispose();


                    command = new SqlCommand("select Aeropuertos.codigoIATA, Aeropuertos.nombre from Vuelos join Escalas on Vuelos.id = Escalas.id_vuelo join Aeropuertos on Aeropuertos.codigoIATA = Escalas.codigoIATA where id = " + idVuelo, connection);
                    sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        escala = new JObject();
                        escala["iata"] = sqlReader["codigoIATA"].ToString();
                        escala["nombre"] = sqlReader["nombre"].ToString();
                        escalas.Add(escala);
                    }
                    sqlReader.Close();
                    command.Dispose();

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                connection.Close();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            vuelo["intermedio"] = escalas;
            return vuelo;
        }
        public static string getVuelosConEscalas()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;

            SqlConnection connection2 = new SqlConnection(connectionString);
            SqlCommand command2;
            SqlDataReader sqlReader2;

            string res = null;
            JArray ids = new JArray();
            JArray total = new JArray();
            JArray vuelo;
            JArray escalas;
            JObject json = new JObject();

            try
            {
                connection.Open();
                command = new SqlCommand("select id from Vuelos where abierto = 1", connection);
                sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        ids.Add(sqlReader["id"].ToString());
                    }
                    sqlReader.Close();
                    command.Dispose();


                    foreach (string id in ids)
                    {
                        //Console.WriteLine("ID: " + id);
                        command = new SqlCommand("select Vuelos.id as idVuelo, nombre as sal, aeropuertoIni as iataSal, aeropuertoFin as iataDes, (select nombre from Aeropuertos where codigoIATA = aeropuertoFin) as des, avion, fecha from Vuelos join Aeropuertos on Vuelos.aeropuertoIni = Aeropuertos.codigoIATA join Aviones on Aviones.id = Vuelos.avion where Vuelos.id = " + id, connection);
                        sqlReader = command.ExecuteReader();

                        vuelo = new JArray();
                        escalas = new JArray();
                        JObject aux = new JObject();

                        while (sqlReader.Read())
                        {
                            //Console.WriteLine("Vuelo: " + sqlReader["iataSal"]);
                            aux["id"] = sqlReader["idVuelo"].ToString();
                            aux["sal"] = sqlReader["sal"].ToString();
                            aux["iataSal"] = sqlReader["iataSal"].ToString();
                            aux["iataDes"] = sqlReader["iataDes"].ToString();
                            aux["des"] = sqlReader["des"].ToString();
                            aux["avion"] = sqlReader["avion"].ToString();
                            aux["fecha"] = sqlReader["fecha"].ToString();

                            //Console.WriteLine();

                            connection2.Open();
                            command2 = new SqlCommand("select Aeropuertos.codigoIATA, Aeropuertos.nombre from Vuelos join Escalas on Vuelos.id = Escalas.id_vuelo join Aeropuertos on Aeropuertos.codigoIATA = Escalas.codigoIATA where id = " + id, connection2);
                            sqlReader2 = command2.ExecuteReader();
                            JObject escala;
                            while (sqlReader2.Read())
                            {
                                //Console.WriteLine("Escala: " + sqlReader2["codigoIATA"]);
                                escala = new JObject();
                                escala["codigoIATA"] = sqlReader2["codigoIATA"].ToString();
                                escala["nombre"] = sqlReader2["nombre"].ToString();
                                escalas.Add(escala);
                            }
                            sqlReader2.Close();
                            command2.Dispose();
                            connection2.Close();
                            aux["intermedio"] = escalas;
                        }
                        sqlReader.Close();
                        command.Dispose();

                        total.Add(aux);
                    }
                    json["data"] = total;
                }
                catch (Exception ex2) { Console.WriteLine(ex2.Message); }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }
            res = JsonConvert.SerializeObject(json).ToString();
            return res;
        }
        public static string getUniversidades()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;

            string response = null;
            JArray universidades = new JArray();
            JObject json = new JObject();

            try
            {
                connection.Open();
                command = new SqlCommand("select nombre from Universidades", connection);
                sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        universidades.Add(sqlReader["nombre"].ToString());
                    }
                    sqlReader.Close();
                    command.Dispose();
                    json["data"] = universidades;
                }
                catch (Exception ex2) { Console.WriteLine(ex2.Message); }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine("Can not open connection ! "); }
            response = JsonConvert.SerializeObject(json).ToString();
            return response;
        }
        public static string getAviones()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select id,pesoMaximo,modelo from Aviones";
            SqlCommand command;
            SqlDataReader sqlReader;

            string response = string.Empty;
            JObject avion;
            JArray aviones = new JArray();
            JObject json = new JObject();
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        avion = new JObject();
                        avion["id"] = sqlReader["id"].ToString();
                        avion["pesoMaximo"] = sqlReader["pesoMaximo"].ToString();
                        avion["modelo"] = sqlReader["modelo"].ToString();
                        aviones.Add(avion);
                    }
                    sqlReader.Close();
                    command.Dispose();
                    json["data"] = aviones;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            response = JsonConvert.SerializeObject(json).ToString();
            return response;
        }
        public static string getAeropuertos()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select nombre,codigoIATA from Aeropuertos";
            SqlCommand command;
            SqlDataReader sqlReader;

            string response = null;
            JObject aeropuerto;
            JArray total = new JArray(); ;
            JObject json = new JObject(); ;
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        aeropuerto = new JObject();
                        aeropuerto["nombre"] = sqlReader["nombre"].ToString();
                        aeropuerto["iata"] = sqlReader["codigoIATA"].ToString();
                        total.Add(aeropuerto);
                    }
                    sqlReader.Close();
                    command.Dispose();
                    json["data"] = total;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            response = JsonConvert.SerializeObject(json).ToString();
            return response;
        }
        public static void sqlInjection(string injection)
        {
            SqlConnection connection = new SqlConnection("Data Source=LOOP-DESKTOP-8F;Initial Catalog=TECAirlines;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");//
            SqlCommand command;
            SqlDataReader sqlReader;
            try
            {
                connection.Open();
                command = new SqlCommand(injection, connection);
                sqlReader = command.ExecuteReader();

                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
        }
        public static string getVuelosEntreAB(string salida, string destino)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;

            SqlConnection connection2 = new SqlConnection(connectionString);
            SqlCommand command2;
            SqlDataReader sqlReader2;


            string res = null;
            JArray ids = new JArray();
            JArray total = new JArray();
            JArray vuelo;
            JArray escalas;
            JObject json = new JObject();
            try
            {
                connection.Open();
                command = new SqlCommand("select id from Vuelos where aeropuertoIni = '" + salida + "' and aeropuertoFin = '" + destino + "' and abierto = 1", connection);
                sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        ids.Add(sqlReader["id"].ToString());
                        //Console.WriteLine("IIDD: " + sqlReader["id"].ToString());
                    }
                    sqlReader.Close();
                    command.Dispose();


                    foreach (string id in ids)
                    {
                        //Console.WriteLine("ID: " + id);
                        command = new SqlCommand("select id, nombre as sal, aeropuertoIni as iataSal, aeropuertoFin as iataDes, (select nombre from Aeropuertos where codigoIATA = aeropuertoFin) as des from Vuelos join Aeropuertos on Vuelos.aeropuertoIni = Aeropuertos.codigoIATA where id = " + id, connection);
                        sqlReader = command.ExecuteReader();

                        vuelo = new JArray();
                        escalas = new JArray();
                        JObject aux = new JObject();

                        while (sqlReader.Read())
                        {
                            //Console.WriteLine("Vuelo: " + sqlReader["iataSal"]);
                            aux["id"] = sqlReader["id"].ToString();
                            aux["sal"] = sqlReader["sal"].ToString();
                            aux["iataSal"] = sqlReader["iataSal"].ToString();
                            aux["iataDes"] = sqlReader["iataDes"].ToString();
                            aux["des"] = sqlReader["des"].ToString();

                            //Console.WriteLine();

                            connection2.Open();
                            command2 = new SqlCommand("select Aeropuertos.codigoIATA, Aeropuertos.nombre from Vuelos join Escalas on Vuelos.id = Escalas.id_vuelo join Aeropuertos on Aeropuertos.codigoIATA = Escalas.codigoIATA where id = " + id, connection2);
                            sqlReader2 = command2.ExecuteReader();
                            JObject escala;
                            while (sqlReader2.Read())
                            {
                                //Console.WriteLine("Escala: " + sqlReader2["codigoIATA"]);
                                escala = new JObject();
                                escala["codigoIATA"] = sqlReader2["codigoIATA"].ToString();
                                escala["nombre"] = sqlReader2["nombre"].ToString();
                                escalas.Add(escala);
                            }
                            sqlReader2.Close();
                            command2.Dispose();
                            connection2.Close();
                            aux["intermedio"] = escalas;
                        }
                        sqlReader.Close();
                        command.Dispose();

                        total.Add(aux);
                    }
                    json["data"] = total;
                }
                catch (Exception ex2) { Console.WriteLine(ex2.Message); }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }
            res = JsonConvert.SerializeObject(json).ToString();
            return res;
        }
        public static bool existeUsuario(string userName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;
            bool response = false;
            try
            {
                connection.Open();
                command = new SqlCommand("IF EXISTS(SELECT* FROM Usuarios WHERE userName = '" + userName + "') BEGIN SELECT 1 as existe END ELSE BEGIN SELECT 0 as existe END", connection);
                sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        //Console.WriteLine("sqlReader[existe].ToString(): " + sqlReader["existe"].ToString());
                        if (sqlReader["existe"].ToString().Equals("1"))
                        {
                            response = true;
                        }
                    }
                }
                catch (Exception ex2) { Console.WriteLine(ex2.Message); }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine("Can not open connection ! "); }
            return response;
        }
        public static bool vueloAbierto(string id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;
            bool response = false;
            try
            {
                connection.Open();
                command = new SqlCommand("SELECT abierto FROM Vuelos WHERE id = " + id, connection);
                sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        if (sqlReader["abierto"].ToString().Equals("True"))
                        {
                            response = true;
                        }
                    }
                }
                catch (Exception ex2) { Console.WriteLine(ex2.Message); }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine("Can not open connection ! "); }
            Console.WriteLine("response: " + response);
            return response;
        }
        public static bool cerrarVuelo(string id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;
            bool response = false;
            try
            {
                connection.Open();
                command = new SqlCommand("update Vuelos set abierto = 0 where id = " + id, connection);
                sqlReader = command.ExecuteReader();

                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine("Can not open connection ! "); }
            return response;
        }
        public static JObject getUsuario(string userName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;
            string response = null;
            JObject json = new JObject();
            try
            {
                connection.Open();
                command = new SqlCommand("exec getUser @userName = '" + userName + "'", connection);
                sqlReader = command.ExecuteReader();

                while (sqlReader.Read())
                {
                    json["username"] = sqlReader["userName"].ToString();
                    json["password"] = sqlReader["password"].ToString();
                    json["nombre"] = sqlReader["nombre"].ToString();
                    json["apellido1"] = sqlReader["apellido1"].ToString();
                    json["apellido2"] = sqlReader["apellido2"].ToString();
                    json["telefono"] = sqlReader["telefono"].ToString();
                    json["correo"] = sqlReader["correo"].ToString();
                    json["nombreTitular"] = sqlReader["nombreTitular"].ToString();
                    json["tarjeta"] = sqlReader["tarjeta"].ToString();
                    json["fechaExp"] = sqlReader["fechaExp"].ToString();
                }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            //response = JsonConvert.SerializeObject(json).ToString();
            //return response;
            return json;
        }
        public static bool logUser(string userName, string password)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;
            bool response = false;
            try
            {
                connection.Open();
                if (existeUsuario(userName))
                {
                    command = new SqlCommand("exec getUser @userName = '" + userName + "'", connection);
                    sqlReader = command.ExecuteReader();
                    try
                    {
                        while (sqlReader.Read())
                        {
                            if (password.Equals(sqlReader["password"].ToString()))
                            {
                                response = true;
                            }
                        }
                    }
                    catch (Exception ex2) { Console.WriteLine(ex2.Message); }
                    sqlReader.Close();
                    command.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine("Can not open connection ! "); }
            return response;
        }
        public static bool actualizarDatosTarjeta(string username, string nombreTitular, string tarjeta, string fechaExp)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "exec actualizarDatosTarjeta @userName = '" + username + "', @nombreTitular = '" + nombreTitular + "', @tarjeta = '" + tarjeta + "', @fechaExp = '" + fechaExp + "'";
            SqlCommand command;
            SqlDataReader sqlReader;
            bool ok = false;

            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                sqlReader = command.ExecuteReader();

                sqlReader.Close();
                command.Dispose();
                connection.Close();
                ok = true;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            return ok;
        }
        public static bool insertReservacion(string username, string idVuelo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;
            bool ok = false;
            try
            {
                sqlInjection("exec crearReservacion @userName = '" + username + "', @idVuelo = " + idVuelo);
                connection.Open();
                command = new SqlCommand("select count(*) as exist from Reservaciones where usuario = '" + username + "' and idVuelo = " + idVuelo, connection);
                sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        if (sqlReader["exist"].ToString().Equals("1"))
                        {
                            ok = true;
                        }
                    }
                }
                catch (Exception ex2) { Console.WriteLine(ex2.Message); }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            return ok;
        }
        public static bool insertVuelo(string precio, string avion, string aeropuertoIni, string aeropuertoFin, string fecha, JArray escalas)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;
            bool ok = false;
            try
            {
                sqlInjection("insert into Vuelos(precio,avion,aeropuertoIni,aeropuertoFin,fecha) values(" + precio + "," + avion + ",'" + aeropuertoIni + "','" + aeropuertoFin + "','" + fecha + "')");
                string id = "";
                /*
                 * Es buena idea usar identity en este caso?
                 * No hay manera de recibir el id del vuelo pq es automatico pero se necesita q el id del vuelo sea el mismo q el q se usa en la insercion de las escalas,
                 * entonces tal vez con multiples conexiones a la vez no se consiga el mismo id del vuelo q se insertó.
                */
                connection.Open();
                command = new SqlCommand("select max(id) as id from Vuelos", connection);
                sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        id = sqlReader["id"].ToString();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                sqlReader.Close();
                command.Dispose();
                command = new SqlCommand("select count(*) as exist from Vuelos where id = " + id, connection);
                sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        if (sqlReader["exist"].ToString().Equals("1"))
                        {
                            ok = true;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                sqlReader.Close();
                command.Dispose();
                try
                {
                    for (int i = 0; i < escalas.Count; i++)
                    {
                        sqlInjection("insert into Escalas(id_vuelo, codigoIATA) values(" + id + ", '" + escalas[i]["iata"].ToString() + "')");
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                connection.Close();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            return ok;
        }
        public static JArray getPasajeros(string idVuelo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;

            JObject pasajero;
            JArray pasajeros = new JArray();
            try
            {
                connection.Open();
                command = new SqlCommand("select userName, nombre, apellido1, apellido2, telefono, correo, peso from Vuelos join Reservaciones on id = idVuelo join Usuarios on userName = usuario where id = " + idVuelo, connection);
                sqlReader = command.ExecuteReader();

                while (sqlReader.Read())
                {
                    pasajero = new JObject();
                    pasajero["username"] = sqlReader["userName"].ToString();
                    pasajero["nombre"] = sqlReader["nombre"].ToString();
                    pasajero["apellido1"] = sqlReader["apellido1"].ToString();
                    pasajero["apellido2"] = sqlReader["apellido2"].ToString();
                    pasajero["telefono"] = sqlReader["telefono"].ToString();
                    pasajero["correo"] = sqlReader["correo"].ToString();
                    pasajero["peso"] = sqlReader["peso"].ToString();
                    pasajeros.Add(pasajero);
                }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            return pasajeros;
        }
        public static bool actualizarPeso(string username, string idVuelo, string peso)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;
            bool ok = true;
            try
            {
                connection.Open();
                command = new SqlCommand("exec actualizarPeso @userName = '" + username + "', @idVuelo = " + idVuelo + ", @peso = " + peso, connection);
                sqlReader = command.ExecuteReader();

                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (SqlException ex)
            {
                ok = false;
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            return ok;
        }
        public static JArray getAsientos(string idVuelo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;

            JArray asientos = new JArray();
            try
            {
                connection.Open();
                command = new SqlCommand("exec getAsientosOcupados @idVuelo = " + idVuelo, connection);
                sqlReader = command.ExecuteReader();

                while (sqlReader.Read())
                {
                    asientos.Add(sqlReader["asiento"].ToString());
                }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            return asientos;
        }
        public static int getCantidadDeAsientos(string idAvion)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;

            int cantidadDeAsientos = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("exec getCantidadAsientos @idAvion = " + idAvion, connection);
                sqlReader = command.ExecuteReader();

                while (sqlReader.Read())
                {
                    cantidadDeAsientos = Int32.Parse(sqlReader["cantidadAsientos"].ToString());
                }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            return cantidadDeAsientos;
        }
        public static bool ocuparAsiento(string username, string idVuelo, string asiento)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader sqlReader;
            bool ok = true;
            try
            {
                connection.Open();
                command = new SqlCommand("exec actualizarAsiento @userName = '" + username + "', @idVuelo = " + idVuelo + ", @asiento = '" + asiento + "'", connection);
                sqlReader = command.ExecuteReader();

                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (SqlException ex)
            {
                ok = false;
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            return ok;
        }
        public static JArray getPromos()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select id,vuelo,fechaIni,fechaFin,descuento,descripcion from Promociones";
            SqlCommand command;
            SqlDataReader sqlReader;

            string response = null;
            JObject promo;
            JArray promos = new JArray();
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        promo = new JObject();
                        promo["id"] = sqlReader["id"].ToString();
                        promo["vuelo"] = sqlReader["vuelo"].ToString();
                        promo["fechaIni"] = sqlReader["fechaIni"].ToString();
                        promo["fechaFin"] = sqlReader["fechaFin"].ToString();
                        promo["descuento"] = sqlReader["descuento"].ToString();
                        promo["descripcion"] = sqlReader["descripcion"].ToString();
                        promos.Add(promo);
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                sqlReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                Console.WriteLine("Codigo de error: " + err.Number);
                Console.WriteLine("Descripcion: " + err.Message);
            }
            return promos;
        }

    }
}