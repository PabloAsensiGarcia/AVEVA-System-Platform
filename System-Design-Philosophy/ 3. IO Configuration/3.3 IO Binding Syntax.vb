' This script can be implemented in two ways:

' 1. As a **Startup Script**:
'    - When the instance runs for the first time, it automatically assigns the input source path 
'      to the I/O attribute using the configuration parameters defined in the template.
'    - Ideal for static or one-time initialization scenarios.

' 2. As an **Execute Script**:
'    - Requires the creation of a Boolean configuration attribute (e.g., cfgAssignIO) 
'      with an initial value of TRUE.
'    - Set the script to execute under the "While True" condition.
'    - After the assignment is complete, reset the Boolean flag to FALSE to prevent repeated execution.

' Example of dynamic input source assignment:
Me.Attribute.InputSource = Me.cfgMasterDIName + "." + Me.cfgScanGroup + "." + "DIAttribute";

' Reset trigger if using execute script method:
Me.cfgAssignIO = false;
