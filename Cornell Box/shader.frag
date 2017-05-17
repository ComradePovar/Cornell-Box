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
vec3 calcDirLight();

void main(){
	vec3 result = calcDirLight();
	outputColor = vec4( result*color, 1.0);
}

vec3 calcDirLight(){
	vec3 result = vec3(1.0, 1.0, 1.0);
	vec3 whiteColor = vec3(1.0, 1.0, 1.0);
	vec3 ambient = ambientIntensity * whiteColor;
	result = ambient;
	
	vec3 norm = normalize(normal);
	vec3 lightDir = normalize(lightPosition - worldPos);
	float diffInfluence = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diffInfluence * whiteColor;
	result += diffuse;
	
	vec3 viewDir = normalize(cameraPosition - worldPos);
	vec3 reflectDir = reflect(-lightDir, norm);
	
	float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
	vec3 specular = 0.5 * spec * whiteColor;
	result += specular;
	
	float distance = length(lightPosition - worldPos);
	float attenuation = 1.0f / (constantAttenuation + linearAttenuation * distance + exponentialAttenuation * distance * distance);
	
	ambient *= attenuation;
	diffuse *= attenuation;
	specular *= attenuation;
	
	return (ambient + diffuse + specular);
}