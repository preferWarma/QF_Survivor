using UnityEngine;
using QFramework;

namespace Game.Ability
{
	public partial class GuardAbility : ViewController
	{
		[Tooltip("旋转半径")] public float radius = 5f;
		[Tooltip("旋转速度")] public float speed = 2f;
		[Tooltip("伤害")] public int damage = 2;
		
		private Transform _target;

		private void Start()
		{
			_target = FindObjectOfType<Player>().transform;

			RotateObj.OnTriggerEnter2DEvent(col =>
			{
				if (col.CompareTag("Enemy"))
				{
					col.GetComponentInParent<Enemy>().GetHurt(damage);
				}
			}).UnRegisterWhenGameObjectDestroyed(this);
		}

		private void Update()
		{
			Rotate();
		}

		private void Rotate()
		{
			var angle =  -Time.time * speed;	// -号是为了顺时针旋转
			var offset = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius);
			RotateObj.transform.position = _target.position + offset;
		}
		
	}
}
