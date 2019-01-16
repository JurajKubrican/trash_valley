using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class HUDScript : MonoBehaviour
    {
        // 0 - Carrying
        // 1 - MP
        public GameObject[] items;

        private float tToHide;

        // Start is called before the first frame update
        void Start()
        {
            items[0].SetActive(false);
            items[2].SetActive(false);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Time.time > tToHide)
            {
                items[2].SetActive(false);
            }
        }


        public void SetCarrying(bool carrying)
        {
            items[0].SetActive(carrying);
        }

        public void SetEnergy(int energy)
        {
            items[1].GetComponent<TextMeshProUGUI>().SetText("Energy: " + energy);
        }

        public void SetAux()
        {
            items[2].SetActive(true);
            tToHide = Time.time + 5;
        }
    }
}