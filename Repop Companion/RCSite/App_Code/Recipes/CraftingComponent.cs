using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CraftingComponent
/// </summary>
public class CraftingComponent
{
    public long ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string URL
    {
        get
        {
            return LinkGenerator.GenerateComponentLink(ID);
        } // get
    } // property URL

    public CraftingComponent(long componentID)
    {
        ID = componentID;
        Crafting_Components component = ComponentGateway.CraftingComponentGetByComponentID(ID);
        Name = component.displayName;
        Description = component.displayDescription;
    } // constructor
} // class CraftingComponent