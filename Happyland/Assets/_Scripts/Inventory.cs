using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Más de una instancia de inventario encontrada");
            return;
        }
        Instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    
    public int space = 12;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count > space)
            {
                Debug.Log("No hay suficiente espacio");
                return false;
            }
            items.Add(item);

            if(onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }
        return true;
    }

    public void Remove (Item item)
    {
        items.Remove (item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
