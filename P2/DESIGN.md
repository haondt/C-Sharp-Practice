# Design Strategy
### Functionality
* File is selected through Windows Explorer prompt.
* If the file follows the naming structure (Project\_Name\_version\_date.\*),
the corresponding data is extracted and the fields are automatically populated.
  * Otherwise, the file name is put into the "Name" field.
* Version is default empty
* Date is default today, but can be changed via a calendar prompt
* Project is default empty, but can be either typed in or taken from a drop
down menu that pulls data from .txt database
* Upon creation, the project name is added to a .txt file acting as a database,
if it is not already in there.
* Resulting filename is shown as a read-only preview next to "save" button,
and is updated live as fields are updated.
### UI
* Input file is found with Windows Explorer Prompt
* Project is typed or taken from dropdown
  * Default empty
* Name is typed
  * Default input file name
* Version is typed
  * Default empty
* Date is calendar prompt
  * Default today
* new filename preview is shown at bottom, next to save button
* Spaces are replaced with hyphens
* All fields must be populated
* New filename **cannot** override an old one.
### Deployment
* Given as a .msi installer (via WiX), encrypted with IntelliLock that simply
places the compiled .exe at the selected location.
