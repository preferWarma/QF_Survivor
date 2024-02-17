/****************************************************************************
 * 2024.2 LIFELINE-R9000P
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UI
{
	public partial class MoneyUsePanel
	{
		[SerializeField] public UnityEngine.UI.Text MoneyRemainText;
		[SerializeField] public UnityEngine.UI.Button BtnCloseMoneyPanel;
		[SerializeField] public RectTransform Btn_UpgradeRoot;
		[SerializeField] public UnityEngine.UI.Button Btn_UpgradeTemplate;

		public void Clear()
		{
			MoneyRemainText = null;
			BtnCloseMoneyPanel = null;
			Btn_UpgradeRoot = null;
			Btn_UpgradeTemplate = null;
		}

		public override string ComponentName
		{
			get { return "MoneyUsePanel";}
		}
	}
}
