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
        else if (valorvida >= 70 && valorvida < 100)
        {
            _vol.profile.TryGet(out injury);
            injury.intensity.value = 0.33f;
            _vol.profile.TryGet(out distorsion);
            distorsion.intensity.value = 0.33f;
            Debug.Log("70");
        }
        else if (valorvida >= 40 && valorvida < 70)
        {
            _vol.profile.TryGet(out injury);
            injury.intensity.value = 0.33f;
            _vol.profile.TryGet(out distorsion);
            distorsion.intensity.value = 0.66f;
            Debug.Log("40");
        }
        else if (valorvida >= 10 && valorvida < 40)
        {
            _vol.profile.TryGet(out injury);
            injury.intensity.value = 1f;
            _vol.profile.TryGet(out distorsion);
            distorsion.intensity.value = 1f;
            Debug.Log("10");
        }
    }

}
