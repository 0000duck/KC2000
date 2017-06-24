using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using GameInteractionContracts;
using ArtificialIntelligence.Contracts;
using IOInterface;

namespace ArtificialIntelligence
{
    public class DestructibleBody : IDestructibleBody, IDestructionObserver
    {
        private MainBodyStatus _bodyStatus;
        private List<IDestructibleBodyPart> _bodyParts;
        private Dictionary<MainBodyStatus, IDestructibleBodyPart> _destroyedBodies;

        public DestructibleBody(List<IDestructibleBodyPart> bodyParts, Dictionary<MainBodyStatus, IDestructibleBodyPart> destroyedBodies)
        {
            _bodyParts = bodyParts;
            _bodyStatus = MainBodyStatus.FullBody;
            _destroyedBodies = destroyedBodies;
        }

        MainBodyStatus IDestructibleBody.BodyStatus
        {
            get { return _bodyStatus; }
        }

        IList<IWorldElement> IDestructibleBody.GetBodyParts(Position3D position, Degree degree)
        {
            IList<IWorldElement> bodyParts = new List<IWorldElement>();
            if (_bodyStatus != MainBodyStatus.FullBody)
            {
                _destroyedBodies[_bodyStatus].AdaptShape(position, degree);
                IDestructibleBodyPart bodyPart = _destroyedBodies[_bodyStatus];

                if(bodyPart == null)
                    bodyPart = _destroyedBodies[MainBodyStatus.DeadlyInjured];

                bodyParts.Add((IWorldElement)bodyPart);
                return bodyParts;
            }
            foreach (IDestructibleBodyPart bodyPart in _bodyParts)
            {
                bodyPart.AdaptShape(position, degree);
                bodyParts.Add((IWorldElement)bodyPart);
            }

            return bodyParts;
        }

        void IDestructionObserver.NotifyFullDestruction(BodyPart bodyPart, Position3D position)
        {
            switch (bodyPart)
            {
                case BodyPart.Head:
                    _bodyStatus = MainBodyStatus.NoHead;
                    break;
                case BodyPart.Legs:
                    _bodyStatus = MainBodyStatus.NoLegs;
                    break;
                case BodyPart.Torso:
                    _bodyStatus = MainBodyStatus.NoTorso;
                    break;
                case BodyPart.Arms:
                    _bodyStatus = MainBodyStatus.NoArms;
                    break;
            }
        }

        void IDestructionObserver.NotifyInnerDestruction()
        {
            _bodyStatus = MainBodyStatus.DeadlyInjured;
        }
    }
}
