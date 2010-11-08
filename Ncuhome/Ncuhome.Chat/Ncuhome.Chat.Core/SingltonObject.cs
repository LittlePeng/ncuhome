using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Chat.Core
{
    public  class SingltonObject<T>  where T:new()
    {
        public static T Instance=new T();
    }
}
