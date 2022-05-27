using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Visibilidad_Vida : MonoBehaviour
{
    public GameObject jugador;
    public Player scriptjugador;
    public Volume _vol;

    private FilmGrain injury;
    private ChromaticAberration distorsion;

    public float valorvida;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        valorvida = scriptjugador.playerLife;
        if (valorvida >= 100)
        {
            _vol.profile.TryGet(out injury);
            injury.intensity.value = 0f;
            _vol.profile.TryGet(out distorsion);
            distorsion.intensity.value = 0f;
            Debug.Log("100");
        }
        else if (valorvida >= 75 && valorvida < 100)
        {
            _vol.profile.TryGet(out injury);
            injury.intensity.value = 0.2f;
            _vol.profile.TryGet(out distorsion);
            distorsion.intensity.value = 0.25f;
            Debug.Log("75");
        }
        else if (valorvida >= 50 && valorvida < 75)
        {
            _vol.profile.TryGet(out injury);
            injury.intensity.value = 0.4f;
            _vol.profile.TryGet(out distorsion);
            distorsion.intensity.value = 0.5f;
            Debug.Log("50");
        }
        else if (valorvida >= 25 && valorvida < 50)
        {
            _vol.profile.TryGet(out injury);
            injury.intensity.value = 0.8f;
            _vol.profile.TryGet(out distorsion);
            distorsion.intensity.value = 0.75f;
            Debug.Log("25");
        }
        else if (valorvida >= 10 && valorvida < 25)
        {
            _vol.profile.TryGet(out injury);
            injury.intensity.value = 1f;
            _vol.profile.TryGet(out distorsion);
            distorsion.intensity.value = 1f;
            Debug.Log("10");
        }
    }

}
