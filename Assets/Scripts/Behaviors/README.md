## Behaviors Scripts

*Behaviors* is largely a catch-all for various behaviors that can be assigned to various prefabs. This can include *controllers*, *input*, or other high-level behavior or data management, as with the *manager or item scripts.

### PlatformerController2D

PlatformerController2D is intended to be a generic physics controller for use in platformers without using the built in unity physics engine (instead rays are used to check for collisions).

Other scripts (for example, and input handling script in the case of players) should utilize this controller primarily through the setActiveX/YVel functions, where are for use with continuous input, or the addForceX/YVel functions, which are for one-time additions of velocity. Additionally, the Jump and Attack functions can be used as expected. Attack will simply spawn the prefab specified in the Generic Attack field in the inspector (for an example of this, check Assets/Prefabs/Items/GenericAttack).
 
There are also a series of modifiers for the physics of the gameobject, such as gravity, jumpVelocity, xDrag (friction) and xBounceFactor (amount the the asset bounces off walls).
 
To fully utilize the animation transitions, an Animator should be set up with at least three states:
   * Idle
   * Moving
   * Jumping
 
Animator parameters isJumping and runVelocity must be set up to handle transitions between these.
 
Current physics default values are set for mid-size (think 16-bit era) pixel art sprites at 1 PPU. At some point I'd like to dynamically set this value based on asset sizes, but for the time being, if you add this to a gameobject and it's not responding as expected, the physics settings likely need to be tweaked to better values for your sprites/PPU settings.

In order for collisions to work correctly, either the gameobject will need to be set to the IgnoreRaycase layer, or probably the better option is to set per-project settings of Edit -> Project Settings -> Queries start in colliders to "off".

For platforms or walls to "collide" correctly (block the object using this controller script), then must have BoxCollider2d components, and must be tagged either "platform", or "passthrough_platform", if you should be able to jump through the platform from below.

### OverheadController2D

Similar to PlatformController2D, but intended for overhead or zelda-likes (up/down movement with no gravity).

### OverheadInput and PlatformerInput

These are intended to provide user input for their respective controller scripts, if those controllers are intended for use with a player character.

### Item

This script turns an otherwise un-interactable asset in to an item, enabling:

 * Item attack, usage
 * Allows the item to be picked up
 * Allows the item to be thrown
 * Automatically tracks the owner's Animator parameters to transition through it's own animations

The script assumes you'll have the same Animator parameters in your item Animator that you would have for a character using PlatformerController2d (isDucking, isJumping, runVelocity, isDead).

An example Item prefab can be found in Assets/Prefabs/Items/Spear. This item's animations/sprites have been set up for a different player character, but it should give a good idea of the expected configuration to build new items.


### CharacterManager, PlayerManager, EnemyManager

These three scripts handle non-physics behavior for PC/NPC assets. Mostly right now this handles this deals with health gain/loss and death.

To create a new NPC, like a new enemy, do the following:

 * Create a game object with sprites/animations (specific animation states that are looked for by the controller are discussed in controller documentation). Give it BoxCollider2d and Rigidbody2d components, being sure to check "Is Trigger" in the collider, and check "simulated" in the rigidbody.
 * Add one of the "Manager" scripts, likely either EnemyManager or CharacterManager
 * To add phsyics, add one of the Controller2d script components.
 * To add behavior, add one of the FSM components.
 * If the NPC is an enemy, give it the "Enemy" tag. This will help with battle/damage logic.
