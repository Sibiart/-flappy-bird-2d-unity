# 🐦 Flappy Bird 2D — Unity Remake with a Custom Procedural Art & Audio Pipeline

A from-scratch Unity 2D remake of the Flappy Bird formula, rebuilt not just to clone the gameplay but to explore **procedural content generation** — the background art, character sprites, UI panels, and sound effects are all generated at edit-time by custom C# tooling rather than imported from external art/audio software.

> Built as a hands-on portfolio project to demonstrate Unity scripting, game-feel implementation, and editor tooling skills.

---

## 🎮 Gameplay

Tap (keyboard, mouse, or touch) to flap and keep the bird airborne, weaving between a stream of procedurally-spawned pipes. Miss a gap, or fly off the top/bottom of the screen, and it's game over.

---

## ✨ What Makes This Project Unique

Most beginner Flappy Bird clones stop at "pipes move left, bird falls, check collisions." This project goes further by treating the **art and audio pipeline itself as an engineering problem**:

### 🖼️ Procedural Background Art
The night sky isn't an imported texture — it's generated in code: a vertical gradient sky, a soft radial moon glow, and multiple layered, randomized storm-cloud clusters, composited pixel-by-pixel and exported as a `Texture2D` → `PNG` → `Sprite` at editor time.

### 🐤 Procedural Character Art
The bird's wings are drawn algorithmically using an implicit heart-curve function, rotated into distinct "up" and "down" flap poses, with edge-detection used to auto-generate a contrasting outline so the wing reads clearly against the body — no external image editor involved.

### 🔊 Synthesized Sound Effects
The wing-flap sound effect is **synthesized, not recorded**: filtered white noise blended with a downward pitch-sweep sine wave, shaped with an attack/decay envelope and a one-pole low-pass filter, then hand-encoded into a valid WAV byte stream and imported as a Unity `AudioClip` — a small dive into digital signal processing fundamentals.

### 🎨 Custom UI System
A hand-rolled 9-sliced rounded-rectangle sprite (generated procedurally, not from a UI asset pack) powers every panel and button in the game, giving a consistent, cohesive "Midnight Neon" visual theme across the main menu, HUD, pause screen, and game-over screen.

### 🔥 Runtime VFX
The bird trails a particle-based flame effect from its wings — built with Unity's `ParticleSystem` using gradient-over-lifetime, size-over-lifetime, and Perlin noise turbulence modules for a believable flicker, rather than a pre-baked animation.

---

## 🧩 Core Features

- **Physics-based flight** — `Rigidbody2D` impulse-driven flap mechanics
- **Procedural pipe spawning** with randomized gaps
- **Multi-input support** — keyboard (Space), mouse click, and touch, via Unity's new Input System
- **Win/loss state machine** — collision-based *and* out-of-bounds detection both trigger a proper Game Over flow (a common beginner-clone gap: most tutorials only check pipe collisions)
- **Animated wing-flap** synced to input, sound, and physics on every tap
- **Score tracking** with a styled, always-legible HUD scoreboard
- **Pause / Resume flow** with a dedicated overlay menu
- **Cohesive art direction** — every visual element (sky, pipes, buttons, panels, particles) shares one deliberate color theme instead of default Unity styling

---

## 🛠️ Tech Stack

| Area | Tools / APIs |
|---|---|
| Engine | Unity (2D URP/Built-in), C# |
| Input | Unity Input System (`Keyboard`, `Mouse`, `Touchscreen`) |
| Physics | `Rigidbody2D`, `Collider2D` |
| VFX | `ParticleSystem` (shape, color-over-lifetime, size-over-lifetime, noise modules) |
| UI | `uGUI` / `TextMeshPro`, custom 9-sliced sprites |
| Procedural Art | `Texture2D` pixel manipulation, `SpriteImportMode`, runtime `AssetDatabase` import pipeline |
| Procedural Audio | Manual PCM sample synthesis + WAV file encoding in C# |

---

## 📁 Project Structure (key scripts)

```
Assets/
├── Birdscript.cs        # Flight physics, input handling, wing animation, flap SFX, bounds check
├── LogicScript.cs        # Score tracking, game-over flow, pause/resume
├── Pipe scripts / prefabs
├── Background_NightStormSky.png   # Procedurally generated
├── BirdWingUp.png / BirdWingDown.png  # Procedurally generated
├── UI_RoundedPanel.png   # Procedurally generated 9-slice UI sprite
└── FlapSound.wav         # Procedurally synthesized
```

---

## 🚀 Getting Started

1. Clone the repo
2. Open the project in Unity (version: `<fill in your Unity version>`)
3. Open the `main` scene
4. Press **Play** — tap / click / press Space to flap

---

## 🧠 What I Learned

- Writing pixel-level texture generation algorithms (implicit shape functions, radial gradients, edge detection) directly in C#
- The basics of digital audio synthesis — envelopes, filtering, and raw WAV encoding — without a DAW
- Building a cohesive UI system from a single reusable 9-sliced sprite instead of piecemeal assets
- Debugging Unity's coordinate/transform hierarchy quirks (e.g. non-uniform parent scale distorting child objects) and correcting for them in code
- Structuring gameplay state (alive/dead, paused/running) cleanly across multiple interacting scripts

---

## 📌 Roadmap / Possible Extensions

- [ ] Difficulty scaling (pipe speed/gap narrowing over time)
- [ ] High-score persistence (`PlayerPrefs` or save file)
- [ ] Mobile build + touch-optimized UI scaling
- [ ] Additional themes (day/sunset variants) swappable at runtime
- [ ] Replace synthesized SFX with a full adaptive audio mix

---

## 📷 Screenshots

*(Add a few gameplay screenshots / a short GIF here — this is often the first thing a recruiter looks at.)*

---

## 📄 License

`<Add a license, e.g. MIT>`

---

## 👤 Author

`<Your name>` — `<portfolio link>` · `<LinkedIn>` · `<email>`
