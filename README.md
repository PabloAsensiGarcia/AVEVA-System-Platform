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



# 1.2 Assign IO with Startup script if autobind not available or applicable

If Autobinding is not an option for a specific group of IO, the next best thing is to assign the input source of an IO attribute from a generic script that lives in the template object.

In order to create something like this, it is essential to reserve 2 configuration attributes for the Device Integration Device Name and the Scan Group of said device.

Following Section 1.1 - we will use a sustainable attribute naming convention such that the attributes related to configuration of the object will start with cfg
