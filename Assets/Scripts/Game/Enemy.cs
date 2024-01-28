using QFramework;
using UnityEngine;

namespace Game
{
	public partial class Enemy : ViewController
	{
		public float speed = 3f;
		public int maxHp = 3;

		private int _hp;
		
		// 引用部分
		private Player _player;
		private SpriteRenderer _spriteRenderer;

		private void Start()
		{
			// 初始化属性
			_hp = maxHp;
			
			// 获取引用
			_player = FindObjectOfType<Player>();
			_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
			
			// 添加到全局敌人列表
			Global.Enemies.Add(this);
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

		public void GetHurt(int damage = 1)
		{
			_hp -= damage;
			if (_hp <= 0)
			{
				Destroy(gameObject);
				Global.Exp.Value++;
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

		private void OnDestroy()
		{
			// 从全局敌人列表中移除
			Global.Enemies.Remove(this);
		}
	}
}
