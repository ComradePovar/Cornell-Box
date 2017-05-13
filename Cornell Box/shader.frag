#version 450

uniform vec3 lightPosition;
uniform float ambientIntensity;
uniform float diffuseIntensity;
uniform float constantAttenuation;
uniform float linearAttenuation;
uniform float exponentialAttenuation;
uniform float specularPower;
uniform float specularIntensity;
uniform vec3 cameraPosition;

in vec3 color;
in vec3 normal;
in vec3 worldPos;

out vec4 outputColor;

vec4 getSpecularLightingColor(vec3 vertexToLight);
vec4 getDiffuseLightingColor(vec3 vertexToLight, float dist);

void main(){
	float dist = length(lightPosition - worldPos);
	vec3 vertexToLight = normalize(lightPosition - worldPos);
	
	outputColor = vec4(color, 1.0)*(getDiffuseLightingColor(vertexToLight, dist) + ambientIntensity*vec4(1.0, 1.0, 1.0, 1.0) + getSpecularLightingColor(vertexToLight));
}
vec4 getSpecularLightingColor(vec3 vertexToLight){
	vec3 cameraDirection = normalize(cameraPosition - worldPos);
	vec3 reflectionVector = reflect(-vertexToLight, normalize(normal));
	float specularFactor = dot(cameraDirection, reflectionVector);
	if (specularFactor > 0)
		return vec4(1.0, 1.0, 1.0, 1.0) * pow(specularFactor, specularPower) * specularIntensity;
	else
		return vec4(0.0, 0.0, 0.0, 0.0);
}

vec4 getDiffuseLightingColor(vec3 vertexToLight, float dist){
	float attitude = constantAttenuation + linearAttenuation * dist + exponentialAttenuation * dist * dist;
	float diffuseFactor = max(0.0, dot(normalize(normal), vertexToLight));
	return vec4(1.0, 1.0, 1.0, 1.0) * (diffuseFactor) * diffuseIntensity / attitude;
}