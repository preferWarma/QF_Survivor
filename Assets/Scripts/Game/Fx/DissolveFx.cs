using QFramework;
using UnityEngine;

namespace Game.Fx
{
    public class DissolveFx : MonoBehaviour
    {
        public Material dissolveMaterial;
        public Color dissolveColor;

        private static readonly int Color = Shader.PropertyToID("_Color");
        private static readonly int Fade = Shader.PropertyToID("_Fade");

        private void Start()
        {
            var material = Instantiate(dissolveMaterial);
            gameObject.GetComponent<SpriteRenderer>().material = material;
            material.SetColor(Color, dissolveColor); // 设置溶解颜色
            ActionKit.Lerp(1, 0, 0.5f, fade =>
            {
                material.SetFloat(Fade, fade); // 设置溶解度
                gameObject.LocalScale(1 + (1 - fade) * 0.5f); // 根据溶解度设置缩放
            }).Start(this, () =>
            {
                Destroy(material);
                this.DestroyGameObjGracefully();
            });
        }
    }
}