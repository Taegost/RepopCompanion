using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for SpacesInfo
/// </summary>
public class SpeciesInfo
{
    public long ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ExtractionMethod { get; private set; }
    public string URL
    {
        get
        {
            if (ID > 0) { return LinkGenerator.GenerateSpeciesLink(ID); }
            return "";
        } // get
    } // property URL

    private List<SpeciesResult> _results = null;
    public List<SpeciesResult> Results
    {
        get
        {
            if (_results == null) { _results = SpeciesGateway.AllSpeciesResultsBySpeciesID(ID); }
            return _results;
        } // get
    } // property Results


    public SpeciesInfo(Species speciesData)
    {
        if (speciesData == null)
        {
            ID = 0;
            Name = "n/a";
            Description = "n/a";
            ExtractionMethod = "n/a";
        }
        else
        {
            ID = speciesData.speciesID;
            Name = speciesData.displayName;
            Description = speciesData.displayDescription;
            ExtractionMethod = speciesData.extractionType;
        }
    } // constructor

} // class SpecesInfo