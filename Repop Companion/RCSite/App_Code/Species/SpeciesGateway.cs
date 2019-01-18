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
    public static List<SpeciesInfo> GetAllSpecies()
    {
        string cacheKey = "AllSpecies";
        List<SpeciesInfo> returnObject = HttpContext.Current.Cache[cacheKey] as List<SpeciesInfo>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Species
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<SpeciesInfo>();
                foreach (Species item in result.ToList()) { returnObject.Add(new SpeciesInfo(item)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllSpecies

    public static SpeciesInfo SpeciesInfoGetBySpeciesID(long objectID)
    {
        string cacheKey = "AllSpeciesBySpeciesID_" + objectID;
        SpeciesInfo returnObject = HttpContext.Current.Cache[cacheKey] as SpeciesInfo;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Species
                              where item.speciesID == objectID
                              select item).FirstOrDefault();
                if (result == null) { return null; }
                returnObject = new SpeciesInfo(result);
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method SpeciesInfoGetBySpeciesID

    public static List<SpeciesInfo> AllSpeciesInfoForItem(long objectID)
    {
        string cacheKey = "AllSpeciesInfoForItem_" + objectID;
        List<SpeciesInfo> returnObject = HttpContext.Current.Cache[cacheKey] as List<SpeciesInfo>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Species_Results
                              where item.itemID == objectID
                              select item).Distinct().OrderBy(x => x.speciesID);
                if (result == null) { return null; }
                returnObject = new List<SpeciesInfo>();
                foreach (Species_Results item in result.ToList()) { returnObject.Add(SpeciesInfoGetBySpeciesID(item.speciesID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method AllSpeciesInfoForItem

    public static List<SpeciesResult> AllSpeciesResultsBySpeciesID(long objectID)
    {
        string cacheKey = "AllSpeciesResultsForItem_" + objectID;
        List<SpeciesResult> returnObject = HttpContext.Current.Cache[cacheKey] as List<SpeciesResult>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Species_Results
                              where item.speciesID == objectID
                              select item).OrderBy(x => x.speciesID);
                if (result == null) { return null; }
                returnObject = new List<SpeciesResult>();
                foreach (Species_Results item in result.ToList()) { returnObject.Add(new SpeciesResult(item)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method AllSpeciesResultsBySpeciesID


} // class SpeciesGateway