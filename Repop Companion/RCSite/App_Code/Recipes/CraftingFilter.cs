using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CraftingComponent
/// </summary>
public class CraftingFilter : IRecipeIngredient
{
    public long ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string URL
    {
        get
        {
            return LinkGenerator.GenerateFilterLink(ID);
        } // get
    } // property URL

    public CraftingFilter(long filterID)
    {
        ID = filterID;
        Crafting_Filters filter = FilterGateway.CraftingFilterGetByFilterID(ID);
        Name = filter.displayName;
        Description = filter.displayDescription;
    } // constructor
} // class CraftingFilter