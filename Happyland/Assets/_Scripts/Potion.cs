using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField]
    private AudioClip _potionSound;

    [SerializeField]
    private float healthQTY = 25.0f;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.AddHealth(healthQTY);
            AudioSource.PlayClipAtPoint(_potionSound, transform.position, 1f);
            Destroy(this.gameObject);
        }
    }
}
