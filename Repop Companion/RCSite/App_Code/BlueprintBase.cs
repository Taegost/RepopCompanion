using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for ItemBase
/// </summary>
public class BlueprintBase : IRecipeResultItem
{
    public long ID { get; private set; }
    public string Name { get; private set; }
    public bool IsHousingStructure { get; private set; }
    public bool IsSiegingUnit { get; private set; }
    public string URL
    {
        get
        {
            if (ID > 0) { return LinkGenerator.GenerateBlueprintLink(ID); }
            return "";
        } // get
    } // property URL

    public BlueprintBase(long itemID)
    {
        ID = itemID;
        if (ID > 0)
        {
            Structure itemRecord = ItemGateway.BlueprintGetByID(itemID);
            Name = itemRecord.displayName;
            IsHousingStructure = itemRecord.isHousingStructure > 0;
            IsSiegingUnit = itemRecord.isSiegingUnit > 0;
        } // if (ID > 0)
        else
        {
            Name = "n/a";
        }
    } // constructor
} // Class BlueprintBase