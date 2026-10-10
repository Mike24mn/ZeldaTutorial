# The Legend of Zelda - Project 1

Recreation of Dungeon #1 from the original 1986 *The Legend of Zelda* in Unity.

## Project Progress

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
- Solid water tiles and a reusable water prefab have been added.
- Pushable blocks, staircase teleports, and the Bow Room have been implemented.
- The Old-Man Room has been implemented with dialogue and a sprite.

#### Resolution and Control Standards

- Game build uses the required windowed 1024 × 960 resolution.
- Runtime resolution is configured using `Screen.SetResolution()`.
- Dungeon is configured as the startup scene for the game build.
- Arrow Keys and WASD control Link's movement.
- X controls the standard weapon.
- Z uses the currently selected alternate weapon.
- Space cycles through available alternate weapons.

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
- Bow is available as an alternate weapon.
- Press Z while the bow is selected to fire an arrow.
- Arrows fire in the direction Link is facing.
- Firing an arrow consumes one rupee.
- Arrow sprite and projectile behavior are implemented.
- Arrows damage enemies through the enemy health and knockback system.

#### Boomerang

- Boomerang alternate weapon is implemented.
- Boomerang can be selected by cycling alternate weapons with Space.
- Press Z while the boomerang is selected to throw it.
- Boomerang is thrown in the direction Link is facing.
- Boomerang spins while traveling.
- Boomerang travels outward and then returns to Link.
- Boomerang returns early after striking an enemy.
- Boomerang damages enemies through the enemy health and knockback system.
- Boomerang is represented in the alternate-weapon HUD.

#### Bomb

- Bomb alternate weapon is implemented.
- Bomb can be selected by cycling alternate weapons with Space.
- Press Z while the bomb is selected to place a bomb.
- Bombs use a timed fuse before exploding.
- Bomb explosion has visible feedback.
- Bomb explosion affects enemies within an area of effect.
- Bombs damage enemies through the enemy health and knockback system.
- Bomb is represented in the alternate-weapon HUD.

#### Alternate Weapon Selection

- Space cycles through the available alternate weapons.
- Currently implemented alternate weapons are Bow, Boomerang, and Bomb.
- Z uses the currently selected alternate weapon.
- The HUD icon updates to display the currently selected alternate weapon.

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
- Sword indicator is implemented.
- Alternate-weapon indicator is implemented.
- Alternate-weapon icon changes when cycling between Bow, Boomerang, and Bomb.
- HUD displays health, rupee count, and key count.

#### Stalfos

- Stalfos enemy sprite and prefab are implemented.
- Stalfos moves around the dungeon in four directions.
- Stalfos changes direction while navigating the environment.
- Stalfos collides with dungeon walls and obstacles.
- Contact with Stalfos damages Link.
- Stalfos has a functional health system.
- Stalfos takes damage from player weapons.
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

| Input | Action |
| --- | --- |
| Arrow Keys / WASD | Move |
| X | Sword |
| Z | Use selected alternate weapon |
| Space | Cycle alternate weapon |
| 1 | Toggle cheat / god mode |

## P1 Alpha Progress

### Completed / Implemented

- Boomerang weapon
- Bomb weapon
- Alternate-weapon cycling with Space
- Alternate-weapon HUD updates
- Functional player directional/movement aesthetics
- Existing player and Stalfos health/knockback systems
- Background music and collectible audio are implemented
- Keese enemy
- Goriya enemy and returning enemy boomerang
- Gel enemy
- BladeTrap enemy
- Wallmaster enemy
- Aquamentus boss with three-projectile fireball attacks, health, and weapon damage support
- Solid water tiles and reusable water prefab
- Pushable blocks and staircase teleports
- Bow Room
- Old-Man Room with dialogue and sprite

### Still In Progress

- Authentic enemy and item placement / level progression
- Additional player and enemy sound effects
- Final Alpha testing and cleanup

## Current Build Status

The project currently includes a playable recreation of the Zelda dungeon with grid-based Link movement, directional sprites, wall collision, solid water tiles, room-to-room progression, health and damage, player and enemy knockback, heart pickups, rupee and key collection, inventory HUD elements, locked doors, sword combat, full-health sword beams, and multiple alternate weapons.

The alternate-weapon system currently supports the Bow, Boomerang, and Bomb. Space cycles between available alternate weapons, the HUD updates to show the selected weapon, and Z activates the selected weapon. The Bow fires arrows using rupees, the Boomerang travels outward and returns to Link, and Bombs explode after a timed fuse and damage nearby enemies.

Stalfos, Keese, Goriya, Gel, BladeTrap, Wallmaster, and Aquamentus are implemented in the Dungeon scene. Standard enemies support weapon damage; BladeTrap charges at Link, while Wallmaster grabs Link and returns him to the dungeon entrance. Aquamentus moves vertically and fires three spread projectiles toward Link when he is nearby. Aquamentus can be defeated using the sword, sword beam, arrows, boomerang, or bombs. Stalfos and Gel can randomly drop collectibles when defeated.

Keys can be collected and tracked through the HUD, and locked doors consume keys when unlocked. Rupees are tracked through the HUD and are consumed when firing arrows. Collectible pickups provide audio feedback.

The cheat system toggles player invincibility while restoring maximum health and maximizing the player's rupee and key counts.

The game is configured to launch directly into the Dungeon scene using the required windowed 1024 × 960 resolution.

A dedicated `LAB_Stalfos` scene is included for isolated enemy testing. The generated Zelda dungeon map is functioning correctly after updating the tile-generation code for the current Unity version.

Development has progressed from the P1 Milestone into the P1 Alpha requirements. All currently planned Alpha enemy types are implemented. The Bow Room, Old-Man Room, pushable blocks, staircase teleports, and solid water tiles have also been added. Remaining Alpha work focuses on authentic enemy and item placement, additional audio, integration testing, and cleanup.

### Keese
- Implemented Keese bat enemy behavior.
- Keese fly in randomized directions and change direction on collisions.
- Keese damage the player on contact.
- Keese have enemy health and support the existing combat/damage system.
- Sword, arrows, boomerang, and bombs can damage/defeat Keese.
- Created a reusable `Keese` prefab.
- Created `LAB_Keese` scene for isolated testing.
- Integrated Keese into the main Dungeon scene.

### Goriya
- Implemented Goriya enemy behavior with cardinal-direction movement.
- Added directional sprites that update based on movement direction.
- Goriya periodically throws boomerangs in the direction it is facing.
- Enemy boomerangs travel outward, return to Goriya, and damage the player.
- Goriya supports health, damage, and knockback.
- Sword, arrows, boomerang, and bombs can damage/defeat Goriya.
- Created reusable `Goriya` and `GoriyaBoomerang` prefabs.
- Created `LAB_Goriya` scene for isolated testing.
- Integrated Goriya into the main Dungeon scene.

### Gel
- Implemented Gel enemy with randomized four-direction movement and pauses between movements.
- Gel collides with walls and obstacles and damages Link on contact.
- Gel has one hit point and can be defeated with the sword, arrows, boomerang, or bombs.
- Defeated Gel randomly drops a rupee, a heart, or no item.
- Configured Gel sprite sheet transparency and sprite import settings.
- Created a reusable `Gel` prefab and integrated it into the main Dungeon scene.
- Gel's two-frame visual animation is deferred; core Alpha gameplay behavior is implemented.

### BladeTrap
- Implemented BladeTrap with horizontal and vertical player detection.
- BladeTrap charges toward Link when aligned within detection range.
- BladeTrap stops charging on collision or after reaching its maximum travel distance, then returns to its starting position.
- BladeTrap damages Link on contact using the existing player damage, knockback, and temporary invincibility system.
- Fixed the BladeTrap sprite background transparency.
- Created a reusable `BladeTrap` prefab and integrated it into the main Dungeon scene.
- Tested charging, return behavior, and contact damage in the Dungeon scene.

### Wallmaster
- Implemented Wallmaster tracking Link and grabbing him on contact.
- Grabbing Link returns him to the dungeon entrance, with camera transitions tested.
- Added respawn cooldown, transparent sprite, and reusable prefab.
- Integrated and tested Wallmaster in the Dungeon scene.

### Aquamentus
- Implemented Aquamentus boss with vertical movement within a limited range.
- Aquamentus detects Link within a nearby area and periodically fires three fireballs in a spread pattern.
- Fireballs damage Link through the existing player damage system and expire automatically.
- Added a six-hit-point health system with brief invulnerability between hits.
- Sword, sword beam, arrows, and boomerang deal one damage; bombs deal two damage.
- Aquamentus is destroyed when its health reaches zero.
- Created reusable `Aquamentus` and `AquamentusFireball` prefabs and integrated the boss into the Dungeon scene.
- Updated player weapon collision and explosion scripts to support Aquamentus damage.

### Bow Room, Staircase Teleports, and Pushable Blocks
- Implemented the Bow Room.
- Added staircase teleport functionality.
- Implemented pushable blocks.

### Old-Man Room
- Added the Old-Man Room with dialogue and a character sprite.

### Water Tiles
- Added solid water tiles and a reusable water prefab.

### Integration Notes
- The above environment features are recorded from the latest teammate commits; full in-game regression testing is still pending.
