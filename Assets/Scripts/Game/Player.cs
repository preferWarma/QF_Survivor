using QFramework;
using UnityEngine;

namespace Game
{
	public partial class Player : ViewController
	{
		public float speed = 7f;

		private Rigidbody2D _rigidbody2D;

		private void Start()
		{
			_rigidbody2D = GetComponent<Rigidbody2D>();
			
			Global.Hp.Value = Global.MaxHp.Value;
		}

		private void Update()
		{
			// Move();
			Move2();
		}

		// 简单的移动， 基于Rigidbody2D
		private void Move()
		{
			var x = Input.GetAxis("Horizontal");
			var y = Input.GetAxis("Vertical");
			_rigidbody2D.velocity = new Vector2(x, y).normalized * speed;
		}
		
		// 通过Lerp来实现平滑移动
		private void Move2()
		{
			var x = Input.GetAxisRaw("Horizontal");
			var y = Input.GetAxisRaw("Vertical");
			var targetVelocity = new Vector2(x, y).normalized * speed;
			
			_rigidbody2D.velocity = Vector2.Lerp(_rigidbody2D.velocity, targetVelocity, 1f - Mathf.Exp(-Time.deltaTime * 5f));
			
		}
	}
}
