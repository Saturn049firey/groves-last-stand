shader_type spatial;
render_mode unshaded, cull_disabled;

uniform vec4 crystal_color : source_color = vec4(0.0, 0.5, 1.0, 1.0);
uniform float pulse_speed : hint_range(0.1, 5.0) = 2.0;
uniform float emission_strength : hint_range(1.0, 10.0) = 3.0;

void fragment() {
    float pulse = 0.7 + 0.3 * sin(TIME * pulse_speed);
    vec3 col = crystal_color.rgb * pulse;
    ALBEDO = col;
    EMISSION = col * emission_strength * pulse;
}