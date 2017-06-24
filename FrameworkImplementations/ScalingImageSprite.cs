using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;
using FrameworkContracts;
using BaseTypes;
using BaseContracts;

namespace FrameworkImplementations
{
    public class ScalingImageSprite : IDrawable, IParticle
    {
        private List<Polygon> _polygons;
        private IPlayerCamera _camera;
        private IPolygonRenderer _polygonRenderer;
        private IWorldTranslator _worldTranslator;
        private IWorldRotator _worldRotator;
        private double _scaleFactor;
        private double _upMovement;
        private Position3D _position;
        private IPercentFader _percentFader;
        private IScaler _scaler;
        private double _startHeight;

        public ScalingImageSprite(IPlayerCamera camera, IPolygonRenderer polygonRenderer, IWorldRotator worldRotator, IWorldTranslator worldTranslator, IScaler scaler,
            List<Polygon> polygons, double scaleFactor, double upMovement, double startHeight, IPercentFader percentFader)
        {
            _camera = camera;
            _polygonRenderer = polygonRenderer;
            _worldRotator = worldRotator;
            _worldTranslator = worldTranslator;
            _scaler = scaler;
            _polygons = polygons;
            _scaleFactor = scaleFactor - 1;
            _upMovement = upMovement;
            _percentFader = percentFader;
            _startHeight = startHeight;
        }

        void IDrawable.Draw()
        {
            double percent = _percentFader.GetPercent();
            _worldTranslator.Store();
            _worldTranslator.TranslateWorld(_position.PositionX, _startHeight + _position.PositionY + (percent * _upMovement), _position.PositionZ);
            _worldRotator.RotateY(270 - _camera.DegreeXRotation);
            _scaler.Scale(1 + (percent * _scaleFactor), 1 + (percent * _scaleFactor), 1 + (percent * _scaleFactor));
            _polygonRenderer.RenderPolygons(_polygons);
            _worldTranslator.Reset();
        }

        bool IParticle.IsFinished()
        {
            return _percentFader.IsFinished();
        }

        void IParticle.Start(Position3D position)
        {
            _position = new Position3D { PositionX = position.PositionX, PositionY = position.PositionY, PositionZ = position.PositionZ };
            _percentFader.Start();
        }
    }
}
