# MyCat
 Test task performed on Uniy 2021.3.16 for 2RealLife

Note:
To add/remove/modify a mood, you need to open the Scripts/Core/Utils/Enums.cs class and change the enum Mood.
To add/remove/change reactions, you need to open Resources/Configs/CatActionsConfig.asset. It contains a list of "Actions" with actions for the cat and its reactions to it.
To add an action and a reaction, you need to: 

1. In the Actions list add a new action

2. In the added action, in the "Name" field, type the name of the action, and in the "Icon" field, choose an icon for the action if we have one.

3. now we have to add the cat's reactions to these actions:

3.1 Add reactions for each mood (currently Bad, Good, and Great). Specify them in each reaction in the "Mood" field. This reaction will play if the cat has the given mood. For reactions contained in one action it is unacceptable to contain the same values in the "Mood" field. This will be indicated by the pop-up window with an error if such reactions appear in one action.

3.2 Next, in the Reaction -> AnimatorController field specify the animation controller for this reaction. The controller must comply with 3 obligatory conditions:

3.2.1 The animation must start with the node on which the "ReactionAnimationController" script hangs, and the "State" field must be set to "Start 

3.2.2 The animation must end with the node on which the "ReactionAnimationController" script is hung, and "Complete" must be set in the "State" field

3.2.3 The controller must contain at least 3 obligatory parameters which are responsible for the logic of playback at a certain mood: IsMoodBad, IsMoodGood, IsMoodGreat (the names correspond to the emotions which are in the enum Mood, so when adding a new emotion the following logic must be followed: IsMood{mood})

3.3 In the Reaction -> NewMood field specify the mood to which this reaction will change. If the mood doesn't change, we leave it at "None".

3.4 In the Reaction -> Description field enter a description for this reaction, if any.

Of course, this could still be simplified by creating a single window that would automatically fill out this config and create an animation controller for reactions with already preset mandatory conditions. However, this would greatly overcomplicate the main task of the test task, so I did not implement it this way.

Note 2:
The animations are a bit crooked, but I couldn't find a better one. I tried to change some of them using UMotion, but that would have taken a lot of time, so I didn't complicate them, because the main task is to demonstrate the ability to work with them, not to develop them.
