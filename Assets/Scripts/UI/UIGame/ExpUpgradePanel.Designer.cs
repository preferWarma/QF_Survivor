/****************************************************************************
 * 2024.2 LIFELINE-R9000P
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UI
{
	public partial class ExpUpgradePanel
	{
		[SerializeField] public RectTransform BtnRoot;
		[SerializeField] public UnityEngine.UI.Button ExpUpgradeItem_Template;
		[SerializeField] public UnityEngine.UI.Button SimpleAbility_Frequency;
		[SerializeField] public UnityEngine.UI.Button SimpleAbility_Power;

		public void Clear()
		{
			BtnRoot = null;
			ExpUpgradeItem_Template = null;
			SimpleAbility_Frequency = null;
			SimpleAbility_Power = null;
		}

		public override string ComponentName
		{
			get { return "ExpUpgradePanel";}
		}
	}
}
