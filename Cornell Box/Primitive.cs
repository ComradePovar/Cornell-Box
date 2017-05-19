using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Cornell_Box
{
    class Primitive
    {
        public int VaoID { get; }
        public int VertexBufferID { get; private set; }
        public int TexCoordBufferID { get; private set; }
        public int NormalBufferID { get; private set; }
        public int ColorBufferID { get; private set; }

        public Primitive()
        {
            VaoID = GL.GenVertexArray();
            GL.BindVertexArray(VaoID);
        }

        public void BindVertices(Vector3[] vertices)
        {
            VertexBufferID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferID);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * Vector3.SizeInBytes), vertices, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
        }

        public void BindNormals(Vector3[] normals)
        {
            NormalBufferID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, NormalBufferID);
            GL.BufferData(BufferTarget.ArrayBuffer, normals.Length * Vector3.SizeInBytes, normals, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 0, 0);
        }

        public void BindColors(Vector3[] colors)
        {
            ColorBufferID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, ColorBufferID);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(colors.Length * Vector3.SizeInBytes), colors, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, 0);
        }
    }
}
