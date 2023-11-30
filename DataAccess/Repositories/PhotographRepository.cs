using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccess.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;


namespace DataAccess.Repositories
{
    public class PhotographRepository : IPhotographRepository
    {
        List<Collection> collections;
       private readonly ILogger<PhotographRepository> logger;

        public PhotographRepository(ILogger<PhotographRepository> logger)
        {
            this.logger = logger;
            handlingJson();
        }
        private async void handlingJson()
        {
            try
            {
                string jsonString = await File.ReadAllTextAsync("collections.json");
                collections = System.Text.Json.JsonSerializer.Deserialize<List<Collection>>(jsonString);
                foreach (var collection in collections)
                {
                    string folderPath = Path.Combine(@"C:\Users\User\Desktop\task\Photographs\Photographs\images", collection.CollectionSymbolization.ToString());
                    // Create the folder
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch(Exception ex)
            {
                logger.LogError("Error in handlingJson " + ex.Message);
            }
        }
 
    public CollectionDetails getCollectionNameById(string id)
        {
            try
            {
                Collection foundCollection = collections.Find(collection => collection.CollectionSymbolization.Equals(id));
                if (foundCollection != null)
                {
                    CollectionDetails collection = new CollectionDetails();
                    collection.CollectionSymbolization = id;
                    collection.Title = foundCollection.Title;
                    collection.NumOfPhotographs = foundCollection.NumOfPhotographs;
                    return collection;
                }
            }
            catch(Exception ex) {
                logger.LogError("Error in getCollectionNameById " + ex.Message);

            }
            return null;

        }
        public async Task AddCards(List<Card> cards)
        {
            try { 
            foreach (var card in cards)
            {
                string json = JsonConvert.SerializeObject(card, Newtonsoft.Json.Formatting.Indented);
                await File.WriteAllTextAsync(card.SavePath, json);

                if (!card.SaveBackPath .Equals(""))
                {
                  await  File.WriteAllTextAsync(card.SaveBackPath, json);

                }
                Collection foundCollection = collections.Find(collection => collection.CollectionSymbolization.Equals(card.CollectionId));
                if (foundCollection != null)
                {
                        foundCollection.NumOfPhotographs++;
                }

            }
            }
            catch (Exception ex)
            {
                logger.LogError("Error in getCollectionNameById " + ex.Message);

            }

        }

    }
}
