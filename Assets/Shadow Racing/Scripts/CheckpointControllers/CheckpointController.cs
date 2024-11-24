namespace Shadow_Racing.Scripts.CheckpointControllers
{
    // Класс отвечает за управление состоянием группы чекпоинтов, включая их
    // сброс и проверку, все ли они пройдены.
    public class CheckpointController
    {
        private Checkpoint[] _checkpoints;
        
        public CheckpointController(Checkpoint[] checkpoints)
        {
            _checkpoints = checkpoints;
        }

        public void AllCheckpointsNotPassed()
        {
            foreach (var checkpoint in _checkpoints)
            {
                checkpoint.NotPassed();
            }
        }

        public bool AllCheckpointsPassed()
        {
            foreach (var checkpoint in _checkpoints)
            {
                if (!checkpoint.IsPassed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}