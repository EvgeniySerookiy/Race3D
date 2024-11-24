using UnityEngine;

namespace Ash_Assets.Sim_Cade_Vehicle_Physics.Scripts
{
    public class TireSmoke : MonoBehaviour
    {
        private ParticleSystem smoke;
        private void Awake()
        {
            smoke = GetComponent<ParticleSystem>();
            smoke.Stop();
        }

        public void playSmoke()
        {
            smoke.Play();
        }
        public void stopSmoke()
        {
            smoke.Stop();
        }
    }
}
