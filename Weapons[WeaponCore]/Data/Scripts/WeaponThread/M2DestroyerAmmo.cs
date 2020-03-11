using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.ShapeDef.Shapes;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.TrajectoryDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.TrajectoryDef.GuidanceType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.DamageScaleDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.DamageScaleDef.ShieldDef.ShieldType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef.AreaEffectType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef;
namespace WeaponThread
{ // Don't edit above this line
    partial class Weapons
    {
        private AmmoDef DestroyerMissileMk1_Ammo => new AmmoDef
        {
            AmmoMagazine = "DestroyerMissileMk1",
                AmmoRound = "DestroyerMissileMk1",
                HybridRound = false, //AmmoMagazine based weapon with energy cost
                EnergyCost = 0.00000000001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
                BaseDamage = 1f,
                Mass = 10f, // in kilograms
                Health = 45f, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
                BackKickForce = 2.5f,

                Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
                {
                    Shape = LineShape,
                    Diameter = 0.1,
                },
                ObjectsHit = new ObjectsHitDef
                {
                    MaxObjectsHit = 0, // 0 = disabled
                    CountBlocks = false, // counts gridBlocks and not just entities hit
                },
                Shrapnel = new ShrapnelDef
                {
                    AmmoRound = "",
                    Fragments = 0,
                    ForwardDegrees = 0,
                    BackwardDegrees = 0,
                },
                DamageScales = new DamageScaleDef
                {
                    MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                    DamageVoxels = true, // true = voxels are vulnerable to this weapon
                    SelfDamage = false, // true = allow self damage.

                    // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                    Characters = 0.2f,
                    Grids = new GridSizeDef
                    {
                        Large = -1f,
                        Small = -1f,
                    },
                    Armor = new ArmorDef
                    {
                        Armor = 0.75f,
                        Light = 0.9f,
                        Heavy = 0.75f,
                        NonArmor = 1.1f,
                    },
                    Shields = new ShieldDef
                    {
                        Modifier = 2f,
                        Type = Kinetic,
                        BypassModifier = -1f,
                    },
                    // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                    Custom = new CustomScalesDef
                    {
                        IgnoreAllOthers = false,
                        Types = new []
                        {
                            new CustomBlocksDef
                            {
                                SubTypeId = "Test1",
                                Modifier = -1f,
                            },
                            new CustomBlocksDef
                            {
                                SubTypeId = "Test2",
                                Modifier = -1f,
                            },
                        },
                    },
                },
                AreaEffect = new AreaDamageDef
                {
                    AreaEffect = Explosive, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                    AreaEffectDamage = 1500f, // 0 = use spillover from BaseDamage, otherwise use this value.
                    AreaEffectRadius = 6f,
                    Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                    {
                        Interval = 60,
                        PulseChance = 75,
                    },
                    Explosions = new ExplosionDef
                    {
                        NoVisuals = true,
                        NoSound = false,
                        Scale = 0.5f,
                        CustomParticle = "Explosion_Missile",
                        CustomSound = "",
                    },
                    Detonation = new DetonateDef
                    {
                        DetonateOnEnd = false,
                        ArmOnlyOnHit = false,
                        DetonationDamage = 0,
                        DetonationRadius = 0,
                    },
                    EwarFields = new EwarFieldsDef
                    {
                        Duration = 60,
                        StackDuration = true,
                        Depletable = false,
                        MaxStacks = 10,
                        TriggerRange = 5f,
                    },
                },
                Beams = new BeamDef
                {
                    Enable = false,
                    VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                    ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                    RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                    OneParticle = false, // Only spawn one particle hit per beam weapon.
                },
                Trajectory = new TrajectoryDef
                {
                    Guidance = Smart,
                    TargetLossDegree = 360f,
                    TargetLossTime = 200, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    AccelPerSec = 30f,
                    DesiredSpeed = 110f,
                    MaxTrajectory = 3500f,
                    FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                    SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                    RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                    Smarts = new SmartsDef
                    {
                        Inaccuracy = 2f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                        Aggressiveness = 1.5f, // controls how responsive tracking is.
                        MaxLateralThrust = 0.50f, // controls how sharp the trajectile may turn
                        TrackingDelay = 150, // Measured in Shape diameter units traveled.
                        MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                        OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    },
                    Mines = new MinesDef
                    {
                        DetectRadius =  200,
                        DeCloakRadius = 100,
                        FieldTime = 1800,
                        Cloak = false,
                        Persist = false,
                    },
                },
                AmmoGraphics = new GraphicDef
                {
                    ModelName = "\\Models\\Weapons\\DestroyerMissile_Mk1_projectile.mwm",
                    VisualProbability = 1f,
                    ShieldHitDraw = true,
                    Particles = new AmmoParticleDef
                    {
                        Ammo = new ParticleDef
                        {
                            Name = "M12_MissileSmokeTrail", //ShipWelderArc
                            Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                            Offset = Vector(x: 0, y: 0, z: 1.5f),
                            Extras = new ParticleOptionDef
                            {
                                Loop = true,
                                Restart = false,
                                MaxDistance = 5000,
                                MaxDuration = 10,
                                Scale = 0.15f,
                            },
                        },
                        Hit = new ParticleDef
                        {
                            Name = "Explosion_Missile",
                            ApplyToShield = true,
                            ShrinkByDistance = true,
                            Color = Color(red: 5, green: 5, blue: 10, alpha: 1),
                            Offset = Vector(x: 0, y: 0, z: 0),
                            Extras = new ParticleOptionDef
                            {
                                Loop = false,
                                Restart = false,
                                MaxDistance = 5000,
                                MaxDuration = 1,
                                Scale = 0.5f,
                                HitPlayChance = 1f,
                            },
                        },
                    },
                    Lines = new LineDef
                    {
                        TracerMaterial = "WeaponLaser", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                        ColorVariance = Random(start: 0.75f, end: 2f), // multiply the color by random values within range.
                        WidthVariance = Random(start: 0f, end: 0.025f), // adds random value to default width (negatives shrinks width)
                        Tracer = new TracerBaseDef
                        {
                            Enable = false,
                            Length = 1f,
                            Width = 0.1f,
                            Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        },
                        Trail = new TrailDef
                        {
                            Enable = false,
                            Material = "WeaponLaser",
                            DecayTime = 128,
                            Color = Color(red: 0, green: 0, blue: 1, alpha: 1),
                            Back = true,
                            CustomWidth = 0,
                            UseWidthVariance = false,
                            UseColorFade = true,
                        },
                        OffsetEffect = new OffsetEffectDef
                        {
                            MaxOffset =  0,// 0 offset value disables this effect
                            MinLength = 0.2f,
                            MaxLength = 3,
                        },
                    },
                },
                AmmoAudio = new AmmoAudioDef
                {
                    TravelSound = "MissileLoop",
                    HitSound = "ArcWepLrgWarheadExpl",
                    HitPlayChance = 1.0f,
                    HitPlayShield = true,
                }, // Don't edit below this line
            
            // AmmoType2
            
        };
    }
}
