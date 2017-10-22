using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDITestbed
{
    class TextService : ITextService
    {
        public string GetSome()
        {
            return "Hello Jonny!";
        }
    }
}
