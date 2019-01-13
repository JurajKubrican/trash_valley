using System;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Assets.Scripts
{
    public class PlayerScript : MonoBehaviour
    {
        public float movementSpeed = 10.0F;

        public GameObject HUD;
        private HUDScript hudScript;


        private bool carryingTrash = false;
        private bool isInRangeOfTrash = false;
        private bool isInRangeOfReactor = false;
        private GameObject trashGo;
        private GameObject reactorGo;


        public double energy = 100;
        private bool isRecharging = false;

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
                    hudScript.SetCarrying(true);
                    Destroy(trashGo);
                }

                if (isInRangeOfReactor && carryingTrash)
                {
                    this.carryingTrash = false;
                    hudScript.SetCarrying(false);
                    reactorGo.GetComponent<ReactorScript>().AddTrash();
                }
            }

            var moveHorizontal = Input.GetAxisRaw("Horizontal");
            var moveVertical = Input.GetAxisRaw("Vertical");

            if (!(Math.Abs(moveHorizontal) > .01) && !(Math.Abs(moveVertical) > .01)) return;


            var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }

        private void FixedUpdate()
        {
            if (isRecharging)
            {
                energy = Math.Min(energy + 100 * Time.deltaTime, 100);
            }
            else
            {
                energy = Math.Max(energy - 10 * Time.deltaTime, 0);
            }

            hudScript.SetEnergy((int) energy);
        }


        private void OnTriggerEnter(Component other)
        {
            Debug.Log(other.tag);
            switch (other.tag)
            {
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
            }
        }

        private void OnTriggerExit(Component other)
        {
            switch (other.tag)
            {
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