using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ConnectingC_andMongoDB
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("--- Conectando C# a MongoDB Atlas ---");

            // 1. Configuración de la cadena de conexión
            string connectionString = "mongodb+srv://warboleda5744_db_user:TF8l3azBH19M4iAf@cluster0.2aeshih.mongodb.net/?appName=Cluster0";

            // 2. Crear el cliente de MongoDB
            var client = new MongoClient(connectionString);

            try
            {
                // 3. Acceder a la base de datos y a la colección
                var database = client.GetDatabase("herramientas3");
                var collection = database.GetCollection<BsonDocument>("books");

                Console.WriteLine("--- Conectando a MongoDB Atlas ---");
                Console.WriteLine("Listando contenido de la colección 'books':\n");

                // 4. Obtener todos los documentos (await válido dentro de método async)
                var documents = await collection.Find(new BsonDocument()).ToListAsync();

                if (documents.Count == 0)
                {
                    Console.WriteLine("No se encontraron documentos en la colección.");
                }
                else
                {
                    foreach (var doc in documents)
                    {
                        Console.WriteLine(doc.ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true }));
                        Console.WriteLine(new string('-', 30));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de conexión: {ex.Message}");
            }
        }
    }
}
