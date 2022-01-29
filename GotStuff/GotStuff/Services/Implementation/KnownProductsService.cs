using GotStuff.Data;
using GotStuff.Models;
using GotStuff.ViewModels;

namespace GotStuff.Services.Implementation
{
    public class KnownProductsService : IKnownProductsService
    {
        private readonly ApplicationDbContext service;

        public KnownProductsService(ApplicationDbContext dbService)
        {
            this.service = dbService;
        }
    }
}
