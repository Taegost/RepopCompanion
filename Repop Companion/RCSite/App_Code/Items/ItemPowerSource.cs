using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for ItemPowerSource
/// </summary>
public class ItemPowerSource
{
    public long PowerIndex { get; private set; }
    public long MaxStorage { get; private set; }
    public bool StoresPower { get; private set; }

    public ItemPowerSource(long itemID)
    {
        Item_Power_Source powerSource = ItemGateway.PowerSourceInfoGetByItemID(itemID);
        Item_Stores_Power powerStorage = ItemGateway.PowerStorageInfoGetByItemID(itemID);
        if (powerSource == null || powerStorage == null)
        {
            StoresPower = false;
            PowerIndex = 0;
            MaxStorage = 0;
        }
        else
        {
            StoresPower = true;
            PowerIndex = powerSource.powerIndex;
            MaxStorage = powerStorage.maxStorage;
        }
    } // constructor
} // class ItemPowerSource