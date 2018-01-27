using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for SpeciesResult
/// </summary>
public class SpeciesResult
{
    private long _parentSpeciesID = -1;

    private SpeciesInfo _parentSpecies = null;
    public SpeciesInfo ParentSpecies
    {
        get
        {
            if (_parentSpecies == null) { _parentSpecies = SpeciesGateway.SpeciesInfoGetBySpeciesID(_parentSpeciesID); }
            return _parentSpecies;
        } // get
    } // property ParentSpecies

    public double Chance { get; private set; }
    public double ChanceMultiplier { get; private set; }
    public long Group { get; private set; }
    public long Count { get; private set; }
    public long Difficulty { get; private set; }
    public long Grade { get; private set; }

    private long itemID = -1;
    private RawMaterial _item = null;
    public RawMaterial Item
    {
        get
        {
            if (_item == null) { _item = new RawMaterial(itemID); }
            return _item;
        } // get
    } // property Item

    public SpeciesResult(Species_Results resultData)
    {
        if (resultData == null)
        {
            _parentSpeciesID = 0;
        }
        else
        {
            _parentSpeciesID = resultData.speciesID;
            Group = resultData.groupID;
            Chance = resultData.chance;
            ChanceMultiplier = resultData.chanceMultiplier;
            itemID = resultData.itemID;
            Count = resultData.count;
            Difficulty = resultData.difficulty;
            Grade = resultData.grade;
        }
    } // constructor
} // class SpeciesResult