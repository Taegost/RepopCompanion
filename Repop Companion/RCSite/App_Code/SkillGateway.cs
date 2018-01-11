using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

public class SkillGateway
{
    #region "Public Methods"

    public static List<Skill> AllTradeSkills()
    {
        string cacheKey = "TradeSkillList";
        List<Skill> returnObject = HttpContext.Current.Cache[cacheKey] as List<Skill>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var tradeSkills = (from skill in myEntities.Skills
                                   join recipe in myEntities.Recipes on skill.skillID equals recipe.skillID
                                   select skill).Distinct().OrderBy(x => x.displayName);
                returnObject = tradeSkills.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if (skillList == null)
        return returnObject;
    } // method AllTradeSkills

    public static Skill GetSkillById(long objectID)
    {
        return GetSkillById(Convert.ToInt32(objectID));
    } // method GetSkillById(long inSkillId)

    public static Skill GetSkillById(Int32 objectID)
    {
        string cacheKey = "Skill_" + objectID;
        Skill returnObject = HttpContext.Current.Cache[cacheKey] as Skill;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from skill in myEntities.Skills
                                where skill.skillID == objectID
                                select skill).FirstOrDefault();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if (currentSkill == null)
        return returnObject;
    } // method GetSkillById

    #endregion // Public Methods
} // class SkillLists