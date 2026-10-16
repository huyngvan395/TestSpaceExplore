# SPACE EXPLORER: AURORA — ANTIGRAVITY MASTER BUILD PROMPT

## 0. ROLE

You are the lead Unity game developer responsible for completing the Unity 2D game project currently open in this workspace.

Project:
- Unity project: `TestSpaceExplore`
- Game title: `SPACE EXPLORER: AURORA`
- Genre: 2D Space Exploration + Shooter + Collecting + Upgrade + Boss Battle
- Target: a polished, playable Unity 2D game suitable for a university project/demo.

The project contains a game design document:

`SPACE_EXPLORER_AURORA_KICH_BAN_GAME.md`

READ THAT FILE FIRST.

The Markdown game design document is the gameplay SOURCE OF TRUTH. Preserve its terminology, structure, objectives, progression and core numbers unless a change is necessary to make the implementation functional.

---

# 1. FIRST ACTION — PROJECT AUDIT

DO NOT immediately generate random scripts.

Before modifying anything:

1. Read `SPACE_EXPLORER_AURORA_KICH_BAN_GAME.md`.
2. Inspect the entire Unity project.
3. Inspect:
   - Existing scenes
   - Existing C# scripts
   - Existing prefabs
   - Existing sprites/assets
   - Existing UI
   - Existing player movement
   - Existing shooting system
   - Existing asteroid system
   - Existing GameManager
   - Existing score/game-over/pause systems
   - Existing scene transitions
   - Existing enemy/boss systems
4. Check Unity Console/compile errors if accessible.
5. Determine which systems already work.
6. Determine which systems are partial, missing or broken.

Create an internal implementation plan before making major changes.

Use this classification:

| Feature | Already exists | Partially exists | Missing | Broken |

IMPORTANT:
- Do not blindly overwrite working systems.
- Do not create duplicate classes.
- Reuse/refactor existing systems when practical.
- Preserve good existing assets.
- Do not claim a feature is complete unless it is implemented and verified.

---

# 2. DEVELOPMENT STRATEGY

Build the game in phases.

Do NOT attempt to blindly implement everything at once.

After each phase:

1. Compile the project.
2. Check for compile errors.
3. Fix errors you can safely fix.
4. Test the implemented feature.
5. Check for broken references.
6. Check for runtime exceptions.
7. Only continue when the current phase is reasonably functional.

Phases:

1. Core Player Movement + Camera + Exploration World
2. Laser Combat + Asteroids
3. Collectibles + Score + Combo
4. Enemy AI + Enemy Projectiles
5. Power-Ups + Energy + Boost
6. Missions + Areas + Warp Gates + Secret Area
7. Upgrade System + Minimap
8. Area 3 + Ancient Star Core + Dreadnought Boss
9. Main Menu + HUD + Pause + Game Over + Victory
10. VFX + Audio + Polish + Balancing
11. Final Automated Quality Check

---

# 3. CORE GAME VISION

The game must NOT feel like a simple endless asteroid shooter.

The core experience is:

**EXPLORE → COLLECT → FIGHT → UPGRADE → DISCOVER → BOSS**

The player controls the spaceship Aurora.

The player must be able to freely move the spaceship in FOUR DIRECTIONS:

- W / A / S / D
- Arrow Keys

The player should feel like they are actually exploring space.

The playable world must be larger than the camera viewport.

The camera follows the spaceship.

The player explores areas, discovers collectibles, encounters enemies, fights, collects resources, completes objectives, unlocks areas and eventually fights the final boss.

---

# 4. PLAYER MOVEMENT

Implement smooth 2D spaceship movement.

Requirements:
- WASD movement.
- Arrow key movement.
- Four-direction movement.
- Rigidbody2D based movement.
- Responsive controls.
- Smooth acceleration/deceleration where appropriate.
- Player remains inside world bounds.
- Camera follows player.
- Subtle spaceship banking/rotation when moving horizontally.
- SHIFT activates boost.
- Boost consumes Energy.
- Boost has sensible limits/cooldown if needed.

Do NOT restrict the player to only the visible screen.

The playable area must be larger than the camera viewport.

---

# 5. CAMERA AND EXPLORATION WORLD

Create a proper exploration environment.

Implement:
- Camera follow.
- World boundaries.
- Exploration zones.
- Spawn points.
- Collectibles distributed throughout the world.
- Enemy encounters.
- Warp gates.
- Secret areas.
- Points of interest.

The player should NOT see the entire area immediately.

Do not create a huge empty map.

The world should have intentional exploration routes and discoveries.

Recommended structure:

STARTING AREA
↓
ASTEROID FIELD
↓
COLLECTIBLE AREA
↓
ENEMY ENCOUNTER
↓
RESOURCE AREA
↓
SECRET AREA
↓
OBJECTIVE LOCATION
↓
WARP GATE

---

# 6. ASTEROIDS

Asteroids are environmental hazards and destructible objects.

Implement 3 sizes:

Large:
- HP: 3
- Score: 20
- Splits into 2 Medium asteroids.

Medium:
- HP: 2
- Score: 30
- Splits into 2 Small asteroids.

Small:
- HP: 1
- Score: 50
- Destroyed completely.

Asteroids should:
- Move in different directions.
- Rotate.
- Have varied speeds.
- Exist throughout exploration areas.
- Be placed/spawned throughout the world.
- NOT simply fall vertically from the top of the screen.

---

# 7. PLAYER COMBAT

The player fires laser projectiles using SPACE.

Requirements:
- Hold SPACE to continuously fire.
- Base fire interval approximately 0.35 seconds.
- Projectile moves forward.
- Projectile has limited lifetime.
- Projectile damages asteroids and monsters.
- Explosion/impact effect when appropriate.

Combat must work reliably with collision detection.

---

# 8. STAR CRYSTALS

Star Crystal is the main collectible.

Requirements:
- Floating animation.
- Rotation.
- Glow/pulse effect where possible.
- Collect when player enters pickup range.
- Magnet behavior.
- Default magnet radius approximately 3 units.
- Star Crystal gives +100 score.
- Combo system.

Combo:
- Collecting crystals within 3 seconds increases combo.
- Example:
  - Crystal 1 = x1
  - Crystal 2 = x2
  - Crystal 3 = x3
  - Crystal 4 = x4
- If the player does not collect another crystal for 3 seconds, combo resets.

Star Crystal should also contribute to progression/upgrades, not only score.

---

# 9. OTHER COLLECTIBLES

Implement:

## Energy Cell
- +20 Energy.
- Used by Boost and certain world interactions.

## Repair Kit
- Restores approximately 25% HP.

## Ancient Artifact
- Rare collectible.
- +500 score.
- Used for exploration/lore/secret discovery.

---

# 10. ENEMY SYSTEM

Implement 3 enemy types.

## CHASER
- HP: 2
- Score: 40
- Detects player.
- Moves toward player.
- Changes direction dynamically.
- Encourages player movement.

## GUNNER
- HP: 2
- Score: 60
- Attempts to maintain distance.
- Moves laterally/horizontally.
- Fires enemy plasma projectiles toward player.

## TANK
- HP: 6
- Score: 100
- Slow movement.
- High durability.
- Heavy enemy.

Each enemy must have noticeably different behavior.

Do NOT make all enemies behave the same.

Enemies should create encounters during exploration instead of spawning directly on top of the player.

---

# 11. ENEMY PROJECTILES

Gunner and Boss can fire projectiles.

Enemy bullets:
- Visually different from player laser.
- Move toward player.
- Have lifetime.
- Damage player.
- Destroy on collision where appropriate.

The player must be able to dodge using movement and BOOST.

---

# 12. PLAYER HEALTH AND SHIELD

Player:
- HP: 100.

Suggested damage:
- Small Asteroid = 25
- Medium Asteroid = 35
- Large Asteroid = 50
- Chaser = 30
- Enemy Bullet = 20
- Boss Charge = 60

Shield:
- Can block one major collision.
- Display visual shield around spaceship.
- Shield disappears after absorbing damage.

If HP reaches zero:
**GAME OVER**

Prevent duplicate damage from the same collision event.

---

# 13. POWER-UPS

Implement 5 power-ups.

## SHIELD
- Blocks one collision.
- Duration/availability approximately 10 seconds.

## RAPID-FIRE
- Fire interval approximately 0.12 seconds.
- Duration 8 seconds.

## TRIPLE-SHOT
- Fires 3 projectiles.
- Center + angled left/right.
- Duration 10 seconds.

## SPEED BOOST
- Approximately +40% movement speed.
- Duration 8 seconds.

## MAGNET
- Increases collectible attraction radius from 3 to approximately 9 units.
- Duration 8 seconds.

Power-ups should be collectible and visually distinct.

---

# 14. ENERGY AND BOOST

The spaceship has Energy.

SHIFT activates BOOST.

Boost:
- Temporarily increases movement speed.
- Consumes Energy.
- Has sensible cooldown/energy drain.
- Has strong visual feedback.

Energy Cell restores Energy.

Do not allow infinite boosting.

---

# 15. UPGRADE SYSTEM

Implement a simple functional upgrade system.

Upgrade categories:

## ENGINE
Increases movement speed.

## LASER
Increases damage.

## SHIELD
Improves defensive capability.

## ENERGY
Increases maximum Energy.

Star Crystal can be spent on upgrades.

Create an upgrade UI.

The upgrade system persists during the current run.

If persistent save data is implemented, use PlayerPrefs or another clean lightweight save system.

---

# 16. AREA 1 — AURORA NEBULA

Theme:
- Blue/purple nebula.
- Relatively calm.
- Tutorial/exploration focused.

Objectives:
- Collect 5 Star Crystals.
- Collect 2 Energy Cells.
- Find/activate Navigation Beacon.

Enemies:
- Chaser.
- Low asteroid density.

After completing the objective:
- Navigation Beacon activates.
- Warp Gate becomes available.
- Player can travel to Area 2.

---

# 17. AREA 2 — ASTEROID FRONTIER

Theme:
- Dense asteroid field.
- More dangerous.

Enemies:
- Chaser.
- Gunner.
- Tank.

Objectives:
- Collect 10 Star Crystals.
- Destroy 8 Monsters.
- Find Warp Gate.
- Collect/use enough Energy to activate Warp Gate.

Add a SECRET AREA.

Secret Area contains:
- Ancient Artifact.
- Bonus Star Crystal(s).
- Optional lore/reward.

The secret area should be discoverable through exploration, not immediately visible.

---

# 18. AREA 3 — BLACK HOLE CORE

Theme:
- Dark purple/black space.
- Large black hole.
- Dangerous environment.

Difficulty:
- High asteroid density.
- Faster enemies.
- More enemy bullets.
- More dangerous encounters.

Main objective:
- Find Ancient Star Core.

When the player finds/activates the Ancient Star Core:
- Trigger warning.
- Start Boss encounter.

---

# 19. FINAL BOSS — DREADNOUGHT

Boss:
**DREADNOUGHT**

HP:
40

Reward:
+1000 score.

Boss must have multiple phases.

## PHASE 1 — FAN SHOT
Boss fires multiple projectiles in a fan pattern.

## PHASE 2 — SUMMON
When Boss reaches approximately 60% HP:
- Summon Chaser enemies.
- Continue attacking player.

## PHASE 3 — ENRAGE
When Boss reaches approximately 30% HP:
- Boss becomes visually more aggressive.
- Attack speed increases approximately 35%.
- Charge attack becomes available.

## CHARGE
- Boss targets player's current position.
- Visual warning approximately 0.5 seconds.
- Boss rapidly moves toward that position.
- Player must dodge using movement/BOOST.

When Boss HP reaches 0:
- Explosion/VFX.
- Victory state.
- Victory screen.

The Boss must be a real gameplay encounter.

Do NOT make it a stationary object that simply loses HP.

---

# 20. MISSION SYSTEM

Implement a Mission Tracker UI.

Example:

AREA 1 OBJECTIVES

[ ] Collect Star Crystals 0/5
[ ] Collect Energy Cells 0/2
[ ] Activate Navigation Beacon

AREA 2 OBJECTIVES

[ ] Collect Star Crystals 0/10
[ ] Destroy Monsters 0/8
[ ] Find Warp Gate
[ ] Activate Warp Gate

AREA 3 OBJECTIVES

[ ] Find Ancient Star Core
[ ] Defeat Dreadnought

Objectives must update automatically.

When an objective is completed:
- Show feedback.
- Update UI.
- Unlock next objective where appropriate.

---

# 21. MINIMAP

Create a simple functional minimap.

Show:
- Player.
- Important collectibles.
- Warp Gate.
- Secret Area after discovery.
- Boss location after Boss activation.
- Important objectives.

The minimap should reinforce exploration.

---

# 22. SCORE SYSTEM

Score values:

- Small Asteroid = +50
- Medium Asteroid = +30
- Large Asteroid = +20
- Chaser = +40
- Gunner = +60
- Tank = +100
- Star Crystal = +100 × Combo
- Ancient Artifact = +500
- Dreadnought = +1000

Display score clearly in HUD.

Track current score and high score.

Use PlayerPrefs or an appropriate save system for High Score.

---

# 23. GAME STATES

Implement:

MAIN MENU
↓
GAMEPLAY
↓
PAUSE
↓
GAME OVER
or
VICTORY

Pause:
- ESC / P.
- Time.timeScale = 0.
- Resume.
- Quit to Main Menu.

Game Over:
- Score.
- High Score.
- NEW RECORD when appropriate.
- Retry.
- Main Menu.

Victory:
- Mission complete.
- Final score.
- High score.
- Play Again.
- Main Menu.

Make sure Time.timeScale is correctly restored when restarting or returning to menus.

---

# 24. UI DESIGN

Use a clean futuristic neon sci-fi style.

HUD should contain:
- SCORE
- COMBO
- HP bar
- ENERGY bar
- SHIELD indicator
- BOOST indicator
- AREA
- MISSION OBJECTIVES
- MINIMAP

Use TextMeshPro.

UI must be readable and must not obstruct gameplay.

---

# 25. VISUAL STYLE

Target:
- 2D sci-fi.
- Neon futuristic interface.
- Blue/purple space atmosphere.
- Bright laser effects.
- Glowing Star Crystals.
- Distinct enemy silhouettes.
- Strong explosion effects.
- Parallax background.

Use existing assets in the project where possible.

Do not replace existing good assets unnecessarily.

If assets are missing:
- Prefer creating procedural/generative visuals automatically.
- Use simple primitives only as temporary fallback.
- Keep the game fully playable.
- Clearly identify optional assets that can later be replaced.

The final game should NOT look like a prototype made entirely from Unity primitive shapes.

---

# 26. AUDIO

Implement an AudioManager architecture.

Support:
- Shoot.
- Explosion.
- Pickup.
- Power-up.
- Enemy hit.
- Boss warning.
- Boss attack.
- Game Over.
- Victory.
- UI click.
- Area transition.

If audio files are unavailable:
- Build the architecture.
- Use safe null checks.
- Do not produce missing-reference errors.

---

# 27. SCENE STRUCTURE

Recommended scenes:

- MainMenu
- Area1_AuroraNebula
- Area2_AsteroidFrontier
- Area3_BlackHoleCore
- EndGame

If existing scenes already serve these purposes:
- Reuse them.
- Do not create unnecessary duplicates.

Each gameplay scene should be playable immediately after opening it.

---

# 28. CODE ARCHITECTURE

Use clean and maintainable C#.

Recommended folders:

Assets/Scripts/
    Player/
    Combat/
    Enemy/
    Exploration/
    Collectibles/
    PowerUps/
    Spawn/
    Game/
    UI/

Recommended scripts where appropriate:

PlayerController.cs
PlayerCombat.cs
PlayerHealth.cs
PlayerEnergy.cs

Bullet.cs
EnemyBullet.cs
DamageSystem.cs
Explosion.cs

Asteroid.cs
Monster.cs
ChaserAI.cs
GunnerAI.cs
TankAI.cs
BossController.cs

ExplorationManager.cs
AreaManager.cs
MissionManager.cs
WarpGate.cs
SecretArea.cs
MiniMapController.cs

StarPickup.cs
EnergyPickup.cs
RepairKit.cs
AncientArtifact.cs

PowerUp.cs

AsteroidSpawner.cs
MonsterSpawner.cs
PickupSpawner.cs

GameManager.cs
ScoreManager.cs
UpgradeManager.cs
SaveManager.cs

HUDController.cs
MainMenuController.cs
PauseController.cs
GameOverController.cs
VictoryController.cs

IMPORTANT:
These are recommended names, not a requirement to duplicate existing classes. Search first and reuse existing code.

---

# 29. AUTOMATIC ASSET AND PREFAB CREATION

You are responsible for creating and configuring the game's assets and prefabs whenever reasonably possible.

I do NOT want to manually create every GameObject and configure every component in the Unity Editor.

Whenever an asset can reasonably be created procedurally or through Unity's built-in systems, create it automatically.

Create/configure:

## PLAYER
- Aurora spaceship.
- Player collider.
- Rigidbody2D.
- Laser spawn point.
- Engine glow.
- Engine particle effect.
- Shield effect.

## PROJECTILES
- Player laser.
- Enemy plasma bullet.
- Boss projectile.

## ENVIRONMENT
- Large asteroid.
- Medium asteroid.
- Small asteroid.
- Space background.
- Nebula background.
- Black Hole Core background.
- Parallax background layers where practical.

## COLLECTIBLES
- Star Crystal.
- Energy Cell.
- Repair Kit.
- Ancient Artifact.

## POWER-UPS
- Shield.
- Rapid Fire.
- Triple Shot.
- Speed Boost.
- Magnet.

## ENEMIES
- Chaser.
- Gunner.
- Tank.

## BOSS
- Dreadnought.
- Boss projectiles.
- Boss shield/energy effects.
- Boss explosion.

## EXPLORATION
- Navigation Beacon.
- Warp Gate.
- Secret Area marker.
- Ancient Star Core.

## VFX
- Laser impact.
- Asteroid explosion.
- Enemy explosion.
- Player explosion.
- Pickup effect.
- Shield hit.
- Boost effect.
- Warp effect.
- Boss explosion.

## UI
- Main Menu.
- HUD.
- HP bar.
- Energy bar.
- Mission tracker.
- Score display.
- Combo display.
- Minimap.
- Pause menu.
- Game Over panel.
- Victory panel.
- Upgrade panel.

---

# 30. ARTWORK CREATION PRIORITY

Prefer this order:

1. Reuse existing assets in the project.
2. Use high-quality existing project resources where available.
3. Create Unity procedural assets where practical.
4. Create simple but visually recognizable generated/placeholder sprites when custom artwork is unavailable.
5. Create reusable prefabs automatically.
6. Configure all components automatically.
7. Only require manual Editor setup when technically unavoidable.

For important objects, create visually recognizable 2D sci-fi artwork:

- Aurora spaceship: detailed futuristic spaceship silhouette.
- Asteroids: irregular rocky shapes with multiple variations.
- Star Crystal: glowing crystalline star.
- Energy Cell: futuristic energy container.
- Repair Kit: sci-fi repair module.
- Ancient Artifact: mysterious alien artifact.
- Chaser: small aggressive alien spacecraft.
- Gunner: ranged alien spacecraft.
- Tank: large armored alien spacecraft.
- Dreadnought: large intimidating boss spaceship.

Maintain one consistent art direction.

Do NOT create hundreds of unnecessary assets.

Every gameplay asset must have a clear purpose.

---

# 31. ASSET ORGANIZATION

Organize generated/imported art into:

Assets/Art/Player/
Assets/Art/Enemies/
Assets/Art/Asteroids/
Assets/Art/Collectibles/
Assets/Art/PowerUps/
Assets/Art/Environment/
Assets/Art/VFX/
Assets/Art/UI/

Configure appropriate:
- Sprite import settings.
- Pixels Per Unit.
- Filter Mode.
- Compression.
- Sorting Layers.
- Sprite Atlas where useful.

---

# 32. PREFAB REQUIREMENT

For every important gameplay object, create a reusable prefab.

Recommended structure:

Assets/Prefabs/
├── Player/
│   └── Aurora.prefab
├── Combat/
│   ├── PlayerLaser.prefab
│   └── EnemyBullet.prefab
├── Environment/
│   ├── AsteroidLarge.prefab
│   ├── AsteroidMedium.prefab
│   ├── AsteroidSmall.prefab
│   ├── WarpGate.prefab
│   └── NavigationBeacon.prefab
├── Collectibles/
│   ├── StarCrystal.prefab
│   ├── EnergyCell.prefab
│   ├── RepairKit.prefab
│   └── AncientArtifact.prefab
├── Enemies/
│   ├── Chaser.prefab
│   ├── Gunner.prefab
│   └── Tank.prefab
├── Boss/
│   └── Dreadnought.prefab
└── PowerUps/
    ├── ShieldPowerUp.prefab
    ├── RapidFirePowerUp.prefab
    ├── TripleShotPowerUp.prefab
    ├── SpeedBoostPowerUp.prefab
    └── MagnetPowerUp.prefab

Do not create duplicate prefabs when a suitable existing prefab already exists.

---

# 33. AUTOMATED UNITY SETUP

Do not simply create empty GameObjects.

Configure required components where appropriate:

- Transform
- SpriteRenderer
- Rigidbody2D
- Collider2D
- Animator
- ParticleSystem
- AudioSource
- Scripts
- Layers
- Tags
- Sorting Layers
- Materials

Set sensible default values.

Avoid unnecessary components.

Use current Unity APIs compatible with the project's Unity version.

---

# 34. AUTOMATIC ANIMATION SETUP

Automatically configure simple animations where appropriate.

PLAYER:
- Engine idle.
- Engine boost.
- Damage/shield feedback.

COLLECTIBLES:
- Floating.
- Rotation.
- Glow/pulse.

POWER-UPS:
- Floating.
- Rotation.
- Glow/pulse.

ENEMIES:
- Idle.
- Hit feedback.
- Death feedback.

ASTEROIDS:
- Rotation.
- Destruction animation/effect.

BOSS:
- Idle movement.
- Attack preparation.
- Enrage effect.
- Hit feedback.
- Death/explosion animation.

If sprite-sheet animation is unavailable, use transform, scale, rotation, emission or particle-based animation.

---

# 35. AUTOMATIC SCENE ASSEMBLY

Do NOT create empty scenes and expect me to assemble them manually.

For each gameplay scene, automatically create/configure:

- Background.
- Parallax layers.
- Player spawn.
- Camera.
- World boundaries.
- Asteroid spawn zones.
- Enemy spawn zones.
- Collectible locations.
- Power-up locations.
- Mission objectives.
- Navigation Beacon.
- Warp Gate.
- Secret Area.
- UI Canvas.
- EventSystem.
- GameManager references.

Populate the scene with meaningful gameplay objects.

The scenes should be playable immediately after opening them.

Use Unity Editor scripting / AssetDatabase / PrefabUtility / SerializedObject where appropriate to automate scene construction.

---

# 36. AUTOMATED PREFAB VALIDATION

After creating each prefab:

1. Verify required components exist.
2. Verify required scripts are attached.
3. Verify colliders are configured.
4. Verify Rigidbody2D settings.
5. Verify tags/layers.
6. Verify prefab references.
7. Verify visual renderer exists.
8. Verify spawning.
9. Verify collision.
10. Verify destruction/pickup behavior.

Do not report a prefab as complete if it has known missing required references.

---

# 37. NO MANUAL SETUP WHEN AUTOMATION IS POSSIBLE

Whenever possible, use Unity Editor scripting / AssetDatabase / PrefabUtility / SerializedObject to automatically create and configure:

- Assets
- Materials
- Prefabs
- Scenes
- UI
- Component references
- Spawn points
- Scene references
- Scriptable/config data

The goal is:

**I should be able to open the Unity project and find a mostly playable game rather than manually assembling every object.**

Do not ask me to manually create GameObjects, prefabs, scenes, components or Inspector references when they can be safely created through Unity Editor scripting.

Only ask for manual intervention when it is genuinely technically unavoidable.

---

# 38. WORLD AND GAMEPLAY BALANCING

The game should feel progressively harder.

AREA 1:
- Exploration/tutorial.
- Low enemy density.
- Lower asteroid density.

AREA 2:
- More asteroids.
- More enemies.
- Introduce Gunner and Tank.
- Secret exploration.

AREA 3:
- High danger.
- Fast enemies.
- Dense hazards.
- Boss encounter.

Avoid unfair instant deaths.

Provide enough space for the player to dodge.

---

# 39. PERFORMANCE

Target normal student laptop/PC hardware.

Avoid:
- Excessive Instantiate/Destroy loops.
- Hundreds of active projectiles.
- Hundreds of active enemies.
- Expensive searches every frame.
- Unnecessary Update() calls.

Use:
- Object pooling where useful.
- Efficient spawning.
- Limited enemy/projectile counts.
- Cleanup of destroyed objects.

---

# 40. TESTING REQUIREMENTS

After each major phase:

- Compile scripts.
- Check Unity Console.
- Fix compile errors.
- Check runtime errors.
- Test the feature.
- Test relevant scene transitions.
- Verify references.

At the end perform a complete gameplay test:

MAIN MENU
→ NEW GAME
→ AREA 1
→ MOVE
→ SHOOT
→ DESTROY ASTEROIDS
→ COLLECT STAR
→ FIGHT CHASER
→ COMPLETE OBJECTIVES
→ ACTIVATE BEACON
→ WARP TO AREA 2
→ FIGHT GUNNER/TANK
→ FIND SECRET AREA
→ COLLECT ARTIFACT
→ ACTIVATE WARP
→ AREA 3
→ FIND STAR CORE
→ DREADNOUGHT BOSS
→ VICTORY

Also test:
- Pause.
- Resume.
- Game Over.
- Retry.
- Main Menu.
- High Score.
- Upgrade.
- Power-ups.
- Boost.
- Area transitions.
- Boss phases.

---

# 41. FINAL AUTOMATED QUALITY CHECK

Before declaring the project complete, perform a full project audit.

Check:

- Compilation errors.
- Missing scripts.
- Duplicate classes.
- Missing prefab references.
- Missing sprites.
- Missing materials.
- Missing AudioClip references.
- Missing scene references.
- Broken buttons.
- Broken scene transitions.
- Incorrect tags.
- Incorrect layers.
- Incorrect colliders.
- Rigidbody2D configuration.
- UI references.
- NullReferenceException risks.
- Destroyed-object reference risks.
- Time.timeScale reset issues.
- Player death flow.
- Boss victory flow.
- High-score flow.
- Restart flow.

If a problem is found:

1. Diagnose it.
2. Fix it if safely possible.
3. Recompile.
4. Re-test.
5. Continue until no known blocking errors remain.

Do NOT simply report errors to me if you can safely fix them yourself.

Only ask me for manual intervention when the task genuinely cannot be performed automatically.

---

# 42. FINAL QUALITY TARGET

The final result must feel like a COMPLETE SMALL GAME, not a collection of disconnected Unity experiments.

The player should immediately understand:

1. Where they are.
2. How to move.
3. How to shoot.
4. What they need to collect.
5. What the current objective is.
6. Where they can explore.
7. Why they should keep moving.
8. How to reach the next area.
9. Why enemies are dangerous.
10. What the final goal is.

The gameplay loop is:

**EXPLORE**
→ **COLLECT**
→ **FIGHT**
→ **SURVIVE**
→ **COMPLETE OBJECTIVE**
→ **UPGRADE**
→ **DISCOVER**
→ **UNLOCK**
→ **BOSS**
→ **VICTORY**

---

# 43. AGENT BEHAVIOR RULES

Follow these rules throughout development:

1. Inspect before modifying.
2. Reuse before replacing.
3. Automate before asking me to click.
4. Build one stable phase at a time.
5. Compile after meaningful code changes.
6. Fix errors before continuing.
7. Avoid duplicate classes and duplicate systems.
8. Do not destroy working functionality.
9. Do not leave important objects invisible.
10. Do not leave critical Inspector references missing.
11. Do not claim completion without verification.
12. Keep the project playable throughout development.
13. Prefer simple robust implementations over unnecessarily complex architecture.
14. Use comments for important gameplay logic.
15. Keep all generated files organized.
16. If a requested feature cannot be fully automated, explain exactly what manual step is unavoidable.

---

# 44. REQUIRED REPORT AFTER EACH PHASE

After completing each phase, provide a concise report:

### Implemented
- What was added.

### Modified
- Which files were changed.

### Created
- Which scripts/assets/prefabs/scenes were created.

### Automated
- What Unity setup was performed automatically.

### Tested
- What was verified.

### Remaining
- Any known issues.

### Manual Steps
- Only genuinely unavoidable manual Unity Editor actions.

Then proceed to the next phase if the current phase is stable.

---

# 45. START NOW

Your first task is NOT to build everything.

FIRST:

1. Read `SPACE_EXPLORER_AURORA_KICH_BAN_GAME.md`.
2. Audit the existing `TestSpaceExplore` project.
3. Identify existing systems.
4. Identify missing systems.
5. Check compile/runtime issues.
6. Create the implementation plan.
7. Start PHASE 1 only after the audit.

Do not ask unnecessary questions.

Make reasonable implementation decisions based on the game design document and the existing project.

The goal is to autonomously build a complete, playable and presentable Unity game with as little manual setup from me as technically possible.
