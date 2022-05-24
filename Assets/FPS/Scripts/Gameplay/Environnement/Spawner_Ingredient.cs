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
            List<GameObject> spawn = new List<GameObject>();
            for (int i = 0; i < DestroyedTime.Count; ++i)
            {
                if (Time.time > DestroyedTime[i] + timeToRespawn)
                {
                    ToSpawn[i].SetActive(true);

                }
            }
        }
    }
    public void RespawnWaiter(Transform obj)
    {
        obj.gameObject.SetActive(false);
        ToSpawn.Add(obj.gameObject);
        DestroyedTime.Add(Time.time);
        obj.gameObject.SetActive(true);

    }

}
