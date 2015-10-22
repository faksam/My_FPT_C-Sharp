using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session05
{
    class BaseClass<T>
    {
        protected T t;
    }
    //non subclass generic
    //must specify generic of baseclass
    class SubClass : BaseClass<int>
    {

    }
    //subclass generic
    //must inheritance 
    class SubClass2<T, U> : BaseClass<T>
    {
        private U u;
    }
}
