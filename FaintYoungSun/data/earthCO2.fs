uniform float uv_fade;
uniform float uv_alpha;

in vec2 TexCoord;

uniform float simUseTime;

out vec4 fragColor;

void main()
{	

	float r = 1. - simUseTime/4500.;
	fragColor = vec4(r, 0., 0., r);
	fragColor.a *= uv_fade * uv_alpha;

}