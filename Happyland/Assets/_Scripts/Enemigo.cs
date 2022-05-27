using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Enemigo : MonoBehaviour
{
    [SerializeField]
    private AudioClip _DeathSound;
    [SerializeField]
    private AudioClip _pinchasoSonido;
    [SerializeField]

    public Volume _vol;

    private Vignette injury;

    public Color colordaño;

    private NavMeshAgent Miagente;

    public Transform[] Waypoint;

    public float rangoAlerta;
    public LayerMask capajugador;

   public bool estaealerta;

    public Transform jugadortransform;
    public GameObject jugador;

    private int siguienteWaypoint;


    public float _pickupHealt = 30f;

    public float velocidad;
    private void Start()
    {
        Miagente = this.GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
      estaealerta =  Physics.CheckSphere(transform.position, rangoAlerta, capajugador);

        if (estaealerta == true)
        {
            transform.LookAt(new Vector3(jugadortransform.position.x,transform.position.y, jugadortransform.position.z));
            Miagente.SetDestination(Vector3.MoveTowards(transform.position,new Vector3(jugadortransform.position.x, transform.position.y, jugadortransform.position.z),velocidad * Time.deltaTime));
        }
        else
        {
            Miagente.SetDestination(Waypoint[siguienteWaypoint].transform.position);
            Vector3 difpos = Waypoint[siguienteWaypoint].transform.position - this.transform.position;
            if (Mathf.Abs(difpos.x) < 0.1 || Mathf.Abs(difpos.z) < 0.1)
            {
                
                if (siguienteWaypoint < Waypoint.Length - 1)
                {
                    siguienteWaypoint++;

                }
                if (siguienteWaypoint == Waypoint.Length - 1)
                {
                    siguienteWaypoint = 0;
                }
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.LessHealth(_pickupHealt);
                AudioSource.PlayClipAtPoint(_DeathSound, transform.position, 1f);
                AudioSource.PlayClipAtPoint(_pinchasoSonido, transform.position, 1f);
                //Debug.Log("GameOver");



                _vol.profile.TryGet(out injury);

                injury.intensity.value = 0.06f;

                injury.color.value = new Color(225, 0, 0, 0);



            }
            //}
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _vol.profile.TryGet(out injury);
        injury.intensity.value = 0.06f;
        colordaño = new Color(0, 0, 0, 0);
        injury.color.value = new Color(0, 0, 0, 0);
        //Debug.Log("salio");
    }
}
