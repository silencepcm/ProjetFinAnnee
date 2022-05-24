using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Ingredient : MonoBehaviour
{
    float timer;
    public float timeToRespawn;
    public GameObject prefabIngredient;
    List<GameObject> ToSpawn;
    List<float> DestroyedTime;
    void Start()
    {
        ToSpawn = new List<GameObject>();
        DestroyedTime = new List<float>();
        List<GameObject> ListeDingredient = new List<GameObject>();
        foreach (Transform spawnCoordinates in transform)
        {
           ListeDingredient.Add(Instantiate(prefabIngredient, spawnCoordinates.localPosition, spawnCoordinates.rotation));
            Destroy(spawnCoordinates.gameObject);
        }
        foreach (GameObject obj in ListeDingredient)
        {
            obj.transform.SetParent(transform);
        }
    }

    private void Update()
    {
        if (ToSpawn.Count > 0)
        {
            List<int> removeFromList = new List<int>();
            for (int i = 0; i < DestroyedTime.Count; ++i)
            {
                if (Time.time > DestroyedTime[i] + timeToRespawn)
                {
                    ToSpawn[i].SetActive(true);
                    removeFromList.Add(i);
                }
            }
            int counter = 0;
            foreach(int i in removeFromList)
            {
                ToSpawn.RemoveAt(i - counter);
                DestroyedTime.RemoveAt(i - counter);
                counter++;
            }
        }
    }
    public void RespawnWaiter(GameObject obj)
    {
        ToSpawn.Add(obj);
        DestroyedTime.Add(Time.time);

    }

}
