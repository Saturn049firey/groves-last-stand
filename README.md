# Grove's Last Stand

## Overview
3D first-person action game where you play as a druid defending a sacred flower from waves of demons. 
Cast spells, manage your mana, and protect the grove at all costs.
Built in Godot 4 with a PS1 retro aesthetic.

### Spells
- **Fireball** (10 mana) - Deals damage, then sets the enemy on fire dealing additional damage over 5 seconds
- **Ice Shard** (15 mana) - Deals damage and slows the enemy for 5 seconds
- **Lightning** (25 mana) - Deals damage and chains to nearby enemies, damage halves with each bounce
- **Poison Cloud** (50 mana) - Launches a slow-moving cloud that stays in place for 5 seconds dealing damage to all enemies inside

## How to play
- WASD - Movement
- Mouse - Look around
- Left Click - Cast spell
- 1/2/3/4 or Scroll Wheel - Switch spells

## TODO list
### Gameplay
- [ ] Add demon waves system (spawn from portals)
- [ ] Add sacred flower with HP that demons attack
- [ ] Game over screen when flower dies
- [ ] Victory screen after surviving X waves
- [ ] Implement spell effects (Fireball burn, Ice slow, Lightning chain, Poison cloud)
- [x] Add spell cooldowns
- [x] Add enemy HP bars (Sprite3D billboard)

### Visuals
- [ ] PS1 post-processing shader (low resolution, fog)
- [ ] Demon model (billboard sprite)
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

## Ideas
- **Spell dice** - Instead of fixed damage, roll random dice
  - Fireball = 2d6 (2-12 damage)
  - Ice Shard = 1d8 (1-8 damage)
  - Lightning = 3d4 (3-12 damage)
  - Poison Cloud = 1d4 per tick (1-4 damage)
- **Spell slots** - Instead of mana bar, limited number of casts per spell, refills after each wave
- **Critical hit** - 10% chance for double damage
- **Resistance** - Some demons are resistant to certain spells (ice demon takes less from Ice Shard etc.)
- **Leveling** - After each wave gain points to upgrade spells, HP or mana
- **Different demon types** - Each has different HP, speed and resistance
- **Spell combos** - Ice Shard slows enemy, then Fireball deals bonus damage (DnD synergy)
- **Flower HP bar** - Show flower HP in HUD when far away, show 3D bar above flower when close
- **Enemy direction indicator** - Show arrows or dots on the edge of the screen pointing to where enemies are coming from