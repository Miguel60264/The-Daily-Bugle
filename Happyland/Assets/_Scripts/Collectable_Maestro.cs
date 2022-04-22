using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Maestro : MonoBehaviour
{
    [SerializeField]
    private AudioClip _collectableMaestroPickUpSound;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.hasMaster = true;
                    player.currentCollectables = player.currentCollectables + 1;
                    AudioSource.PlayClipAtPoint(_collectableMaestroPickUpSound, transform.position, 1f);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
