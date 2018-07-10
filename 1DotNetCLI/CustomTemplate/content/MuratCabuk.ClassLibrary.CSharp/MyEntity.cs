

namespace MuratCabuk.ClassLibrary.CSharp
{
    using System;
using MuratCabuk.ClassLibrary.CSharp.Helpers;


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
