using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousFire : MonoBehaviour
{
    [SerializeField]
    private AudioClip _lessHealthSound;

    [SerializeField]
    private float healthQTY = 10.0f;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.RemoveHealth(healthQTY);
            AudioSource.PlayClipAtPoint(_lessHealthSound, transform.position, 1f);
        }
    }
}
