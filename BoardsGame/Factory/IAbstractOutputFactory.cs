﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public interface IAbstractOutputFactory
    {
        IFileOutStream Generate(IArgumentsEngine args);
    }
}
