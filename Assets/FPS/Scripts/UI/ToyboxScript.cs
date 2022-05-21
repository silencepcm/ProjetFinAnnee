using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.FPS.Game;
namespace Unity.FPS.Gameplay
{
    public class ToyboxScript : MonoBehaviour
    {
        private PlayerInputHandler playerInput;
        private PlayerCharacterController playerCharacterController;
        public List<GameObject> jumpUIObjects;
        public List<GameObject> tirUIObjects;
        public List<GameObject> trampolantes;
        public List<GameObject> trampolanteUIParams;
        public GameObject movementUISpeedOnGround;
        public GameObject movementUISpeedInAir;
        public GameObject MinSpeedFallDamage;
        public GameObject MaxSpeedFallDamage;
        public GameObject FallDamageVALEURatMinSpeed;
        public GameObject FallDamageVALEURatMaxSpeed;
        public GameObject InventaireUIFeedBack;
        public GameObject UIPanel;
        public GameObject InnerPanel;
        WeaponController playerWeaponsController;
        public List<Transform> toggleUI;
        public List<Transform> valeurUI;
        void Start()
        {
            playerInput = FindObjectOfType<PlayerInputHandler>();
            playerCharacterController = FindObjectOfType<PlayerCharacterController>();
            playerWeaponsController = playerCharacterController.GetComponent<PlayerWeaponsManager>().Weapon;
            LoadValues();
        }
        public void LoadValues()
        {

            foreach (Transform element in toggleUI)
            {
                Toggle toggle = element.GetComponent<Toggle>();
                if (element.name == "FallDamage")
                {
                    toggle.isOn = GameManager.Instance.FallDamage;
                    playerCharacterController.RecievesFallDamage = GameManager.Instance.FallDamage;
                    MinSpeedFallDamage.SetActive(GameManager.Instance.FallDamage);
                    MaxSpeedFallDamage.SetActive(GameManager.Instance.FallDamage);
                    FallDamageVALEURatMinSpeed.SetActive(GameManager.Instance.FallDamage);
                    FallDamageVALEURatMaxSpeed.SetActive(GameManager.Instance.FallDamage);
                }
            }
            foreach (Transform element in valeurUI)
            {
                TMP_InputField text = element.GetComponent<TMP_InputField>();
                switch (element.name)
                {
                    case "MovementSpeedOnGround":
                        text.text = GameManager.Instance.MaxSpeedOnGround.ToString();
                        break;
                    case "MovementSpeedInAir":
                        text.text = GameManager.Instance.MaxSpeedInAir.ToString();
                        break;
                    case "JumpForce":
                        text.text  = GameManager.Instance.JumpForce.ToString();
                        break;
                    case "GravityForce":
                        text.text = GameManager.Instance.GravityForce.ToString();
                        break;
                    case "MaxChargeDuration":
                        text.text = GameManager.Instance.MaxChargeDuration.ToString();
                        break;
                    case "MaxAmmo":
                        text.text = GameManager.Instance.MaxAmmo.ToString();
                        break;
                    case "BulletSpreadAngle":
                        text.text = GameManager.Instance.BulletSpreadAngle.ToString();
                        break;
                    case "TrampoplanteForce":
                        text.text = GameManager.Instance.TrampoplanteForce.ToString();
                        break;
                    case "MinSpeedFallDamage":
                        text.text = GameManager.Instance.MinSpeedFallDamage.ToString();
                        break;
                    case "FallDamageValeurAtMinSpeed":
                        text.text = GameManager.Instance.FallDamageValeurAtMinSpeed.ToString();
                        break;
                    case "MaxSpeedFallDamage":
                        text.text = GameManager.Instance.MaxSpeedFallDamage.ToString();
                        break;
                    case "FallDamageValeurAtMaxSpeed":
                        text.text = GameManager.Instance.FallDamageValeurAtMaxSpeed.ToString();
                        break;
                }
            }
        }
        public void FallDamageActivate(Toggle toggle)
        {
            playerCharacterController.RecievesFallDamage = toggle.isOn;
            MinSpeedFallDamage.SetActive(toggle.isOn);
            MaxSpeedFallDamage.SetActive(toggle.isOn);
            FallDamageVALEURatMinSpeed.SetActive(toggle.isOn);
            FallDamageVALEURatMaxSpeed.SetActive(toggle.isOn);
            GameManager.Instance.FallDamage = toggle.isOn;
        }

        public void SetGravityForce(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.GravityDownForce = f;
                GameManager.Instance.GravityForce = f;
            }
        }

        public void SetMovementSpeedOnGround(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.MaxSpeedOnGround = f;
                GameManager.Instance.MaxSpeedOnGround = f;
            }
        }

        public void SetMovementSpeedInAir(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.MaxSpeedInAir = f;
                GameManager.Instance.MaxSpeedInAir = f;
            }
        }

        public void SetJumpForce(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.JumpForce = f;
                GameManager.Instance.JumpForce = f;

            }
        }
        public void SetMaxAmmo(TMP_InputField textObj)
        {
            if (int.TryParse(textObj.text, out int f) && playerWeaponsController != null)
            {
                playerWeaponsController.MaxAmmo = f;
                GameManager.Instance.MaxAmmo = f;

            }
        }
        public void SetMaxChargeDuration(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f) && playerWeaponsController != null)
            {
                playerWeaponsController.MaxChargeDuration = f;
                GameManager.Instance.MaxChargeDuration = f;

            }
        }
        public void SetSpreadAngle(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f) && playerWeaponsController != null)
            {
                playerWeaponsController.BulletSpreadAngle = f;
                GameManager.Instance.BulletSpreadAngle = f;

            }
        }
        public void SetWeaponsManager()
        {
            playerWeaponsController = GameObject.Find("Player").GetComponent<WeaponController>();
        }
        public void SetTrampoplanteForce(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                GameManager.Instance.TrampoplanteForce = f;
                playerCharacterController.TrampoplanteForce = f;
            }
        }


        public void SetMinSpeedFallDamage(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.MinSpeedForFallDamage = f;
                GameManager.Instance.MinSpeedFallDamage = f;
            }
        }
        public void SetMaxSpeedFallDamage(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.MaxSpeedForFallDamage = f;
                GameManager.Instance.MaxSpeedFallDamage = f;
            }
        }
        public void SetMinFallDamage(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.FallDamageAtMinSpeed = f;
                GameManager.Instance.FallDamageValeurAtMinSpeed = f;
            }
        }
        public void SetMaxFallDamage(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.FallDamageAtMaxSpeed = f;
                GameManager.Instance.FallDamageValeurAtMaxSpeed = f;
            }
        }

        public void SaveChanges()
        {
            SaveToyboxScript.save_game();
        }
    }
}
