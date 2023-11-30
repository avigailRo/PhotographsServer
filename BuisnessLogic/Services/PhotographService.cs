using BuisnessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services
{
    public class PhotographService: IPhotographService
    {
        readonly IPhotographRepository photographRepository;


        public PhotographService(IPhotographRepository photographRepository)
        {
           
            this.photographRepository = photographRepository;
        }
        public CollectionDetails getCollectionNameById(string id)
        {
            
            return photographRepository.getCollectionNameById(id);
        }
        public async Task AddCards(List<Card> cards)
        {
          await photographRepository.AddCards(cards);

        }

    }
}
