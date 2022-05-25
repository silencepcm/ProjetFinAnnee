using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Unity.FPS.Game;


namespace Unity.FPS.Game
{
    public class ProjectileBase : MonoBehaviour
    {
        public GameObject Owner { get; private set; }
        public Vector3 InitialPosition { get; private set; }
        public Vector3 InitialDirection { get; private set; }
        public Vector3 InheritedMuzzleVelocity { get; private set; }
        public float InitialCharge { get; private set; }
        Rigidbody rb;
        public UnityAction OnShoot;
        public float GravityDownAcceleration => GameManager.Instance.BulletGravity;

        public float speed = 5f;

        public void Shoot(WeaponController controller)
        {
            Owner = controller.Owner;
            InitialPosition = transform.position;
            InitialDirection = transform.forward;
            InheritedMuzzleVelocity = controller.MuzzleWorldVelocity;
            InitialCharge = controller.CurrentCharge;
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward*speed;
            OnShoot?.Invoke();

        }

        private void Update()
        {
            /*   if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10, layerMask))
               {
                   Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                   Debug.Log("Did Hit");
               }*/

            if (GravityDownAcceleration > 0)
            {
                // add gravity to the projectile velocity for ballistic effect
                rb.velocity += Vector3.down * GravityDownAcceleration * Time.deltaTime;
            }


             /*public void OnCollisionEnter(Collision collision)
            {
                if (collision.collider.tag == "Enemy")
                {
                    Debug.Log("ENEMY");
                }
                Destroy(this);
            }*/
        }
        
    }
}