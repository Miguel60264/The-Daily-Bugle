using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Nuevo item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "Nuevo item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}