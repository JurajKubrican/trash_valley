using UnityEngine;

namespace Assets.Scripts
{
    public class BatteryScript : MonoBehaviour
    {
        private GameObject activeBase;

        private void Start()
        {
            activeBase = transform.Find("ActiveBase").gameObject;
            activeBase.SetActive(false);
        }

        public void SetActive(bool active)
        {
            activeBase.SetActive(active);
        }
    }
}