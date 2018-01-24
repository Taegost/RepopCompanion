using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CraftingRecipeAgent
/// </summary>
public class CraftingRecipeAgent
{
    public CraftingRecipe ParentRecipe { get; private set; }
    public long Count { get; private set; }
    public long Weight { get; private set; }

    private long craftingComponentID;
    private CraftingComponent _craftingComponent = null;
    public CraftingComponent CraftingComponent
    {
        get
        {
            if (_craftingComponent == null)
            {
                _craftingComponent = new CraftingComponent(craftingComponentID);
            }
            return _craftingComponent;
        } // get
    } // property CraftingComponent
    public string URL
    {
        get
        {
            return LinkGenerator.GenerateComponentLink(CraftingComponent.ID);
        } // get
    } // property URL

    public CraftingRecipeAgent(Recipe_Agents agent)
    {
        ParentRecipe = new CraftingRecipe(agent.recipeID);
        Count = agent.count;
        Weight = agent.weight;
        craftingComponentID = agent.componentID;
    } // constructor
} // class CraftingRecipeAgent