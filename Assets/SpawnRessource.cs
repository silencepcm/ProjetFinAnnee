using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRessource : MonoBehaviour
{
    public GameObject prefabIngredient;
    public GameObject Ingredient;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn();

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
      Ingredient = Instantiate(prefabIngredient, this.transform.position, Quaternion.identity);
        
    }

    public void Destroy()
    {
        Destroy(this);
    }

    public GameObject GetIngredient()
    {
        return Ingredient;
    }
}
