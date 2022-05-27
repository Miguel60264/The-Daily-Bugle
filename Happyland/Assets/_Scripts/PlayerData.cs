using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public float playerLife;
    public float currentCollectables;
    public float[] position;

    public PlayerData (Player player)
    {
        playerLife = player.playerLife;
        currentCollectables = player.currentCollectables;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
