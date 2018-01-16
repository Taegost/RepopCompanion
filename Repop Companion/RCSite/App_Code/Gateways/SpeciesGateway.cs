using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for SubsistenceGateway
/// </summary>
public class SpeciesGateway
{
    public static List<Species> GetAllSpecies()
    {
        string cacheKey = "AllSpecies";
        List<Species> returnObject = HttpContext.Current.Cache[cacheKey] as List<Species>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Species
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllSpecies

    public static Species GetSpeciesBySpeciesID(long objectID)
    {
        string cacheKey = "AllSpeciesBySpeciesID_" + objectID;
        Species returnObject = HttpContext.Current.Cache[cacheKey] as Species;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Species
                              where item.speciesID == objectID
                              select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetSpeciesBySpeciesID

    public static List<Species_Results> GetAllSpeciesResultsForItem(long objectID)
    {
        string cacheKey = "AllSpeciesResultsForItem_" + objectID;
        List<Species_Results> returnObject = HttpContext.Current.Cache[cacheKey] as List<Species_Results>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Species_Results
                              where item.itemID == objectID
                              select item).OrderBy(x => x.speciesID);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllSpeciesResultsForItem




} // class SpeciesGateway