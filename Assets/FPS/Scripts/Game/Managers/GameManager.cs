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
                    GameObject container = new GameObject("GameManager");
                    _instance = container.AddComponent<GameManager>();
                    _instance.Start();
                    container.tag = "GameManager";
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
    public WeaponShootType WeaponType;

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
            MaxSpeedOnGround = data.MovementSpeed;
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
            WeaponType = data.WeaponType;
        }
        else
        {
            Movement = true;
            Saut = true;
            Tir = true;
            Trampoplante = true;
            FallDamage = true;
            Inventaire = true;
            MaxSpeedOnGround = 1;
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
            WeaponType = WeaponShootType.Automatic;
        }
    }
}
