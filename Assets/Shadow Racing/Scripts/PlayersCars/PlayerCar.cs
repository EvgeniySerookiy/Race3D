using Ash_Assets.Sim_Cade_Vehicle_Physics.Scripts;
using Cinemachine;
using Shadow_Racing.Scripts.Cars;
using Shadow_Racing.Scripts.ReplayRecorders;
using UnityEngine;

namespace Shadow_Racing.Scripts.PlayersCars
{
    // Класс отвечает за управление автомобилем игрока, включая обработку ввода, сброс
    // состояния и включение/отключение управления.
    public class PlayerCar
    {
        private readonly Car _car;
        private readonly SimcadeVehicleController _simcadeVehicleController;
        private readonly CinemachineVirtualCamera _cinemachineVirtualCamera; 
        private readonly Rigidbody _rigidbody;
        private RecordInput _recordInput;
        private Transform _startPositionCar;

        public PlayerCar(Car car, Transform startPositionCar)
        {
            _car = car;
            _startPositionCar = startPositionCar;
            _cinemachineVirtualCamera = _car.GetComponentInChildren<CinemachineVirtualCamera>();
            _simcadeVehicleController = _car.GetComponent<SimcadeVehicleController>();
            _rigidbody = _car.GetComponent<Rigidbody>();
        }

        public void Update()
        {
            if(!_simcadeVehicleController.CanDrive)
                return;
            _recordInput.AccelerationInput = Input.GetAxis("Vertical");
            _recordInput.SteerInput = Input.GetAxis("Horizontal");
            _recordInput.BrakeInput = Input.GetAxis("Jump");
            _simcadeVehicleController.SetInput(_recordInput);
        }

        public void ResetPositionCar()
        {
            _rigidbody.transform.position = _startPositionCar.position;
            _rigidbody.transform.rotation = _startPositionCar.rotation;
        }
        
        public void ResetPositionCamera() 
        {
            _cinemachineVirtualCamera.gameObject.SetActive(false);
            _cinemachineVirtualCamera.gameObject.SetActive(true);
        }

        public void ResetVelocity()
        {
            _rigidbody.velocity = Vector3.zero;
        }
        
        public RecordInput GetInput()
        {
            return _recordInput;
        }

        public void SetDrivingEnabled(bool canDrive)
        {
            _simcadeVehicleController.CanDrive = canDrive;
        }
    }
}