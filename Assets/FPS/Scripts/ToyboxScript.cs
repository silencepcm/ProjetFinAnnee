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
        public List<GameObject> movementUIObjects;
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
            foreach (var element in movementUIObjects)
            {
                element.SetActive(toggle.isOn);
            }
            playerInput.SetCanDo(toggle.isOn, "MovementSpeed");
        }
        public void JumpActivate(Toggle toggle)
        {
            foreach (var element in jumpUIObjects)
            {
                element.SetActive(toggle.isOn);
            }
            playerInput.SetCanDo(toggle.isOn, "JumpForce");
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
