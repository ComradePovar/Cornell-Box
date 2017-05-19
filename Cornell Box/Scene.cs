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
        private Primitive pyramid;
        private Primitive tallBlock;
        private Primitive ceiling;
        private RoomShader shader;

        public Scene(string vertexShaderPath, string fragmentShaderPath)
        {
            shader = new RoomShader(vertexShaderPath, fragmentShaderPath);
            Camera = new Camera(new Vector3(278, 273, -800), new Vector3(278, 273, -799), Vector3.UnitY);
            light = new PointLight(new Vector3(268.0f, 284.4f, 279.6f), 32f, 0.5f, 0.4f, 0.6f, 0.8f, 0.0025f, 5E-06f);
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
                new Vector3(-1, -1, 1),
                new Vector3(-1, -1, -1),
                new Vector3(1, -1, -1),
                new Vector3(1, -1, 1)
            };
            ceiling.BindVertices(vertices);
            ceiling.BindColors(colors);
            ceiling.BindNormals(normals);

            pyramid = new Primitive();
            vertices = new Vector3[]
            {
                new Vector3(185.0f, 165.0f, 169.0f),
                new Vector3(240.0f, 0.0f, 272.0f),
                new Vector3(82.0f, 0.0f, 225.0f),

                new Vector3(185.0f, 165.0f, 169.0f),
                new Vector3(82.0f, 0.0f, 225.0f),
                new Vector3(130.0f, 0.0f, 65.0f),

                new Vector3(185.0f, 165.0f, 169.0f),
                new Vector3(130.0f, 0.0f, 65.0f),
                new Vector3(290.0f, 0.0f, 114.0f),

                new Vector3(185.0f, 165.0f, 169.0f),
                new Vector3(290.0f, 0.0f, 114.0f),
                new Vector3(240.0f, 0.0f, 272.0f)
            };
            colors = new Vector3[]
            {
                new Vector3(0.0f, 1.0f, 1.0f),
                new Vector3(0.0f, 1.0f, 1.0f),
                new Vector3(0.0f, 1.0f, 1.0f),

                new Vector3(0.0f, 1.0f, 1.0f),
                new Vector3(0.0f, 1.0f, 1.0f),
                new Vector3(0.0f, 1.0f, 1.0f),

                new Vector3(0.0f, 1.0f, 1.0f),
                new Vector3(0.0f, 1.0f, 1.0f),
                new Vector3(0.0f, 1.0f, 1.0f),

                new Vector3(0.0f, 1.0f, 1.0f),
                new Vector3(0.0f, 1.0f, 1.0f),
                new Vector3(0.0f, 1.0f, 1.0f)
            };
            normals = new Vector3[]
            {
                GetNormal(vertices[0] - vertices[1], vertices[2] - vertices[0]),
                GetNormal(vertices[0] - vertices[1], vertices[2] - vertices[0]),
                GetNormal(vertices[0] - vertices[1], vertices[2] - vertices[0]),

                GetNormal(vertices[3] - vertices[4], vertices[5] - vertices[3]),
                GetNormal(vertices[3] - vertices[4], vertices[5] - vertices[3]),
                GetNormal(vertices[3] - vertices[4], vertices[5] - vertices[3]),

                GetNormal(vertices[6] - vertices[7], vertices[8] - vertices[6]),
                GetNormal(vertices[6] - vertices[7], vertices[8] - vertices[6]),
                GetNormal(vertices[6] - vertices[7], vertices[8] - vertices[6]),

                GetNormal(vertices[9] - vertices[10], vertices[11] - vertices[9]),
                GetNormal(vertices[9] - vertices[10], vertices[11] - vertices[9]),
                GetNormal(vertices[9] - vertices[10], vertices[11] - vertices[9])
            };
            pyramid.BindVertices(vertices);
            pyramid.BindColors(colors);
            pyramid.BindNormals(normals);

            tallBlock = new Primitive();
            vertices = new Vector3[]
            {
                new Vector3(423.0f, 330.0f, 247.0f),
                new Vector3(265.0f, 330.0f, 296.0f),
                new Vector3(314.0f, 330.0f, 456.0f),
                new Vector3(472.0f, 330.0f, 406.0f),
                
                new Vector3(423.0f, 0.0f, 247.0f),
                new Vector3(423.0f, 330.0f, 247.0f),
                new Vector3(472.0f, 330.0f, 406.0f),
                new Vector3(472.0f, 0.0f, 406.0f),

                new Vector3(472.0f, 0.0f, 406.0f),
                new Vector3(472.0f, 330.0f, 406.0f),
                new Vector3(314.0f, 330.0f, 456.0f),
                new Vector3(314.0f, 0.0f, 456.0f),
                
                new Vector3(314.0f, 0.0f, 456.0f),
                new Vector3(314.0f, 330.0f, 456.0f),
                new Vector3(265.0f, 330.0f, 296.0f),
                new Vector3(265.0f, 0.0f, 296.0f),

                new Vector3(265.0f, 0.0f, 296.0f),
                new Vector3(265.0f, 330.0f, 296.0f),
                new Vector3(423.0f, 330.0f, 247.0f),
                new Vector3(423.0f, 0.0f, 247.0f)
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
            tallBlock.BindVertices(vertices);
            tallBlock.BindColors(colors);
            tallBlock.BindNormals(normals);

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

            GL.UniformMatrix4(shader.ProjectionMatrixID, false, ref Camera.ProjectionMatrix);
            GL.UniformMatrix4(shader.ModelViewMatrixID, false, ref Camera.ModelViewMatrix);
            GL.Uniform3(shader.CameraPositionID, ref Camera.Eye);
            GL.Uniform1(shader.AmbientIntensityID, light.AmbientIntensity);
            GL.Uniform1(shader.DiffuseIntensityID, light.DiffuseIntensity);
            GL.Uniform3(shader.LightPositionID, ref light.Position);
            GL.Uniform1(shader.ConstantAttenuationID, light.ConstantAttenuation);
            GL.Uniform1(shader.LinearAttenuationID, light.LinearAttenuation);
            GL.Uniform1(shader.ExponentialAttenuationID, light.ExponentialAttenuation);
            GL.Uniform1(shader.SpecularIntensityID, light.SpecularIntensity);
            GL.Uniform1(shader.SpecularPowerID, light.SpecularPower);

            GL.BindVertexArray(floor.VaoID);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            GL.BindVertexArray(backWall.VaoID);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            GL.BindVertexArray(rightWall.VaoID);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            GL.BindVertexArray(leftWall.VaoID);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            GL.BindVertexArray(ceiling.VaoID);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            GL.BindVertexArray(pyramid.VaoID);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 12);

            GL.BindVertexArray(tallBlock.VaoID);
            GL.DrawArrays(PrimitiveType.Quads, 0, 20);

            GL.BindVertexArray(lightSource.VaoID);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            shader.Stop();
            GL.Color3(1f, 1f, 1f);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(light.Position);
            GL.End();
        }
    }
}
