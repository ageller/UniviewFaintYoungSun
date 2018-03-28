uniform float uv_fade;
uniform float uv_alpha;

in vec2 TexCoord;

uniform float simUseTime;

out vec4 fragColor;

void main()
{	

	float tmin = 1000.;
	float tdur = 1000.;
	float tdiff = abs(simUseTime - tmin);
	float r = clamp(tdiff/tdur, 0.2, 0.7);
	fragColor = vec4(r, 0., 0., r);
	fragColor.a *= uv_fade * uv_alpha;

}