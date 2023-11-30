using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Interfaces
{
    public interface IPhotographService
    {
        public CollectionDetails getCollectionNameById(string id);
        public Task AddCards(List<Card> cards);


    }
}
