# Unity-SingleCameraMultipleDisplayURP

This example uses a custom URP Render Feature you can get here: https://github.com/Cyanilux/URP_BlitRenderFeature

The example project shows the basic functionality how to render a scene once and output it on multiple displays in URP. Here is how to do this in your own project.

What you will need to get this to run:

* 3 (or more) Cameras in your Scene
* a Rendertexture
* a Shadergraph
* a Material with the Shadergraph
* a second Renderer in your URP Asset
 
What you need to do:

* Configure the Rendertexture with the desired render resolution (you can use multiple Rendertextures for various resolutions like this example or a Rendertexture with dynamic resolution but need a dedicated script to set this up in any case)
* Create a Shadergraph with your Rendertexture as Input, connect it to a Texture2D Sampler and from the Sampler RGBA to Fragment Base Color. Save the Shader.
Configure your Main Camera with your Rendertexture as Output. Use your normal URP Renderer for the Main Camera and setup you Culling Mask to only render what you need (e.g. exclude GUI) on both output Displays. The Main Camera needs to have a lower priority (e.g. -1) than the Display Cameras.
* Configure your Display Cameras to use your new second Renderer and a higher Priority (e.g. 0). Set the Culling Mask to only show what you need on this display (e.g. GUI layer).
* Setup the new second Renderer only with the Blit Render Feature. In the Feature select Before Render as Event and use your Material with the Shadergraph in Blit Material.
 
This way you will render your scene only once for multiple displays and can even use layers / culling masks on your Display Cameras to add to the basic view.

One thing to keep in mind is that the resolution of the Rendertexture may differ from the display resolution. This has some (undesired) side effects: If the aspect ratio is different the image may be stretched on one axis. If the resolution of the rendertexture is too low the output may be blurry. In any case Input.mousePosition (e.g. for Raycasts) X & Y axis will have to be adjusted with the factor the Rendertexture and Display resolutions differ to work properly.