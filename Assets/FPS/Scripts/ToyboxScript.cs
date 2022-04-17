using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Unity.FPS.Gameplay
{
    public class ToyboxScript : MonoBehaviour
    {

        private PlayerInputHandler playerInput;
        private PlayerCharacterController playerCharacterController;
        public List<GameObject> activators;
        public Canvas BoxInterface;
        public List<GameObject> jumpUIObjects;
        public GameObject movementUISpeedOnGround;
        public GameObject InventaireUIFeedBack;
        void Start()
        {
            playerInput = FindObjectOfType<PlayerInputHandler>();
            playerCharacterController = FindObjectOfType<PlayerCharacterController>();
        }
        public void ToyboxInterfaceOnOff()
        {
            BoxInterface.gameObject.SetActive(!BoxInterface.isActiveAndEnabled);
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
        public void SetInventaire(Toggle toggle)
        {
            InventaireUIFeedBack.SetActive(toggle.isOn);
            playerInput.SetCanDo(toggle.isOn, "Inventaire");
        }
        public void SetGravityForce(TMP_InputField textObj)
        {
            playerCharacterController.GravityDownForce = int.Parse(textObj.text);
        }
        public void SetMovementSpeedOnGround(TMP_InputField textObj)
        {
            playerCharacterController.MaxSpeedOnGround = int.Parse(textObj.text);
        }
        public void SetMovementSpeedInAir(TMP_InputField textObj)
        {
            playerCharacterController.MaxSpeedInAir = int.Parse(textObj.text);
        }
        public void SetJumpForce(TMP_InputField textObj)
        {
            playerCharacterController.JumpForce = int.Parse(textObj.text);
        }
    }
}
