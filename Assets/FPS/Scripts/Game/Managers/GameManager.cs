using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;
public class GameManager : MonoBehaviour
{

    #region SINGLETON PATTERN
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    Resources.Load<GameObject>("GameManager");
                    _instance.Start();
                }
            }

            return _instance;
        }
    }
    #endregion
    public bool Movement;
    public bool Saut;
    public bool Tir;
    public bool Trampoplante;
    public bool FallDamage;
    public bool Inventaire;
    public float MaxSpeedOnGround;
    public float MaxSpeedInAir;
    public float JumpForce;
    public float GravityForce;
    public float MaxChargeDuration;
    public int MaxAmmo;
    public float BulletSpreadAngle;
    public int BulletsPerShot;
    public float TrampoplanteForce;
    public float MinSpeedFallDamage;
    public float FallDamageValeurAtMinSpeed;
    public float MaxSpeedFallDamage;
    public float FallDamageValeurAtMaxSpeed;


    public float MaxSoif;
    public float MinSoif;

    public float MaxGourde;
    public float MinGourde;

    public float MaxNourriture;
    public float MinNourriture;


    public bool Collect;
    public bool Eat;


    public float DelaySoif;
    public float DelayNourriture;
    public float DegatsNourriture;
    public float DegatsSoif;

    public int NbIngredientA;
    public int NbIngredientB;
    public int NbIngredientC;
    public int NbIngredientD;
    public int NbIngredientE;
    public int NbIngredientF;
    public int NbIngredientG;

    public int NbRecette1;
    public int NbRecette2;
    public int NbRecette3;
    public int NbRecette4;
    public int NbRecette5;

    private void Start()
    {
        SaveData data = SaveToyboxScript.LoadData();
        if (data != null)
        {
            Movement = data.Movement;
            Saut = data.Saut;
            Tir = data.Tir;
            Trampoplante = data.Trampoplante;
            FallDamage = data.FallDamage;
            Inventaire = data.Inventaire;
            MaxSpeedOnGround = data.MovementSpeedOnGround;
            MaxSpeedInAir = data.MovementSpeedInAir;
            JumpForce = data.JumpForce;
            GravityForce = data.GravityForce;
            MaxChargeDuration = data.MaxChargeDuration;
            MaxAmmo = data.MaxAmmo;
            BulletSpreadAngle = data.BulletSpreadAngle;
            BulletsPerShot = data.BulletsPerShot;
            TrampoplanteForce = data.TrampoplanteForce;
            MinSpeedFallDamage = data.MinSpeedFallDamage;
            FallDamageValeurAtMinSpeed = data.FallDamageValeurAtMinSpeed;
            MaxSpeedFallDamage = data.MaxSpeedFallDamage;
            FallDamageValeurAtMaxSpeed = data.FallDamageValeurAtMaxSpeed;


            MaxSoif = data.maxThirst;
            MinSoif = data.minThirst;
            MaxGourde = data.maxGourde;
            MinGourde = data.minGourde;
            MaxNourriture = data.maxNourriture;
            MinNourriture = data.minNourriture;

            Collect = data.Collect;
            Eat = data.Eat;


            DelaySoif = data.DelaySoif;
            DelayNourriture = data.DelayNourriture;
            DegatsSoif = data.DegatsSoif;
            DegatsNourriture = data.DegatsNourriture;

            NbIngredientA = data.NbIngredientA;
            NbIngredientB = data.NbIngredientB;
            NbIngredientC = data.NbIngredientC;
            NbIngredientD = data.NbIngredientD;
            NbIngredientE = data.NbIngredientE;
            NbIngredientF = data.NbIngredientF;
            NbIngredientG = data.NbIngredientG;

            NbRecette1 = data.NbRecette1;
            NbRecette2 = data.NbRecette2;
            NbRecette3 = data.NbRecette3;
            NbRecette4 = data.NbRecette4;
            NbRecette5 = data.NbRecette5;
        }
        else
        {
            Movement = true;
            Saut = true;
            Tir = true;
            Trampoplante = true;
            FallDamage = true;
            Inventaire = true;
            MaxSpeedOnGround = 5;
            MaxSpeedInAir = 5;
            JumpForce = 1;
            GravityForce = 1;
            MaxChargeDuration = 1;
            MaxAmmo = 1;
            BulletSpreadAngle = 1;
            BulletsPerShot = 1;
            TrampoplanteForce = 1;
            MinSpeedFallDamage = 1;
            FallDamageValeurAtMinSpeed = 1;
            MaxSpeedFallDamage = 1;
            FallDamageValeurAtMaxSpeed = 1;


            MaxSoif = 100f;
            MinSoif = 0f;
            MaxGourde = 100f;
            MinGourde = 0f;
            MaxNourriture = 100f;
            MinNourriture = 0f;


            DelaySoif = 3f;
            DelayNourriture = 3f;
            DegatsSoif = 10f;
            DegatsNourriture = 10f;

            NbIngredientA = 0;
            NbIngredientB = 0;
            NbIngredientC = 0;
            NbIngredientD = 0;
            NbIngredientE = 0;
            NbIngredientF = 0;
            NbIngredientG = 0;

            NbRecette1 = 0;
            NbRecette2 = 0;
            NbRecette3 = 0;
            NbRecette4 = 0;
            NbRecette5 = 0;
        }
    }
}
