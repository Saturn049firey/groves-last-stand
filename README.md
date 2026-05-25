# Grove's Last Stand

## Overview
3D first-person action game where you play as a druid defending a sacred flower from waves of demons. 
Cast spells, manage your mana, and protect the grove at all costs.
Built in Godot 4 with a PS1 retro aesthetic.

## How to play
- WASD - Movement
- Mouse - Look around
- Left Click - Cast spell
- 1/2/3/4 or Scroll Wheel - Switch spells
- ESC - Release cursor

## Spells
- **Fireball** (10 mana) - Deals damage, then sets the enemy on fire dealing additional damage over 5 seconds
- **Ice Shard** (15 mana) - Deals damage and slows the enemy for 5 seconds
- **Lightning** (25 mana) - Deals damage and chains to nearby enemies, damage halves with each bounce
- **Poison Cloud** (50 mana) - Launches a slow-moving cloud that stays in place for 5 seconds dealing damage to all enemies inside

## TODO list
### Gameplay
- [ ] Add demon waves system (spawn from portals)
- [ ] Add sacred flower with HP that demons attack
- [ ] Game over screen when flower dies
- [ ] Victory screen after surviving X waves
- [ ] Implement spell effects (Fireball burn, Ice slow, Lightning chain, Poison cloud)
- [ ] Add spell cooldowns
- [ ] Add enemy HP bars (Sprite3D billboard)

### Visuals
- [ ] PS1 post-processing shader (low resolution, fog)
- [ ] Demon model (billboard sprite rendered from Blender)
- [ ] Sacred flower model
- [ ] Environment (trees, rocks, arena boundary)
- [ ] Spell particle effects
- [ ] Hit effects on enemies

### Audio
- [ ] Spell cast sounds
- [ ] Demon sounds
- [ ] Ambient forest sounds
- [ ] Music

### Polish
- [ ] Main menu
- [ ] Pause menu
- [ ] Score system
- [ ] Difficulty scaling per wave