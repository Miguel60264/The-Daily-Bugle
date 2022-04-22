using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Peluche : MonoBehaviour
{
    [SerializeField]
    private AudioClip _collectablePeluchePickUpSound;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.hasBear = true;
                    player.currentCollectables = player.currentCollectables + 1;
                    AudioSource.PlayClipAtPoint(_collectablePeluchePickUpSound, transform.position, 1f);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
