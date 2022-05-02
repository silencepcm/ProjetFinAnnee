using UnityEngine;
using System.IO;
namespace Unity.FPS.Game
{
    public static class SaveToyboxScript
    {
        public static string file_path() { return Application.dataPath + "/Toyboxdata.mine"; }

        public static SaveData LoadData()
        {
            if (File.Exists(file_path()))
            {
                string loaded_data = File.ReadAllText(file_path());
                SaveData lod = JsonUtility.FromJson<SaveData>(loaded_data);
                Debug.Log("lod.player_health");//just to just if the data is correct
                return lod;
            }
            else
            {
                Debug.Log("File doesn't exist");
                return null;
            }
        }

        public static void save_game()
        {
            SaveData data = new SaveData();
            data.Movement = GameManager.Instance.Movement;
            data.Saut = GameManager.Instance.Saut;
            data.Tir = GameManager.Instance.Tir;
            data.Trampoplante = GameManager.Instance.Trampoplante;
            data.FallDamage = GameManager.Instance.FallDamage;
            data.Inventaire = GameManager.Instance.Inventaire;
            data.MovementSpeed = GameManager.Instance.MaxSpeedOnGround;
            data.JumpForce = GameManager.Instance.JumpForce;
            data.GravityForce = GameManager.Instance.GravityForce;
            data.MaxChargeDuration = GameManager.Instance.MaxChargeDuration;
            data.MaxAmmo = GameManager.Instance.MaxAmmo;
            data.BulletSpreadAngle = GameManager.Instance.BulletSpreadAngle;
            data.BulletsPerShot = GameManager.Instance.BulletsPerShot;
            data.TrampoplanteForce = GameManager.Instance.TrampoplanteForce;
            data.MinSpeedFallDamage = GameManager.Instance.MinSpeedFallDamage;
            data.FallDamageValeurAtMinSpeed = GameManager.Instance.FallDamageValeurAtMinSpeed;
            data.MaxSpeedFallDamage = GameManager.Instance.MaxSpeedFallDamage;
            data.FallDamageValeurAtMaxSpeed = GameManager.Instance.FallDamageValeurAtMaxSpeed;

            string json_data = JsonUtility.ToJson(data);
            File.WriteAllText(file_path(), json_data);
        }
    }
    }
