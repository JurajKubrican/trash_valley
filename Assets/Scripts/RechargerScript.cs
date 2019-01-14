using System;
using UnityEngine;

namespace Assets.Scripts
{


    public class RechargerScript : MonoBehaviour
    {
 
        public GameObject Recharger;
        private CapsuleCollider rechargerCollider;
        private Transform rechargerLight;

        private void Start()
        {
            rechargerCollider = Recharger.GetComponent<CapsuleCollider>();
            rechargerLight = Recharger.transform.GetChild(0);
        }



    }
}