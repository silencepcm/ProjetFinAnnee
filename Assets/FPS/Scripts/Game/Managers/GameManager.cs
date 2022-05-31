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
    [HideInInspector] public bool FallDamage;
    [HideInInspector] public float MaxSpeedOnGround;
    [HideInInspector] public float MaxSpeedInAir;
    [HideInInspector] public float JumpForce;
    [HideInInspector] public float GravityForce;
    [HideInInspector] public float MaxChargeDuration;
    [HideInInspector] public int MaxAmmo;
    [HideInInspector] public float BulletSpreadAngle;
    [HideInInspector] public float TrampoplanteForce;
    [HideInInspector] public float MinSpeedFallDamage;
    [HideInInspector] public float FallDamageValeurAtMinSpeed;
    [HideInInspector] public float MaxSpeedFallDamage;
    [HideInInspector] public float FallDamageValeurAtMaxSpeed;


    [HideInInspector] public int MaxVie;
    [HideInInspector] public int Vie;


    [HideInInspector] public float MaxSoif;
    [HideInInspector] public float MinSoif;

    [HideInInspector] public float MaxGourde;
    [HideInInspector] public float MinGourde;

    [HideInInspector] public float MaxNourriture;
    [HideInInspector] public float MinNourriture;


    [HideInInspector] public bool Collect;
    [HideInInspector] public bool Eat;


    [HideInInspector] public float DelaySoif;
    [HideInInspector] public float DelayNourriture;
    [HideInInspector] public float DegatsNourriture;
    [HideInInspector] public float DegatsSoif;

    [HideInInspector] public int NbIngredientA;
    [HideInInspector] public int NbIngredientB;
    [HideInInspector] public int NbIngredientC;
    [HideInInspector] public int NbIngredientD;
    [HideInInspector] public int NbIngredientE;
    [HideInInspector] public int NbIngredientF;
    [HideInInspector] public int NbIngredientG;

    [HideInInspector] public int NbRecette1;
    [HideInInspector] public int NbRecette2;
    [HideInInspector] public int NbRecette3;
    [HideInInspector] public int NbRecette4;
    [HideInInspector] public int NbRecette5;

    [HideInInspector] public float BulletGravity;
    [HideInInspector] public float BulletSpeed;


    [HideInInspector] public float BruteWalkSpeed;
    [HideInInspector] public float BruteRunSpeed;
    [HideInInspector] public float BruteAngleSpeed;
    [HideInInspector] public float BruteAttackDistance;
    [HideInInspector] public float BruteAttackStopDistance;
    [HideInInspector] public float BruteDetectDistance;
    [HideInInspector] public float BruteAcceleration;

    [HideInInspector] public float TourelleWalkSpeed;
    [HideInInspector] public float TourelleRunSpeed;
    [HideInInspector] public float TourelleAngleSpeed;
    [HideInInspector] public float TourelleAttackDistance;
    [HideInInspector] public float TourelleAttackStopDistance;
    [HideInInspector] public float TourelleDetectDistance;
    [HideInInspector] public float TourelleAcceleration;

    [HideInInspector] public float FrondeWalkSpeed;
    [HideInInspector] public float FrondeRunSpeed;
    [HideInInspector] public float FrondeAngleSpeed;
    [HideInInspector] public float FrondeAttackDistance;
    [HideInInspector] public float FrondeAttackStopDistance;
    [HideInInspector] public float FrondeDetectDistance;
    [HideInInspector] public float FrondeAcceleration;


    public void Start()
    {
        SaveData data = SaveToyboxScript.LoadData();
        if (data != null)
        {
            FallDamage = data.FallDamage;
            MaxSpeedOnGround = data.MovementSpeedOnGround;
            MaxSpeedInAir = data.MovementSpeedInAir;
            JumpForce = data.JumpForce;
            GravityForce = data.GravityForce;
            MaxChargeDuration = data.MaxChargeDuration;
            MaxAmmo = data.MaxAmmo;
            BulletSpreadAngle = data.BulletSpreadAngle;
            TrampoplanteForce = data.TrampoplanteForce;
            MinSpeedFallDamage = data.MinSpeedFallDamage;
            FallDamageValeurAtMinSpeed = data.FallDamageValeurAtMinSpeed;
            MaxSpeedFallDamage = data.MaxSpeedFallDamage;
            FallDamageValeurAtMaxSpeed = data.FallDamageValeurAtMaxSpeed;

            Vie = data.Vie;
            MaxVie = data.MaxVie;

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

            BulletGravity = data.BulletGravity;
            BulletSpeed = data.BulletSpeed;



            BruteWalkSpeed = data.BruteWalkSpeed;
            BruteRunSpeed = data.BruteRunSpeed;
            BruteAngleSpeed = data.BruteAngleSpeed;
            BruteAttackDistance = data.BruteAttackDistance;
            BruteAttackStopDistance = data.BruteAttackStopDistance;
            BruteDetectDistance = data.BruteDetectDistance;
            BruteAcceleration = data.BruteAcceleration;

            TourelleWalkSpeed = data.TourelleWalkSpeed;
            TourelleRunSpeed = data.TourelleRunSpeed;
            TourelleAngleSpeed = data.TourelleAngleSpeed;
            TourelleAttackDistance = data.TourelleAttackDistance;
            TourelleAttackStopDistance = data.TourelleAttackStopDistance;
            TourelleDetectDistance = data.TourelleDetectDistance;
            TourelleAcceleration = data.TourelleAcceleration;

            FrondeWalkSpeed = data.FrondeWalkSpeed;
            FrondeRunSpeed = data.FrondeRunSpeed;
            FrondeAngleSpeed = data.FrondeAngleSpeed;
            FrondeAttackDistance = data.FrondeAttackDistance;
            FrondeAttackStopDistance = data.FrondeAttackStopDistance;
            FrondeDetectDistance = data.FrondeDetectDistance;
            FrondeAcceleration = data.FrondeAcceleration;

        }
        else
        {
            FallDamage = true;
            MaxSpeedOnGround = 7;
            MaxSpeedInAir = 7;
            JumpForce = 11;
            GravityForce = 33;
            MaxChargeDuration = 5;
            MaxAmmo = 5;
            BulletSpreadAngle = 5;
            TrampoplanteForce = 35;
            MinSpeedFallDamage = 26;
            FallDamageValeurAtMinSpeed = 5;
            MaxSpeedFallDamage = 52;
            FallDamageValeurAtMaxSpeed = 20;


            Vie = 100;
            MaxVie = 100;
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

            BulletGravity = 10;
            BulletSpeed = 3;


            BruteWalkSpeed = 3f;
            BruteRunSpeed = 4.5f;
            BruteAngleSpeed = 120f;
            BruteAttackDistance = 2f;
            BruteAttackStopDistance = 2.3f;
            BruteDetectDistance = 8f;
            BruteAcceleration = 8f;

            TourelleWalkSpeed = 3f;
            TourelleRunSpeed = 4.5f;
            TourelleAngleSpeed = 120f;
            TourelleAttackDistance = 6f;
            TourelleAttackStopDistance = 10f;
            TourelleDetectDistance = 10f;

            FrondeWalkSpeed = 3f;
            FrondeRunSpeed = 4.5f;
            FrondeAngleSpeed = 120f;
            FrondeAttackDistance = 6f;
            FrondeAttackStopDistance = 10f;
            FrondeDetectDistance = 10f;
        }
    }
}
