

namespace Merhaba
{
    using System;
using Merhaba.Helpers;


    public class MyEntity
    {
        public int MyProperty { get; set; }
        public string MyOtherProperty { get; set; }

        public string GetText()
            {
            return new StringHelper().GetLenght("merhaba");
            }
    }
  
}
