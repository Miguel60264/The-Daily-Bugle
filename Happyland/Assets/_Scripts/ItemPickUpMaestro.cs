using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpMaestro : MonoBehaviour
{
    public Item item;
    public AudioClip _collectableMaestroPickUpSound;
    private float collectable = 1.0f;
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.AddCollectable(collectable);
                    AudioSource.PlayClipAtPoint(_collectableMaestroPickUpSound, transform.position, 1f);
                    bool wasPickedUp = Inventory.Instance.Add(item);
                    if (wasPickedUp)
                        Destroy(this.gameObject);
                    Debug.Log("Recogió el item: " + item.name);
                }
            }
        }
    }
}
