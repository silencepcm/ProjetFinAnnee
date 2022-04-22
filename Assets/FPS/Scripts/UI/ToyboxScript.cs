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
        public GameObject movementUISpeedOnGround;
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
    }
}
