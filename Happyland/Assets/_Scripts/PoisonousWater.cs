using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;

public class PoisonousWater : MonoBehaviour
{
    [SerializeField]
    private AudioClip _lessHealthSound;

    [SerializeField]
    private float healthQTY = 15.0f;

    public Volume _vol;

    private Vignette injury;

    public Color colordaño;

    public AudioMixer audioMixer;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.RemoveHealth(healthQTY);
            AudioSource.PlayClipAtPoint(_lessHealthSound, transform.position, 1f);

            _vol.profile.TryGet(out injury);
            injury.intensity.value = 0.5f;
            injury.color.value = new Color(0, 50, 50, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _vol.profile.TryGet(out injury);
        injury.intensity.value = 0.01f;
        colordaño = new Color(0, 0, 0, 0);
        injury.color.value = new Color(0, 0, 0, 0);
        Debug.Log("Salio");
    }
}
