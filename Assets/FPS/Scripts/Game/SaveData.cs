namespace Unity.FPS.Game
{
    [System.Serializable]
    public class SaveData
    {
        public bool Movement;
        public bool Saut;
        public bool Tir;
        public bool Trampoplante;
        public bool FallDamage;
        public bool Inventaire;
        public float MovementSpeed;
        public float JumpForce;
        public float GravityForce;
        public float MaxChargeDuration;
        public int MaxAmmo;
        public float BulletSpreadAngle;
        public int BulletsPerShot;
        public float TrampoplanteForce;
        public float MinSpeedFallDamage;
        public float FallDamageValeurAtMinSpeed;
        public float MaxSpeedFallDamage;
        public float FallDamageValeurAtMaxSpeed;
        public WeaponShootType WeaponType;
    }
}
