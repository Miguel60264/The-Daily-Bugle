using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;

    public bool empty;
    public Sprite icon;

    public GameObject slotIconGameObject;

    private void Start()
    {

        slotIconGameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
    }

    public void UpdateSlot()
    {
        slotIconGameObject.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        slotIconGameObject.GetComponent<Image>().sprite = icon;
       
    }
}