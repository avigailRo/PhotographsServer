using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IPhotographRepository
    {
        public CollectionDetails getCollectionNameById(string id);
        public  Task AddCards(List<Card> cards);

    }
}
