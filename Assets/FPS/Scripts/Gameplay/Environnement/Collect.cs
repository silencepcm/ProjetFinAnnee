using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class Collect : MonoBehaviour
    {

        public AudioClip CollectSfx;
        public GameObject CollectVfxPrefab;
        public GameObject Inventaire;

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
            PlayPickupFeedback();
            gameObject.SetActive(false);
            if (name != "Sac")
            {
                if(Type == TypeRessource.Munitite)
                {
                    Inventaire.GetComponent<InventaireScript>().Munitite += 1;
                }
                else if (Type == TypeRessource.Directite)
                {
                    Inventaire.GetComponent<InventaireScript>().Directite += 1;
                }
                else if (Type == TypeRessource.Clochite)
                {
                    Inventaire.GetComponent<InventaireScript>().Clochite += 1;
                }
                else if(Type == TypeRessource.Baie)
                {
                    Inventaire.GetComponent<InventaireScript>().Baie += 1;
                }
                else if (Type == TypeRessource.Fruit)
                {
                    Inventaire.GetComponent<InventaireScript>().Fruit += 1;
                }
                else if(Type == TypeRessource.Plontite1)
                {
                    Inventaire.GetComponent<InventaireScript>().Plontite1 += 1;
                }
                else
                {
                    Inventaire.GetComponent<InventaireScript>().Poussite += 1;
                }
                GetComponentInParent<Spawner_Ingredient>().RespawnWaiter(gameObject);
            }
        }
    }
}