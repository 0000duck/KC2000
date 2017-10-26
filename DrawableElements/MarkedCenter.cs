using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using OpenTK.Graphics.OpenGL;
using IOInterface;
using Render.Contracts;

namespace DrawableElements
{
    public class MarkedCenter : IDrawable
    {
        void IDrawable.Draw()
        {
            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.Lighting);

            

            GL.Color3(0.0f, 1.0f, 1.0f);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex3(-3, 0, 0);
            GL.Vertex3(3, 0, 0);
            GL.End();
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex3(1, 0, 1);
            GL.Vertex3(2, 0, -1);
            GL.End();
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex3(1, 0, -1);
            GL.Vertex3(2, 0, 1);
            GL.End();

            GL.Color3(1.0f, 1.0f, 0.0f);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex3(0,-3,  0);
            GL.Vertex3(0,3,  0);
            GL.End();

            GL.Color3(1.0f, 0.0f, 1.0f);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex3(0, 0, -3);
            GL.Vertex3(0, 0, 3);
            GL.End();

            GL.Color3(1.0f, 1.0f, 1.0f);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Lighting);
        }
    }
}
