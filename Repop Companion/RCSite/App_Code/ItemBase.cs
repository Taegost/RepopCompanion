using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for ItemBase
/// </summary>
public abstract class ItemBase
{
    public long ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public ItemGroupEnum Group { get; private set; }
    public string URL
    {
        get
        {
            if (ID > 0) { return LinkGenerator.GenerateItemLink(ID); }
            return "";
        } // get
    } // property URL

    public ItemBase(long itemID)
    {
        ID = itemID;
        if (ID > 0)
        {
            Item itemRecord = ItemGateway.GetItemByID(itemID);
            Name = itemRecord.displayName;
            Description = itemRecord.displayDescription;
            Group = ItemGateway.DetermineItemGroupByItemID(ID);
        } // if (ID > 0)
        else
        {
            Name = "n/a";
            Description = "n/a";
            Group = ItemGroupEnum.Unknown;
        }
    } // constructor
} // Class ItemBase