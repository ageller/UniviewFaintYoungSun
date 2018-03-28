uniform float uv_fade;
uniform float uv_alpha;
uniform sampler2D VenusTexture;

flat in float DistanceFade;
in vec2 TexCoord;

uniform vec3 glowColor;

out vec4 FragColor;

void main()
{	
	vec4 mapColor = texture(VenusTexture,TexCoord);
    mapColor.a*=uv_alpha*uv_fade;
	FragColor = mapColor;

}