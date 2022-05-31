using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class Collect : MonoBehaviour
    {

        public AudioClip CollectSfx;
        public GameObject CollectVfxPrefab;

        public enum TypeRessource
        {
            Munitite,
            Directite,
            Clochite,
            Baie,
            Fruit,
            Poussite,
            Plontite1
        }

        public TypeRessource Type;

        Collider m_Collider;
        Vector3 m_StartPosition;
        bool m_HasPlayedFeedback;

        public void Start()
        {
            m_Collider = GetComponent<Collider>();

            m_Collider.isTrigger = true;
            m_StartPosition = transform.position;
        }

        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            PlayerCharacterController pickingPlayer = other.GetComponentInParent<PlayerCharacterController>();
            if (pickingPlayer)
            {
                pickingPlayer.SetCanCollect(gameObject, true);
            }
        }
        void OnTriggerExit(Collider other)
        {
            PlayerCharacterController pickingPlayer = other.GetComponentInParent<PlayerCharacterController>();

            if (pickingPlayer)
            {
                pickingPlayer.SetCanCollect(gameObject, false);
            }
        }

        public void PlayPickupFeedback()
        {
            if (m_HasPlayedFeedback)
                return;

            if (CollectSfx)
            {
                AudioUtility.CreateSFX(CollectSfx, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
            }

            if (CollectVfxPrefab)
            {
                Instantiate(CollectVfxPrefab, transform.position, Quaternion.identity);
            }

            m_HasPlayedFeedback = true;
        }
        public void CollectEvent()
        {
            
            if (Type == TypeRessource.Munitite)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<InventaireScript>().Munitite += 1;
            }
            else if (Type == TypeRessource.Directite)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<InventaireScript>().Directite += 1;
            }
            else if (Type == TypeRessource.Clochite)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<InventaireScript>().Clochite += 1;
            }
            else if (Type == TypeRessource.Baie)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<InventaireScript>().Baie += 1;
            }
            else if (Type == TypeRessource.Fruit)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<InventaireScript>().Fruit += 1;
            }
            else if (Type == TypeRessource.Plontite1)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<InventaireScript>().Plontite1 += 1;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<InventaireScript>().Poussite += 1;
            }

            PlayPickupFeedback();
            gameObject.SetActive(false);
            if (name != "Sac")
            {
                
                GetComponentInParent<Spawner_Ingredient>().RespawnWaiter(gameObject);
            }

           
        }
    }
}