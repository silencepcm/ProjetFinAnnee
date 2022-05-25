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
            data.FallDamage = GameManager.Instance.FallDamage;
            data.MovementSpeedOnGround = GameManager.Instance.MaxSpeedOnGround;
            data.MovementSpeedInAir = GameManager.Instance.MaxSpeedInAir;
            data.JumpForce = GameManager.Instance.JumpForce;
            data.GravityForce = GameManager.Instance.GravityForce;
            data.MaxChargeDuration = GameManager.Instance.MaxChargeDuration;
            data.MaxAmmo = GameManager.Instance.MaxAmmo;
            data.BulletSpreadAngle = GameManager.Instance.BulletSpreadAngle;
            data.TrampoplanteForce = GameManager.Instance.TrampoplanteForce;
            data.MinSpeedFallDamage = GameManager.Instance.MinSpeedFallDamage;
            data.FallDamageValeurAtMinSpeed = GameManager.Instance.FallDamageValeurAtMinSpeed;
            data.MaxSpeedFallDamage = GameManager.Instance.MaxSpeedFallDamage;
            data.FallDamageValeurAtMaxSpeed = GameManager.Instance.FallDamageValeurAtMaxSpeed;


            data.NbIngredientA = GameManager.Instance.NbIngredientA;
            data.NbIngredientB = GameManager.Instance.NbIngredientB;
            data.NbIngredientC = GameManager.Instance.NbIngredientC;
            data.NbIngredientD = GameManager.Instance.NbIngredientD;
            data.NbIngredientE = GameManager.Instance.NbIngredientE;
            data.NbIngredientF = GameManager.Instance.NbIngredientF;
            data.NbIngredientG = GameManager.Instance.NbIngredientG;

            data.Eau = GameManager.Instance.eau;
            data.nourriture = GameManager.Instance.Nourriture;

            data.NbRecette1 = GameManager.Instance.NbRecette1;
            data.NbRecette2 = GameManager.Instance.NbRecette2;
            data.NbRecette3 = GameManager.Instance.NbRecette3;
            data.NbRecette4 = GameManager.Instance.NbRecette4;
            data.NbRecette5 = GameManager.Instance.NbRecette5;

            data.BulletGravity = GameManager.Instance.BulletGravity;
            data.BulletSpeed = GameManager.Instance.BulletSpeed;


            string json_data = JsonUtility.ToJson(data);
            File.WriteAllText(file_path(), json_data);
        }
    }
}
