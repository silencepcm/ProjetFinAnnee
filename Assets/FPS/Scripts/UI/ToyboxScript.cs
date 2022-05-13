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
                switch (element.name)
                {
                    case "CanMove":
                        toggle.isOn = GameManager.Instance.Movement;
                        movementUISpeedOnGround.SetActive(toggle.isOn);
                        movementUISpeedInAir.SetActive(toggle.isOn);    
                        playerInput.SetCanDo(toggle.isOn, "Movement");
                        break;
                    case "CanJump":
                        toggle.isOn = GameManager.Instance.Saut;
                        playerInput.SetCanDo(toggle.isOn, "Jump");
                        for (int i = 0; i < jumpUIObjects.Count; ++i)
                        {
                            jumpUIObjects[i].SetActive(toggle.isOn);
                        }
                            break;
                    case "Inventaire":
                        toggle.isOn = GameManager.Instance.Inventaire;
                        InventaireUIFeedBack.SetActive(toggle.isOn);
                        playerInput.SetCanDo(toggle.isOn, "Inventaire");
                        break;
                    case "Tir":
                        toggle.isOn = GameManager.Instance.Tir;
                        playerInput.SetCanDo(GameManager.Instance.Tir, "Tir");
                        for (int i = 0; i < tirUIObjects.Count; ++i)
                        {
                            tirUIObjects[i].SetActive(toggle.isOn);
                        }
                            break;
                    case "Trampoplante":
                        toggle.isOn = GameManager.Instance.Trampoplante;
                        foreach (var obj in trampolantes)
                        {
                            obj.SetActive(GameManager.Instance.Trampoplante);
                        }
                        for (int i = 0; i < trampolanteUIParams.Count; ++i)
                        {
                            trampolanteUIParams[i].SetActive(GameManager.Instance.Trampoplante);
                            switch (trampolanteUIParams[i].name)
                            {
                                case "TrampoplanteForce":
                                    trampolanteUIParams[i].GetComponent<TMP_InputField>().text = GameManager.Instance.TrampoplanteForce.ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case "FallDamage":
                        toggle.isOn = GameManager.Instance.FallDamage;
                        playerCharacterController.RecievesFallDamage = GameManager.Instance.FallDamage;
                        MinSpeedFallDamage.SetActive(GameManager.Instance.FallDamage);
                        MaxSpeedFallDamage.SetActive(GameManager.Instance.FallDamage);
                        FallDamageVALEURatMinSpeed.SetActive(GameManager.Instance.FallDamage);
                        FallDamageVALEURatMaxSpeed.SetActive(GameManager.Instance.FallDamage);
                        break;
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
                    case "BulletsPerShot":
                        text.text = GameManager.Instance.BulletsPerShot.ToString();
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
        public void MovementActivate(Toggle toggle)
        {

            movementUISpeedOnGround.SetActive(toggle.isOn);
            movementUISpeedOnGround.GetComponent<TMP_InputField>().text = GameManager.Instance.MaxSpeedOnGround.ToString();
            playerInput.SetCanDo(toggle.isOn, "Movement");
            GameManager.Instance.Movement = toggle.isOn;
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
        public void JumpActivate(Toggle toggle)
        {
            playerInput.SetCanDo(toggle.isOn, "Jump");
            GameManager.Instance.Saut = toggle.isOn;
            for (int i = 0; i < jumpUIObjects.Count; ++i)
            {
                jumpUIObjects[i].SetActive(toggle.isOn);
                switch (jumpUIObjects[i].name)
                {
                    case "JumpForce":
                        jumpUIObjects[i].GetComponent<TMP_InputField>().text = GameManager.Instance.JumpForce.ToString();
                        break;
                    case "GravityForce":
                        jumpUIObjects[i].GetComponent<TMP_InputField>().text = GameManager.Instance.GravityForce.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        public void SetTir(Toggle toggle)
        {
            playerInput.SetCanDo(toggle.isOn, "Tir");
            GameManager.Instance.Tir = toggle.isOn;
            for (int i = 0; i < tirUIObjects.Count; ++i)
            {
                tirUIObjects[i].SetActive(toggle.isOn);
                switch (tirUIObjects[i].name)
                {
                    case "MaxAmmo":
                        tirUIObjects[i].GetComponent<TMP_InputField>().text = GameManager.Instance.MaxAmmo.ToString();
                        break;
                    case "MaxChargeDuration":
                        tirUIObjects[i].GetComponent<TMP_InputField>().text = GameManager.Instance.MaxChargeDuration.ToString();
                        break;
                    case "BulletSpreadAngle":
                        tirUIObjects[i].GetComponent<TMP_InputField>().text = GameManager.Instance.BulletSpreadAngle.ToString();
                        break;
                    case "BulletsPerShot":
                        tirUIObjects[i].GetComponent<TMP_InputField>().text = GameManager.Instance.BulletsPerShot.ToString();
                        break;
                    default:
                        break;
                }
            }
        }


        public void SetTrampoplantes(Toggle toggle)
        {
            GameManager.Instance.Trampoplante = toggle.isOn;
            foreach (var obj in trampolantes)
            {
                obj.SetActive(toggle.isOn);
            }
            for (int i = 0; i < trampolanteUIParams.Count; ++i)
            {
                trampolanteUIParams[i].SetActive(toggle.isOn);
                switch (trampolanteUIParams[i].name)
                {
                    case "TrampoplanteForce":
                        trampolanteUIParams[i].GetComponent<TMP_InputField>().text = GameManager.Instance.TrampoplanteForce.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        public void SetInventaire(Toggle toggle)
        {
            GameManager.Instance.Inventaire = toggle.isOn;
            InventaireUIFeedBack.SetActive(toggle.isOn);
            playerInput.SetCanDo(toggle.isOn, "Inventaire");
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
        public void SetBulletsPerShot(TMP_InputField textObj)
        {
            if (int.TryParse(textObj.text, out int f) && playerWeaponsController != null)
            {
                playerWeaponsController.BulletsPerShot = f;
                GameManager.Instance.BulletsPerShot = f;

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
