namespace Game.EnemyDesign
{
    public interface IEnemy
    {
        public float Speed { get; set; }
        public float MaxHp { get; set; }
        
        public void MoveToPlayer();
        public void GetHurt(float damage, bool force = false);
    }
}