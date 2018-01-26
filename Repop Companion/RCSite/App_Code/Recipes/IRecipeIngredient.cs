using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IRecipeIngredient
/// </summary>
public interface IRecipeIngredient
{
     long ID { get;  }
     string Name { get;  }
     string Description { get; }
     string URL { get; }
} // interface IRecipeIngredient