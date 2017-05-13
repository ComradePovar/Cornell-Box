using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Cornell_Box
{
    class Camera
    {
        public Vector3 Eye;
        public Vector3 Target { get; }
        public Vector3 UpVector { get; }
        public Matrix4 ModelViewMatrix;
        public Matrix4 ProjectionMatrix;

        public Camera(Vector3 eye, Vector3 target, Vector3 upVector)
        {
            Eye = eye;
            Target = target;
            UpVector = upVector;

            ModelViewMatrix = Matrix4.LookAt(Eye, Target, UpVector);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref ModelViewMatrix);
        }

        public void Resize(int width, int height)
        {
            ProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, width / (float)height, 1, 10000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref ProjectionMatrix);
        }
    }
}
