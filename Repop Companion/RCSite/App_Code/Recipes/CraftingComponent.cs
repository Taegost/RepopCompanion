using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CraftingComponent
/// </summary>
public class CraftingComponent : IRecipeIngredient
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

    private List<ItemBase> _items = null;
    public List<ItemBase> Items
    {
        get
        {
            if (_items == null)
            {
                _items = ItemGateway.ItemsGetByComponentID(ID);
            }
            return _items;
        } // get
    } // property Items

    public CraftingComponent(long componentID)
    {
        ID = componentID;
        Crafting_Components component = ComponentGateway.CraftingComponentGetByComponentID(ID);
        if (component == null)
        {
            Name = "n/a";
            Description = "n/a";
        }
        else
        {
            Name = component.displayName;
            Description = component.displayDescription;
        }
    } // constructor
} // class CraftingComponent