## HUDManager

This is still in a very early stage, but ideally will become a singleton class/prefab for all HUD objects. Currently, it can handle player life and the pause screen. 



## Dialog

The Dialog script allows for scripted Dialog events between player and NPC. To create a new piece of dialog, first duplicate the [Dialog prefab](https://github.com/eschiller/2d_project_template/tree/master/Assets/Scripts/Prefabs/HUDManagement). Then, set the number of steps and portraits you'd like in your Dialog, and fill in the text and portrait sprites for each step in the inspector.

Once your done with your prefab, you can drag and drop it to the "dialog" filed in the Character/Enemy/PlayerManager component for your NPC in the inspector.
