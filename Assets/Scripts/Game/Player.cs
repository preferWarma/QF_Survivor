using QFramework;
using UI;
using UnityEngine;

namespace Game
{
	public partial class Player : ViewController
	{
		public float speed = 5f;

		private Rigidbody2D _rigidbody2D;

		private void Start()
		{
			// ResKit.Init();
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			Move();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			Destroy(gameObject);
			UIKit.OpenPanel<UIGameOver>();
		}

		// 简单的移动， 基于Rigidbody2D
		private void Move()
		{
			var x = Input.GetAxis("Horizontal");
			var y = Input.GetAxis("Vertical");
			_rigidbody2D.velocity = new Vector2(x, y).normalized * speed;
		}
	}
}
