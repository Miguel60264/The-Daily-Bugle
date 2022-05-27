using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarNivel : MonoBehaviour
{
    public static string siguienteNivel;

    public static void LoadLevel(string name)
    {
        siguienteNivel = name;

        SceneManager.LoadScene("Tutorial");
    }
}
