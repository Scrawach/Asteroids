namespace Components
{
    public class MonoTimer
    {
        private readonly float _targetTime;
        private float _elapsedTime;

        public MonoTimer(float targetTime)
        {
            _targetTime = targetTime;
            _elapsedTime = 0f;
        }
        
        public bool IsDone { get; private set; }

        public void Start()
        {
            IsDone = false;
            _elapsedTime = 0;
        }

        public void Update(float delta)
        {
            if (IsDone)
                return;
            
            UpdateTime(with: delta);
        }

        private void UpdateTime(float with)
        {
            _elapsedTime += with;
            
            if (_elapsedTime >= _targetTime) 
                IsDone = true;
        }
    }
}