shader_type spatial;
render_mode unshaded, cull_disabled;

uniform float speed : hint_range(0.1, 5.0) = 1.5;

void fragment() {
    vec2 uv = UV - vec2(0.5);
    float radius = length(uv);
    
    // Orízne vse mimo kruh
    if (radius > 0.5) {
        discard;
    }
    
    // Spirala
    float angle = atan(uv.y, uv.x);
    float spiral = mod(angle / (2.0 * 3.14159) + radius * 3.0 - TIME * speed, 1.0);
    
    // Cerveno-fialove barvy bez modre
    vec3 col = mix(
        vec3(0.6, 0.0, 0.0),
        vec3(0.6, 0.0, 0.2),
        spiral
    );
    
    // Kraj portalu ztmavi
    col *= 1.0 - radius * 1.5;
    
    ALBEDO = col;
    EMISSION = col * 2.5;
}