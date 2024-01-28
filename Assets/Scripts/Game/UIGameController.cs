using QFramework;
using UI;

namespace Game
{
	public partial class UIGameController : ViewController
	{
		private void Start()
		{
			UIKit.OpenPanel<UIGame>();
		}

		private void OnDestroy()
		{
			UIKit.ClosePanel<UIGame>();
		}
	}
}
