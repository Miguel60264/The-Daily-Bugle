using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarJuego : MonoBehaviour
{
    public static string abrirJuego;
    public void LoadLevel(string name)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            abrirJuego = name;
            SceneManager.LoadScene("StartWindow");
        }
    }
}
