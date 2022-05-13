using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Ingredient : MonoBehaviour
{
    public GameObject[] ListeDeSpawner;
    public List<GameObject> ListeDingredient = new List<GameObject>();
    public int timer;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ListeDeSpawner.Length; i++)
        {
            ListeDeSpawner[i].GetComponent<SpawnRessource>().Spawn();
            ListeDingredient.Add(ListeDeSpawner[i].GetComponent<SpawnRessource>().GetIngredient()); 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += 1;
        if (timer > 10000)
        {
            timer = 0;
            for(int j = 0; j < ListeDingredient.Count; j++)
            {
                Destroy(ListeDingredient[j]);
                
            }
            ListeDingredient.Clear();
            for (int i = 0; i < ListeDeSpawner.Length; i++)
            {
                ListeDeSpawner[i].GetComponent<SpawnRessource>().Spawn();
                ListeDingredient.Add(ListeDeSpawner[i].GetComponent<SpawnRessource>().GetIngredient());
            }
        }
    }
}
