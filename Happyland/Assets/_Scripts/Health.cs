using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject Player;
    public TMP_Text healthText;
    public Image healthBar;
    float currentHealth;
    float maxHealth = 100;
    float lerpSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Current health: " + currentHealth + "%";
        currentHealth = Player.GetComponent<Player>().playerLife;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        lerpSpeed = 3f * Time.deltaTime;
        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maxHealth, lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (currentHealth / maxHealth));
        healthBar.color = healthColor;
    }
}
