using UnityEngine;

namespace Assets.Scripts
{
    public class WatterfallTrapScript : MonoBehaviour
    {
        // Start is called before the first frame update
        private new BoxCollider collider;
        private ParticleSystem[] waterfalls;

        void Start()
        {
            collider = gameObject.GetComponent<BoxCollider>();
            waterfalls = transform.GetComponentsInChildren<ParticleSystem>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time % 2 < 1)
            {
                waterfalls[0].Play();
                waterfalls[1].Play();
            }
            else
            {
                waterfalls[0].Stop();
                waterfalls[1].Stop();
            }

            collider.enabled = (Time.time -.3) % 2 < 1;
        }
    }
}