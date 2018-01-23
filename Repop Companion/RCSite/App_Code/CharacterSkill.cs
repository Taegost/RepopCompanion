using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CharacterSkill
/// </summary>
public class CharacterSkill
{
    public long ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsTradeSkill { get; private set; }
    public string URL
    {
        get
        {
            return LinkGenerator.GenerateTradeskillLink(ID);
        } // get
    } // property URL

    public CharacterSkill(long skillID)
    {
        ID = skillID;
        Skill skillRecord = SkillGateway.GetSkillById(ID);
        Name = skillRecord.displayName;
        Description = skillRecord.displayDescription;
        IsTradeSkill = SkillGateway.AllTradeSkills().Contains(skillRecord);
    } // constructor
} // class CharacterSkill