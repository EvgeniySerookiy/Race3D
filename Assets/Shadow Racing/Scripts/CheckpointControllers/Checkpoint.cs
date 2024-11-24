using Shadow_Racing.Scripts.Cars;
using UnityEngine;

namespace Shadow_Racing.Scripts.CheckpointControllers
{
    // Класс отвечает за отображение состояний чекпоинта
    public class Checkpoint : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        public bool IsPassed { get; private set; }

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void NotPassed()
        {
            _meshRenderer.material.color = ColorConstants.RED_COLOR_LINE;
            IsPassed = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Car>(out _))
            {
                _meshRenderer.material.color = ColorConstants.GREEN_COLOR_LINE;
                IsPassed = true;
            }
        }
    }
}