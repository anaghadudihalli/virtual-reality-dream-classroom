Continuum VirtualUIC-EVL
=======

## Introduction ##
This submodule contains the models and scenes for the VirtualUIC project - specifically ERF, EVL, and related EVL models.
 
This repository is intended to be added to an existing/new Unity project as a submodule and not as a standalone project. This is due to this submodule being used in the larger VirtualUIC-COE project.

However the assets contained in this module are designed to be used independently of the parent VirtualUIC-COE project.

However some scenes may use the following submodules:

* https://github.com/arthurnishimoto/module-omicron
* https://bitbucket.org/arthurnishimoto/module-sage2
  
Also all the larger models and textures are stored using Git Large File Storage (LFS) and requires the LFS extension to be installed:

* https://git-lfs.github.com/

If not installed properly, when you clone this repository, most models will fail to load in Unity and .blend files will be listed as ~100 KB in size instead of the actual model file.