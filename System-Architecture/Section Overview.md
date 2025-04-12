# 🏗️ Best Practices for Architecting a System Platform Application Distribution
Designing a scalable, reliable, and maintainable AVEVA System Platform architecture requires thoughtful distribution of roles and components across the system landscape. The architecture should be based on performance requirements, redundancy needs, client access patterns, and system complexity.

## 1. Define System Roles Early
System Platform supports role-based installation, which allows components to be distributed based on node responsibilities. Typical roles include:

Galaxy Repository Server (GR): Centralized database for all project objects and configuration.

IDE Client Node: Engineering workstation where applications are developed and managed.

Application Object Servers (AppEngines): Runtime environments where instances of platform objects execute.

InTouch Runtime Nodes: HMI viewers for operator interfaces (can be thick clients or via OMI).

Historian Node: Collects and stores historical data, accessible by queries, reports, and trending.

License Server: Hosts the AVEVA Enterprise License service for all nodes.

System Monitor Manager/Agent: For system health monitoring.

## 2. Separate Critical Roles
For better performance, reliability, and security:

Host the Galaxy Repository, Historian, and License Server on separate nodes.

Run AppEngines on dedicated servers to isolate execution logic from UI and database workloads.

Keep the IDE (development environment) on separate engineering workstations, not on production nodes.

## 3. Use Redundancy Where Needed
AppEngines support redundant pair configurations, which are critical for high-availability systems.

Use redundant license servers and configure the license manager with failover options.

Redundant System Platform nodes should be aligned with network redundancy and failover planning.

## 4. Follow AVEVA’s Supported Topologies
Some standard and supported distribution patterns include:

Single-node configuration: Suitable for testing or very small systems.

Development & Runtime separation: Keeps development isolated from operations.

Fully distributed system: Large-scale deployment with multiple servers for repository, engines, historian, and HMIs.

**5. Network & Firewall Considerations**
Ensure that all required ports are open between nodes (e.g., SQL Server ports, GR communication, OMI Web).

Use static IPs or reserved DNS for all core nodes.

Disable automatic Windows updates and configure controlled patching strategies.

## 6. Scalability and Performance Planning
Carefully plan scan rates, I/O loads, and tag counts across AppEngines.

Utilize deployment groups and scan groups to logically distribute workload.

Consider Historian tiering or remote collectors for high-volume environments.

## 7. System Monitor Integration
Deploy System Monitor Agents on every node.

Centralize monitoring in the System Monitor Manager, typically colocated with GR or a dedicated node.

Configure health alerts for CPU, memory, heartbeat, and application-level failures.

##8. Backup & Recovery
Regularly back up the Galaxy Repository.

Use AVEVA-provided backup tools or scheduled SQL Server backups.

Document and test restore procedures for each critical component.

## 9. Development Lifecycle Management
Use separate Galaxies for development, staging, and production.

Manage object templates in a controlled versioning environment.

Consider using Object Export/Import for deployment pipelines.
