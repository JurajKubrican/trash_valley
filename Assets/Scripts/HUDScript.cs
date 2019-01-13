using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    // 0 - Carrying
    // 1 - MP
    public GameObject[] items;
    
    // Start is called before the first frame update
    void Start()
    {
        items[0].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void SetCarrying(bool carrying)
    {
        items[0].SetActive(carrying);

    }

    public void SetEnergy(int energy)
    {
        items[1].GetComponent<TextMeshProUGUI>().SetText("Energy: " + energy);

    }
}