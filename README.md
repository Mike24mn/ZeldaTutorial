# The Legend of Zelda - Project 1

Recreation of Dungeon #1 from the original 1986 *The Legend of Zelda* in Unity.

## P1 Milestone Progress

### Completed

#### Grid-Based Movement

- Implemented grid-based movement for Link.
- Link moves in four directions without diagonal movement.
- Link aligns to the movement grid when changing directions.
- Directional movement sprites are implemented.

#### Dungeon / Environment

- Dungeon #1 map is generated from the provided Zelda map.
- Fixed tile-generation compatibility issue that caused generated dungeon sprites to appear incorrectly.
- Wall collision is implemented using generated wall tile prefabs.
- Doorway collision has been adjusted to allow Link to move between connected rooms.
- Camera displays a complete Zelda room using the required 4:3 presentation.
- Camera transitions between rooms as Link moves through dungeon doorways.

#### Sword

- Sword attacks in the direction Link is facing.
- Press X to use the sword.
- Sword uses directional sprites for up, down, left, and right.
- Sword collision damages enemies.
- Sword is only active during the attack.
- At full health, the sword shoots a damaging beam.
- Sword beam damages enemies.
- Sword beam has a cooldown.

#### Bow and Arrows

- Bow/arrow attack is implemented.
- Press Z to fire an arrow.
- Arrows fire in the direction Link is facing.
- Firing an arrow consumes one rupee.
- Arrow sprite and projectile behavior are implemented.

#### Player Health and Damage

- Link has a functional health system.
- Three-heart health display is shown in the HUD.
- Enemy contact damages Link.
- Link flashes after taking damage.
- Temporary invulnerability prevents immediate repeated damage.
- Knockback is applied when Link takes damage.
- Player death/restart behavior is implemented.
- Heart pickup restores health.
- Full health controls availability of the sword beam.

#### Rupees

- Rupee pickups are implemented.
- Collecting rupees increases the player's rupee count.
- Current rupee count is displayed in the HUD.
- Rupees are consumed when firing arrows.

#### Weapon UI

- HUD displays weapon information.
- Sword and bow indicators are implemented.

#### Stalfos

- Stalfos enemy sprite and prefab are implemented.
- Stalfos moves around the dungeon in four directions.
- Stalfos changes direction while navigating the environment.
- Stalfos collides with dungeon walls and obstacles.
- Contact with Stalfos damages Link.
- Stalfos can interact with the player's combat mechanics.
- Collider size was adjusted to allow proper movement through dungeon passages.
- A separate `LAB_Stalfos` scene was created for testing Stalfos behavior.

#### Cheat / Invincibility Mode

- Debug/cheat functionality is implemented.
- Press 1 to toggle the implemented god-mode/invincibility behavior.

#### Functional Player Aesthetics

- Link has directional sprites.
- Link uses different sprites to indicate movement.
- Combat and damage provide visual feedback.

## Controls

| Input | Action |
| --- | --- |
| Arrow Keys / WASD | Move |
| X | Sword |
| Z | Bow / Fire Arrow |
| 1 | Toggle cheat / god mode |

## P1 Milestone Tasks Still In Progress

Remaining milestone work includes:

- Locked doors and keys
- Remaining dungeon mechanic integration
- Final testing and cleanup
- Project management / submission requirements

## Current Build Status

The project currently includes a playable recreation of the Zelda dungeon with grid-based Link movement, directional sprites, wall collision, room-to-room progression, health and damage, knockback, heart pickups, rupee collection, sword combat, full-health sword beams, bow and arrow combat, weapon HUD elements, cheat functionality, and a functional Stalfos enemy.

A dedicated `LAB_Stalfos` scene is included for isolated enemy testing. The generated Zelda dungeon map is functioning correctly after updating the tile-generation code for the current Unity version.

Development is ongoing toward completion of the P1 Milestone deliverable.