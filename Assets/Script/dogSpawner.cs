using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogSpawner : MonoBehaviour
{
    public List<GameObject> dogTypes;
    public List<GameObject> spawnPoints;
    public int dogsAmount = 0;

    int[] spawner = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};
    int[] dog = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};

    void reshuffle(int[] number)
    {
        for (int t = 0; t < number.Length; t++)
        {
            int tmp = number[t];
            int r = Random.Range(t, number.Length);
            number[t] = number[r];
            number[r] = tmp;
        }
    }

    void Start()
    {
        //spawnPoints[0].SetActive(false);
        reshuffle(spawner);
        reshuffle(dog);

        
        for (int i = 0, j = 0; i < 15; i++, j++)
        {
            //if (j == 10) j = 0;
            Instantiate(dogTypes[dog[i]], new Vector3(spawnPoints[spawner[i]].transform.position.x, spawnPoints[spawner[i]].transform.position.y + 1.2f, spawnPoints[spawner[i]].transform.position.z), spawnPoints[spawner[i]].transform.rotation);
            //Instantiate(dogTypes[dog[j]], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y + 1.2f, spawnPoints[i].transform.position.z), spawnPoints[i].transform.rotation);
        }

    }

    void Update()
    {

    }
}
