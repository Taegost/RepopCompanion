using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

public class SkillGateway
{
    #region "Public Methods"

    public static List<CharacterTradeSkill> TradeSkillsGetAll()
    {
        string cacheKey = "TradeSkillList";
        List<CharacterTradeSkill> returnObject = HttpContext.Current.Cache[cacheKey] as List<CharacterTradeSkill>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var tradeSkills = (from skill in myEntities.Skills
                                   join recipe in myEntities.Recipes on skill.skillID equals recipe.skillID
                                   select skill).Distinct().OrderBy(x => x.displayName);
                returnObject = new List<CharacterTradeSkill>();
                foreach (Skill skill in tradeSkills.ToList()) { returnObject.Add(new CharacterTradeSkill(skill.skillID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if (skillList == null)
        return returnObject;
    } // method TradeSkillsGetAll

    public static Skill SkillGetById(long objectID)
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
    } // method SkillGetById

    #endregion // Public Methods
} // class SkillLists