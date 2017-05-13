using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Cornell_Box
{
    class Scene
    {
        public Camera Camera { get; private set; }
        public PointLight light { get; private set; }
        private Primitive lightSource;
        private Primitive floor;
        private Primitive backWall;
        private Primitive rightWall;
        private Primitive leftWall;
        private Primitive shortBlock;
        private Primitive pyramid;
        private Primitive ceiling;
        private RoomShader shader;

        public Scene(string vertexShaderPath, string fragmentShaderPath)
        {
            shader = new RoomShader(vertexShaderPath, fragmentShaderPath);
            Camera = new Camera(new Vector3(278, 273, -800), new Vector3(278, 273, -799), Vector3.UnitY);
            light = new PointLight(new Vector3(278.0f, 374.4f, 279.5f), 182f, 0.02f, 0.4f, 0.7f, 0.05f, 0.003f, 0.000012f);
            InitPrimitives();
        }

        private Vector3 GetNormal(Vector3 v1, Vector3 v2)
        {
            Vector3 normal = new Vector3();
            normal.X = v1.Y * v2.Z - v1.Z * v2.Y;
            normal.Y = v1.Z * v2.X - v1.X * v2.Z;
            normal.Z = v1.X * v2.Y - v1.Y * v2.X;

            return normal.Normalized();
        }
        private void InitPrimitives()
        {
            Vector3 creamColor = new Vector3(243/255f, 229/255f, 171/255f);

            floor = new Primitive();
            Vector3[] vertices =
            {
                new Vector3(552.8f, 0.0f, 0.0f),
                new Vector3(0.0f, 0.0f, 0.0f),
                new Vector3(0.0f, 0.0f, 559.2f),
                new Vector3(549.6f, 0.0f, 559.2f)
            };
            Vector3[] colors =
            {
                creamColor,
                creamColor,
                creamColor,
                creamColor
            };
            Vector3[] normals =
            {
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                new Vector3(-1, 1, 1),
                new Vector3(1, 1, 1),
                new Vector3(1, 1, -1),
                new Vector3(-1, 1, -1)
            };
            floor.BindVertices(vertices);
            floor.BindColors(colors);
            floor.BindNormals(normals);

            backWall = new Primitive();
            vertices = new Vector3[]
            {
                new Vector3(549.6f, 0.0f, 559.2f),
                new Vector3(0.0f, 0.0f, 559.2f),
                new Vector3(0.0f, 548.8f, 559.2f),
                new Vector3(556.0f, 548.8f, 559.2f)
            };
            colors = new Vector3[]
            {
                creamColor,
                creamColor,
                creamColor,
                creamColor
            };
            normals = new Vector3[]
            {
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1])
                new Vector3(-1, 1, -1),
                new Vector3(1, 1, -1),
                new Vector3(1, -1, -1),
                new Vector3(-1, -1, -1)
            };
            backWall.BindVertices(vertices);
            backWall.BindColors(colors);
            backWall.BindNormals(normals);

            rightWall = new Primitive();
            vertices = new Vector3[]
            {
                new Vector3(0.0f, 0.0f, 559.2f),
                new Vector3(0.0f, 0.0f, 0.0f),
                new Vector3(0.0f, 548.8f, 0.0f),
                new Vector3(0.0f, 548.8f, 559.2f)
            };
            colors = new Vector3[]
            {
                new Vector3(0.0f, 1.0f, 0.0f),
                new Vector3(0.0f, 1.0f, 0.0f),
                new Vector3(0.0f, 1.0f, 0.0f),
                new Vector3(0.0f, 1.0f, 0.0f)
            };
            normals = new Vector3[]
            {
                new Vector3(1, 1, -1),
                new Vector3(1, 1, 1),
                new Vector3(1, -1, 1),
                new Vector3(1, -1, -1)
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1])
            };
            rightWall.BindVertices(vertices);
            rightWall.BindColors(colors);
            rightWall.BindNormals(normals);

            leftWall = new Primitive();
            vertices = new Vector3[]
            {
                new Vector3(552.8f, 0.0f, 0.0f),
                new Vector3(549.6f, 0.0f, 559.2f),
                new Vector3(556.0f, 548.8f, 559.2f),
                new Vector3(556.0f, 548.8f, 0.0f)
            };
            colors = new Vector3[]
            {
                new Vector3(1.0f, 0.0f, 0.0f),
                new Vector3(1.0f, 0.0f, 0.0f),
                new Vector3(1.0f, 0.0f, 0.0f),
                new Vector3(1.0f, 0.0f, 0.0f)
            };
            normals = new Vector3[]
            {
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1])
                new Vector3(-1, 1, 0),
                new Vector3(-1, 1, -1),
                new Vector3(-1, -1, -1),
                new Vector3(-1, -1, 0)
            };
            leftWall.BindVertices(vertices);
            leftWall.BindColors(colors);
            leftWall.BindNormals(normals);

            ceiling = new Primitive();
            vertices = new Vector3[]
            {
                new Vector3(556.0f, 548.8f, 0.0f),
                new Vector3(556.0f, 548.8f, 559.2f),
                new Vector3(0.0f, 548.8f, 559.2f),
                new Vector3(0.0f, 548.8f, 0.0f)
            };
            colors = new Vector3[]
            {
                creamColor,
                creamColor,
                creamColor,
                creamColor
            };
            normals = new Vector3[]
            {
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                //GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1])
                new Vector3(-1, -1, 1),
                new Vector3(-1, -1, -1),
                new Vector3(1, -1, -1),
                new Vector3(1, -1, 1)
            };
            ceiling.BindVertices(vertices);
            ceiling.BindColors(colors);
            ceiling.BindNormals(normals);

            shortBlock = new Primitive();
            vertices = new Vector3[]
            {
                new Vector3(130.0f, 165.0f, 65.0f),
                new Vector3(82.0f, 165.0f, 225.0f),
                new Vector3(240.0f, 165.0f, 272.0f),
                new Vector3(290.0f, 165.0f, 114.0f),

                new Vector3(290.0f, 0.0f, 114.0f),
                new Vector3(290.0f, 165.0f, 114.0f),
                new Vector3(240.0f, 165.0f, 272.0f),
                new Vector3(240.0f, 0.0f, 272.0f),

                new Vector3(130.0f, 0.0f, 65.0f),
                new Vector3(130.0f, 165.0f, 65.0f),
                new Vector3(290.0f, 165.0f, 114.0f),
                new Vector3(290.0f, 0.0f, 114.0f),

                new Vector3(82.0f, 0.0f, 225.0f),
                new Vector3(82.0f, 165.0f, 225.0f),
                new Vector3(130.0f, 165.0f, 65.0f),
                new Vector3(130.0f, 0.0f, 65.0f),

                new Vector3(240.0f, 0.0f, 272.0f),
                new Vector3(240.0f, 165.0f, 272.0f),
                new Vector3(82.0f, 165.0f, 225.0f),
                new Vector3(82.0f, 0.0f, 225.0f),
            };
            colors = new Vector3[]
            {
                creamColor,
                creamColor,
                creamColor,
                creamColor,

                creamColor,
                creamColor,
                creamColor,
                creamColor,

                creamColor,
                creamColor,
                creamColor,
                creamColor,

                creamColor,
                creamColor,
                creamColor,
                creamColor,

                creamColor,
                creamColor,
                creamColor,
                creamColor
            };
            normals = new Vector3[]
            {
                GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),

                GetNormal(vertices[5] - vertices[4], vertices[6] - vertices[5]),
                GetNormal(vertices[5] - vertices[4], vertices[6] - vertices[5]),
                GetNormal(vertices[5] - vertices[4], vertices[6] - vertices[5]),
                GetNormal(vertices[5] - vertices[4], vertices[6] - vertices[5]),

                GetNormal(vertices[9] - vertices[8], vertices[10] - vertices[9]),
                GetNormal(vertices[9] - vertices[8], vertices[10] - vertices[9]),
                GetNormal(vertices[9] - vertices[8], vertices[10] - vertices[9]),
                GetNormal(vertices[9] - vertices[8], vertices[10] - vertices[9]),

                GetNormal(vertices[13] - vertices[12], vertices[14] - vertices[13]),
                GetNormal(vertices[13] - vertices[12], vertices[14] - vertices[13]),
                GetNormal(vertices[13] - vertices[12], vertices[14] - vertices[13]),
                GetNormal(vertices[13] - vertices[12], vertices[14] - vertices[13]),


                GetNormal(vertices[17] - vertices[16], vertices[18] - vertices[17]),
                GetNormal(vertices[17] - vertices[16], vertices[18] - vertices[17]),
                GetNormal(vertices[17] - vertices[16], vertices[18] - vertices[17]),
                GetNormal(vertices[17] - vertices[16], vertices[18] - vertices[17])
            };
            normals[0] = normals[5] = normals[18] = (normals[0] + normals[5] + normals[18]).Normalized();
            normals[1] = normals[14] = normals[17] = (normals[1] + normals[14] + normals[17]).Normalized();
            normals[2] = normals[10] = normals[13] = (normals[2] + normals[10] + normals[13]).Normalized();
            normals[3] = normals[6] = normals[9] = (normals[3] + normals[6] + normals[9]).Normalized();
            normals[4] = normals[19] = (normals[4] + normals[19]).Normalized();
            normals[7] = normals[8] = (normals[7] + normals[8]).Normalized();
            normals[11] = normals[12] = (normals[11] + normals[12]).Normalized();
            normals[15] = normals[16] = (normals[15] + normals[16]).Normalized();
            shortBlock.BindVertices(vertices);
            shortBlock.BindColors(colors);
            shortBlock.BindNormals(normals);

            pyramid = new Primitive();
            vertices = new Vector3[]
            {
                new Vector3(314.0f, 0.0f, 456.0f),
                new Vector3(368.5f, 330.0f, 351.25f),
                new Vector3(265.0f, 0.0f, 296.0f),
                
                new Vector3(265.0f, 0.0f, 296.0f),
                new Vector3(368.5f, 330.0f, 351.25f),
                new Vector3(423.0f, 0.0f, 247.0f),

                new Vector3(423.0f, 0.0f, 247.0f),
                new Vector3(368.5f, 330.0f, 351.25f),
                new Vector3(472.0f, 0.0f, 406.0f),
                
                new Vector3(472.0f, 0.0f, 406.0f),
                new Vector3(368.5f, 330.0f, 351.25f),
                new Vector3(314.0f, 0.0f, 456.0f),
            };
            colors = new Vector3[]
            {
                creamColor,
                creamColor,
                creamColor,
               
                creamColor,
                creamColor,
                creamColor,

                creamColor,
                creamColor,
                creamColor,
                
                creamColor,
                creamColor,
                creamColor
            };
            normals = new Vector3[]
            {
                GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),

                GetNormal(vertices[4] - vertices[3], vertices[5] - vertices[4]),
                GetNormal(vertices[4] - vertices[3], vertices[5] - vertices[4]),
                GetNormal(vertices[4] - vertices[3], vertices[5] - vertices[4]),

                GetNormal(vertices[7] - vertices[6], vertices[8] - vertices[7]),
                GetNormal(vertices[7] - vertices[6], vertices[8] - vertices[7]),
                GetNormal(vertices[7] - vertices[6], vertices[8] - vertices[7]),

                GetNormal(vertices[10] - vertices[9], vertices[11] - vertices[10]),
                GetNormal(vertices[10] - vertices[9], vertices[11] - vertices[10]),
                GetNormal(vertices[10] - vertices[9], vertices[11] - vertices[10])
            };
            normals[0] = normals[11] = (normals[0] + normals[11]).Normalized();
            normals[2] = normals[3] = (normals[2] + normals[3]).Normalized();
            normals[5] = normals[6] = (normals[5] + normals[6]).Normalized();
            normals[7] = normals[8] = (normals[7] + normals[8]).Normalized();
            normals[1] = normals[4] = normals[7] = normals[10] = (normals[1] + normals[4] + normals[7] + normals[10]).Normalized();
            pyramid.BindVertices(vertices);
            pyramid.BindColors(colors);
            pyramid.BindNormals(normals);

            lightSource = new Primitive();
            vertices = new Vector3[]
            {
                new Vector3(343.0f, 548.7f, 227.0f),
                new Vector3(343.0f, 548.7f, 332.0f),
                new Vector3(213.0f, 548.7f, 332.0f),
                new Vector3(213.0f, 548.7f, 227.0f)
            };
            colors = new Vector3[]
            {
                new Vector3(1.0f, 1.0f, 1.0f),
                new Vector3(1.0f, 1.0f, 1.0f),
                new Vector3(1.0f, 1.0f, 1.0f),
                new Vector3(1.0f, 1.0f, 1.0f)
            };
            normals = new Vector3[]
            {
                GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1]),
                GetNormal(vertices[1] - vertices[0], vertices[2] - vertices[1])
            };
            lightSource.BindVertices(vertices);
            lightSource.BindColors(colors);
            lightSource.BindNormals(normals);
        }

        public void Render()
        {
            shader.Start();
            GL.Enable(EnableCap.CullFace);
            GL.PolygonMode(MaterialFace.Back, PolygonMode.Fill);

            GL.UniformMatrix4(shader.ProjectionMatrixID, false, ref Camera.ProjectionMatrix);
            GL.UniformMatrix4(shader.ModelViewMatrixID, false, ref Camera.ModelViewMatrix);
            GL.Uniform3(shader.CameraPositionID, ref Camera.Eye);
            GL.Uniform1(shader.AmbientIntensityID, light.AmbientIntensity);
            GL.Uniform1(shader.DiffuseIntensityID, light.DiffuseIntensity);
            GL.Uniform3(shader.LightDirectionID, ref light.Position);
            GL.Uniform1(shader.ConstantAttenuationID, light.ConstantAttenuation);
            GL.Uniform1(shader.LinearAttenuationID, light.LinearAttenuation);
            GL.Uniform1(shader.ExponentialAttenuationID, light.ExponentialAttenuation);
            GL.Uniform1(shader.SpecularIntensityID, light.SpecularIntensity);
            GL.Uniform1(shader.SpecularPowerID, light.SpecularPower);

            GL.BindVertexArray(floor.VaoID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, floor.VertexBufferID);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, floor.ColorBufferID);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, floor.NormalBufferID);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            GL.BindVertexArray(backWall.VaoID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, backWall.VertexBufferID);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, backWall.ColorBufferID);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, backWall.NormalBufferID);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            GL.BindVertexArray(rightWall.VaoID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, rightWall.VertexBufferID);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, rightWall.ColorBufferID);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, rightWall.NormalBufferID);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            GL.BindVertexArray(leftWall.VaoID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, leftWall.VertexBufferID);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, leftWall.ColorBufferID);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, leftWall.NormalBufferID);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            GL.BindVertexArray(ceiling.VaoID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, ceiling.VertexBufferID);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, ceiling.ColorBufferID);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, ceiling.NormalBufferID);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            GL.BindVertexArray(shortBlock.VaoID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, shortBlock.VertexBufferID);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, shortBlock.ColorBufferID);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, shortBlock.NormalBufferID);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.DrawArrays(PrimitiveType.Quads, 0, 20);

            GL.BindVertexArray(pyramid.VaoID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, pyramid.VertexBufferID);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, pyramid.ColorBufferID);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, pyramid.NormalBufferID);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 12);

            GL.BindVertexArray(lightSource.VaoID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, lightSource.VertexBufferID);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, lightSource.ColorBufferID);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, lightSource.NormalBufferID);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            shader.Stop();
            GL.Color3(1f, 1f, 1f);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(light.Position);
            GL.End();
        }
    }
}
