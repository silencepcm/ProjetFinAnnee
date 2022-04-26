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
        public List<GameObject> activators;
        public List<GameObject> jumpUIObjects;
        public List<GameObject> tirUIObjects;
        public List<GameObject> trampolantes;
        public List<GameObject> trampolanteUIParams;
        public GameObject movementUISpeedOnGround;
        public GameObject MinSpeedFallDamage;
        public GameObject MaxSpeedFallDamage;
        public GameObject FallDamageVALEURatMinSpeed;
        public GameObject FallDamageVALEURatMaxSpeed;
        public GameObject InventaireUIFeedBack;
        WeaponController playerWeaponsController;
        void Start()
        {
            playerInput = FindObjectOfType<PlayerInputHandler>();
            playerCharacterController = FindObjectOfType<PlayerCharacterController>();
        }
        public void MovementActivate(Toggle toggle)
        {

                movementUISpeedOnGround.SetActive(toggle.isOn);
            movementUISpeedOnGround.GetComponent<TMP_InputField>().text = playerCharacterController.MaxSpeedOnGround.ToString();
            playerInput.SetCanDo(toggle.isOn, "MovementSpeed");
        }
        public void FallDamageActivate(Toggle toggle)
        {
            playerCharacterController.RecievesFallDamage = toggle.isOn;
            MinSpeedFallDamage.SetActive(toggle.isOn);
            MaxSpeedFallDamage.SetActive(toggle.isOn);
            FallDamageVALEURatMinSpeed.SetActive(toggle.isOn);
            FallDamageVALEURatMaxSpeed.SetActive(toggle.isOn);
            MinSpeedFallDamage.GetComponent<TMP_InputField>().text = playerCharacterController.MinSpeedForFallDamage.ToString();
            MaxSpeedFallDamage.GetComponent<TMP_InputField>().text = playerCharacterController.MaxSpeedForFallDamage.ToString();
            FallDamageVALEURatMinSpeed.GetComponent<TMP_InputField>().text = playerCharacterController.FallDamageAtMinSpeed.ToString();
            FallDamageVALEURatMaxSpeed.GetComponent<TMP_InputField>().text = playerCharacterController.FallDamageAtMaxSpeed.ToString();
        }
        public void JumpActivate(Toggle toggle)
        {
            playerInput.SetCanDo(toggle.isOn, "JumpForce");
                for(int i =0; i < jumpUIObjects.Count; ++i)
                {
                    jumpUIObjects[i].SetActive(toggle.isOn);
                    switch (jumpUIObjects[i].name)
                    {
                        case "JumpForce":
                        jumpUIObjects[i].GetComponent<TMP_InputField>().text = playerCharacterController.JumpForce.ToString();
                            break;
                        case "GravityForce":
                            jumpUIObjects[i].GetComponent<TMP_InputField>().text = playerCharacterController.GravityDownForce.ToString();
                            break;
                        default:
                            break;
                    }
                }
        }

        public void SetTir(Toggle toggle)
        {
            playerInput.SetCanDo(toggle.isOn, "Tir");
            for (int i = 0; i < tirUIObjects.Count; ++i)
            {
                tirUIObjects[i].SetActive(toggle.isOn);
                switch (tirUIObjects[i].name)
                {
                    case "MaxAmmo":
                        tirUIObjects[i].GetComponent<TMP_InputField>().text = playerWeaponsController.MaxAmmo.ToString();
                        break;
                    case "MaxChargeDuration":
                        tirUIObjects[i].GetComponent<TMP_InputField>().text = playerWeaponsController.MaxChargeDuration.ToString();
                        break;
                    case "BulletSpreadAngle":
                        tirUIObjects[i].GetComponent<TMP_InputField>().text = playerWeaponsController.BulletSpreadAngle.ToString();
                        break;
                    case "BulletsPerShot":
                        tirUIObjects[i].GetComponent<TMP_InputField>().text = playerWeaponsController.BulletsPerShot.ToString();
                        break;
                    case "WeaponType":
                        tirUIObjects[i].transform.Find("Label").GetComponent<TextMeshProUGUI>().text = playerWeaponsController.ShootType.ToString();
                        break;
                    default:
                        break;
                }
            }
        }


        public void SetTrampoplantes(Toggle toggle)
        {
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
                        trampolanteUIParams[i].GetComponent<TMP_InputField>().text = playerCharacterController.TrampoplanteForce.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        public void SetInventaire(Toggle toggle)
        {
            InventaireUIFeedBack.SetActive(toggle.isOn);
            playerInput.SetCanDo(toggle.isOn, "Inventaire");
        }

        public void SetGravityForce(TMP_InputField textObj)
        {
            if(textObj.text.Length > 0)
            playerCharacterController.GravityDownForce = float.Parse(textObj.text);
        }

        public void SetMovementSpeedOnGround(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.MaxSpeedOnGround = f;
            }
        }

        public void SetMovementSpeedInAir(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.MaxSpeedInAir = f;
            }
        }

        public void SetJumpForce(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.JumpForce = f;
            }
        }
        public void SetMaxAmmo(TMP_InputField textObj)
        {
            if (int.TryParse(textObj.text, out int f))
            {
                playerWeaponsController.MaxAmmo = f;
            }
        }
        public void SetMaxChargeDuration(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerWeaponsController.MaxChargeDuration = f;
            }
        }
        public void SetSpreadAngle(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerWeaponsController.BulletSpreadAngle = f;
            }
        }
        public void SetBulletsPerShot(TMP_InputField textObj)
        {
            if (int.TryParse(textObj.text, out int f))
            {
                playerWeaponsController.BulletsPerShot = f;
            }
        }
        public void setToggleSettingsTypeWeapon(TMP_Dropdown dropdown)
        {
            switch (dropdown.options[dropdown.value].text)
            {
                case "Handle":
                    playerWeaponsController.ShootType = WeaponShootType.Manual;
                    break;
                case "Automatic":
                    playerWeaponsController.ShootType = WeaponShootType.Automatic;
                    break;
                case "Charge":
                    playerWeaponsController.ShootType = WeaponShootType.Charge;
                    break;
            } 
        }
        public void SetWeaponsManager()
        {
            playerWeaponsController = playerCharacterController.GetComponent<PlayerWeaponsManager>().WeaponParentSocket.GetChild(0).GetComponent<WeaponController>();
        }
        public void SetTrampoplanteForce(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.TrampoplanteForce = f;
            }
        }


        public void SetMinSpeedFallDamage(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.MinSpeedForFallDamage = f;
            }
        }
        public void SetMaxSpeedFallDamage(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.MaxSpeedForFallDamage = f;
            }
        }
        public void SetMinFallDamage(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.FallDamageAtMinSpeed = f;
            }
        }
        public void SetMaxFallDamage(TMP_InputField textObj)
        {
            if (float.TryParse(textObj.text, out float f))
            {
                playerCharacterController.FallDamageAtMaxSpeed = f;
            }
        }
    }
}
