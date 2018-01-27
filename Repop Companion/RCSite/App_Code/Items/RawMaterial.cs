using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemRawMaterial
/// </summary>
public class RawMaterial : ItemBase
{
    private List<SpeciesInfo> _species = null;
    public List<SpeciesInfo> Species
    {
        get
        {
            if (_species == null) { _species = SpeciesGateway.AllSpeciesInfoForItem(ID); }
            return _species;
        } // get
    } // property Species

    private List<SpeciesResult> _speciesResults = null;
    public List<SpeciesResult> SpeciesResults
    {
        get
        {
            if (_speciesResults == null)
            {
                _speciesResults = new List<SpeciesResult>();
                foreach (SpeciesInfo species in Species)
                {
                    foreach (SpeciesResult result in species.Results)
                        if (result.Item.ID == ID && !(_speciesResults.Contains(result))) { _speciesResults.Add(result); }
                } // foreach
            } // if (_speciesResults == null)
            return _speciesResults;
        } // get
    } // property ResultsGetByItemID

    public RawMaterial(long itemID) : base(itemID)
    {
    } // constructor
} // class RawMaterial