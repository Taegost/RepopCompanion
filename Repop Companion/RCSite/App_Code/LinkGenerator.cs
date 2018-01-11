using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LinkGenerator
/// </summary>
public class LinkGenerator
{
    public static string GenerateRecipeLink(long objectID)
    {
        return GenerateRecipeLink(Convert.ToInt32(objectID));
    }

    public static string GenerateRecipeLink(int objectID)
    {
        return "~/TradeSkills/Recipe.aspx?RecipeID=" + objectID;
    } // method GenerateRecipeLink

    public static string GenerateItemLink(long objectID)
    {
        return GenerateItemLink(Convert.ToInt32(objectID));
    }

    public static string GenerateItemLink(int objectID)
    {
        return "~/Items/Item.aspx?ItemID=" + objectID;
    } // method GenerateItemLink

    public static string GenerateFittingLink(long objectID)
    {
        return GenerateFittingLink(Convert.ToInt32(objectID));
    }

    public static string GenerateFittingLink(int objectID)
    {
        return "~/Items/Fitting.aspx?FittingID=" + objectID;
    } // method GenerateFittingLink

    public static string GenerateBlueprintLink(long objectID)
    {
        return GenerateBlueprintLink(Convert.ToInt32(objectID));
    }

    public static string GenerateBlueprintLink(int objectID)
    {
        return "~/Items/Blueprint.aspx?BlueprintID=" + objectID;
    } // method GenerateBlueprintLink

    public static string GenerateTradeskillLink(long objectID)
    {
        return GenerateTradeskillLink(Convert.ToInt32(objectID));
    }

    public static string GenerateTradeskillLink(int objectID)
    {
        return "~/TradeSkills/Default.aspx?TradeSkillId=" + objectID;
    } // method GenerateBlueprintLink
} // class LinkGenerator