using QFramework;
using UI;
using UnityEngine;

namespace Game.EnemyDesign
{
	public partial class Enemy : ViewController
	{
		public float moveSpeed = 3f;
		public float maxHp = 3;

		private float _hp;
		private bool _isHurt;	// 是否处于受击状态
		
		// 引用部分
		protected Player Player;
		private SpriteRenderer _spriteRenderer;

		protected virtual void Start()
		{
			// 初始化属性
			_hp = maxHp;
			
			// 获取引用
			Player = FindObjectOfType<Player>();
			_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
			
			// 添加到全局敌人列表
			Global.Enemies.Add(this);
			Global.EnemyCount.Value = Global.Enemies.Count;
		}

		protected virtual void Update()
		{
			MoveToPlayer();
		}
		
		protected void MoveToPlayer()
		{
			if (Player == null) return;
			var direction = (Player.transform.position - transform.position).normalized;
			transform.Translate(direction * (moveSpeed * Time.deltaTime));
		}

		/// <summary>
		/// 对敌人造成伤害
		/// </summary>
		/// <param name="damage">伤害值</param>
		/// <param name="force">是否忽略受伤无敌帧并强制造成伤害</param>
		public void GetHurt(float damage = 1f, bool force = false)
		{
			if (_isHurt && !force) return;	// 给一个受击的无敌帧用于显示受击动画
			
			_hp -= damage;
			AudioKit.PlaySound("HitEnemy");
			if (_hp <= 0)
			{
				// 掉落物品
				DroppedItemManager.Instance.GenerateItem(transform.position);
				// 死亡
				Destroy(gameObject);
			}
			
			// 简易受伤动画
			_isHurt = true;
			_spriteRenderer.color = Color.red;
			ActionKit.Delay(0.2f, () =>
				{
					if (_spriteRenderer == null) return;
					_spriteRenderer.color = Color.white;
					_isHurt = false;
				}).Start(this);
			
			// 显示伤害飘字
			FloatTextController.Play(FloatTextPoint.position, damage.ToString());
		}
		
		public float DistanceToPlayer()
		{
			if (Player == null) return float.MaxValue;
			return (transform.position - Player.transform.position).magnitude;
			
		}
		
		private void OnDestroy()
		{
			// 从全局敌人列表中移除
			Global.Enemies.Remove(this);
			Global.EnemyCount.Value = Global.Enemies.Count;
		}
	}
}
