﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public interface ILoginRepository
    {
        bool IsExistUser(string username, string password);
    }
}
