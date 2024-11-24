using System.Collections.Generic;
using Shadow_Racing.Scripts.PlayersCars;
using UnityEngine;

namespace Shadow_Racing.Scripts.ReplayRecorders
{
    // Класс отвечает за запись ввода игрока с временными метками для последующего воспроизведения.
    public class PlayerRecorder
    {
        private readonly PlayerCar _playerCar;
        private readonly List<TimedRecordInput> _timedRecordInputs = new();
        private float _startTime;
        private bool _isRecording;

        public PlayerRecorder(PlayerCar playerCar)
        {
            _playerCar = playerCar;
            Debug.Log("PlayerRecorder");
        }

        public void FixedUpdate()
        {
            if (!_isRecording) 
                return;
            var input = _playerCar.GetInput();
            _timedRecordInputs.Add(new TimedRecordInput(input, Time.time - _startTime));
        }

        public void StartRecording()
        {
            _startTime = Time.time;
            _isRecording = true;
        }

        public void ResetRecording()
        {
            _isRecording = false;
            _timedRecordInputs.Clear();
        }
        
        public List<TimedRecordInput> GetTimedRecordInput()
        {
            return _timedRecordInputs;
        }
    }
}