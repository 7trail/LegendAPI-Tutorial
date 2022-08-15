using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOLModTemplate
{
	public class NewDamageUp : Item
	{
		public NewDamageUp()
		{
			this.ID = NewDamageUp.staticID;
			this.category = Item.Category.Offense;
			this.damageMod = new NumVarStatMod(this.ID, 1.0f, 10, VarStatModType.Multiplicative, false); //Doubles damage
		}
		public override string ExtraInfo
		{
			get
			{
				return base.PercentToStr(this.damageMod, "+");
			}
		}

		public override void Activate()
		{
			this.SetModStatus(true);
		}
		public override void Deactivate()
		{
			this.SetModStatus(false);
		}

		public virtual void SetModStatus(bool givenStatus)
		{
			StatManager.ModifyAllStatData(this.damageMod, this.parentSkillCategory, StatData.damageStr, new StatManager.ModApplyConditional(base.IgnoreStatusConditional), givenStatus);
		}
		public static string staticID = "ModName::NewDamageUp";

		protected NumVarStatMod damageMod;
	}

}
