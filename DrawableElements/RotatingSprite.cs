using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using Render.Contracts;

namespace DrawableElements
{
    public class RotatingSprite : IMirroredDrawable, IVisualParameterUpdater, IVisualParameterized
    {
        private List<Polygon> Polygons { set; get; }
        private IPlayerCamera Camera { set; get; }
        private IVisualParameters VisualParameters { set; get; }
        private IPolygonRenderer _polygonRenderer;
        private IRenderedSideSwitcher _renderedSideSwitcher;
        private IWorldRotator _worldRotator;

        public RotatingSprite(IPlayerCamera camera, IPolygonRenderer polygonRenderer, IRenderedSideSwitcher renderedSideSwitcher, IWorldRotator worldRotator, double width, double height)
        {
            Camera = camera;
            _polygonRenderer = polygonRenderer;
            _renderedSideSwitcher = renderedSideSwitcher;
            _worldRotator = worldRotator;
            CreatePolygons(width, height);
        }

        public RotatingSprite(IPlayerCamera camera, IPolygonRenderer polygonRenderer, IRenderedSideSwitcher renderedSideSwitcher, IWorldRotator worldRotator, IVisualParameters visualParameters)
        {
            Camera = camera;
            _polygonRenderer = polygonRenderer;
            _renderedSideSwitcher = renderedSideSwitcher;
            _worldRotator = worldRotator;
            VisualParameters = visualParameters;
            CreatePolygons(visualParameters.SideLengthX, visualParameters.Height);
        }

        public void Draw()
        {
            _worldRotator.RotateY(270 - Camera.DegreeXRotation);
            _polygonRenderer.RenderPolygons(Polygons);
        }

        public void DrawMirrored()
        {
            _worldRotator.RotateY(90 - Camera.DegreeXRotation);
            _renderedSideSwitcher.SwitchToBackSide();
            _polygonRenderer.RenderPolygons(Polygons);
            _renderedSideSwitcher.SwitchToFrontSide();
        }

        private void CreatePolygons(double width, double height)
        {
            Polygons = new List<Polygon>();

            Polygon triangleOne = new Polygon();

            float zero = 0.005f;
            float one = 0.995f;

            triangleOne.Vertices = new List<Vertex>();
            triangleOne.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = -(float)(width / 2.0) },
                TextureCoordinate = new VertexTextureCoordinate { X = zero, Y = one }
            });
            triangleOne.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = -(float)(width / 2.0), Y = (float)height },
                TextureCoordinate = new VertexTextureCoordinate { X = zero, Y = zero }
            });
            triangleOne.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = (float)(width / 2.0), Y = (float)height },
                TextureCoordinate = new VertexTextureCoordinate { X = one, Y = zero }
            });

            triangleOne.Normal = new Normal { Y = 1 };

            Polygons.Add(triangleOne);

            Polygon triangleTwo = new Polygon();

            triangleTwo.Vertices = new List<Vertex>();
            triangleTwo.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = -(float)(width / 2.0) },
                TextureCoordinate = new VertexTextureCoordinate { X = zero, Y = one }
            });
            triangleTwo.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = (float)(width / 2.0), Y = (float)height },
                TextureCoordinate = new VertexTextureCoordinate { X = one, Y = zero }
            });
            triangleTwo.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = (float)(width / 2.0) },
                TextureCoordinate = new VertexTextureCoordinate { X = one, Y = one }
            });


            triangleTwo.Normal = new Normal { Y = 1 };

            Polygons.Add(triangleTwo);
        }

        void IVisualParameterUpdater.UpdateParameters(IVisualParameters visualParameters, Degree rotation)
        {
            VisualParameters = visualParameters;
            CreatePolygons(visualParameters.SideLengthX, visualParameters.Height);
        }

        IVisualParameters IVisualParameterized.GetParameters()
        {
            return VisualParameters;
        }
    }
}
