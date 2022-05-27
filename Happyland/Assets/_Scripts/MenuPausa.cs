using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool _juegopausado;

    [SerializeField]
    public GameObject _MenudePausaUI;
    [SerializeField]
    public GameObject _MenudePausaUIOpciones;
    [SerializeField]
    public GameObject _MenudePausaUIjuego;

    public GameObject jugador;

    public Player player;

    public KeyCode pausar;
    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKeyDown(pausar))
        {
            if (_juegopausado)
            {
                continuar();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pausa();
            }
        }
    }

    public void continuar()
    {
        _MenudePausaUI.SetActive(false);
        _MenudePausaUIOpciones.SetActive(false);
        _MenudePausaUIjuego.SetActive(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1f;
        if (jugador != null)
        {
            Debug.Log("Continuar");
            jugador.GetComponent<Player>().gamepause = false;
            _juegopausado = false;
        }
    }

    public void opciones()
    {
        _MenudePausaUI.SetActive(false);
        _MenudePausaUIOpciones.SetActive(true);
        _MenudePausaUIjuego.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (jugador != null)
        {
            jugador.GetComponent<Player>().gamepause = false;
            _juegopausado = true;
        }
    }

    public void pausa()
    {
        _MenudePausaUI.SetActive(true);
        _MenudePausaUIjuego.SetActive(false);
        _MenudePausaUIOpciones.SetActive(false);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (jugador != null)
        {
            jugador.GetComponent<Player>().gamepause = false;
            _juegopausado = true;
        }
    }

    public void guardarPartida()
    {
        SaveSystem.SaveGame(player);
    }
    
    public void menu()
    {
        SceneManager.LoadScene("StartWindow");
        //Debug.Log("cargando menu...");
    }
    
    public void salir()
    {
        Debug.Log("saliendo...");
        Application.Quit();
    }
}
