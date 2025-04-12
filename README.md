# AVEVA System Platform Development Guidelines

This repository is a curated collection of development standards, scripting examples, and practical resources that I have developed and refined over the course of working extensively with **AVEVA System Platform** (formerly Wonderware). It is intended to support engineers, developers, and system integrators by offering structured guidance and reusable solutions for common challenges in industrial automation projects.

The content ranges from scripting patterns and best practices to design templates and architectural guidelines aimed at promoting clarity, scalability, and maintainability within System Platform environments. Whether you're building a system from scratch or refining an existing deployment, this repository provides actionable insights that can help accelerate development while maintaining high engineering standards.



## 1.1 Object Naming & Attribute Structure

While not strict rules, the following conventions have proven highly effective in my own projects. These naming patterns help clarify attribute purpose at a glance and ensure consistency across objects:

- **Status-related attributes**: Prefixed with `sts` (e.g., `stsRunning`, `stsValveOpen`) – used for signals or values that reflect real-time system status.  
- **Alarm-related attributes**: Prefixed with `alm` (e.g., `almHighPressure`, `almFaultDetected`) – used for alarm states or alarm-related indicators.  
- **Configuration or internal-use attributes**: Prefixed with `cfg` (e.g., `cfgSetpoint`, `cfgCalculationMode`) – used for parameters, calculations, or internal logic.

All attribute names follow **CamelCase** for readability and standardization.

## 1.2 Input Source Configuration
In scenarios where Autobinding is not feasible for a specific group of I/O points, the recommended alternative is to dynamically assign the input source of I/O attributes through a generic script placed within the template object. This method maintains scalability and reduces repetitive manual configuration across multiple instances.

To implement this effectively, it is important to reserve two configuration attributes within the object template:

`cfgDeviceName` – Represents the Device Integration (DI) object name.

`cfgScanGroup` – Specifies the scan group within the device.

These configuration attributes enable the script to programmatically construct and assign the appropriate input source references at runtime.

Refer to the syntax here:
[IO Binding Script](bindingIOScript.vb)

In line with the naming conventions outlined in Section 1.1, configuration-related attributes are prefixed with cfg, ensuring clarity and consistency throughout the application structure. This approach enhances maintainability and reinforces good design practices across the object hierarchy.

### 1.2.1 IO Structures from Onsite Devices
In most cases, the field devices you interface with will present their data in structured formats such as Words, Bytes, or DWords. This approach not only simplifies data handling and storage on the device side but also significantly reduces network traffic when the SCADA system queries the device—improving overall efficiency.

However, while compact data structures are ideal for transmission, they are not always the most intuitive format for application-level logic or HMI design. To improve clarity and usability within System Platform, it is highly recommended to decode these structures into Boolean attributes within your objects. Rather than reading a word or integer and interpreting its bitwise values manually, creating individual Boolean tags for each relevant bit provides far greater transparency (unless the structure has been given an appropriate decimal definition by the data structure provider; i.e. 1-Running, 2-Stopped, 255-Failed).

This practice simplifies the configuration of graphics, animations, and alarms, making it much easier to map attribute states to visual elements. Clear, descriptive Boolean attributes allow for more intuitive template creation and reduce the likelihood of errors during development.

While AVEVA System Platform has some limitations around data type handling—which we will explore later—the focus for now is on how to extract and decode structured data efficiently to create clear, maintainable Boolean attributes.

Refer to the scripting here:
[Bitmasking Data Structure](bitmaskingDataStructures.vb)

### 1.2.2 Data Structure Limitations
AVEVA System Platform has limited native support for data types, particularly when it comes to handling signed integers. Based on my experience, attempting to read signed values—such as those stored in 16-bit or 32-bit signed registers—from field devices often leads to incorrect readings or erratic values. This issue stems from the platform's restricted data type support.

System Platform supports only nine data types: Boolean, Integer, Float, Double, String, Time, ElapsedTime, InternationalizedString, and BigString. Unfortunately, all numerical data types are treated as unsigned, which means that signed values—such as 32-bit signed integers (e.g., IEEE 754 encoded floats or PLC DINT types)—are not interpreted correctly. As a result, the system may display nonsensical values or even return bad quality signals when attempting to read such data directly.

The appropriate solution depends largely on both the device type and the communication driver being used. For instance, in my experience working with both Siemens (SIDIRECT) and Modbus TCP (MBTCP) drivers, each requires a different approach:

SIDIRECT (Siemens):
When reading DWORD, DINT, or any 32-bit signed value, referencing the address directly (e.g., DBxx,DWORDyyy) can lead to either invalid data or bad signal quality. A more reliable method involves breaking down the 32-bit structure into smaller, manageable parts. Instead of referencing the problematic DWORD, split it into two WORDs (e.g., DBxx,WORDyy and DBxx,WORDzz) or into four BYTEs (e.g., DBxx,BYTEaa, BYTEbb, BYTEcc, BYTEdd). You can then reconstruct, interpret or filter the value as needed in your logic, scripts or device integration object.

MBTCP (Modbus):
Modbus communication can present additional challenges when dealing with floating-point or 32-bit values, particularly those following the IEEE 754 standard. In my experience, these values are typically split across two consecutive 16-bit Modbus registers. When read directly, the data in each register may appear erratic or unintelligible, making it unclear how to extract meaningful values.

The root of the issue lies in byte and word ordering. To correctly interpret the data:

Identify the two 16-bit registers that make up the 32-bit value.

Swap their order to account for the correct word significance—i.e., transform (R1, R2) into (R2, R1) if required by the device's register layout.

Combine the swapped registers into a single 32-bit integer.

Use a function or conversion utility—such as a Microsoft .NET class method—to reinterpret the resulting integer as a floating-point number based on the IEEE 754 standard.

This conversion allows you to accurately extract the original float value from the device. Keep in mind that Modbus devices may differ in how they handle endianness (word and byte order), so validating the expected format from the device documentation is essential.

These are the raw values from the MBTCP driver:
{Post picture}

Refer to the script below to show how to reassign:
[Modbus Register Reading](modbusRegRead.vb)

This approach allows greater control and accuracy when working around the platform's data type limitations, and ensures that values are interpreted correctly and reliably.
