# AVEVA System Platform Development Guidelines

This repository is a curated collection of development standards, scripting examples, and practical resources that I have developed and refined over the course of working extensively with **AVEVA System Platform** (formerly Wonderware). It is intended to support engineers, developers, and system integrators by offering structured guidance and reusable solutions for common challenges in industrial automation projects.

The content ranges from scripting patterns and best practices to design templates and architectural guidelines aimed at promoting clarity, scalability, and maintainability within System Platform environments. Whether you're building a system from scratch or refining an existing deployment, this repository provides actionable insights that can help accelerate development while maintaining high engineering standards.

## 1. System Design Philosophy

When developing in AVEVA System Platform, simplicity and structure are key. The complexity of large-scale industrial applications can escalate quickly, so it's essential to establish a clean, well-organized foundation from the start. A consistent approach to object design, attribute naming, and project layout greatly enhances both team collaboration and system maintainability.

## 1.1 Object Naming & Attribute Structure

While not strict rules, the following conventions have proven highly effective in my own projects. These naming patterns help clarify attribute purpose at a glance and ensure consistency across objects:

- **Status-related attributes**: Prefixed with `sts` (e.g., `stsRunning`, `stsValveOpen`) – used for signals or values that reflect real-time system status.  
- **Alarm-related attributes**: Prefixed with `alm` (e.g., `almHighPressure`, `almFaultDetected`) – used for alarm states or alarm-related indicators.  
- **Configuration or internal-use attributes**: Prefixed with `cfg` (e.g., `cfgSetpoint`, `cfgCalculationMode`) – used for parameters, calculations, or internal logic.

All attribute names follow **CamelCase** for readability and standardization.

## 1.2 Input Source Configuration via Scripted Binding
In scenarios where Autobinding is not feasible for a specific group of I/O points, the recommended alternative is to dynamically assign the input source of I/O attributes through a generic script placed within the template object. This method maintains scalability and reduces repetitive manual configuration across multiple instances.

To implement this effectively, it is important to reserve two configuration attributes within the object template:

`cfgDeviceName` – Represents the Device Integration (DI) object name.

`cfgScanGroup` – Specifies the scan group within the device.

These configuration attributes enable the script to programmatically construct and assign the appropriate input source references at runtime.

In line with the naming conventions outlined in Section 1.1, configuration-related attributes are prefixed with cfg, ensuring clarity and consistency throughout the application structure. This approach enhances maintainability and reinforces good design practices across the object hierarchy.
