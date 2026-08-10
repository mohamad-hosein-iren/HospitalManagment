# Advanced Hospital Management System

An advanced, comprehensive desktop platform designed for hospital operation management, built with **C#** and **Windows Forms (.NET)**. This project demonstrates strict adherence to Object-Oriented Programming (OOP) principles, custom data structures, and a structured layered architecture.

---

## Project Overview

This system streamlines hospital workflows including patient registration, medical records, appointment scheduling, and staff management. It avoids relying on built-in standard collections, instead utilizing custom hand-crafted generic data structures to demonstrate deep computer science concepts.

---

## Core Features

### 1. Advanced Object-Oriented Programming (OOP)
* **4-Level Inheritance Tree:** `IIdentifiable` / `IPrintable` -> `Person` (Abstract) -> `Employee` (Abstract) -> `Doctor` / `Nurse`
* **Abstraction:** Base abstract classes (`Person`, `Employee`) enforcing clear domain boundaries.
* **Interfaces:** Extensive use of standard and custom interfaces (`IIdentifiable`, `IPrintable`, `IComparable`, `IEnumerable`).
* **Polymorphism:** Implementation of method overloading, overriding, and dynamic behavior across derived classes.
* **Encapsulation:** Fully encapsulated private fields exposed via robust properties with strict validation.
* **Indexers & Operator Overloading:** Custom indexers for quick entity lookup inside `Hospital` and `Department` classes.

### 2. Custom Generic Data Structures
Implemented from scratch without using standard `.NET` collections:
* **`CustomList<T>`:** Dynamic generic list supporting traversal (`IEnumerable`) and bound checking.
* **`CustomQueue<T>`:** Generic First-In-First-Out (FIFO) queue for patient queue management.
* **`CustomStack<T>`:** Generic Last-In-First-Out (LIFO) stack for operation logs and action history.

### 3. Events, Delegates & Enums
* **Custom Delegates & Events:** Event-driven architecture for handling bed status updates, record creation, and critical alerts.
* **Comprehensive Enums:** Over 10 custom enums governing user roles, admission statuses, medical specialties, and shift schedules.

---

## Architecture & Project Structure

The solution is divided into clear logical modules and layers:

### 1. Core Logic & Domain Layer (`managment hospital`)
* **`CustomCollections/`**: Hand-crafted generic data structures (`CustomList`, `CustomQueue`, `CustomStack`).
* **`Interface/`**: Base domain interfaces and contracts.
* **`Models/`**:
  * **`Enum/`**: System state and role definitions.
  * **`Hospital/`**: Structural domain models (`Department`, `Room`, `Bed`).
  * **`Medical/`**: Clinical operation models (`MedicalRecord`, `Appointment`, `Treatment`).
  * **`People/`**: Hierarchy for staff and patients (`Person`, `Patient`, `Employee`, `Doctor`, `Nurse`).

### 2. User Interface Layer (`WinFormsApp1`)
* **`MainForm`**: Central system dashboard.
* **`PatientsForm`**: Patient records, intake, and status tracking.
* **`DoctorsForm`**: Physician and specialty management.
* **`NursesForm`**: Nursing staff allocations and shift management.
* **`EmployeeForm`**: Administrative staff management.
* **`AppointmentsForm`**: Scheduling and queue tracking.

---

## Tech Stack & Tools

* **Language:** C# (.NET)
* **UI Framework:** Windows Forms (WinForms)
* **IDE:** Visual Studio 2022
* **Version Control:** Git & GitHub

---

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/mohamad-hosein-iren/HospitalManagment.git](https://github.com/mohamad-hosein-iren/HospitalManagment.git)
