using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Cornell_Box
{
    class PointLight
    {
        public Vector3 Position;
        public float AmbientIntensity;
        public float DiffuseIntensity;
        public float ConstantAttenuation;
        public float LinearAttenuation;
        public float ExponentialAttenuation;
        public float SpecularPower;
        public float SpecularIntensity;

        public PointLight (Vector3 position, float specularPower, float specularIntensity, float ambientIntensity, float diffuseIntensity, float constantAtt, float linearAtt, float exponentialAtt)
        {
            Position = position;
            AmbientIntensity = ambientIntensity;
            ConstantAttenuation = constantAtt;
            LinearAttenuation = linearAtt;
            ExponentialAttenuation = exponentialAtt;
            DiffuseIntensity = diffuseIntensity;
            SpecularPower = specularPower;
            SpecularIntensity = specularIntensity;
        }
    }
}
