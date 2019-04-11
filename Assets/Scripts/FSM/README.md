## State Machine behavior scripts

The FSMState and StateMachine scripts are parent classes intended to assist with more complex behavior (either in levels or PC/NPCs) than would work well in an individual scripts. 

The basic design is that first child FSMState classes are written, with a focus on the UpdateState method which is called each update. Once all the child states for the machines are written, a series of string-key/FSMState pairs are added to a StateMachine via the StateMachine.AddState method.

Lastly, the StateMachine should call the initial state of the machine via the StateMachine.ChangeState method. From there control will be handed off to subsequent states from whatever state is currently running.

There are examples of NPC behavior and level behavior statemachines at [States] (https://github.com/eschiller/2d_project_template/tree/master/Assets/Scripts/FSM/States) and [StateMachines] (https://github.com/eschiller/2d_project_template/tree/master/Assets/Scripts/FSM/StateMachines).
