uniform float uv_fade;
uniform float uv_alpha;
uniform sampler2D VenusTexture;
uniform float simWaterFac;
uniform float simUseTime;

in vec2 TexCoord;

out vec4 FragColor;

void main()
{	
	vec4 mapColor = texture(VenusTexture,TexCoord);
	float fac = simWaterFac * clamp((1. - simUseTime/4500.), 0, 1);
	float fade = 1. - fac*(1. - mapColor.a);
	float rfac = clamp(0.6*fade*fade - 1., -1, 0);
	float bfac = clamp((1. - 2.*fade*fade), 0, 1.);
	float gfac = clamp((0.7 - 4. * (fade - 0.6) * (fade - 0.6)) - bfac, -1, 0.0);
	mapColor.r += fac*rfac;
	mapColor.g += fac*gfac;
	mapColor.b += fac*bfac;
    mapColor.a = uv_alpha*uv_fade;
	FragColor = mapColor;

}