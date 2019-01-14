using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerScript : MonoBehaviour
    {
        public float movementSpeed = 10.0F;

        public GameObject HUD;
        public GameObject PauseMenu;
        private HUDScript hudScript;
        public double MaxBat = 100;


        public bool carryingTrash = false;
        private bool isInRangeOfTrash = false;
        private bool isInRangeOfBattery = false;
        private bool isInRangeOfReactor = false;
        private GameObject trashGo;
        private GameObject reactorGo;
        private GameObject batteryGo;


        public double energy = 100;
        private bool isRecharging = false;

        private bool isInWater = false;
        private bool isWin = false;

        private void Start()
        {
            hudScript = HUD.GetComponent<HUDScript>();
        }


        private void Update()
        {
            if (Input.GetKeyDown("e"))
            {
                if (isInRangeOfTrash && !carryingTrash)
                {
                    carryingTrash = true;
                    isInRangeOfTrash = false;
                    Destroy(trashGo);
                }
                else if (isInRangeOfTrash && carryingTrash)
                {
                    hudScript.SetAux();
                }

                if (isInRangeOfBattery)
                {
                    Destroy(batteryGo);
                    isInRangeOfBattery = false;
                    MaxBat += 100;
                    energy += 100;
                }

                if (isInRangeOfReactor && carryingTrash)
                {
                    carryingTrash = false;
                    reactorGo.GetComponent<ReactorScript>().AddTrash();
                    if (reactorGo.GetComponent<ReactorScript>().TrashCount == 4)
                    {
                        isWin = true;
                    }
                }
            }

            hudScript.SetCarrying(carryingTrash);

            var moveHorizontal = Input.GetAxisRaw("Horizontal");
            var moveVertical = Input.GetAxisRaw("Vertical");

            if (!(Math.Abs(moveHorizontal) > .01) && !(Math.Abs(moveVertical) > .01)) return;


            var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }

        private void FixedUpdate()
        {
            if (isWin)
            {
                PauseMenu.GetComponent<PauseMenuScript>().Win();
            }

            if (isRecharging)
                energy = Math.Min(energy + 100 * Time.deltaTime, MaxBat);
            else
            {
                energy = Math.Max(energy - (15 * (isInWater ? 10 : 1)) * Time.deltaTime, 0);
            }


            if (Math.Abs(energy) < 0.0001)
            {
                PauseMenu.GetComponent<PauseMenuScript>().Die();
            }

            hudScript.SetEnergy((int) energy);

            if (transform.position.y < -10)
            {
                PauseMenu.GetComponent<PauseMenuScript>().Die();
            }

        }


        private void OnTriggerEnter(Component other)
        {
            switch (other.tag)
            {
                case "battery":
                    other.GetComponent<BatteryScript>().SetActive(true);
                    batteryGo = other.gameObject;
                    isInRangeOfBattery = true;
                    break;
                case "water":
                    isInWater = true;
                    break;
                case "trash":
                    other.GetComponent<TrashScript>().SetActive(true);
                    trashGo = other.gameObject;
                    isInRangeOfTrash = true;
                    break;
                case "reactor":
                    other.GetComponent<ReactorScript>().SetActive(true);
                    reactorGo = other.gameObject;
                    isInRangeOfReactor = true;
                    break;
                case "recharger":
                    isRecharging = true;
                    break;
                case "pit":
                    PauseMenu.GetComponent<PauseMenuScript>().Die();
                    break;
            }
        }

        private void OnTriggerExit(Component other)
        {
            switch (other.tag)
            {
                case "battery":
                    other.GetComponent<BatteryScript>().SetActive(false);
                    isInRangeOfBattery = true;
                    break;
                case "water":
                    isInWater = false;
                    break;
                case "trash":
                    other.GetComponent<TrashScript>().SetActive(false);
                    isInRangeOfTrash = false;
                    break;
                case "reactor":
                    other.GetComponent<ReactorScript>().SetActive(false);
                    isInRangeOfReactor = false;
                    break;
                case "recharger":
                    isRecharging = false;
                    break;
            }
        }
    }
}