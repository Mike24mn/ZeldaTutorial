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

#### Resolution and Control Standards

- Game build uses the required windowed 1024 × 960 resolution.
- Runtime resolution is configured using `Screen.SetResolution()`.
- Dungeon is configured as the startup scene for the game build.
- Arrow Keys and WASD control Link's movement.
- X controls the standard weapon (sword).
- Z controls the alternate weapon (bow).

#### Sword

- Sword attacks in the direction Link is facing.
- Press X to use the sword.
- Sword uses directional sprites for up, down, left, and right.
- Sword collision damages enemies.
- Sword is only active during the attack.
- At full health, the sword shoots a damaging beam.
- Sword beam damages enemies.
- Sword beam has a cooldown.
- Sword and sword beam attacks use the enemy health and knockback system.

#### Bow and Arrows

- Bow/arrow attack is implemented.
- Press Z to fire an arrow.
- Arrows fire in the direction Link is facing.
- Firing an arrow consumes one rupee.
- Arrow sprite and projectile behavior are implemented.
- Arrows damage enemies through the enemy health and knockback system.

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
- Current rupee count is displayed in the HUD with a rupee icon.
- Rupee pickups provide audio feedback.
- Rupees are consumed when firing arrows.

#### Keys and Locked Doors

- Key pickups are implemented.
- Collecting a key increases the player's key count.
- Current key count is displayed in the HUD with a key icon.
- Key pickups provide audio feedback.
- Locked doors prevent Link from passing without a key.
- Entering a locked door with a key consumes one key.
- The door unlocks after consuming a key and allows Link to continue into the connected room.

#### Collectable Power-Ups / Enemy Drops

- Heart and rupee collectible prefabs are implemented.
- Stalfos can drop collectibles when defeated.
- Enemy drops are randomized between a rupee, a heart, or no item.
- Dropped rupees can be collected and update the player's rupee count.
- Dropped hearts can be collected to restore player health.

#### Weapon UI

- HUD displays weapon information.
- Sword and bow indicators are implemented.
- HUD displays health, rupee count, and key count.

#### Stalfos

- Stalfos enemy sprite and prefab are implemented.
- Stalfos moves around the dungeon in four directions.
- Stalfos changes direction while navigating the environment.
- Stalfos collides with dungeon walls and obstacles.
- Contact with Stalfos damages Link.
- Stalfos has a functional health system.
- Stalfos takes damage from the sword, sword beam, and arrows.
- Stalfos is knocked back when damaged.
- Stalfos is defeated when its health reaches zero.
- Defeated Stalfos can randomly drop a heart or rupee.
- Collider size was adjusted to allow proper movement through dungeon passages.
- A separate `LAB_Stalfos` scene was created for testing Stalfos behavior.

#### Cheat / Invincibility Mode

- Debug/cheat functionality is implemented.
- Press 1 to toggle god-mode/invincibility behavior.
- Activating the cheat restores Link to maximum health.
- Activating the cheat maximizes the player's rupee count.
- Activating the cheat maximizes the player's key count.

#### Functional Player Aesthetics

- Link has directional sprites.
- Link uses different sprites to indicate movement.
- Combat and damage provide visual feedback.
- Collectible pickups provide visual and audio feedback.

## Controls

| **InputAction**   |                         |
| ----------------- | ----------------------- |
| Arrow Keys / WASD | Move                    |
| X                 | Sword                   |
| Z                 | Bow / Fire Arrow        |
| 1                 | Toggle cheat / god mode |

## P1 Milestone Tasks Still In Progress

Remaining milestone work includes:

- Final testing and cleanup
- Project management / submission requirements
- Windows and Mac build preparation
- Final deliverable packaging

## Current Build Status

The project currently includes a playable recreation of the Zelda dungeon with grid-based Link movement, directional sprites, wall collision, room-to-room progression, health and damage, player and enemy knockback, heart pickups, rupee and key collection, inventory HUD elements, locked doors, sword combat, full-health sword beams, bow and arrow combat, weapon HUD elements, cheat functionality, and a functional Stalfos enemy.

Stalfos uses a health system rather than being immediately destroyed by attacks. Sword, sword beam, and arrow attacks damage Stalfos and apply knockback. When defeated, Stalfos can randomly drop a heart, a rupee, or no collectible.

Keys can be collected and tracked through the HUD, and locked doors consume keys when unlocked. Rupees are also tracked through the HUD and are consumed when firing arrows. Collectible pickups provide audio feedback.

The cheat system toggles player invincibility while restoring maximum health and maximizing the player's rupee and key counts.

The game is configured to launch directly into the Dungeon scene using the required windowed 1024 × 960 resolution. The required milestone control scheme is implemented for movement, the standard weapon, and the alternate weapon.

A dedicated `LAB_Stalfos` scene is included for isolated enemy testing. The generated Zelda dungeon map is functioning correctly after updating the tile-generation code for the current Unity version.

Development is now in the final testing, build, and submission preparation stage for the P1 Milestone deliverable.
