using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject _MenudeinicioUI;
    public GameObject _MenudeopcionesUI;

    private float playerLife;
    private float currentCollectables;


    public void cargarescena()
    {
        CargarNivel.LoadLevel("Forest_Scene");
    }
    public void Opciones()
    {
        _MenudeopcionesUI.SetActive(false);

    }
    public void configuraciones()
    {
        _MenudeinicioUI.SetActive(false);
        _MenudeopcionesUI.SetActive(true);
    }

    public void principal()
    {
        _MenudeinicioUI.SetActive(true);
        _MenudeopcionesUI.SetActive(false);
    }

    public void cargarPartida()
    {
        PlayerData data = SaveSystem.LoadGame();

        playerLife = data.playerLife;
        currentCollectables = data.currentCollectables;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;

        CargarNivel.LoadLevel("Forest_Scene");
    }


    public void salir()
    {
        Debug.Log("saliendo...");
        Application.Quit();
    }
}
