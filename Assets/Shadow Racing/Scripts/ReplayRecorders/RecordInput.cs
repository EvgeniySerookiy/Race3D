namespace Shadow_Racing.Scripts.ReplayRecorders
{
    // Структура отвечает за хранение данных о вводе игрока, включая ускорение,
    // поворот и торможение.
    public struct RecordInput
    {
        public float AccelerationInput;
        public float SteerInput;
        public float BrakeInput;
    
        public RecordInput(float acceleration, float steer, float brake)
        {
            AccelerationInput = acceleration;
            SteerInput = steer;
            BrakeInput = brake;
        }
    }
}