using System;
using UnityEngine;

namespace Assets.Scripts
{

  
    public class ReactorScript : MonoBehaviour
    {
        private GameObject activeBase;
        public int TrashCount = 0;

        public Material ActiveMaterial;
        public GameObject[] lights;

        public GameObject Recharger;
        private CapsuleCollider rechargerCollider;
        private Transform rechargerLight;

        private float[] ranges = new float[]
        {
            0f,
            5,
            7,
            10,
            13,
        };

        private float[] heights = new float[]
        {
            0f,
            8.4f,
            13.2f,
            18,
            23,
        };





        private void Start()
        {
            activeBase = transform.Find("ActiveBase").gameObject;
            activeBase.SetActive(false);
            rechargerCollider = Recharger.GetComponent<CapsuleCollider>();
            rechargerLight = Recharger.transform.GetChild(0);
        }

        public void SetActive(bool active)
        {
            activeBase.SetActive(active);
            Debug.Log(active);
        }

        public void AddTrash()
        {
            TrashCount++;
            var materials = new[]
            {
                ActiveMaterial,
            };
            for (int i = 0; i < TrashCount; i++)
            {
                lights[i].GetComponent<Renderer>().materials = materials;
            }

            if (TrashCount == 4)
            {
                lights[4].GetComponent<Renderer>().materials = materials;
            }

            rechargerLight.position = new Vector3(rechargerLight.position.x, heights[TrashCount], rechargerLight.position.z);
            rechargerCollider.radius = ranges[TrashCount];
        }

      
    }
}