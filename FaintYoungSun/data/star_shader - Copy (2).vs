uniform mat4x4 uv_modelViewInverseMatrix;
uniform mat4x4 uv_projectionInverseMatrix;

in vec3 uv_vertexAttrib;

// the distance from the sun center
out float distance;

out vec3 cameraPosition;
out vec3 rayDirection;

void main(void)
{
    cameraPosition = (uv_modelViewInverseMatrix * vec4(0, 0, 0, 1)).xyz;
    distance = length(cameraPosition);
    rayDirection = (mat3(uv_modelViewInverseMatrix) * (uv_projectionInverseMatrix * vec4(uv_vertexAttrib.xy, 0.5, 1.0)).xyz);
    gl_Position = vec4(uv_vertexAttrib, 1.0);
}
