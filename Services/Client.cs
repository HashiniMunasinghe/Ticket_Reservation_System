using EAD_Ticket_Reservation_system.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EAD_Ticket_Reservation_system.Services
{
    public class Client
    {
        private readonly IMongoCollection<ClientModel> _clients;

        //public Client(IDatabaseConnection connection, IMongoClient mongoClient) 
        //{
        //    var database = mongoClient.GetDatabase(connection.DatabaseName);
        //    _clients = database.GetCollection<ClientModel>(connection.CollectionName);
        //}

        public Client(IOptions<DatabaseConnection> datbaseConnection)
        {
            var mongoClient = new MongoClient(
                datbaseConnection.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                datbaseConnection.Value.DatabaseName);

            _clients = mongoDatabase.GetCollection<ClientModel>(
                datbaseConnection.Value.CollectionName);
        }
        public ClientModel Create(ClientModel client)
        {
            _clients.InsertOne(client);
            return client;
        }

        public void Delete(string Id)
        {
            _clients.DeleteOne(client => client.Id == Id);
        }

        public List<ClientModel> Get()
        {
            return _clients.Find(client => true).ToList();
        }

        public ClientModel Get(string Id)
        {
            return _clients.Find(client => client.Id == Id).FirstOrDefault();
        }

        public void Update(string Id, ClientModel client)
        {
            _clients.ReplaceOne(client => client.Id == Id, client);
        }
    }
}
