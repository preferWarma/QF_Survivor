using Game.Fx;
using QFramework;
using UnityEngine;

namespace Game
{
	public partial class FxController : ViewController
	{
		private static FxController _instance;

		private void Start()
		{
			_instance = this;
		}

		public static void Play(SpriteRenderer sprite, Color dissolveColor)
		{
			_instance.EnemyDieFx.Instantiate()
				.Position(sprite.Position())
				.LocalScale(sprite.Scale())
				.Self(self =>
				{
					self.GetComponent<DissolveFx>().dissolveColor = dissolveColor;
					self.sprite = sprite.sprite;
				})
				.Show();
		}

		private void OnDestroy()
		{
			_instance = null;
		}
	}
	
}
