using UnityEngine;

namespace Assets.Scripts
{
    public class CameraMove : MonoBehaviour
    {
        public GameObject Player;
        private Vector3 _offset;
        private Vector3 _dest;
        private float speed = 6f;

        void Start()
        {
            _offset = new Vector3(0, 10, -8);
        }

        void LateUpdate()
        {
//        transform.position = player.transform.position + offset;


            _dest = Player.transform.position + _offset;
            transform.position = Vector3.Lerp(transform.position, _dest, speed * Time.deltaTime);
        }
    }
}