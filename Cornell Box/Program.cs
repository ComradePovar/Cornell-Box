using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;


namespace Cornell_Box
{
    class Program : GameWindow
    {
        private Scene scene;

        public Program() : base(800, 600, OpenTK.Graphics.GraphicsMode.Default, "Cornell box")
        {
            VSync = VSyncMode.On;
            scene = new Scene("shader.vert", "shader.frag");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(0.1f, 0.2f, 0.3f, 1.0f);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            scene.Camera.Resize(Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            
            if (Keyboard[Key.Q])
            {
                scene.light.ConstantAttenuation -= 0.05f;
                Console.WriteLine(scene.light.ConstantAttenuation);
            }
            if (Keyboard[Key.W])
            {
                scene.light.ConstantAttenuation += 0.05f;
                Console.WriteLine(scene.light.ConstantAttenuation);
            }
            if (Keyboard[Key.A])
            {
                scene.light.LinearAttenuation -= 0.0005f;
                Console.WriteLine(scene.light.LinearAttenuation);
            }
            if (Keyboard[Key.S])
            {
                scene.light.LinearAttenuation += 0.0005f;
                Console.WriteLine(scene.light.LinearAttenuation);
            }
            if (Keyboard[Key.Z])
            {
                scene.light.ExponentialAttenuation -= 0.000001f;
                Console.WriteLine(scene.light.ExponentialAttenuation);
            }
            if (Keyboard[Key.X])
            {
                scene.light.ExponentialAttenuation += 0.000001f;
                Console.WriteLine(scene.light.ExponentialAttenuation);
            }
            if (Keyboard[Key.Up])
            {
                scene.light.Position.Y += 10f;
                Console.WriteLine(scene.light.Position.Y);
            }
            if (Keyboard[Key.Down])
            {
                scene.light.Position.Y -= 10f;
                Console.WriteLine(scene.light.Position.Y);
            }
            if (Keyboard[Key.Left])
            {
                scene.light.Position.X += 10f;
                Console.WriteLine(scene.light.Position.X);
            }
            if (Keyboard[Key.Right])
            {
                scene.light.Position.X -= 10f;
                Console.WriteLine(scene.light.Position.X);
            }
            if (Keyboard[Key.ControlLeft])
            {
                scene.light.Position.Z -= 10f;
                Console.WriteLine(scene.light.Position.Z);
            }
            if (Keyboard[Key.ShiftLeft])
            {
                scene.light.Position.Z += 10f;
                Console.WriteLine(scene.light.Position.Z);
            }
            if (Keyboard[Key.Plus])
            {
                scene.light.SpecularIntensity += 0.01f;
                Console.WriteLine(scene.light.SpecularIntensity);
            }
            if (Keyboard[Key.Minus])
            {
                scene.light.SpecularIntensity -= 0.01f;
                Console.WriteLine(scene.light.SpecularIntensity);
            }
            if (Keyboard[Key.KeypadMinus])
            {
                scene.light.SpecularPower -= 1f; ;
                Console.WriteLine(scene.light.SpecularPower);
            }
            if (Keyboard[Key.KeypadPlus])
            {
                scene.light.SpecularPower += 1f;
                Console.WriteLine(scene.light.SpecularPower);
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Enable(EnableCap.DepthTest);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            scene.Render();

            SwapBuffers();
        }
        static void Main(string[] args)
        {
            using (var program = new Program())
            {
                program.Run(30.0);
            }
        }
    }
}
