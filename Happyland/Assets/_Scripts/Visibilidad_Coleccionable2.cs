using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visibilidad_Coleccionable2 : MonoBehaviour
{
    public GameObject Player;
    public Image collectablesBar;
    float currentCollectables;
    float maxCollectables = 12;
    float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentCollectables = Player.GetComponent<Player>().currentCollectables;
        if (currentCollectables > maxCollectables) currentCollectables = maxCollectables;
    }

    // Update is called once per frame
    void Update()
    {
        currentCollectables = Player.GetComponent<Player>().currentCollectables;
        if (currentCollectables > maxCollectables) currentCollectables = maxCollectables;
        lerpSpeed = 3f * Time.deltaTime;
        CollectablesBarFiller();
        ColorChanger();
    }
    
    void CollectablesBarFiller()
    {
        collectablesBar.fillAmount = Mathf.Lerp(collectablesBar.fillAmount, currentCollectables / maxCollectables, lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.white, (currentCollectables / maxCollectables));
        collectablesBar.color = healthColor;
    }
}
