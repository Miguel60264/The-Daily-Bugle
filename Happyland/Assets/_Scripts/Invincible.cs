using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour
{
    [SerializeField]
    private AudioClip _grenadePickUpSound;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                player.inmunity = true;
                AudioSource.PlayClipAtPoint(_grenadePickUpSound, transform.position, 1f);
                Destroy(this.gameObject);
            }
        }
    }
}
