using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Ingredient : MonoBehaviour
{
    List<GameObject> ListeDingredient = new List<GameObject>();
    List<Transform> DestroyedIngredients = new List<Transform>();
    float timer;
    public float timeToRespawn;
    public GameObject prefabIngredient;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform spawnCoordinates in transform)
        {
            Instantiate(prefabIngredient, spawnCoordinates.localPosition, spawnCoordinates.rotation);
            Destroy(spawnCoordinates.gameObject);
        }
    }


    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > timeToRespawn)
        {
            timer = 0f;
            foreach(var obj in DestroyedIngredients)
            {
               ListeDingredient.Add(Instantiate(prefabIngredient, obj.position, obj.rotation).gameObject);
            }
            DestroyedIngredients.Clear();
        }
    }
}
