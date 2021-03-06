﻿namespace ForumSystem.Services.Data
{
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetCategoryByName<T>(string name);

        
    }
}
