using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointsList : MonoBehaviour {

    public static List<Vector3> respawnPointsList = new List<Vector3>();

    
    // Use this for initialization
    void Start ()
    {
        shuffleRespawnPoints();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static Vector3 respawnMethod ()
    {
        shuffleRespawnPoints();

        int maxRespawns = respawnPointsList.Count;
        int randomNumber = Random.Range(0, maxRespawns);
        Vector3 vector = respawnPointsList[randomNumber];
        return vector;
    }

    static void shuffleRespawnPoints()
    {
        respawnPointsList.Clear();
        respawnPointsList.Add(new Vector3(-3, Random.Range(-5, 5), -9.7f));
        respawnPointsList.Add(new Vector3(3, Random.Range(-5, 5), -9.7f));
        respawnPointsList.Add(new Vector3(Random.Range(-3, 3), 5, -9.7f));
        respawnPointsList.Add(new Vector3(Random.Range(-3, 3), -5, -9.7f));

    }

}
