﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session4
{
    class MyException : Exception
    {
        public MyException(string s)
            :base(s)
        {

        }
        //other biz
    }
}