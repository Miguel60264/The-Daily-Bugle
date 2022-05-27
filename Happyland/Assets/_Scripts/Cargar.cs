using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cargar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string levelToLoad = CargarNivel.siguienteNivel;

        StartCoroutine(this.MakeTheLoad(levelToLoad));
    }

    IEnumerator MakeTheLoad(string level)
    {
        //yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        while (operation.isDone == false)
        {
            yield return null;
        }
    }
}
