using QFramework;
using UI;

namespace Game
{
	public partial class GameStartController : ViewController
	{
		private void Awake()
		{
			ResKit.Init();
		}

		private void Start()
		{
			UIKit.OpenPanel<UIGameStart>();
		}
	}
}
