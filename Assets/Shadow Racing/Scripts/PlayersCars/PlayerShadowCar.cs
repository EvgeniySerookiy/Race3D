using System.Collections.Generic;
using Ash_Assets.Sim_Cade_Vehicle_Physics.Scripts;
using Shadow_Racing.Scripts.Cars;
using Shadow_Racing.Scripts.ReplayRecorders;
using UnityEngine;

namespace Shadow_Racing.Scripts.PlayersCars
{
    // Класс отвечает за управление теневым автомобилем игрока, включая воспроизведение записанных
    // данных управления и активацию/деактивацию объекта теневого автомобиля.
    public class PlayerShadowCar
    {
        private readonly CarShadow _carShadow;
        private readonly SimcadeVehicleController _simcadeVehicleController;
        private List<TimedRecordInput> _recordedInputs;
        private int _currentRecordIndex;
        private float _startTime;
        public bool IsReplaying { get; private set; }

        public PlayerShadowCar(CarShadow carShadow)
        {
            _carShadow = carShadow;
            _simcadeVehicleController = _carShadow.GetComponent<SimcadeVehicleController>();
        }

        public void FixedUpdate()
        {
            if (IsReplaying && _recordedInputs != null && _currentRecordIndex < _recordedInputs.Count)
            {
                float elapsedTime = Time.time - _startTime;
                if (elapsedTime >= _recordedInputs[_currentRecordIndex].KeyPressTime)
                {
                    _simcadeVehicleController.SetInput(_recordedInputs[_currentRecordIndex].RecordInput);
                    _currentRecordIndex++;
                }
            }
        }

        public void StartReplay(List<TimedRecordInput> recordedInputs)
        {
            _recordedInputs = recordedInputs;
            _currentRecordIndex = 0;
            _startTime = Time.time;
            IsReplaying = true;
        }

        public void EnableCarShadow(bool isEnabled)
        {
            _carShadow.gameObject.SetActive(isEnabled);
        }
    }
}