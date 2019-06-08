using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace NancyRest
{
    public static class PostGresMan
    {
        public static NpgsqlConnection connection = new NpgsqlConnection();

        public static string connectionString = "Username=postgres@tabasserver1; Password=Holis1234; Host=tabasserver1.postgres.database.azure.com; Port=5432; Database=tabas";

        public static string regisTrab(string username, string password, string nombre, string appelido1, string apellido2, string cedula, string rol)
        {
            JObject response = new JObject();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string query = "select procRegistrarTrabajador(";

                query += "'" + username + "'" + ", " + "'" + password + "'" + ", " + "'" + nombre + "'" + ", " + "'" + appelido1 + "'" + ", " + "'" + apellido2 + "'" + ", " + cedula + ", " + rol + ")";


                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                   
                    Console.Write(dr[0]);
                    response["data"] = dr[0].ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail");
                Console.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }



            return response.ToString();
        }

        public static string regisMarca(string marca, string id)
        {
            JObject response = new JObject();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string query = "insert into Marcas(idMarca,marca) values(";

                query += id + ", " + "'" + marca + "'" + ")";


                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {

                    Console.Write(dr[0]);
                    response["data"] = dr[0].ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail");
                Console.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }



            return response.ToString();
        }


        public static string regisBC(string marca, string id, string modelo)
        {
            JObject response = new JObject();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string query = "insert into BagCarts(idBagCart,marca,modelo) values(";

                query += id + ", " + "'" + marca + "'" +  ", " + modelo + ")";


                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {

                    Console.Write(dr[0]);
                    response["data"] = dr[0].ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail");
                Console.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }



            return response.ToString();
        }

        public static string asigBC(string idvuelo, string idbagcart)
        {
            JObject response = new JObject();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string query = "select proc_asignarBagCartVuelo(";

                query += idvuelo + ", " + idbagcart + ")";


                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {

                    Console.Write(dr[0]);
                    response["data"] = dr[0].ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail");
                Console.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }



            return response.ToString();
        }

        public static string asigMalBC(string idMaleta, string username, string trabajadorRX, string estado, string comentario,  string idbagcart)
        {
            JObject response = new JObject();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string query = "select * from proc_asignarMaletaBagCart(";

                query += idMaleta + ", " + "'" + username + "'" + ", " + "'" + trabajadorRX + "'" + ", " + estado + ", " + "'" + comentario + "'" + ", " + idbagcart + ")";


                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {

                    Console.Write(dr[0]);
                    response["data"] = dr[0].ToString();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fail");
                Debug.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Debug.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Debug.WriteLine("Fallo Cerrar");
            }



            return response.ToString();
        }

        public static string getBCIdent()
        {

            JArray idents = new JArray();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                NpgsqlTransaction tran = connection.BeginTransaction();

                NpgsqlCommand command = new NpgsqlCommand("select idbagcart from bagcarts", connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    idents.Add(dr[0].ToString());
                    //Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6} \n", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                    //Console.Write("{0} \n", dr[0]);
                }

                //Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fail");
                Debug.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }

            JObject response = new JObject();
            response["data"] = idents;

            Debug.WriteLine(response.ToString());

            return response.ToString();
        }


        public static string getBC()
        {

            JArray idents = new JArray();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                NpgsqlTransaction tran = connection.BeginTransaction();

                NpgsqlCommand command = new NpgsqlCommand("select * from bagcarts where sello is null", connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    idents.Add(dr[0].ToString());
                    //Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6} \n", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                    //Console.Write("{0} \n", dr[0]);
                }

                //Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fail");
                Debug.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }

            JObject response = new JObject();
            response["data"] = idents;

            Debug.WriteLine(response.ToString());

            return response.ToString();
        }



        public static string getVuelos()
        {

            JObject vuelo;
            JArray vuelos = new JArray();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                NpgsqlTransaction tran = connection.BeginTransaction();

                NpgsqlCommand command = new NpgsqlCommand("select * from vuelos where bagcart is null", connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    vuelo = new JObject();
                    vuelo["id"] = dr[0].ToString();
                    vuelo["avion"] = dr[1].ToString();
                    vuelo["fecha"] = dr[2].ToString();
                    vuelo["abierto"] = dr[3].ToString();
                    vuelo["bagcart"] = dr[4].ToString();
                    vuelos.Add(vuelo);
                    //Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6} \n", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                    //Console.Write("{0} \n", dr[0]);
                }

                //Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fail");
                Debug.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }

            JObject response = new JObject();
            response["data"] = vuelos;

            Debug.WriteLine(response.ToString());

            return response.ToString();
        }

        public static string getVuelosBC()
        {

            JObject vuelo;
            JArray vuelos = new JArray();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                NpgsqlTransaction tran = connection.BeginTransaction();

                NpgsqlCommand command = new NpgsqlCommand("select * from vuelos where bagcart is not null", connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    vuelo = new JObject();
                    vuelo["id"] = dr[0].ToString();
                    vuelo["avion"] = dr[1].ToString();
                    vuelo["fecha"] = dr[2].ToString();
                    vuelo["abierto"] = dr[3].ToString();
                    vuelo["bagcart"] = dr[4].ToString();
                    vuelos.Add(vuelo);
                    //Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6} \n", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                    //Console.Write("{0} \n", dr[0]);
                }

                //Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fail");
                Debug.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }

            JObject response = new JObject();
            response["data"] = vuelos;

            Debug.WriteLine(response.ToString());

            return response.ToString();
        }

        public static string getMaxMarca()
        {

            JObject response = new JObject();
            

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                NpgsqlTransaction tran = connection.BeginTransaction();

                NpgsqlCommand command = new NpgsqlCommand("select max(idMarca) + 1  from marcas", connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    response["data"] = dr[0].ToString();
                    //Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6} \n", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                    //Console.Write("{0} \n", dr[0]);
                }

                //Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fail");
                Debug.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }

            Debug.WriteLine(response.ToString());

            return response.ToString();
        }

        public static string getMarcas()
        {

            JObject marca;
            JArray marcas = new JArray();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                NpgsqlTransaction tran = connection.BeginTransaction();

                NpgsqlCommand command = new NpgsqlCommand("select * from Marcas", connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    marca = new JObject();
                    marca["id"] = dr[0].ToString();
                    marca["marca"] = dr[1].ToString();
                    marcas.Add(marca);
                    //Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6} \n", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                    //Console.Write("{0} \n", dr[0]);
                }

                //Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fail");
                Debug.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }

            JObject response = new JObject();
            response["data"] = marcas;

            Debug.WriteLine(response.ToString());

            return response.ToString();
        }

        public static JObject getTrab(string username)
        {
            JObject jsonO = new JObject();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                NpgsqlTransaction tran = connection.BeginTransaction();
                NpgsqlCommand command = new NpgsqlCommand("select * from procGetTrabajador('" + username + "');", connection);
                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    jsonO["username"] = dr[0].ToString();
                    jsonO["pw"] = dr[1].ToString();
                    jsonO["nombre"] = dr[2].ToString();
                    jsonO["apellido1"] = dr[3].ToString();
                    jsonO["apellido2"] = dr[4].ToString();
                    jsonO["cedula"] = dr[5].ToString();
                    jsonO["rol"] = dr[6].ToString();

                }
            }
            catch (Exception ex)
            { Console.WriteLine("Fail"); Console.WriteLine(ex); }

            try
            { if (connection.State == System.Data.ConnectionState.Open) { connection.Close(); Console.WriteLine("Cerrada"); } }
            catch (Exception ex)
            { Console.WriteLine(ex); Console.WriteLine("Fallo al cerrar"); }

            Debug.WriteLine(jsonO.ToString());

            return jsonO;
        }

        public static string getUsernamesTrab()
        {
            JObject username;
            JArray usernames = new JArray();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                NpgsqlTransaction tran = connection.BeginTransaction();
                NpgsqlCommand command = new NpgsqlCommand("select username from Trabajadores", connection);
                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    
                    usernames.Add(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail");
                Console.WriteLine(ex);
            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo al cerrar");
            }

            JObject response = new JObject();
            response["data"] = usernames;

            Debug.WriteLine(response.ToString());

            return response.ToString();
        }

        public static bool existsTrab(string username)
        {
            bool response = false;
            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                NpgsqlTransaction tran = connection.BeginTransaction();
                NpgsqlCommand command = new NpgsqlCommand("select exists (select username from Trabajadores where username = '" + username + "');", connection);
                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Debug.WriteLine("dr[0].ToString(): " + dr[0].ToString());
                    if (dr[0].ToString().Equals("True"))
                    {
                        response = true;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Fail"); Console.WriteLine(ex); }
            try { if (connection.State == System.Data.ConnectionState.Open) { connection.Close(); Console.WriteLine("Cerrada"); } }
            catch (Exception ex) { Console.WriteLine(ex); Console.WriteLine("Fallo al cerrar"); }
            Debug.WriteLine(response.ToString());
            return response;
        }

        public static bool coincidePassword(string username, string password)
        {
            bool response = false;
            if (existsTrab(username))
            {
                try
                {

                    connection.ConnectionString = connectionString;
                    connection.Open();
                    NpgsqlTransaction tran = connection.BeginTransaction();
                    NpgsqlCommand command = new NpgsqlCommand("select * from procGetPasswordTrabajador('" + username + "');", connection);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString().Equals(password))
                        {
                            response = true;
                        }
                    }
                }
                catch (Exception ex)
                { Console.WriteLine("Fail"); Console.WriteLine(ex); }

                try
                { if (connection.State == System.Data.ConnectionState.Open) { connection.Close(); Console.WriteLine("Cerrada"); } }
                catch (Exception ex)
                { Console.WriteLine(ex); Console.WriteLine("Fallo al cerrar"); }

                Debug.WriteLine(response.ToString());

            }
            return response;
        }

        public static string getAllMaletas()
        {
            JObject jsonO;
            JArray jArray = new JArray();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                NpgsqlTransaction tran = connection.BeginTransaction();
                NpgsqlCommand command = new NpgsqlCommand("select * from maletas where idmaleta not in (select idmaleta from MaletasBagCarts)", connection);
                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    jsonO = new JObject();
                    jsonO["idMaleta"] = dr[0].ToString();
                    jsonO["username"] = dr[1].ToString();
                    jsonO["color"] = dr[2].ToString();
                    jsonO["peso"] = dr[3].ToString();
                    jsonO["costo"] = dr[4].ToString();

                    jArray.Add(jsonO);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail");
                Console.WriteLine(ex);
            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo al cerrar");
            }

            JObject response = new JObject();
            response["data"] = jArray;

            Debug.WriteLine(response.ToString());

            return response.ToString();
        }

        public static string getAllRoles()
        {
            JObject jsonO;
            JArray jArray = new JArray();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                NpgsqlTransaction tran = connection.BeginTransaction();
                NpgsqlCommand command = new NpgsqlCommand("select idRol,rol from Roles;", connection);
                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    jsonO = new JObject();
                    jsonO["idRol"] = dr[0].ToString();
                    jsonO["rol"] = dr[1].ToString();

                    jArray.Add(jsonO);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail");
                Console.WriteLine(ex);
            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo al cerrar");
            }

            JObject response = new JObject();
            response["data"] = jArray;

            Debug.WriteLine(response.ToString());

            return response.ToString();
        }


        public static string getIDMal()
        {

            JObject response = new JObject();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                NpgsqlTransaction tran = connection.BeginTransaction();

                NpgsqlCommand command = new NpgsqlCommand("select max(idMaleta) + 1  from maletas", connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    response["data"] = dr[0].ToString();
                    //Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6} \n", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                    //Console.Write("{0} \n", dr[0]);
                }

                //Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fail");
                Debug.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }


            Debug.WriteLine(response.ToString());

            return response.ToString();
        }

        public static string regisMal(string username, string idmaleta, string color, string peso, string costo)
        {
            JObject response = new JObject();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string query = "insert into Maletas(idMaleta, username, color, peso, costo) values(";

                query += idmaleta + ", " + "'" + username + "'" + ", " + "'" + color + "'" + ", "  + peso + ", " + costo + ")";



                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {

                    Console.Write(dr[0]);
                    response["data"] = dr[0].ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail");
                Console.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }



            return response.ToString();
        }

        public static string getMalfromBC(string idbagcart)
        {
            JObject response = new JObject();
            JObject maleta;
            JArray maletas = new JArray();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string query = "select * from MaletasBagCarts where bagcart = ";

                query += idbagcart + "and estado = 1";



                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    maleta = new JObject();
                    maleta["idMaleta"] = dr[0].ToString();
                    maleta["username"] = dr[1].ToString();
                    maleta["trabajadorrx"] = dr[2].ToString();
                    maleta["bagcart"] = dr[3].ToString();
                    maleta["estado"] = dr[4].ToString();
                    maleta["comentario"] = dr[5].ToString();

                    Console.Write(dr[0]);
                    maletas.Add(maleta);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail");
                Console.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }

            response["data"] = maletas;

            return response.ToString();
        }

        public static string asigMalAv(string idMaleta, string username, string avion, string bodega, string trabajadorSC)
        {
            JObject response = new JObject();


            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string query = "select proc_asignarMaletaAvion(";

                query += idMaleta + ", " + "'" + username + "'" + ", " + avion + ", " + bodega + ", " + "'" + trabajadorSC + "'" + ")";

                Debug.WriteLine(query);



                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    response["data"] = dr[0].ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail");
                Debug.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fallo Cerrar");
            }

            return response.ToString();
        }


        public static string getBod(string idavion)
        {
            JObject response = new JObject();
            JObject bodega;
            JArray bodegas = new JArray();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string query = "select * from bodegas where avion = ";

                query += idavion;



                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    bodega = new JObject();
                    bodega["idbodega"] = dr[1].ToString();
                    bodega["capacidad"] = dr[2].ToString();

                    Console.Write(dr[0]);
                    bodegas.Add(bodega);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fail");
                Debug.WriteLine(ex);

            }
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Debug.WriteLine("Cerrada");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Debug.WriteLine("Fallo Cerrar");
            }

            response["data"] = bodegas;

            return response.ToString();
        }
    }
}