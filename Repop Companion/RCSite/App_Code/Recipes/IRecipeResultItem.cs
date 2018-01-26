using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public interface IRecipeResultItem
{
    long ID { get;  }
    string URL { get; }
    string Name { get;  }
} // interface IRecipeResultItem