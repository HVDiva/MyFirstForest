﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Data.IDAO
{
    public interface IGenreDAO
    {
        Genre GetGenre(int id);
        IList<Genre> GetGenres();
    }

    
    
    
}
