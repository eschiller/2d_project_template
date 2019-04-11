This template is my starting point to bootstrap 2d unity projects. Additional READMEs can be found in individual asset folders.

## High-level workflow

At a high level, gameflow is supposed to be managed between the LevelManager, which should handle any scene specific logic and data, and the GameManager, which handles data and behavior that must cross scenes.

To use the LevelManager check "Initialize Players and Cams" in the LevelManager, and drag camera and player prefabs in to the specified slots in the inspector (or create them in the scene itself).

The LevelManager can also optionally have a FSM if more complex behavior is needed. An example of this can be seen at [AmenaStateMachine](https://github.com/eschiller/2d_project_template/blob/master/Assets/Scripts/FSM/StateMachines/ArenaStateMachine.cs).

## Asset Types

Documentation for specific asset types has been broken into READMEs in their containing script direcotories. To view it, follow the links below.

 * [Behaviors (2d character controllers, input, item and character/enemy management scripts)] (https://github.com/eschiller/2d_project_template/tree/master/Assets/Scripts/Behaviors)
 * [Finite State Machines] (https://github.com/eschiller/2d_project_template/tree/master/Assets/Scripts/FSM)
 * [Game Management] (https://github.com/eschiller/2d_project_template/tree/master/Assets/Scripts/Prefabs/GameManagement)
 * [Level Managemnet] (https://github.com/eschiller/2d_project_template/tree/master/Assets/Scripts/Prefabs/LevelManagement)
 * [HUD Management] (https://github.com/eschiller/2d_project_template/tree/master/Assets/Scripts/Prefabs/HUDManagement)

## Creating a new NPC

To create a new NPC, like a new enemy, do the following:

 * Create a game object with sprites/animations (specific animation states that are looked for by the controller are discussed in controller documentation). Give it BoxCollider2d and Rigidbody2d components, being sure to check "Is Trigger" in the collider, and check "simulated" in the rigidbody.
 * Add one of the "Manager" scripts, likely either EnemyManager or CharacterManager
 * To add phsyics, add one of the Controller2d script components.
 * To add behavior, add one of the FSM components.
 * If the NPC is an enemy, give it the "Enemy" tag. This will help with battle/damage logic.
