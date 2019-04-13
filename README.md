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

