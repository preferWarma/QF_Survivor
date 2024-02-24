using QFramework;
using UnityEngine;

namespace Game.EnemyDesign
{
    public class Boss : Enemy
    {
        [Tooltip("警告距离")] public float warningDistance = 8f;
        [Tooltip("冲刺速度")] public float dashSpeed = 10f;
        [Tooltip("警告时间")] public float warningTime = 1f;
        [Tooltip("警告标志")] public Transform alertSign;
        
        private readonly FSM<BossState> _fsm = new();
        private Rigidbody2D _rigidbody;
        
        private Vector3 _dashStartPos;  // 冲刺开始位置
        private Vector3 _dashDirection; // 冲刺方向
        private float _dashDistance;    // 冲刺距离
        private float _timer;   // 计时器

        protected override void Start()
        {
            base.Start();
            _rigidbody = GetComponent<Rigidbody2D>();
            
            // 初始化状态机
            _fsm.State(BossState.MoveToPlayer)
                .OnEnter(() =>
                {
                    _rigidbody.velocity = Vector2.zero;
                })
                .OnUpdate(() =>
                {
                    // 移动到玩家, 如果距离小于某值, 则切换到Warning状态
                    MoveToPlayer();
                    if (DistanceToPlayer() < warningDistance)
                    {
                        _fsm.ChangeState(BossState.Warning);
                    }
                });
            
            _fsm.State(BossState.Warning)
                .OnEnter(() =>
                {
                    _rigidbody.velocity = Vector2.zero;
                    _timer = 0f;
                    alertSign.Show();
                }).
                OnUpdate(() =>
                {
                    // 警告玩家, 如果警告时间到, 则切换到DashToPlayer状态
                    _timer += Time.deltaTime;
                    if (_timer > warningTime)
                    {
                        _fsm.ChangeState(BossState.DashToPlayer);
                    }
                })
                .OnExit(() =>
                {
                    alertSign.Hide();
                });

            _fsm.State(BossState.DashToPlayer)
                .OnEnter(() =>
                {
                    var dir = (Player.transform.position - transform.position).normalized;
                    _rigidbody.velocity = dir * dashSpeed;
                    _dashStartPos = transform.position;
                    _dashDistance = DistanceToPlayer() * 1.1f;
                })
                .OnUpdate(() =>
                {
                    if ((transform.position - _dashStartPos).magnitude > _dashDistance)
                    {
                        _fsm.ChangeState(BossState.MoveToPlayer);
                    }
                });
            
            // 设置初始状态
            _fsm.StartState(BossState.MoveToPlayer);
        }

        protected override void Update()
        {
            _fsm.Update();
        }
    }

    public enum BossState
    {
        MoveToPlayer,   // 移动到玩家
        DashToPlayer,   // 冲刺到玩家
        Warning,    // 警告
    }
}