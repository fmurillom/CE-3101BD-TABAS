using Nancy;
using Nancy.Extensions;
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NancyRest
{
    public class Server : NancyModule
    {
        public Server() : base("/")
        {
            After.AddItemToEndOfPipeline((ctx) => ctx.Response
            .WithHeader("Access-Control-Allow-Origin", "*")
            .WithHeader("Access-Control-Allow-Methods", "GET, POST")
            .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type"));

            


            Get("/marcas", _ => {
                string response = PostGresMan.getMarcas();
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Get("/Maxmarcas", _ => {
                string response = PostGresMan.getMaxMarca();
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Get("/getVuelos", _ => {
                string response = PostGresMan.getVuelos();
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });
            Get("/getVuelosBC", _ => {
                string response = PostGresMan.getVuelosBC();
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Get("/getBCIdents", _ => {
                string response = PostGresMan.getBCIdent();
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Get("/getBC", _ => {
                string response = PostGresMan.getBC();
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Get("/", _ => {
                return "Za Warudo from Server!";
            });

            //Get["/"] = _ => "Za Warudo from Server!";


            Post("/buscV",  x =>
            {
                Console.WriteLine("post: /buscV");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string salida = data["salida"].ToString();
                string destino = data["destino"].ToString();

                string response = SQLManager.getVuelosEntreAB(salida, destino);
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Post("/getMalBCid", x =>
            {
                Console.WriteLine("post: /buscV");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string idbagcart = data["idbagcart"].ToString();

                string response = PostGresMan.getMalfromBC(idbagcart);
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Post("/regisTrab", x =>
            {
                Console.WriteLine("post: /registrab");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string username = data["username"].ToString(); 
                string password = data["password"].ToString(); 
                string nombre = data["nombre"].ToString(); 
                string appelido1 = data["apellido1"].ToString(); 
                string apellido2 = data["apellido2"].ToString(); 
                string cedula = data["cedula"].ToString(); 
                string rol = data["rol"].ToString();


                string response = PostGresMan.regisTrab(username, password, nombre, appelido1, apellido2, cedula, rol);
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Post("/asigMBC", x =>
            {
                Console.WriteLine("post: /registrab");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string idMaleta = data["idMaleta"].ToString();
                string username = data["username"].ToString();
                string trabajadorRX = data["trabajadorRX"].ToString();
                string estado = data["estado"].ToString();
                string comentario = data["comentario"].ToString();
                string idbagcart = data["idbagcart"].ToString();


                string response = PostGresMan.asigMalBC(idMaleta, username, trabajadorRX, estado, comentario, idbagcart);
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Post("/regisMarca", x =>
            {
                Console.WriteLine("post: /regisMarca");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string marca = data["marca"].ToString();
                string id = data["id"].ToString();




                string response = PostGresMan.regisMarca(marca, id);
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Post("/getBod", x =>
            {
                Console.WriteLine("post: /regisMarca");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string idavion = data["idavion"].ToString();

                string response = PostGresMan.getBod(idavion);
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Post("/asigMalAV", x =>
            {
                Console.WriteLine("post: /regisMarca");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string idMaleta = data["idMaleta"].ToString();
                string username = data["username"].ToString();
                string avion = data["avion"].ToString();
                string idbod = data["idbod"].ToString();
                string trabajadorSC = data["trabajadorSC"].ToString();

                string response = PostGresMan.asigMalAv(idMaleta, username, avion, idbod, trabajadorSC);
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Get("/getUsernames", _ =>
            {
                string response = PostGresMan.getUsernamesTrab();
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Get("/getmalid", _ =>
            {
                string response = PostGresMan.getIDMal();
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Get("/getAllMaletas", _ =>
            {
                string response = PostGresMan.getAllMaletas();
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Post("/loginTrab", x =>
            {
                Console.WriteLine("post: /loginTrab");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                JObject jsonResponse = new JObject();
                jsonResponse["data"] = "Respuesta Default";

                string username = data["username"].ToString();
                string password = data["password"].ToString();

                if (PostGresMan.existsTrab(username))
                {
                    if (PostGresMan.coincidePassword(username, password))
                    {
                        jsonResponse["data"] = PostGresMan.getTrab(username);
                        Console.WriteLine(username + " Logueado");
                    }
                    else
                    {
                        jsonResponse["data"] = "0";
                    }
                }
                else
                {
                    jsonResponse["data"] = "-1";
                }

                Console.WriteLine("Response:\n" + jsonResponse.ToString());
                var jsonBytes = Encoding.UTF8.GetBytes(jsonResponse.ToString());
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Get("/getRoles", _ =>
            {
                string response = PostGresMan.getAllRoles();
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Post("/asigbc", x =>
            {
                Console.WriteLine("post: /regisMarca");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string idvuelo = data["idvuelo"].ToString();
                string idbagcart = data["idbagcart"].ToString();




                string response = PostGresMan.asigBC(idvuelo, idbagcart);
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Post("/cmaleta", x =>
            {
                Console.WriteLine("post: /regisMarca");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string username = data["usrname"].ToString();
                string color = data["color"].ToString();
                string idmaleta = data["idmaleta"].ToString();
                string peso = data["peso"].ToString();
                string costo = data["costo"].ToString();




                string response = PostGresMan.regisMal(username, idmaleta, color, peso, costo);
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Post("/regisBC", x =>
            {
                Console.WriteLine("post: /regisBC");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string marca = data["marca"].ToString();
                string id = data["id"].ToString();
                string modelo = data["modelo"].ToString();



                string response = PostGresMan.regisBC(marca, id, modelo);
                Console.WriteLine("Response:\n" + response);

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Post("/regiU", x =>
            {
                Console.WriteLine("post: /regiU");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string userName = data["username"].ToString();
                string password = data["password"].ToString();
                string nombre = data["nombre"].ToString();
                string A1 = data["apellido1"].ToString();
                string A2 = data["apellido2"].ToString();
                string telefono = data["telefono"].ToString();
                string correo = data["correo"].ToString();

                JObject jsonResponse = new JObject();
                jsonResponse["data"] = "Respuesta Default";

                string response = null;

                if (SQLManager.existeUsuario(userName))
                {
                    jsonResponse["data"] = "Ya existia";
                }
                else
                {
                    string query = "EXEC RegistrarUsuario @userName = '" + userName + "',@password = '" + password + "',@nombre = '" + nombre + "',@apellido1 = '" + A1 + "',@apellido2 = '" + A2 + "',@telefono = '" + telefono + "',@correo = '" + correo + "',@nombreTitular = null,@tarjeta = null,@fechaExp = null";
                    SQLManager.sqlInjection(query);
                    if (SQLManager.existeUsuario(userName))
                    {
                        jsonResponse["data"] = "success";
                    }
                    else
                    {
                        jsonResponse["data"] = "failure";
                    }
                }

                response = jsonResponse.ToString();
                Console.WriteLine("Response:\n" + response);
                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Post("/login", x =>
            {
                Console.WriteLine("post: /login");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string userName = data["username"].ToString();
                string password = data["password"].ToString();

                JObject jsonResponse = new JObject();
                jsonResponse["data"] = "Respuesta Default";

                if (SQLManager.existeUsuario(userName))
                {
                    if (SQLManager.logUser(userName, password))
                    {
                        jsonResponse["data"] = SQLManager.getUsuario(userName);
                        Console.WriteLine(userName + " Logueado");
                    }
                    else
                    {
                        jsonResponse["username"] = "0";
                    }
                }
                else
                {
                    jsonResponse["username"] = "-1";
                }
                Console.WriteLine("Response:\n" + jsonResponse.ToString());
                var jsonBytes = Encoding.UTF8.GetBytes(jsonResponse.ToString());
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Post("/asientosOcu", x =>
            {
                Console.WriteLine("post: /asientosOcu");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string id = data["id"].ToString();

                JObject jsonResponse = new JObject();
                jsonResponse["data"] = "Respuesta Default";

                jsonResponse["data"] = SQLManager.getAsientos(id);

                Console.WriteLine("Response:\n" + jsonResponse.ToString());
                var jsonBytes = Encoding.UTF8.GetBytes(jsonResponse.ToString());
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Post("/ocuparAsiento",  x =>
            {
                Console.WriteLine("post: /ocuparAsiento");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string idVuelo = data["idVuelo"].ToString();
                string username = data["username"].ToString();
                string asiento = data["asiento"].ToString();
                string correo = data["correo"].ToString();
                string laWeaDelCorreo = data["mensaje"].ToString();

                //ocuparAsiento

                JObject jsonResponse = new JObject();
                jsonResponse["data"] = "Respuesta Default";
                if (SQLManager.ocuparAsiento(username, idVuelo, asiento))
                {
                    jsonResponse["data"] = "Success";
                    CorreoManager.mandarCorreo(correo, laWeaDelCorreo);
                }
                else
                {
                    jsonResponse["data"] = "Failure";
                }


                Console.WriteLine("Response:\n" + jsonResponse.ToString());
                var jsonBytes = Encoding.UTF8.GetBytes(jsonResponse.ToString());
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });






            Post("/cantAsientos", x =>
            {
                Console.WriteLine("post: /cantAsientos");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string id = data["id"].ToString();

                JObject jsonResponse = new JObject();
                jsonResponse["data"] = "Respuesta Default";

                jsonResponse["data"] = SQLManager.getCantidadDeAsientos(id);

                Console.WriteLine("Response:\n" + jsonResponse.ToString());
                var jsonBytes = Encoding.UTF8.GetBytes(jsonResponse.ToString());
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });



            Post("/pasajerosV", x =>
            {
                Console.WriteLine("post: /pasajerosV");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string id = data["id"].ToString();

                JObject jsonResponse = new JObject();
                jsonResponse["data"] = "Respuesta Default";

                jsonResponse["data"] = SQLManager.getPasajeros(id);

                Console.WriteLine("Response:\n" + jsonResponse.ToString());
                var jsonBytes = Encoding.UTF8.GetBytes(jsonResponse.ToString());
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Post("/actualizarMALETA", x =>
            {
                Console.WriteLine("post: /actualizarMALETA");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string id = data["id"].ToString();
                string username = data["username"].ToString();
                string peso = data["peso"].ToString();

                JObject jsonResponse = new JObject();

                if (SQLManager.actualizarPeso(username, id, peso))
                {
                    jsonResponse["data"] = "Success";
                }
                else
                {
                    jsonResponse["data"] = "Demasiada maleta";
                }

                Console.WriteLine("Response:\n" + jsonResponse.ToString());
                var jsonBytes = Encoding.UTF8.GetBytes(jsonResponse.ToString());
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Post("/tarj", x =>
            {
                Console.WriteLine("post: /tarj");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request:\n" + data);

                string username = data["username"].ToString();
                string tarjeta = data["tarjeta"].ToString();
                string nombreTitular = data["nombreTitular"].ToString();
                string fechaExp = data["fechaExp"].ToString();

                JObject jsonResponse = new JObject();
                jsonResponse["data"] = "Respuesta Default";
                string response = null;

                if (SQLManager.existeUsuario(username))
                {
                    if (SQLManager.actualizarDatosTarjeta(username, nombreTitular, tarjeta, fechaExp))
                    {
                        jsonResponse["data"] = "Success";
                    }
                    else
                    {
                        jsonResponse["data"] = "Failure";
                    }
                }
                else
                {
                    Console.WriteLine("No existe el usuario: " + username);
                    jsonResponse["data"] = "No existe el usuario: " + username;
                }
                response = jsonResponse.ToString();
                Console.WriteLine("response:\n" + response);
                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Post("/getV", x =>
            {
                Console.WriteLine("post: /getV");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request: " + data);

                string id = data["id"].ToString();
                JObject jsonResponse = new JObject();
                jsonResponse["data"] = "Respuesta Default";

                jsonResponse["data"] = SQLManager.getVueloConEscalas(id);
                Console.WriteLine("Response:\n" + jsonResponse.ToString());

                var jsonBytes = Encoding.UTF8.GetBytes(jsonResponse.ToString());
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Post("/cerrarV", x =>
            {
                Console.WriteLine("post: /cerrarV");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                //Console.WriteLine("Request: " + data);

                string id = data["id"].ToString();
                JObject jsonResponse = new JObject();
                jsonResponse["data"] = "Respuesta Default";

                string response = null;

                if (SQLManager.vueloAbierto(id))
                {
                    SQLManager.cerrarVuelo(id);
                    if (!SQLManager.vueloAbierto(id))
                    {
                        jsonResponse["data"] = "success";
                    }
                    else
                    {
                        jsonResponse["data"] = "failure";
                    }
                }
                else
                {
                    jsonResponse["data"] = "Ya estaba cerrado";
                }

                response = jsonResponse.ToString();
                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

            Post("/reserV", x =>
            {
                Console.WriteLine("post: /reserV");
                string json = this.Request.Body.AsString();
                JObject data = JObject.Parse(json);
                Console.WriteLine("Request: " + data);

                string id = data["id"].ToString();
                string username = data["username"].ToString();

                JObject jsonResponse = new JObject();
                jsonResponse["data"] = "Respuesta Default";

                if (SQLManager.insertReservacion(username, id))
                {
                    jsonResponse["data"] = "Success";
                }
                else
                {
                    jsonResponse["data"] = "Failure";
                }

                Console.WriteLine("Response:\n" + jsonResponse.ToString());
                var jsonBytes = Encoding.UTF8.GetBytes(jsonResponse.ToString());
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Post("/crearV", x =>
            {
                Console.WriteLine("post: /crearV");
                string request = this.Request.Body.AsString();
                JObject json = JObject.Parse(request);
                Console.WriteLine("Request:\n" + json);

                string precio = json["precio"].ToString();
                string avion = json["avion"].ToString();
                string aeropuertoIni = json["aeropuertoIni"].ToString();
                string aeropuertoFin = json["aeropuertoFin"].ToString();
                string fecha = json["fecha"].ToString();
                JArray escalasJSON = (JArray)json["intermadios"];

                JObject jsonResponse = new JObject();
                jsonResponse["data"] = "Respuesta Default";

                if (SQLManager.insertVuelo(precio, avion, aeropuertoIni, aeropuertoFin, fecha, escalasJSON))
                {
                    Console.WriteLine("Vuelo insertado");
                    jsonResponse["data"] = "Success";
                }
                else
                {
                    jsonResponse["data"] = "Failure";
                }

                Console.WriteLine("Response:\n" + jsonResponse.ToString());
                var jsonBytes = Encoding.UTF8.GetBytes(jsonResponse.ToString());
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Get("/vuelosE", _ =>
            {
                Console.WriteLine("get: /vuelosE");
                string response = SQLManager.getVuelosConEscalas();
                Console.WriteLine("Response:\n" + response);
                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Get("/unis", _ =>
            {
                Console.WriteLine("get: /unis");
                string response = SQLManager.getUniversidades();
                Console.WriteLine("Response:\n" + response);
                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };

            });


            Get("/avios", _ =>
            {
                Console.WriteLine("get: /avios");
                string response = SQLManager.getAviones();
                Console.WriteLine("Response:\n" + response);
                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Get("/aeros", _ =>
            {
                Console.WriteLine("get: /aeros");
                string response = SQLManager.getAeropuertos();
                Console.WriteLine("Response:\n" + response);
                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });


            Get("/promos", _ =>
            {
                Console.WriteLine("get: /promos");
                JObject jsonResponse = new JObject();
                jsonResponse["data"] = SQLManager.getPromos();
                Console.WriteLine("Response:\n" + jsonResponse.ToString());
                var jsonBytes = Encoding.UTF8.GetBytes(jsonResponse.ToString());
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            });

 
        }
    }
}