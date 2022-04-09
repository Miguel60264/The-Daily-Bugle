using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour
{
    [SerializeField]
    private AudioClip _grenadePickUpSound;

    [SerializeField]
    private float healthQTY = 5.0f;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                player.AddHealth(healthQTY);
                AudioSource.PlayClipAtPoint(_grenadePickUpSound, transform.position, 1f);
                Destroy(this.gameObject);
            }
        }
    }
}
