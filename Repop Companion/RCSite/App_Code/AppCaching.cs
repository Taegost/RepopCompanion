using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AppCaching
/// </summary>
public class AppCaching
{
    public static void AddToCache(string cacheKey, object cacheObject)
    {
        try
        {
            HttpContext.Current.Cache.Add(cacheKey, cacheObject, null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                TimeSpan.FromMinutes(20), System.Web.Caching.CacheItemPriority.High, null);
        }
        catch (Exception ex)
        {
            string msg = string.Format("Unhandled exception occurred while adding the following data into the cache:\nCacheKey: {0}\nError: {1}", 
                cacheKey, ex.Message);
            throw new HttpUnhandledException(msg, ex);
        }
    } // method AddToCache
} // class AppCaching