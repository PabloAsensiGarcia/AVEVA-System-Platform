# Attribute Structure

While not strict rules, the following conventions have proven highly effective in my own projects. These naming patterns help clarify attribute purpose at a glance and ensure consistency across objects:

- **Status-related attributes**: Prefixed with `sts` (e.g., `stsRunning`, `stsValveOpen`) – used for signals or values that reflect real-time system status.  
- **Alarm-related attributes**: Prefixed with `alm` (e.g., `almHighPressure`, `almFaultDetected`) – used for alarm states or alarm-related indicators.  
- **Configuration or internal-use attributes**: Prefixed with `cfg` (e.g., `cfgSetpoint`, `cfgCalculationMode`) – used for parameters, calculations, or internal logic.

All attribute names follow **CamelCase** for readability and standardization.
