

using System.Linq;
using SMS.Core.Interfaces;

namespace SMS.Core.Entities
{
    public class Option<TKey,TElement>:IOption<TKey, TElement>
    {


        public TKey Id { get; set; }

        public string Title { get; set; }

        public string Desc { get; set; }

        public TElement Obj { get; set; }

        public  bool IsSelected { get; set; }

    }
}
