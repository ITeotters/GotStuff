﻿using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IDetailedStockProductService
    {
        Task<List<DetailedStockProductVm>> GetAllTheSameStocks(DetailedStockProductVm detailedProductVm);
    }
}
