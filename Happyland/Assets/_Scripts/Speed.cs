using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField]
    private AudioClip _speedPotionPickUpSound;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                player.speed = true;
                AudioSource.PlayClipAtPoint(_speedPotionPickUpSound, transform.position, 1f);
                Destroy(this.gameObject);
            }
        }
    }
}
