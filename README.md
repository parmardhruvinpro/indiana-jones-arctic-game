# Indiana Jones: Arctic Circle Pursuit

A lightweight Unity 3D prototype inspired by classic adventure exploration: an icy Arctic dig site, collectible relics, and a treasure objective.

Features
- Third-person player movement with jumping
- Arctic terrain and icy platform layout
- Collectible relic objects
- Win condition after finding all artifacts
- Simple UI overlay and runtime-generated scene setup

Controls
- WASD / Arrow keys: Move
- Space: Jump
- Right mouse button: Orbit camera
- Esc: Unlock cursor if using editor play mode

How to run in Unity
1. Download and install Unity Hub + Unity 2022.3 LTS or newer.
2. Open this repository folder as a Unity project.
3. In the Unity Editor, create/open a scene and add an empty GameObject named `GameBootstrap`.
4. Attach the `GameBootstrap` script from `Assets/Scripts/GameBootstrap.cs` to that object.
5. Press Play.
6. The bootstrap script creates the player, terrain, relics, and camera automatically.

Notes
- This is a prototype focused on playable core mechanics rather than cinematic storytelling.
- The project uses only built-in Unity primitives, so it works without external art assets.

Project structure
- `Assets/Scripts/` — gameplay logic
- `Assets/Scenes/` — scene files (add your own scene when ready)

Recommended next upgrades
- Add enemies and chase mechanics
- Add a temple entrance and puzzle gate
- Add sound effects and atmosphere
- Add UI menus and title screen
- Replace simple primitives with custom models and textures
