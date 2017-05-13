using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Cornell_Box
{
    class RoomShader
    {
        public int ID { get; private set; }
        public int ProjectionMatrixID { get; private set; }
        public int ModelViewMatrixID { get; private set; }
        public int CameraPositionID { get; private set; }
        public int LightDirectionID { get; private set; }
        public int AmbientIntensityID { get; private set; }
        public int ConstantAttenuationID { get; private set; }
        public int LinearAttenuationID { get; private set; }
        public int ExponentialAttenuationID { get; private set; }
        public int DiffuseIntensityID { get; private set; }
        public int SpecularIntensityID { get; private set; }
        public int SpecularPowerID { get; private set; }

        public RoomShader(string vertexShaderPath, string fragmentShaderPath)
        {
            ID = GL.CreateProgram();

            CreateShader(vertexShaderPath, ShaderType.VertexShader);
            CreateShader(fragmentShaderPath, ShaderType.FragmentShader);
            GL.LinkProgram(ID);
            GetUniformLocations();
        }

        public void Start()
        {
            GL.UseProgram(ID);
        }

        public void Stop()
        {
            GL.UseProgram(0);
        }

        private void GetUniformLocations()
        {
            ProjectionMatrixID = GL.GetUniformLocation(ID, "projectionMatrix");
            ModelViewMatrixID = GL.GetUniformLocation(ID, "modelViewMatrix");
            LightDirectionID = GL.GetUniformLocation(ID, "lightPosition");
            AmbientIntensityID = GL.GetUniformLocation(ID, "ambientIntensity");
            DiffuseIntensityID = GL.GetUniformLocation(ID, "diffuseIntensity");
            ConstantAttenuationID = GL.GetUniformLocation(ID, "constantAttenuation");
            LinearAttenuationID = GL.GetUniformLocation(ID, "linearAttenuation");
            ExponentialAttenuationID = GL.GetUniformLocation(ID, "exponentialAttenuation");
            CameraPositionID = GL.GetUniformLocation(ID, "cameraPosition");
            SpecularIntensityID = GL.GetUniformLocation(ID, "specularIntensity");
            SpecularPowerID = GL.GetUniformLocation(ID, "specularPower");
        }
        private void CreateShader(string shaderPath, ShaderType type)
        {
            int shaderID = GL.CreateShader(type);
            GL.ShaderSource(shaderID, File.ReadAllText(shaderPath));
            GL.CompileShader(shaderID);

            int compileStatus;
            GL.GetShader(shaderID, ShaderParameter.CompileStatus, out compileStatus);
            if (compileStatus == 0)
            {
                throw new Exception(GL.GetShaderInfoLog(shaderID));
            }

            GL.AttachShader(ID, shaderID);
        }
    }
}
