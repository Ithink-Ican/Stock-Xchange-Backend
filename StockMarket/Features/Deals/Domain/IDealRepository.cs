﻿namespace StockMarket.Features.Deals.Domain;

public interface IDealRepository
{
    Task Create(Deal deal);
    Task<List<Deal>> GetAll();
    Task<Deal> Get(DealId id);
    Task Update(Deal deal);
    Task Delete(DealId dealId);
}
