using System;
using System.Collections.Generic;

namespace Task_1
{
    interface ISearchable
    {
        List<Product> SearchByPrice(double maxPrice);
        List<Product> SearchByCategory(string category);
        List<Product> SearchByRating(int minRating);
    }

}