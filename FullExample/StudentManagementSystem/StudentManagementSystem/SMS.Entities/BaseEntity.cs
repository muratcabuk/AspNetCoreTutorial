using System;
using System.Collections.Generic;
using System.Text;
using SMS.Core;

namespace SMS.Entities
{
  public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }


    }
}
