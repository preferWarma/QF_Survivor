using DG.Tweening;
using UnityEngine;
using QFramework;

namespace UI
{
	public partial class FloatTextController : ViewController
	{
		private static FloatTextController _instance;


		private void Start()
		{
			_instance = this;
		}


		/// <summary>
		/// 显示飘字
		/// </summary>
		/// <param name="position">显示位置</param>
		/// <param name="text">显示文本</param>
		public static void Play(Vector2 position, string text)
		{
			_instance.FloatText.InstantiateWithParent(_instance.transform)
				.Self(floatText =>
				{
					floatText.text = text;
					floatText.transform.position = position;
					// 使用 DoTween 实现飘字效果， 向上飘的同时放大(使用join同时执行两个动画), 在此之后淡出并消失
					DOTween.Sequence()
						.Join(floatText.transform.DOMoveY(position.y + 0.3f, 0.5f))
						.Join(floatText.transform.DOScale(floatText.transform.localScale * 1.2f, 0.5f))
						.Append(floatText.DOFade(0f, 0.2f)).SetDelay(0.2f)
						.OnComplete(() => { floatText.gameObject.DestroySelf(); });
				}).Show();
		}
	}
}
