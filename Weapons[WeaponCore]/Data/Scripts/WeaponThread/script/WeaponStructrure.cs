using System.Collections.Generic;
using ProtoBuf;
using VRageMath;

namespace WeaponThread
{
    public class WeaponStructure
    {
        [ProtoContract]
        public struct WeaponDefinition
        {
            [ProtoMember(1)] internal ModelAssignmentsDef Assignments;
            [ProtoMember(2)] internal TargetingDef Targeting;
            [ProtoMember(3)] internal AnimationDef Animations;
            [ProtoMember(4)] internal HardPointDef HardPoint;
            [ProtoMember(5)] internal AmmoDef[] Ammos;
            [ProtoMember(6)] internal string ModPath;

            [ProtoContract]
            public struct ModelAssignmentsDef
            {
                [ProtoMember(1)] internal MountPointDef[] MountPoints;
                [ProtoMember(2)] internal string[] Barrels;

                [ProtoContract]
                public struct MountPointDef
                {
                    [ProtoMember(1)] internal string SubtypeId;
                    [ProtoMember(2)] internal string AimPartId;
                    [ProtoMember(3)] internal string MuzzlePartId;
                    [ProtoMember(4)] internal string AzimuthPartId;
                    [ProtoMember(5)] internal string ElevationPartId;
                }
            }

            [ProtoContract]
            public struct TargetingDef
            {
                public enum Threat
                {
                    Projectiles,
                    Characters,
                    Grids,
                    Neutrals,
                    Meteors,
                    Other
                }

                public enum BlockTypes
                {
                    Any,
                    Offense,
                    Utility,
                    Power,
                    Production,
                    Thrust,
                    Jumping,
                    Steering
                }

                [ProtoMember(1)] internal int TopTargets;
                [ProtoMember(2)] internal int TopBlocks;
                [ProtoMember(3)] internal double StopTrackingSpeed;
                [ProtoMember(4)] internal float MinimumDiameter;
                [ProtoMember(5)] internal float MaximumDiameter;
                [ProtoMember(6)] internal bool ClosestFirst;
                [ProtoMember(7)] internal BlockTypes[] SubSystems;
                [ProtoMember(8)] internal Threat[] Threats;
            }

            [ProtoContract]
            public struct AnimationDef
            {
                [ProtoMember(1)] internal PartAnimationSetDef[] WeaponAnimationSets;
                [ProtoMember(2)] internal WeaponEmissive[] Emissives;
                [ProtoMember(3)] internal string[] HeatingEmissiveParts;


                [ProtoContract(IgnoreListHandling = true)]
                public struct PartAnimationSetDef
                {
                    public enum EventTriggers
                    {
                        Reloading,
                        Firing,
                        Tracking,
                        Overheated,
                        TurnOn,
                        TurnOff,
                        BurstReload,
                        OutOfAmmo,
                        PreFire,
                        EmptyOnGameLoad,
                        StopFiring,
                        StopTracking
                    }


                    [ProtoMember(1)] internal string[] SubpartId;
                    [ProtoMember(2)] internal string BarrelId;
                    [ProtoMember(3)] internal uint StartupFireDelay;
                    [ProtoMember(4)] internal Dictionary<EventTriggers, uint> AnimationDelays;
                    [ProtoMember(5)] internal EventTriggers[] Reverse;
                    [ProtoMember(6)] internal EventTriggers[] Loop;
                    [ProtoMember(7)] internal Dictionary<EventTriggers, RelMove[]> EventMoveSets;
                    [ProtoMember(8)] internal EventTriggers[] TriggerOnce;
                    [ProtoMember(9)] internal EventTriggers[] ResetEmissives;

                }

                [ProtoContract]
                public struct WeaponEmissive
                {
                    [ProtoMember(1)] internal string EmissiveName;
                    [ProtoMember(2)] internal string[] EmissivePartNames;
                    [ProtoMember(3)] internal bool CycleEmissivesParts;
                    [ProtoMember(4)] internal bool LeavePreviousOn;
                    [ProtoMember(5)] internal Vector4[] Colors;
                    [ProtoMember(6)] internal float[] IntensityRange;
                }

                [ProtoContract]
                internal struct RelMove
                {
                    public enum MoveType
                    {
                        Linear,
                        ExpoDecay,
                        ExpoGrowth,
                        Delay,
                        Show, //instant or fade
                        Hide, //instant or fade
                    }

                    [ProtoMember(1)] internal MoveType MovementType;
                    [ProtoMember(2)] internal XYZ[] LinearPoints;
                    [ProtoMember(3)] internal XYZ Rotation;
                    [ProtoMember(4)] internal XYZ RotAroundCenter;
                    [ProtoMember(5)] internal uint TicksToMove;
                    [ProtoMember(6)] internal string CenterEmpty;
                    [ProtoMember(7)] internal bool Fade;
                    [ProtoMember(8)] internal string EmissiveName;

                    [ProtoContract]
                    internal struct XYZ
                    {
                        [ProtoMember(1)] internal double x;
                        [ProtoMember(2)] internal double y;
                        [ProtoMember(3)] internal double z;
                    }
                }
            }

            [ProtoContract]
            public struct HardPointDef
            {
                public enum Prediction
                {
                    Off,
                    Basic,
                    Accurate,
                    Advanced,
                }

                [ProtoMember(1)] internal string WeaponName;
                [ProtoMember(2)] internal int DelayCeaseFire;
                [ProtoMember(3)] internal float DeviateShotAngle;
                [ProtoMember(4)] internal double AimingTolerance;
                [ProtoMember(5)] internal Prediction AimLeadingPrediction;
                [ProtoMember(6)] internal LoadingDef Loading;
                [ProtoMember(7)] internal AiDef Ai;
                [ProtoMember(8)] internal HardwareDef HardWare;
                [ProtoMember(9)] internal UiDef Ui;
                [ProtoMember(10)] internal HardPointAudioDef Audio;
                [ProtoMember(11)] internal HardPointParticleDef Graphics;
                [ProtoMember(12)] internal OtherDef Other;

                [ProtoContract]
                public struct LoadingDef
                {
                    [ProtoMember(1)] internal int ReloadTime;
                    [ProtoMember(2)] internal int RateOfFire;
                    [ProtoMember(3)] internal int BarrelsPerShot;
                    [ProtoMember(4)] internal int SkipBarrels;
                    [ProtoMember(5)] internal int TrajectilesPerBarrel;
                    [ProtoMember(6)] internal int HeatPerShot;
                    [ProtoMember(7)] internal int MaxHeat;
                    [ProtoMember(8)] internal int HeatSinkRate;
                    [ProtoMember(9)] internal float Cooldown;
                    [ProtoMember(10)] internal int DelayUntilFire;
                    [ProtoMember(11)] internal int ShotsInBurst;
                    [ProtoMember(12)] internal int DelayAfterBurst;
                    [ProtoMember(13)] internal bool DegradeRof;
                    [ProtoMember(14)] internal int BarrelSpinRate;
                    [ProtoMember(15)] internal bool FireFullBurst;
                }


                [ProtoContract]
                public struct UiDef
                {
                    [ProtoMember(1)] internal bool RateOfFire;
                    [ProtoMember(2)] internal bool DamageModifier;
                    [ProtoMember(3)] internal bool ToggleGuidance;
                    [ProtoMember(4)] internal bool EnableOverload;
                }


                [ProtoContract]
                public struct AiDef
                {
                    [ProtoMember(1)] internal bool TrackTargets;
                    [ProtoMember(2)] internal bool TurretAttached;
                    [ProtoMember(3)] internal bool TurretController;
                    [ProtoMember(4)] internal bool PrimaryTracking;
                    [ProtoMember(5)] internal bool LockOnFocus;
                }

                [ProtoContract]
                public struct HardwareDef
                {
                    [ProtoMember(1)] internal float RotateRate;
                    [ProtoMember(2)] internal float ElevateRate;
                    [ProtoMember(3)] internal Vector3D Offset;
                    [ProtoMember(4)] internal bool FixedOffset;
                    [ProtoMember(5)] internal int MaxAzimuth;
                    [ProtoMember(6)] internal int MinAzimuth;
                    [ProtoMember(7)] internal int MaxElevation;
                    [ProtoMember(8)] internal int MinElevation;
                    [ProtoMember(9)] internal float InventorySize;
                }

                [ProtoContract]
                public struct HardPointAudioDef
                {
                    [ProtoMember(1)] internal string ReloadSound;
                    [ProtoMember(2)] internal string NoAmmoSound;
                    [ProtoMember(3)] internal string HardPointRotationSound;
                    [ProtoMember(4)] internal string BarrelRotationSound;
                    [ProtoMember(5)] internal string FiringSound;
                    [ProtoMember(6)] internal bool FiringSoundPerShot;
                    [ProtoMember(7)] internal string PreFiringSound;
                }

                [ProtoContract]
                public struct OtherDef
                {
                    [ProtoMember(1)] internal int GridWeaponCap;
                    [ProtoMember(2)] internal int EnergyPriority;
                    [ProtoMember(3)] internal int RotateBarrelAxis;
                    [ProtoMember(4)] internal bool MuzzleCheck;
                    [ProtoMember(5)] internal bool Debug;
                }
                [ProtoContract]
                public struct HardPointParticleDef
                {
                    [ProtoMember(1)] internal ParticleDef Barrel1;
                    [ProtoMember(2)] internal ParticleDef Barrel2;
                }
            }

            [ProtoContract]
            public class AmmoDef
            {
                [ProtoMember(1)] internal string AmmoMagazine;
                [ProtoMember(2)] internal string AmmoRound;
                [ProtoMember(3)] internal bool HybridRound;
                [ProtoMember(4)] internal float EnergyCost;
                [ProtoMember(5)] internal float BaseDamage;
                [ProtoMember(6)] internal float Mass;
                [ProtoMember(7)] internal float Health;
                [ProtoMember(8)] internal float BackKickForce;
                [ProtoMember(9)] internal DamageScaleDef DamageScales;
                [ProtoMember(10)] internal ShapeDef Shape;
                [ProtoMember(11)] internal ObjectsHitDef ObjectsHit;
                [ProtoMember(12)] internal TrajectoryDef Trajectory;
                [ProtoMember(13)] internal AreaDamageDef AreaEffect;
                [ProtoMember(14)] internal BeamDef Beams;
                [ProtoMember(15)] internal ShrapnelDef Shrapnel;
                [ProtoMember(16)] internal GraphicDef AmmoGraphics;
                [ProtoMember(17)] internal AmmoAudioDef AmmoAudio;
                [ProtoMember(18)] internal bool HardPointUsable;

                [ProtoContract]
                public struct DamageScaleDef
                {

                    [ProtoMember(1)] internal float MaxIntegrity;
                    [ProtoMember(2)] internal bool DamageVoxels;
                    [ProtoMember(3)] internal float Characters;
                    [ProtoMember(4)] internal bool SelfDamage;
                    [ProtoMember(5)] internal GridSizeDef Grids;
                    [ProtoMember(6)] internal ArmorDef Armor;
                    [ProtoMember(7)] internal CustomScalesDef Custom;
                    [ProtoMember(8)] internal ShieldDef Shields;

                    [ProtoContract]
                    public struct GridSizeDef
                    {
                        [ProtoMember(1)] internal float Large;
                        [ProtoMember(2)] internal float Small;
                    }

                    [ProtoContract]
                    public struct ArmorDef
                    {
                        [ProtoMember(1)] internal float Armor;
                        [ProtoMember(2)] internal float Heavy;
                        [ProtoMember(3)] internal float Light;
                        [ProtoMember(4)] internal float NonArmor;
                    }

                    [ProtoContract]
                    public struct CustomScalesDef
                    {
                        [ProtoMember(1)] internal CustomBlocksDef[] Types;
                        [ProtoMember(2)] internal bool IgnoreAllOthers;
                    }

                    [ProtoContract]
                    public struct ShieldDef
                    {
                        internal enum ShieldType
                        {
                            Heal,
                            Bypass,
                            Emp,
                            Energy,
                            Kinetic
                        }

                        [ProtoMember(1)] internal float Modifier;
                        [ProtoMember(2)] internal ShieldType Type;
                        [ProtoMember(3)] internal float BypassModifier;
                    }
                }

                [ProtoContract]
                public struct ShapeDef
                {
                    public enum Shapes
                    {
                        LineShape,
                        SphereShape,
                    }

                    [ProtoMember(1)] internal Shapes Shape;
                    [ProtoMember(2)] internal double Diameter;
                }

                [ProtoContract]
                public struct ObjectsHitDef
                {
                    [ProtoMember(1)] internal int MaxObjectsHit;
                    [ProtoMember(2)] internal bool CountBlocks;
                }


                [ProtoContract]
                public struct CustomBlocksDef
                {
                    [ProtoMember(1)] internal string SubTypeId;
                    [ProtoMember(2)] internal float Modifier;
                }

                [ProtoContract]
                public struct GraphicDef
                {
                    [ProtoMember(1)] internal bool ShieldHitDraw;
                    [ProtoMember(2)] internal float VisualProbability;
                    [ProtoMember(3)] internal string ModelName;
                    [ProtoMember(4)] internal AmmoParticleDef Particles;
                    [ProtoMember(5)] internal LineDef Lines;

                    [ProtoContract]
                    public struct AmmoParticleDef
                    {
                        [ProtoMember(1)] internal ParticleDef Ammo;
                        [ProtoMember(2)] internal ParticleDef Hit;
                    }

                    [ProtoContract]
                    public struct LineDef
                    {
                        [ProtoMember(1)] internal TracerBaseDef Tracer;
                        [ProtoMember(2)] internal string TracerMaterial;
                        [ProtoMember(3)] internal Randomize ColorVariance;
                        [ProtoMember(4)] internal Randomize WidthVariance;
                        [ProtoMember(5)] internal TrailDef Trail;
                        [ProtoMember(6)] internal OffsetEffectDef OffsetEffect;

                        [ProtoContract]
                        public struct OffsetEffectDef
                        {
                            [ProtoMember(1)] internal double MaxOffset;
                            [ProtoMember(2)] internal double MinLength;
                            [ProtoMember(3)] internal double MaxLength;
                        }

                        [ProtoContract]
                        public struct TracerBaseDef
                        {
                            [ProtoMember(1)] internal bool Enable;
                            [ProtoMember(2)] internal float Length;
                            [ProtoMember(3)] internal float Width;
                            [ProtoMember(4)] internal Vector4 Color;
                        }

                        [ProtoContract]
                        public struct TrailDef
                        {
                            [ProtoMember(1)] internal bool Enable;
                            [ProtoMember(2)] internal string Material;
                            [ProtoMember(3)] internal int DecayTime;
                            [ProtoMember(4)] internal Vector4 Color;
                            [ProtoMember(5)] internal bool Back;
                            [ProtoMember(6)] internal float CustomWidth;
                            [ProtoMember(7)] internal bool UseWidthVariance;
                            [ProtoMember(8)] internal bool UseColorFade;
                        }
                    }
                }
                
                [ProtoContract]
                public struct BeamDef
                {
                    [ProtoMember(1)] internal bool Enable;
                    [ProtoMember(2)] internal bool ConvergeBeams;
                    [ProtoMember(3)] internal bool VirtualBeams;
                    [ProtoMember(4)] internal bool RotateRealBeam;
                    [ProtoMember(5)] internal bool OneParticle;
                }

                [ProtoContract]
                public struct ShrapnelDef
                {
                    [ProtoMember(1)] internal string AmmoRound;
                    [ProtoMember(2)] internal int Fragments;
                    [ProtoMember(3)] internal float ForwardDegrees;
                    [ProtoMember(4)] internal float BackwardDegrees;
                }


                [ProtoContract]
                public struct AreaDamageDef
                {
                    public enum AreaEffectType
                    {
                        Disabled,
                        Explosive,
                        Radiant,
                        AntiSmart,
                        JumpNullField,
                        EnergySinkField,
                        AnchorField,
                        EmpField,
                        OffenseField,
                        NavField,
                        DotField,
                    }

                    [ProtoMember(1)] internal double AreaEffectRadius;
                    [ProtoMember(2)] internal float AreaEffectDamage;
                    [ProtoMember(3)] internal AreaEffectType AreaEffect;
                    [ProtoMember(4)] internal PulseDef Pulse;
                    [ProtoMember(5)] internal DetonateDef Detonation;
                    [ProtoMember(6)] internal ExplosionDef Explosions;
                    [ProtoMember(7)] internal EwarFieldsDef EwarFields;



                    [ProtoContract]
                    public struct PulseDef
                    {
                        [ProtoMember(1)] internal int Interval;
                        [ProtoMember(2)] internal int PulseChance;
                    }

                    [ProtoContract]
                    public struct EwarFieldsDef
                    {
                        [ProtoMember(1)] internal int Duration;
                        [ProtoMember(2)] internal bool StackDuration;
                        [ProtoMember(3)] internal bool Depletable;
                        [ProtoMember(4)] internal double TriggerRange;
                        [ProtoMember(5)] internal int MaxStacks;
                    }

                    [ProtoContract]
                    public struct DetonateDef
                    {
                        [ProtoMember(1)] internal bool DetonateOnEnd;
                        [ProtoMember(2)] internal bool ArmOnlyOnHit;
                        [ProtoMember(3)] internal float DetonationRadius;
                        [ProtoMember(4)] internal float DetonationDamage;
                    }

                    [ProtoContract]
                    public struct ExplosionDef
                    {
                        [ProtoMember(1)] internal bool NoVisuals;
                        [ProtoMember(2)] internal bool NoSound;
                        [ProtoMember(3)] internal float Scale;
                        [ProtoMember(4)] internal string CustomParticle;
                        [ProtoMember(5)] internal string CustomSound;
                    }


                }

                [ProtoContract]
                public struct AmmoAudioDef
                {
                    [ProtoMember(1)] internal string TravelSound;
                    [ProtoMember(2)] internal string HitSound;
                    [ProtoMember(3)] internal float HitPlayChance;
                    [ProtoMember(4)] internal bool HitPlayShield;
                }

                [ProtoContract]
                public struct TrajectoryDef
                {
                    internal enum GuidanceType
                    {
                        None,
                        Remote,
                        TravelTo,
                        Smart,
                        DetectTravelTo,
                        DetectSmart,
                        DetectFixed,
                    }

                    [ProtoMember(1)] internal float MaxTrajectory;
                    [ProtoMember(2)] internal float AccelPerSec;
                    [ProtoMember(3)] internal float DesiredSpeed;
                    [ProtoMember(4)] internal float TargetLossDegree;
                    [ProtoMember(5)] internal int TargetLossTime;
                    [ProtoMember(6)] internal int MaxLifeTime;
                    [ProtoMember(7)] internal int FieldTime;
                    [ProtoMember(8)] internal Randomize SpeedVariance;
                    [ProtoMember(9)] internal Randomize RangeVariance;
                    [ProtoMember(10)] internal GuidanceType Guidance;
                    [ProtoMember(11)] internal SmartsDef Smarts;
                    [ProtoMember(12)] internal MinesDef Mines;


                    [ProtoContract]
                    public struct SmartsDef
                    {
                        [ProtoMember(1)] internal double Inaccuracy;
                        [ProtoMember(2)] internal double Aggressiveness;
                        [ProtoMember(3)] internal double MaxLateralThrust;
                        [ProtoMember(4)] internal double TrackingDelay;
                        [ProtoMember(5)] internal int MaxChaseTime;
                        [ProtoMember(6)] internal bool OverideTarget;
                        [ProtoMember(7)] internal int MaxTargets;
                    }

                    [ProtoContract]
                    public struct MinesDef
                    {
                        [ProtoMember(1)] internal double DetectRadius;
                        [ProtoMember(2)] internal double DeCloakRadius;
                        [ProtoMember(3)] internal int FieldTime;
                        [ProtoMember(4)] internal bool Cloak;
                        [ProtoMember(5)] internal bool Persist;
                    }
                }

                [ProtoContract]
                public struct Randomize
                {
                    [ProtoMember(1)] internal float Start;
                    [ProtoMember(2)] internal float End;
                }
            }

            [ProtoContract]
            public struct ParticleOptionDef
            {
                [ProtoMember(1)] internal float Scale;
                [ProtoMember(2)] internal float MaxDistance;
                [ProtoMember(3)] internal float MaxDuration;
                [ProtoMember(4)] internal bool Loop;
                [ProtoMember(5)] internal bool Restart;
                [ProtoMember(6)] internal float HitPlayChance;
            }


            [ProtoContract]
            public struct ParticleDef
            {
                [ProtoMember(1)] internal string Name;
                [ProtoMember(2)] internal Vector4 Color;
                [ProtoMember(3)] internal Vector3D Offset;
                [ProtoMember(4)] internal ParticleOptionDef Extras;
                [ProtoMember(5)] internal bool ApplyToShield;
                [ProtoMember(6)] internal bool ShrinkByDistance;
            }
        }
    }
}
