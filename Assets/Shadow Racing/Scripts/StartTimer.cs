using System;
using System.Collections;
using Shadow_Racing.Scripts.Cars;
using Shadow_Racing.Scripts.PlayersCars;
using Shadow_Racing.Scripts.CheckpointControllers;
using TMPro;
using UnityEngine;
using Zenject;

namespace Shadow_Racing.Scripts
{
    // Класс управляет обратным отсчетом до начала гонки, отключает и включает управление автомобилем,
    // а также инициирует события для запуска второго раунда или сброса сцены при пересечении финишной
    // черты и прохождении всех контрольных точек.
    public class StartTimer : MonoBehaviour
    {
        public event Action OnActiveSecondRound;
        public event Action OnActiveResetScene;
        
        [SerializeField] private TextMeshPro _startText;
        [SerializeField] private GameObject _startLine;

        private Material _materialStartLine;
        private PlayerCar _playerCar;
        private CheckpointController _checkpointController;
        private int _count;

        [Inject]
        public void Construct(PlayerCar playerCar, CheckpointController checkpointController)
        {
            _playerCar = playerCar;
            _checkpointController = checkpointController;
            Debug.Log("StartTimer");
        }
        
        public void Initialize()
        {
            _playerCar.SetDrivingEnabled(false);
            _materialStartLine = _startLine.GetComponent<MeshRenderer>().material;
            StartCoroutine(StartCountdown());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Car>(out _) && _checkpointController.AllCheckpointsPassed())
            {
                _checkpointController.AllCheckpointsNotPassed();
                if (_count == 0)
                    OnActiveSecondRound.Invoke();
                
                else
                    OnActiveResetScene.Invoke();
                
                _count++;
            }
        }

        public void StartPositionStartTimer()
        {
            _startText.text = "3";
            _startText.color = ColorConstants.RED_COLOR_LINE;
            _materialStartLine.color = ColorConstants.RED_COLOR_LINE;
            _playerCar.SetDrivingEnabled(false);
            StartCoroutine(StartCountdown());
        }

        private IEnumerator StartCountdown()
        {
            int countdown = 3;

            while (countdown > 0)
            {
                _startText.text = countdown.ToString();
                yield return new WaitForSeconds(1f);
                countdown--;
            }
            
            _startText.text = "GO!";
            _startText.color = ColorConstants.GREEN_COLOR_TEXT;
            _materialStartLine.color = ColorConstants.GREEN_COLOR_LINE;
            _playerCar.SetDrivingEnabled(true);
            
            yield return new WaitForSeconds(5f);
            
            _startText.text = "FINISH";
            _startText.color = ColorConstants.WHITE_COLOR_TEXT;
            _materialStartLine.color = ColorConstants.WHITE_COLOR_LINE;
        }
    }
}
