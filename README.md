*🏥 Hospital Management System*

A Windows Forms application built in C# that manages hospital operations including patients, doctors, appointments, and billing. It uses MySQL as the backend and connects through the MySql.Data.dll connector.

---

*📌 Features*

👨‍⚕️ *Doctor Management* – Add, edit, delete doctor records

🧑‍⚕ *Patient Management* – Add, edit, delete patient records

📅 *Appointment Booking* – Schedule and manage appointments

💰 *Billing System* – Generate patient bills with services listed

🔐 *Main Admin Panel* – Navigate between modules through a central dashboard

---

🛠 *Technologies Used*

C# Windows Forms (.NET Framework)

MySQL Database

MySql.Data.dll (MySQL Connector/NET)

Visual Studio

---

🚀 *How to Run*

_1. Requirements_

Visual Studio (with Windows Forms)

MySQL Server & MySQL Workbench

MySql.Data.dll (Connector/NET installed or referenced in project)

_2. Setup_

Clone the repo:
git clone https://github.com/tubakhalil4/HospitalManagementSystem.git

Create the database:
Open MySQL Workbench and run:

CREATE DATABASE HospitalDB;

Manually create the required tables (Doctor, Patient, Appointment, Billing) or use SQL scripts if available.

Update the connection string in your C# forms (typically something like):

string connStr = "server=localhost;user id=root;password=yourpassword;database=HospitalDB;";

Make sure MySql.Data.dll is referenced in your project.

---

*👨‍🏫 Project Info*: 

 *Subject*: Visual Programming
 
 *Instructor*: Sir Jasim Shah
 
 *Semester Project*

 ---
 
*👩‍👩‍👧‍👦 Team Memebers*

Tuba Khalil, Nosheen Zahra, Hifza Riaz, and Misbah Bibi
