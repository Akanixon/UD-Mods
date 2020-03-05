using Sandbox.Common.ObjectBuilders;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRage.Game.Entity;
using VRage.ModAPI;
using VRageMath;
using Sandbox.Game.Entities;

namespace PlasmaField
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Reactor), false, "LBFusionReactor", "SBFusionReactor", "LBFusionReactoradv", "SBFusionReactoradv")]
    public class ReactorRotatorGameLogic : MyGameLogicComponent
    {
        private const float MAX_RATE = (float)Math.PI * 2; // 360 deg/sec
        MyReactor _reactor;

        public override void OnAddedToContainer()
        {
            if (MyAPIGateway.Utilities.IsDedicated) return;
            _reactor = (MyReactor)Entity;
            _reactor.IsWorkingChanged += Reactor_IsWorkingChanged;
            Reactor_IsWorkingChanged(_reactor);
        }

        public override void OnBeforeRemovedFromContainer()
        {
            if (MyAPIGateway.Utilities.IsDedicated) return;
            _reactor.IsWorkingChanged -= Reactor_IsWorkingChanged;
            _reactor = null;
            _effect?.Stop();
            if (_effect != null)
                MyParticlesManager.RemoveParticleEffect(_effect);
        }

        private void Reactor_IsWorkingChanged(IMyCubeBlock obj)
        {
            UpdateParticleEffect();
            NeedsUpdate = _reactor.IsWorking ? MyEntityUpdateEnum.EACH_FRAME : MyEntityUpdateEnum.NONE;
        }

        private MyParticleEffect _effect;
        private IMyModel _effectCachedModel;
        private MatrixD? _effectMatrix;

        const float ParticleMaxDistance = 30;



        private void UpdateParticleEffect()
        {
            if (_effectCachedModel != _reactor.Model)
            {
                _effectCachedModel = _reactor.Model;
                var tmp = new Dictionary<string, IMyModelDummy>();
                _effectCachedModel?.GetDummies(tmp);
                _effectMatrix = tmp.GetValueOrDefault("subpart_PlasmaParticle")?.Matrix; // empty for particle
            }
            if (_reactor.IsWorking && _effectMatrix.HasValue)
            {
                var fractionalOutput = _reactor.CurrentOutput / _reactor.MaxOutput;
                var dTheta = 2 * MyEngineConstants.PHYSICS_STEP_SIZE_IN_SECONDS;
                _effectMatrix = _effectMatrix.Value * MatrixD.CreateRotationY(-dTheta);
                if (_effect == null)

                    MyParticlesManager.TryCreateParticleEffect("EMPdamageEffect", out _effect); // particle subtype
                _effect.WorldMatrix = _effectMatrix.Value * _reactor.WorldMatrix;
                _effect.Velocity = _reactor.CubeGrid.Physics?.GetVelocityAtPoint(_effect.WorldMatrix.Translation) ?? Vector3.Right; // rotation

                if (_effect == null) return;
               // if (Vector3D.DistanceSquared(MyAPIGateway.Session.Camera.WorldMatrix.Translation, _reactor.Position) >= ParticleMaxDistance * ParticleMaxDistance)
                //    return;

            }
            else
            {
                _effect?.Stop();
                if (_effect != null)
                    MyParticlesManager.RemoveParticleEffect(_effect);
                _effect = null;
                if (_effect == null) return;
            }
            
        }

        public override void UpdateAfterSimulation()
        {
            if (MyAPIGateway.Utilities.IsDedicated) return;
            UpdateParticleEffect();
            MyEntitySubpart subpart;
            if (_reactor != null && _reactor.TryGetSubpart("PlasmaParticle", out subpart))
            {
                var sub = (IMyEntity)subpart;
                var fractionalOutput = (_reactor.CurrentOutput + 1) / 4800;
                var dTheta = 1 * MAX_RATE /* * fractionalOutput*/ * MyEngineConstants.PHYSICS_STEP_SIZE_IN_SECONDS;
                subpart.SetEmissiveParts("PlasmaEmissive", Color.Teal, 1/* fractionalOutput*/);
                sub.LocalMatrix = sub.LocalMatrix * Matrix.CreateRotationY(dTheta);
            }

        }
    }
}
