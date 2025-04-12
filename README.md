# AVEVA System Platform Development Guidelines

This repository is a curated collection of development standards, scripting examples, and practical resources that I have developed and refined over the course of working extensively with AVEVA System Platform (formerly Wonderware). It is intended to support engineers, developers, and system integrators by offering structured guidance and reusable solutions for common challenges in industrial automation projects.

The content ranges from scripting patterns and best practices to design templates and architectural guidelines aimed at promoting clarity, scalability, and maintainability within System Platform environments. Whether you're building a system from scratch or refining an existing deployment, this repository provides actionable insights that can help accelerate development while maintaining high engineering standards.

---

## 📂 Repository Structure

- **[System Design Philosophy](System-Design-Philosophy/)**  
Guidelines and best practices for designing scalable and maintainable System Platform applications

- **[Object Naming Conventions](https://github.com/PabloAsensiGarcia/AVEVA-System-Platform/blob/main/System-Design-Philosophy/2.%20Attribute%20Structure.md)**  
Standardized naming conventions for attributes and objects to ensure consistency across projects

- **[Dynamic IO Binding](https://github.com/PabloAsensiGarcia/AVEVA-System-Platform/blob/main/System-Design-Philosophy/3.1%20IO%20Binding%20Script.md)**  
Techniques for assigning input sources to IO attributes dynamically when autobinding is not feasible

- **[Bitmasking Data Structures](https://github.com/PabloAsensiGarcia/AVEVA-System-Platform/blob/main/System-Design-Philosophy/4.1%20Data%20Structures.md)**  
Methods for decoding structured data (e.g., words, bytes) into boolean attributes for clarity and usability

- **[Handling Signed Data Types](https://github.com/PabloAsensiGarcia/AVEVA-System-Platform/blob/main/System-Design-Philosophy/4.1%20Data%20Structures.md)**  
Workarounds for System Platform's limitations with signed integers and floating-point numbers

- **[Modbus Register Reading](https://github.com/PabloAsensiGarcia/AVEVA-System-Platform/blob/main/System-Design-Philosophy/4.1%20Data%20Structures.md)**  
Scripts and explanations for interpreting Modbus register pairs into meaningful values
Certainly! Here's an updated version of the `README.md` file for the [AVEVA-System-Platform](https://github.com/PabloAsensiGarcia/AVEVA-System-Platform) repository. This revision incorporates key insights from the AVEVA System Platform Installation Guide (2023 R2 SP1) and aligns with best practices for system architecture and deployment.

---

## 🏗️ System Architecture Best Practices

Designing an effective AVEVA System Platform architecture involves strategic distribution of roles and components. Key considerations include:

- **Role-Based Distribution**: Assign specific roles to nodes, such as Galaxy Repository Server, IDE Client Node, Application Object Servers (AppEngines), InTouch Runtime Nodes, Historian Node, License Server, and System Monitor Manager/Agent.

- **Separation of Critical Roles**: Host the Galaxy Repository, Historian, and License Server on separate nodes to enhance performance and security.

- **Redundancy**: Implement redundant configurations for AppEngines and License Servers to ensure high availability.

- **Network Configuration**: Ensure proper network setup with static IPs or reserved DNS, and configure firewalls to allow necessary ports.

- **Scalability**: Plan for scalability by considering scan rates, I/O loads, and tag counts across AppEngines.

- **System Monitoring**: Deploy System Monitor Agents on all nodes and centralize monitoring through the System Monitor Manager.

- **Backup & Recovery**: Regularly back up the Galaxy Repository and test restore procedures for critical components.

- **Development Lifecycle Management**: Maintain separate environments for development, staging, and production, and manage object templates with version control.

For more information refer to: 
[System Architecture](https://github.com/PabloAsensiGarcia/AVEVA-System-Platform/tree/main/System-Architecture)

---

## 📦 Installation & Configuration

The `Installation-Setup/` directory provides detailed instructions for:

- **Prerequisites & Preparation**: System requirements, supported clients, and network configuration.

- **Licensing**: Setup and activation of the AVEVA Enterprise License Server.

- **Installing Core Components**: Step-by-step installation of Application Server, IDE, Historian, and more.

- **System Platform Configuration**: Configurator setup, license mode, identity management, and historian settings.

- **Upgrade & Repair**: Guidelines for upgrading components and repairing installations.

- **Uninstallation Procedures**: Instructions for component-by-component uninstallation and complete system removal.

- **Security & Permissions**: Network account setup, SQL Server security modes, and OS-level permissions.

- **SQL Server Configuration**: Port and firewall settings, handling preinstalled versions, and custom configurations.

- **Silent Installations & Automation**: Creating response files and automating installations.

---

## 🧰 Scripting & Automation

The `Scripting-Patterns/` directory offers:

- **Standardized Code Snippets**: Common scripting patterns for automation tasks.

- **Error Handling Templates**: Templates to manage and log errors effectively.

- **Performance Optimization Scripts**: Scripts designed to enhance system performance.

For more information please refer to:
[System Design Philosophy](https://github.com/PabloAsensiGarcia/AVEVA-System-Platform/tree/main/System-Design-Philosophy)

---

## 🎨 Templates & Utilities

- **Templates/**: Ready-to-use templates for objects, graphics, and applications to streamline development.

- **Utilities/**: A collection of tools and scripts for system monitoring, diagnostics, and maintenance tasks.

---

## 📄 License

N/A.

---

## 🤝 Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your proposed changes.

---

## 📬 Contact

For questions or suggestions, please open an issue in this repository.

---
