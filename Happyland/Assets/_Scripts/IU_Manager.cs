using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IU_Manager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textAmmoText;
    public GameObject maestro;
    public GameObject gato;
    public GameObject peluche;

    // Start is called before the first frame update
    void Start()
    {
        maestro.SetActive(false);
        gato.SetActive(false);
        peluche.SetActive(false);
    }

    public void UpdateAmmo(int count)
    { 
       _textAmmoText.text = "Ammo: " + count; 
    }

    public void CollectMaestro()
    {
        maestro.SetActive(true);
    }

    public void CollectGato()
    {
        gato.SetActive(true);
    }

    public void CollectPeluche()
    {
        peluche.SetActive(true);
    }

    public void PaywithCoin()
    {
        maestro.SetActive(false);
    }
}
