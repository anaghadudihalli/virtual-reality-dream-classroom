# virtual-reality-dream-classroom

Tools Used:
- Unity Game Engine (Version 2019.4.1f1) - https://unity3d.com/get-unity/download/archive
- VRTK v3.3 - https://github.com/ExtendRealityLtd/VRTK/tree/3.3.0
- MakeHuman v1.1.1 - http://www.makehumancommunity.org/content/downloads.html
- Mixamo - https://www.mixamo.com/#/
- Blender v2.83 - https://www.blender.org/download/


Instructions on how to use:

- Please install the above mentioned version of Unity. All required files for VRTK are included in the project.
- Download the zip folder of the project.
- Open the project in Unity.
- If the scene isn't loaded by default, go to Assets->virtualuic-evl->Scenes. Drag the 'EVL' scene into the hierarchy.
- If you get a Steam popup when you play the scene just click Ignore All and it should go away. If not, go to the VRTL_SDKManager gameobject in the heirarchy and its VRTK_SDK Manager child. Under available SDKs, remove SteamVR.
- Though the project supports VR headsets SDKs like SteamVR, OculusVR, Unity etc, since I do not own one, I cannot vouch for the project's working and compatibility using a headset. It can always be run using the VRTK simulator.
Hit Play.

VRTK Simulator key bindings:

- WASD keys for movement in four directions
- Q to teleport to a location
- Alt to use the controllers. Left click to grad a grabbable object and left click again to release it.
- In controller mode, you can move along the axes using Control and Alt. Tab to switch between the left and right controllers.
- E to switch to shrink to a small size.
- R to get back to the normal size.

