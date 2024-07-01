using UnityEngine;
using UnityEngine.Events;

namespace MyTimer
{
    //Timer�����ڴ��沿��Э�̣��ʺϴ��������ǿ�ġ���Ҫ�������ʵĻ���Ҫ���������رյ�Э��

    /// <summary>
    /// ����һ����ʱ��ı仯
    /// </summary>
    /// <typeparam name="TValue">�仯�����еķ���ֵ����</typeparam>
    /// <typeparam name="TLerp">���㷵��ֵ�ķ���</typeparam>
    [System.Serializable]
    public class Timer<TValue, TLerp> where TLerp : ILerp<TValue>, new()
    {
        private readonly bool unscaled;
        private readonly GameCycle gameCycle;

        [SerializeField]
        protected bool paused;
        /// <summary>
        /// �Ƿ���ͣ������Timerǰ��һ��Ҫȷ����Paused==true
        /// </summary>
        public bool Paused
        {
            get => paused;
            set
            {
                if (paused != value)
                {
                    paused = value;
                    if (value)
                    {
                        gameCycle.RemoveFromGameCycle(EInvokeMode.Update, Update);
                        OnPause?.Invoke(Current);
                    }
                    else
                    {
                        gameCycle.AttachToGameCycle(EInvokeMode.Update, Update);
                        OnResume?.Invoke(Current);
                    }
                }
            }
        }

        [SerializeField]
        protected bool completed;
        /// <summary>
        /// �Ƿ����
        /// </summary>
        public bool Completed
        {
            get => completed;
            protected set
            {
                if (completed != value)
                {
                    completed = value;
                    if (value)
                    {
                        OnComplete?.Invoke();
                    }
                }
            }
        }

        /// <summary>
        /// ������ʱ��
        /// </summary>
        public float Time { get; protected set; }
        /// <summary>
        /// ����İٷֱȣ�0��1)
        /// </summary>
        public float Percent => Mathf.Clamp01(Time / Duration);
        /// <summary>
        /// ��ʱ��
        /// </summary>
        public float Duration { get; protected set; }
        /// <summary>
        /// ��ֵ
        /// </summary>
        public TValue Origin { get; protected set; }
        /// <summary>
        /// ��ֵ
        /// </summary>
        public TValue Target { get; protected set; }

        public ILerp<TValue> Lerp { get; protected set; }
        /// <summary>
        /// ��ǰֵ
        /// </summary>
        public TValue Current => Lerp.Value(Origin, Target, Percent, Time, Duration);

        /// <summary>
        /// ��ͣʱ����
        /// </summary>
        public event UnityAction<TValue> OnPause;
        /// <summary>
        /// ����/�����ͣʱ����
        /// </summary>
        public event UnityAction<TValue> OnResume;
        /// <summary>
        /// ��ʱ��ʱ����
        /// </summary>
        public event UnityAction OnComplete;
        /// <summary>
        /// ����ʱÿ֡����
        /// </summary>
        public event UnityAction<TValue> OnTick;

        public Timer(bool unscaled = false)
        {
            Lerp = new TLerp();
            this.unscaled = unscaled;
            gameCycle = GameCycle.Instance;
            paused = true;
        }

        public Timer(Timer<TValue, TLerp> from) : this()
        {
            CopyFrom(from);
        }

        /// <summary>
        /// ΪMyTimer���ó�ʼ���Լ��Ƿ���������
        /// </summary>
        public virtual void Initialize(TValue origin, TValue target, float duration, bool start = true)
        {
            Duration = duration;
            Origin = origin;
            Target = target;
            if (start)
                Restart();
        }

        protected void Update()
        {
            if (unscaled) Time += UnityEngine.Time.unscaledDeltaTime;
            else Time += UnityEngine.Time.deltaTime;
            OnTick?.Invoke(Current);
            if (Time >= Duration)
            {
                Paused = true;
                Completed = true;
            }
        }

        /// <param name="fixedTime">��Ϊtrue�ɱ����ۻ����</param>
        public void Restart(bool fixedTime = false)
        {
            if (fixedTime)
                Time -= Duration;
            else
                Time = 0;
            Paused = false;
            Completed = false;
        }

        /// <summary>
        /// �ü�ʱ�����㲢��ͣ
        /// </summary>
        public void ReturnToZero()
        {
            Time = 0;
            Paused = true;
            Completed = false;
        }

        /// <summary>
        /// ʹ��ʱ�����̵�ʱ��
        /// </summary>
        public void ForceComplete()
        {
            Time = Duration;
            OnTick?.Invoke(Current);
            Paused = true;
            Completed = true;
        }

        /// <summary>
        /// ����һ����ʱ������
        /// ���ܻ�����ش���ί�У�Ҫע��
        /// </summary>
        /// <param name="from"></param>
        public void CopyFrom(Timer<TValue, TLerp> from)
        {
            Paused = from.Paused;
            Completed = from.Completed;
            Time = from.Time;
            Duration = from.Duration;
            Origin = from.Origin;
            Target = from.Target;
        }

        public void ResetEvents()
        {
            OnPause = null;
            OnResume = null;
            OnTick = null;
            OnComplete = null;
        }

        public override string ToString()
        {
            return $"Paused:{Paused},Completed:{Completed},Origin:{Origin},Target:{Target},Duration:{Duration}";
        }
    }
}