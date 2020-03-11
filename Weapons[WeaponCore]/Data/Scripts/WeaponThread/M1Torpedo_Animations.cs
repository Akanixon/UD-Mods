using System.Collections.Generic;
using static WeaponThread.WeaponStructure;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef.PartAnimationSetDef.EventTriggers;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef.RelMove.MoveType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef.RelMove;


namespace WeaponThread
{ // Don't edit above this line
    partial class Weapons
    {
        private AnimationDef M1TorpedoAnimations => new AnimationDef
        {
            WeaponAnimationSets = new[]
            {
                #region Barrels Animations
                new PartAnimationSetDef()
                {
                    SubpartId = Names("barrel_013"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts, OnFireDelay = delaying fire of weapon when turned on
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        [EmptyOnGameLoad] = new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire, EmptyOnGameLoad define a new[] for each
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0, 0), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },


                        },
                    }
                }, //EmptyOnLoad



                new PartAnimationSetDef()
                {
                    SubpartId = Names("barrel_013"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts, OnFireDelay = delaying fire of weapon when turned on
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        [Firing] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Hide,
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, 0), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },


                            },
                        [Reloading] =
                            new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 180, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, 0), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Show,
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, 0), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },

                            },
                        
                    }
                },

                #endregion
                //---------//
                #region Doors
                #region EmptyOnLoad
                //new PartAnimationSetDef()
                //{
                //    SubpartId = Names("HatchPushPart"),
                //    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                //    StartupFireDelay = 240,
                //    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts, OnFireDelay = delaying fire of weapon when turned on
                //    Reverse = Events(),
                //    Loop = Events(),
                //    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                //    {
                //        [EmptyOnGameLoad] = new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire, EmptyOnGameLoad define a new[] for each
                //        {
                //            new RelMove
                //                {
                //                    CenterEmpty = "",
                //                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                //                    MovementType = Delay,
                //                    LinearPoints = new XYZ[0],
                //                    Rotation = Transformation(0, 0, 0), //degrees
                //                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                //                },

                //                new RelMove
                //                {
                //                    CenterEmpty = "",
                //                    TicksToMove = 120, //number of ticks to complete motion, 60 = 1 second
                //                    MovementType = ExpoDecay,
                //                    LinearPoints = new[]
                //                    {
                //                        Transformation(0, 0, -0.150), //linear movement
                //                    },
                //                    Rotation = Transformation(0, 0, 0), //degrees
                //                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                //                },


                //        },
                //    }
                //}, //EmptyOnLoad Push

                //new PartAnimationSetDef()
                //{
                //    SubpartId = Names("HatchRotatePart1"),
                //    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                //    StartupFireDelay = 240,
                //    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 60, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 60, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts, OnFireDelay = delaying fire of weapon when turned on
                //    Reverse = Events(),
                //    Loop = Events(),
                //    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                //    {
                //        [EmptyOnGameLoad] = 
                //        new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire, EmptyOnGameLoad define a new[] for each
                //        {
                //            new RelMove
                //            {
                //                CenterEmpty = "",
                //                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                //                MovementType = Delay,
                //                LinearPoints = new XYZ[0],
                //                Rotation = Transformation(0, 0, 0), //degrees
                //                RotAroundCenter = Transformation(0, 0, 0), //degrees
                //            },
                //            new RelMove
                //            {
                //                CenterEmpty = "",
                //                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                //                MovementType = ExpoGrowth,
                //                LinearPoints = new XYZ[0],
                //                Rotation = Transformation(-52.5, 0, 0), //degrees
                //                RotAroundCenter = Transformation(0, 0, 0), //degrees
                //            },
                //            new RelMove
                //            {
                //                CenterEmpty = "",
                //                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                //                MovementType = ExpoDecay,
                //                LinearPoints = new XYZ[0],
                //                Rotation = Transformation(-52.5, 0, 0), //degrees
                //                RotAroundCenter = Transformation(0, 0, 0), //degrees
                //            },


                //        },

                //    }
                //}, //EmptyOnLoad Hatch 1

                //new PartAnimationSetDef()
                //{
                //    SubpartId = Names("HatchRotatePart2"),
                //    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                //    StartupFireDelay = 240,
                //    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 60, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 60, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts, OnFireDelay = delaying fire of weapon when turned on
                //    Reverse = Events(),
                //    Loop = Events(),
                //    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                //    {
                //        [EmptyOnGameLoad] = new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire, EmptyOnGameLoad define a new[] for each
                //        {
                //            new RelMove
                //            {
                //                CenterEmpty = "",
                //                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                //                MovementType = Delay,
                //                LinearPoints = new XYZ[0],
                //                Rotation = Transformation(0, 0, 0), //degrees
                //                RotAroundCenter = Transformation(0, 0, 0), //degrees
                //            },
                //            new RelMove
                //            {
                //                CenterEmpty = "",
                //                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                //                MovementType = ExpoGrowth,
                //                LinearPoints = new XYZ[0],
                //                Rotation = Transformation(52.5, 0, 0), //degrees
                //                RotAroundCenter = Transformation(0, 0, 0), //degrees
                //            },
                //            new RelMove
                //            {
                //                CenterEmpty = "",
                //                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                //                MovementType = ExpoDecay,
                //                LinearPoints = new XYZ[0],
                //                Rotation = Transformation(52.5, 0, 0), //degrees
                //                RotAroundCenter = Transformation(0, 0, 0), //degrees
                //            },


                //        },

                //    }
                //}, //EmptyOnLoad HAtch 2
                #endregion
                new PartAnimationSetDef()
                {
                    SubpartId = Names("HatchRotatePart1"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 60, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 60, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts, OnFireDelay = delaying fire of weapon when turned on
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        [Reloading] =
                        new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire, EmptyOnGameLoad define a new[] for each
                        {

                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoGrowth,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoDecay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1500, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoGrowth,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(-52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoDecay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(-52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },


                        },
                        
                        [TurnOn] =
                        new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire, EmptyOnGameLoad define a new[] for each
                        {


                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoGrowth,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(-52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoDecay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(-52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },


                        },
                        [TurnOff] =
                        new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire, EmptyOnGameLoad define a new[] for each
                        {

                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoGrowth,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoDecay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },



                        },
                    }
                }, // Reload Hatch 1
                
               
               
               
                new PartAnimationSetDef()
                {
                    SubpartId = Names("HatchRotatePart2"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 60, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 60, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts, OnFireDelay = delaying fire of weapon when turned on
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        [Reloading] = new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire, EmptyOnGameLoad define a new[] for each
                        {

                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoGrowth,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(-52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoDecay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(-52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1500, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoGrowth,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoDecay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },


                        },
                        
                        [TurnOn] =
                        new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire, EmptyOnGameLoad define a new[] for each
                        {


                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoGrowth,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoDecay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },


                        },
                        [TurnOff] =
                        new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire, EmptyOnGameLoad define a new[] for each
                        {

                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoGrowth,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(-52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = ExpoDecay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(-52.5, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },



                        },
                    }
                }, //  Reload Hatch 2
                


                new PartAnimationSetDef()
                {
                    SubpartId = Names("HatchPushPart"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 60, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 60, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts, OnFireDelay = delaying fire of weapon when turned on
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {

                        [Reloading] =
                            new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                            {


                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 120, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoDecay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, 0.150), //linear movement //Z = forward
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                
                                

                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 1380, //number of ticks to complete motion, 60 = 1 second Removed60tick due to animation lag
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },

                                
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 120, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoDecay,
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, -0.150), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },

                                //--------------------Reverse

                               



                            },

                        
                        [TurnOn] =
                            new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                            {


                                


                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 120, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoDecay,
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, -0.150), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },

                                //--------------------Reverse

                               



                            },
                        [TurnOff] =
                            new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                            {


                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 120, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoDecay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, 0.150), //linear movement //Z = forward
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },



                                

                                //--------------------Reverse

                               



                            },




                    }
                }, //Reload Push

                
                #endregion

                //-------//

               
               



            }
        };
    }
}
