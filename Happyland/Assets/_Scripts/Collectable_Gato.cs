using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Gato : MonoBehaviour
{
    [SerializeField]
    private AudioClip _collectableGatoPickUpSound;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.hasCoin = true;
                    AudioSource.PlayClipAtPoint(_collectableGatoPickUpSound, transform.position, 1f);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
