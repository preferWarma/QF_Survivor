using QFramework;
using UI;
using UnityEngine;

namespace Game
{
	public partial class Enemy : ViewController
	{
		public float speed = 3f;
		
		private int _hp = 3;
		
		// 引用部分
		private Player _player;
		private SpriteRenderer _spriteRenderer;

		private void Start()
		{
			_hp = 3;
			
			_player = FindObjectOfType<Player>();
			_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		}

		private void Update()
		{
			MoveToPlayer();
		}
		
		private void MoveToPlayer()
		{
			if (_player == null) return;
			var direction = (_player.transform.position - transform.position).normalized;
			transform.Translate(direction * (speed * Time.deltaTime));
		}

		public void GetHurt()
		{
			_hp--;
			if (_hp == 0)
			{
				Destroy(gameObject);
				UIKit.OpenPanel<UIGamePass>();
			}
			
			// 简易受伤动画
			_spriteRenderer.color = Color.red;
			ActionKit.Delay(0.2f, () =>
				{
					if (_spriteRenderer == null) return;
					_spriteRenderer.color = Color.white;
				}).StartGlobal();
		}
		
		public float DistanceToPlayer()
		{
			if (_player == null) return float.MaxValue;
			return (transform.position - _player.transform.position).magnitude;
			
		}
	}
}
