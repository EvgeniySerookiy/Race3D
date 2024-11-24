namespace Shadow_Racing.Scripts.ReplayRecorders
{
    // Структура отвечает за хранение данных о вводе игрока и времени, когда этот ввод
    // был произведён.
    public struct TimedRecordInput
    {
        public RecordInput RecordInput;
        public float KeyPressTime;

        public TimedRecordInput(RecordInput recordInput, float keyPressTime)
        {
            RecordInput = recordInput;
            KeyPressTime = keyPressTime;
        }
    }
}