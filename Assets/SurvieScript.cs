using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Script en construction : OBJECTIF : GEstion des barres d'eau/de Nourriture/de Gourde/de vie + lancement de la mort lier a la barre de vie
public class SurvieScript : MonoBehaviour
{
    public GameObject InventairePanel;
    public Slider SliderNourriture;
    public Slider SliderEau;
    public Slider SliderGourde;
    public Slider Vie;
    private float minNourriture = 0f;
    private float maxNourriture = 100f;
    private float minEau = 0f;
    private float maxEau = 100f;
    private float minGourde = 0f;
    private float maxGourde = 100f;
    private float minVie = 0f;
    private float maxVie = 100f;
    private int timerCoolDown = 2;
    private int timer = 0;
    public float perteEauSec;
    public float perteNourritureSec;
    public float perteVieSec;


    // Start is called before the first frame update
    void Start()
    {
        //initialisation des barres
        SliderNourriture.value = maxNourriture;
        SliderEau.value = maxEau;
        SliderGourde.value = maxGourde;
        Vie.value = maxVie;
    }
    public void FixedUpdate()
    {
        //perte d'eau et de nourriture
        SliderNourriture.value = 1f - perteNourritureSec;
        SliderEau.value -= perteEauSec;

        //perte de vie si l'une des 2 barres est a 0
        if (SliderEau.value <= 0f || SliderNourriture.value <= 0f)
        {
            Vie.value -= perteVieSec;
            if (Vie.value <= 0f)
            {
                Dead();
            }
        }
    }

    private void Update()
    {
       
        timer += 1;
        //mise a 0 de la barre de nourriture
        if (SliderNourriture.value <= minNourriture)
        {
            SliderNourriture.value = minNourriture;
        }
        if (SliderNourriture.value >= maxNourriture)
        {
            SliderNourriture.value = maxNourriture;
        }

        if(Vie.value >= maxVie)
        {
           Vie.value = maxVie;
        }

        //mise a 0 de la barre d'eau
        if (SliderEau.value <= minEau)
        {
            SliderEau.value = minEau;
        }
        if(SliderEau.value >= maxEau)
        {
            SliderEau.value = maxEau;
        }

        if(SliderGourde.value <= minGourde)
        {
            SliderGourde.value = minGourde;
        }
        if(SliderGourde.value >= maxGourde)
        {
            SliderGourde.value = maxGourde;
        }

        //Boit dans la gourde si touche alpha3 enfoncer
        if (Input.GetKeyDown(KeyCode.Alpha3) && timer>timerCoolDown && SliderGourde.value >= 20f)
        {
            SliderGourde.value -= 20f;
            SliderEau.value += 20f;
        }
        //Mange un fruit si touche alpha2 enfoncer ATTENTION!!!!  A FAIRE : lier a l'inventaire pour detruire un obj nourriture dedans 
        if(Input.GetKeyDown(KeyCode.Alpha2)&& timer > timerCoolDown)
        {
            SliderNourriture.value += 20f;
            if(InventairePanel.GetComponent<InventaireScript>().Clochite > 0)
            {
                InventairePanel.GetComponent<InventaireScript>().Clochite -= 1;
            }else if(InventairePanel.GetComponent<InventaireScript>().Baie > 0)
            {
                InventairePanel.GetComponent<InventaireScript>().Baie -= 1;
            }
            

            if(Input.GetKeyDown(KeyCode.H) && timer > timerCoolDown && InventairePanel.GetComponent<InventaireScript>().NbPotionSanté > 0 && Vie.value < maxVie)
            {
                InventairePanel.GetComponent<InventaireScript>().NbPotionSanté -= 1;
                Vie.value = maxVie;
            }
        }
       

    }

    public void Dead()
    {
        Debug.Log("Mort"); // tuer le perso et lancer la scene de defaite
    }

    // Update is called once per frame
    
}
