using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField]
    private AudioClip _heartPickUpSound;

    private float healthQTY = 25.0f;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.AddHealth(healthQTY);
                    AudioSource.PlayClipAtPoint(_heartPickUpSound, transform.position, 1f);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
