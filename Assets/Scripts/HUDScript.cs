using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        public void SetEnergy(double maxEnergy, double energy)
        {
            items[1].GetComponent<TextMeshProUGUI>().SetText("Energy: " +  Math.Round(energy) );
            items[3].GetComponent<Slider>().value = (float) (energy / maxEnergy);
        }

        public void SetAux()
        {
            items[2].SetActive(true);
            tToHide = Time.time + 5;
        }
    }
}