uniform float uv_fade;
uniform float uv_alpha;
uniform sampler2D bmng;
uniform sampler2D stateTexture;

flat in float DistanceFade;
in vec2 TexCoord;
flat in vec3 starColor;

uniform vec3 glowColor;

void main()
{	
	float redTemp=4000.;
	float blueTemp = 10000.;
	float solTemp = 5600.;
	vec4 currentColor = texture(stateTexture, vec2(0.5));
	float currentTemp = currentColor.r;
	vec4 mixColor;
	float mixFactor;
	vec4 mapColor = texture(bmng,TexCoord);
	if (currentTemp >solTemp) {
	  mixColor=vec4(0.8,0,1.0,2.0);
	  mixFactor = clamp((currentTemp-solTemp)/(blueTemp-solTemp),0.0,1.0);
	} else {
	  mixColor=vec4(-0.5,-.5,-.5,1.0);
	  mixFactor = clamp((currentTemp-solTemp)/(redTemp-solTemp),0.0,1.0);
	}
	float greenFactor=clamp(4.0*(mapColor.g-0.5*(mapColor.r+mapColor.b)),0,1.0);
	vec4 color = mix(mapColor,mixColor,mixFactor*greenFactor);
    color.a*=uv_alpha*uv_fade;
	gl_FragColor = color;

}