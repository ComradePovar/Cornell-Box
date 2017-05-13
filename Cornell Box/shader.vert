#version 400

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelViewMatrix;

layout (location = 0) in vec3 inPosition;
layout (location = 1) in vec3 inColor;
layout (location = 2) in vec3 inNormal;

out vec3 color;
out vec3 normal;
out vec3 worldPos;

void main(){
	gl_Position = projectionMatrix * modelViewMatrix * vec4(inPosition, 1.0);
	color = inColor;
	normal = inNormal;
	worldPos = inPosition;
}