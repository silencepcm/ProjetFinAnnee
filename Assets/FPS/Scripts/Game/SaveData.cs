namespace Unity.FPS.Game
{
    [System.Serializable]
    public class SaveData
    {
        public bool FallDamage;
        public float MovementSpeedOnGround;
        public float MovementSpeedInAir;
        public float JumpForce;
        public float GravityForce;
        public float MaxChargeDuration;
        public int MaxAmmo;
        public float BulletSpreadAngle;
        public float TrampoplanteForce;
        public float MinSpeedFallDamage;
        public float FallDamageValeurAtMinSpeed;
        public float MaxSpeedFallDamage;
        public float FallDamageValeurAtMaxSpeed;
        public WeaponShootType WeaponType;


        public float maxThirst;
        public float minThirst;

        public float maxGourde;
        public float minGourde;

        public float maxNourriture;
        public float minNourriture;

        public bool Collect;
        public bool Eat;

        public float DelaySoif;
        public float DelayNourriture;
        public float DegatsSoif;
        public float DegatsNourriture;

        public float Eau;
        public float nourriture;


        public int NbIngredientA;
        public int NbIngredientB;
        public int NbIngredientC;
        public int NbIngredientD;
        public int NbIngredientE;
        public int NbIngredientF;
        public int NbIngredientG;

        public int NbRecette1;
        public int NbRecette2;
        public int NbRecette3;
        public int NbRecette4;
        public int NbRecette5;

        public float BulletGravity;
        public float BulletSpeed;
    }
}
