using Shadow_Racing.Scripts.PlayersCars;
using Shadow_Racing.Scripts.ReplayRecorders;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Shadow_Racing.Scripts
{
    // Класс управляет переходами между первым и вторым раундами, записывает действия игрока,
    // воспроизводит тень автомобиля, сбрасывает сцену и обновляет состояние объектов в игре.
    public class GameController : MonoBehaviour
    {
        private const string FIRST_ROUND = "First round";
        private const string SECOND_ROUND = "Second round";
        
        [SerializeField] private TextMeshProUGUI _roundText;
        [SerializeField] private Button _resetSceneButton;
        
        private StartTimer _startTimer;
        private PlayerRecorder _playerRecorder;
        private PlayerCar _playerCar;
        private PlayerShadowCar _playerShadowCar;

        [Inject]
        public void Construct(StartTimer startTimer, PlayerCar playerCar, 
            PlayerShadowCar playerShadowCar, PlayerRecorder playerRecorder)
        {
            _startTimer = startTimer;
            _playerShadowCar = playerShadowCar;
            _playerCar = playerCar;
            _playerRecorder = playerRecorder;
        }

        private void Awake()
        {
            _startTimer.OnActiveSecondRound += StartSecondRound;
            _startTimer.OnActiveResetScene += ResetScene;
            _resetSceneButton.onClick.AddListener(ResetScene);
            StartFirstRound();
        }

        private void ResetScene()
        {
            _playerRecorder.ResetRecording();
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            
        }

        private void StartSecondRound()
        {
            _roundText.text = SECOND_ROUND;
            _playerCar.ResetPositionCar();
            _playerCar.ResetPositionCamera();
            _playerCar.ResetVelocity();
            _playerShadowCar.EnableCarShadow(true);
            _playerShadowCar.StartReplay(_playerRecorder.GetTimedRecordInput());
            _startTimer.StartPositionStartTimer();
        }

        private void StartFirstRound()
        {
            _roundText.text = FIRST_ROUND;
            _startTimer.Initialize();
            _playerRecorder.StartRecording();
            _playerShadowCar.EnableCarShadow(false);
        }
        
        private void FixedUpdate()
        {
            _playerRecorder.FixedUpdate();
            _playerShadowCar.FixedUpdate();
        }

        private void Update()
        {
            _playerCar.Update();
        }

        private void OnDisable()
        {
            _startTimer.OnActiveSecondRound -= StartSecondRound;
            _startTimer.OnActiveResetScene -= ResetScene;
            _resetSceneButton.onClick.RemoveListener(ResetScene);
        }
    }
}