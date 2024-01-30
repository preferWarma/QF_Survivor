using QFramework;
using UI;

namespace Game
{
	public partial class GameStartController : ViewController
	{
		private void Start()
		{
			UIKit.OpenPanel<UIGameStart>();
		}
	}
}
