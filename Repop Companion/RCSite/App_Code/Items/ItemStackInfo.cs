using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for ItemStackInfo
/// </summary>
public class ItemStackInfo
{
    public long DefaultStackSize { get; private set; }
    public long MaxStackSize { get; private set; }
    public bool IsStackable { get; private set; }

    public ItemStackInfo(long itemID)
    {
        Item_Stackable stackObject = ItemGateway.ItemStackInfoGetByItemID(itemID);
        if (stackObject == null)
        {
            IsStackable = false;
            DefaultStackSize = 0;
            MaxStackSize = 0;
        }
        else
        {
            IsStackable = true;
            DefaultStackSize = (long)stackObject.defaultStackSize;
            MaxStackSize = (long)stackObject.maxStackSize;
        }
    } // constructor
} // class ItemStackInfo