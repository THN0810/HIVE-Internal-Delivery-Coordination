# HIVE Logistics Management System

## Academic Business Analysis &amp; System Design Project

&gt; **Academic Institution:** University of Finance - Marketing (UFM), Ho Chi Minh City  
&gt; **Faculty:** Faculty of Data Science | **Department:** Management Information Systems (MIS)  
&gt; **Course:** Professional Practice Report (Thực hành nghề nghiệp)  
&gt; **Author:** Trịnh Hoàng Ngân  
&gt; **Advisor:** M.Sc. Lâm Hoàng Trúc Mai  
&gt; **Target Enterprise:** HIVE Transportation Services Trading Co., Ltd.  
&gt; **Tools &amp; Tech Stack:** Business Analysis (BABOK, BPMN 2.0, DFD, UML), SQL Server 2022 (T-SQL, Triggers, RBAC), C# .NET Windows Forms, Visual Studio 2022, PowerDesigner, Draw.io.

---

## 1\. Project Overview

### Business Context

**HIVE Transportation Services Trading Co., Ltd.** is an internal logistics and transport coordination firm providing freight delivery across urban and inter-provincial routes. As order volume grew, the company experienced operational challenges due to fragmented, manual record-keeping—relying on paper notes, disconnected Excel spreadsheets, phone calls, and Zalo messaging groups.

These manual practices made it difficult to:

* Consistently track transport orders across their lifecycle.
* Verify real-time driver and vehicle availability during dispatching.
* Coordinate transport assignments without risk of scheduling conflicts.
* Receive timely delivery status updates from drivers.
* Reconcile payment receipts and issue VAT invoices accurately.
* Consolidate operational performance and revenue reports for management.

### Proposed Solution

This academic project analyzes and designs a centralized logistics coordination system to digitize and streamline HIVE's core operational activities:

* **Delivery Order Management:** Centralized order intake, automated tracking code generation, and lifecycle history.
* **Dispatch Management:** Resource matching (drivers and vehicles) with automated scheduling constraint validation.
* **Transport Resource Management:** Centralized management of driver profiles, licenses, vehicle fleets, and availability statuses.
* **Freight Payment &amp; Invoicing:** Payment receipt logging, fee itemization, and automated VAT invoice calculation.
* **Reporting &amp; Analytics:** Operational status monitoring and revenue report generation.
* **User Account &amp; Permission Management:** Role-Based Access Control (RBAC) ensuring data security across internal roles.

---

## 2\. My Contribution

To address the operational challenges at HIVE, I conducted an end-to-end system analysis and design project covering three primary domains:

```
+-----------------------------------------------------------------------------------+
|                                  MY CONTRIBUTION                                  |
+------------------------------------+----------------------------------------------+
| 1. Business Analysis (BA)          | • Elicited 25 Functional &amp; 18 Non-Functional |
|                                    |   Requirements across 5 business modules.    |
|                                    | • Modeled AS-IS &amp; TO-BE processes using      |
|                                    |   BPMN 2.0, BFD, 3-level DFD, &amp; UML (56 UCs).|
+------------------------------------+----------------------------------------------+
| 2. Database Engineering           | • Designed a 3NF relational schema with      |
|    (SQL Server)                    |   21 physical tables.                        |
|                                    | • Implemented T-SQL triggers for double-     |
|                                    |   booking prevention and VAT calculation.    |
|                                    | • Configured RBAC across 5 roles &amp; 67 rules. |
+------------------------------------+----------------------------------------------+
| 3. Application Development         | • Developed a C# WinForms desktop prototype  |
|    (C# .NET &amp; ADO.NET)             |   connected to SQL Server.                   |
|                                    | • Built 5 role-based UI interfaces to        |
|                                    |   validate end-to-end workflows.            |
+------------------------------------+----------------------------------------------+

```

### Key Deliverables:

1. **Business Analysis:**

  * Surveyed AS-IS workflows and formulated the digital TO-BE process architecture.
  * Documented **25 Functional Requirements (FRs)** and **18 Non-Functional Requirements (NFRs)**.
  * Constructed system process models: Business Function Diagram (BFD), 3-level Data Flow Diagrams (Context, Level 0, Level 1), BPMN 2.0 process models, and an overall UML Use Case model containing **56 Use Cases** across 5 user roles.
2. **Database Design &amp; Implementation:**

  * Designed a normalized relational database schema (`QuanLyDieuPhoiVanChuyen_HIVE`) comprising **21 physical tables** in 3rd Normal Form (3NF) across 5 functional domains.
  * Programmed automated T-SQL triggers to enforce business constraints, including preventing driver and vehicle double-booking during active time slots, and recalculating invoice pre-tax and VAT totals.
  * Established a Role-Based Access Control (RBAC) security structure defining **67 permissions** across 5 system roles, supporting both role-level and account-level overrides.
3. **Application Development:**

  * Built a C# Windows Forms desktop application prototype connected to SQL Server using ADO.NET data access layers.
  * Implemented **5 role-specific user interfaces** (*Dispatcher, Driver, Accountant, Manager, Admin*) to simulate and validate the end-to-end delivery coordination lifecycle.

---

## 3\. Business Analysis &amp; System Modeling

### 3.1 TO-BE Process Architecture

The proposed TO-BE process digitizes the transport lifecycle into a centralized workflow connecting 5 internal roles:

```
[Customer Request] ──&gt; (Dispatcher) ──&gt; [Create Order &amp; Validate] ──&gt; [Assign Driver &amp; Vehicle]
                                                                            │
[Management BI] &lt;── [Accounting Invoicing] &lt;── [Driver Delivery] &lt;──────────┘

```

1. **Order Intake:** Dispatcher records order details; the system assigns a unique tracking code (`DVCxxx`).
2. **Dispatch &amp; Allocation:** Dispatcher matches available drivers and vehicles (`LDPxxx`); T-SQL triggers prevent double-booking.
3. **Trip Execution:** Driver views assigned trips in their workspace ("Nhiệm vụ của tôi"), updates delivery milestones, and logs transit incidents.
4. **Financial Settlement:** Accountant logs payment receipts (`PTTxxx`) and issues VAT invoices (`HDxxx`) automatically calculated from line items.
5. **Reporting:** Manager accesses operational summary reports and revenue analytics.

\--Image of: --02-bpmn-tobe-workflow *Figure 1: TO-BE Delivery Coordination Process Model (BPMN 2.0).*

---

### 3.2 System Requirements Summary

#### Functional Requirements (25 Core FRs)

The 25 functional requirements are structured into **5 core business modules**:

* **Order Lifecycle Management (FR-06 to FR-10, FR-20):** Order creation with auto-generated tracking codes (`DVCxxx`), multi-criteria filtering, lifecycle state management (*New, Dispatching, Assigned, In-Transit, Completed, Cancelled*), and immutable status history logs.
* **Resource Allocation &amp; Dispatch (FR-11 to FR-15, FR-19):** Management of driver profiles (license classes, expiry dates) and vehicle fleets (tonnage capacity, maintenance status); real-time availability checks; dispatch order creation (`LDPxxx`); and transit incident logging.
* **Driver Workspace (FR-16 to FR-18):** Dedicated driver interface for viewing assigned tasks, accepting/rejecting assignments with mandatory reason entry, and updating real-time trip milestones.
* **Financial Settlement &amp; Invoicing (FR-21 to FR-23):** Recording payment receipts (`PTTxxx`), tracking unpaid accounts, and issuing VAT invoices (`HDxxx`) with automated tax calculations and printable document exports.
* **Security &amp; Administration (FR-01 to FR-05, FR-24, FR-25):** Role-based authentication, user account management, granular permission assignment, executive dashboard, and operational BI reports.

#### Key Non-Functional Requirements (18 NFRs)

* **Performance (NFR-01):** Standard query and navigation response time within 2–5 seconds under normal operational loads.
* **Access Control (NFR-04, NFR-05):** Mandatory user authentication and strict feature restriction mapped to assigned roles (`VT001` to `VT005`).
* **Data Integrity (NFR-07, NFR-08):** Mandatory field validation, unique constraint checks (Tax IDs, phone numbers, license plates), and synchronized state updates across screens.
* **Auditability (NFR-09):** Immutable logging of order status changes, timestamps, and updating user accounts.
* **Exportability (NFR-15):** Exporting operational and financial reports to PDF and CSV formats.

---

### 3.3 Modeling Diagrams

#### 1\. Business Function Diagram (BFD)

Structured into 5 primary operational pillars:

1. `1.0` System Administration &amp; Security
2. `2.0` Logistics Master Data Management
3. `3.0` Order Management &amp; Dispatching
4. `4.0` Financial Settlement &amp; Invoicing
5. `5.0` Reporting &amp; Statistics

\--Image of: --03-bfd-diagram *Figure 2: Business Function Diagram (BFD).*

#### 2\. Data Flow Diagrams (DFD)

* **Context Level DFD:** Defines external interactions between the central system (`0.0`) and external entities (**Customer**, **Management**).
* **Level 0 DFD:** Decomposes system operations into 5 major processes linked to 4 central data stores:  
  * `D1: Logistics Master Data` (Customers, Drivers, Vehicles)
  * `D2: Orders &amp; Dispatch Records` (Orders, Line Items, Dispatch Slips, Incident Logs)
  * `D3: Payments &amp; Invoices` (Payment Receipts, VAT Invoices, Fee Categories)
  * `D4: Accounts &amp; Permissions` (User Accounts, System Roles, Permissions)
* **Level 1 DFD:** Detailed breakdowns for order dispatching and financial accounting.

\--Image of: --04-dfd-level-0 *Figure 3: Data Flow Diagram (DFD) Level 0.*

#### 3\. UML Use Case Architecture

Encompasses **56 Use Cases** (`UC001` to `UC056`) across 5 primary human actors (**Dispatcher**, **Driver**, **Accountant**, **Manager**, **System Admin**) and 1 automated actor (**System Handler**).

\--Image of: --05-uml-usecase-model *Figure 4: Overall UML Use Case Model.*

---

## 4\. Relational Database Engineering (`QuanLyDieuPhoiVanChuyen_HIVE`)

### 4.1 Database Architecture Overview

* **Database Engine:** Microsoft SQL Server 2022
* **Database Name:** `QuanLyDieuPhoiVanChuyen_HIVE`
* **Schema Design:** **21 Physical Tables** in 3rd Normal Form (3NF) across 5 core operational domains:

```
                                +-----------------------------------+
                                | QuanLyDieuPhoiVanChuyen_HIVE (DB) |
                                +-----------------------------------+
                                                  |
     +------------------+------------------+------+------------------+------------------+
     |                  |                  |                         |                  |
+----+-----+       +----+-----+       +----+-----+             +-----+----+       +-----+----+
|PERSONNEL &amp;|      | CUSTOMERS|       |  FLEET &amp; |             | ORDERS &amp; |       | PAYMENTS |
|  SECURITY |      |          |       |   CARGO  |             | DISPATCH |       |&amp; INVOICES|
+-----------+      +----------+       +----------+             +----------+       +----------+
| ChucVu    |      | LoaiKH   |       | LoaiPT   |             | DonVC    |       | PhieuTT  |
| NhanVien  |      | KhachHang|       | PhuongTien|            | ChiTietDVC|      | HoaDonVC |
| TaiKhoan  |      +----------+       | LoaiHH   |             | LenhDP   |       | LoaiPhiVC|
| VaiTroHT  |                         +----------+             | LichSuLS |       | ChiTietHD|
| Quyen     |                                                  | PhieuPS  |       +----------+
| PhanQuyen |                                                  +----------+
+-----------+

```

\--Image of: --06-erd-physical-model *Figure 5: Physical Entity-Relationship Diagram (ERD) - 21 Relational Tables.*

---

### 4.2 Automated T-SQL Business Rule Triggers

#### 1\. Driver Double-Booking Prevention (`TRG_LenhDieuPhoi_KhongTrungTaiXe`)

Prevents assigning a driver to multiple active dispatch orders at the same scheduled time:

```
CREATE TRIGGER TRG_LenhDieuPhoi_KhongTrungTaiXe
ON LenhDieuPhoi AFTER INSERT, UPDATE AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM LenhDieuPhoi l1
        JOIN LenhDieuPhoi l2 ON l1.MaLenhDP &lt;&gt; l2.MaLenhDP
            AND l1.MaNV = l2.MaNV
            AND l1.TGPhanCong = l2.TGPhanCong
        WHERE l1.TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')
          AND l2.TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')
          AND l1.TGPhanCong IS NOT NULL
    )
    BEGIN
        RAISERROR (N'Tài xế đã có lệnh điều phối đang hoạt động tại thời điểm phân công này.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;

```

#### 2\. Vehicle Double-Booking Prevention (`TRG_LenhDieuPhoi_KhongTrungPhuongTien`)

Ensures a vehicle cannot be assigned to two active dispatch orders simultaneously.

#### 3\. Invoice Pre-Tax &amp; VAT Total Recalculation (`TRG_ChiTietHDVC_CapNhatTongTienHoaDon`)

Automatically recalculates `HoaDonVanChuyen.TongTienTruocThue` whenever invoice line items (`ChiTietHDVC`) are modified. Post-tax totals (`TongTienSauThue`) are calculated via a persistent computed column:

```
CAST(ROUND(TongTienTruocThue * (1 + ThueVAT / 100.0), 2) AS DECIMAL(18,2))

```

---

### 4.3 Role-Based Access Control (RBAC) Security Structure

The database controls feature access through **67 System Permissions** (`Q001` to `Q067`) mapped to **5 System Roles** (`VT001` – `VT005`):

* `VT001` (Dispatcher): Orders, driver/vehicle lookup, and dispatch management (`Q021-Q027`, `Q030`, `Q033`, `Q036-Q051`).
* `VT002` (Driver): View assigned trips, update progress, and log transit incidents (`Q036`, `Q040`, `Q044`, `Q047-Q050`).
* `VT003` (Accountant): Payment records, VAT invoicing, and financial reporting (`Q024`, `Q036`, `Q040`, `Q052-Q065`, `Q067`).
* `VT004` (Manager): Read-only operational oversight and BI reporting (`Q066`, `Q067`).
* `VT005` (System Admin): Full system administration (`Q001-Q067`).

*Note:* The `PhanQuyen` table supports both **Role-Level Permissions** (`MaVT`) and **Account-Level Overrides** (`MaTK`), enabling custom permission grants or revocations for individual user accounts.

---

## 5\. C# WinForms Application Prototype

### 5.1 Technology Stack &amp; Implementation

* **Application Type:** C# .NET Windows Forms Desktop Prototype
* **IDE:** Microsoft Visual Studio 2022
* **Database Connection:** ADO.NET (`Microsoft.Data.SqlClient`) connecting to SQL Server 2022
* **Data Presentation:** DataGridView, Form-based navigation, and printable document layouts

---

### 5.2 Role-Based User Interfaces

```
+------------------+-------------------------------------------------------------------+
| User Role        | Application Interface Functions                                   |
+------------------+-------------------------------------------------------------------+
| Dispatcher       | • Interactive dispatch board for pending orders (DVCxxx).         |
|                  | • Driver &amp; vehicle capacity matching and dispatch slip generation. |
|                  | • Order creation, updates, and customer master records.           |
+------------------+-------------------------------------------------------------------+
| Driver           | • Task management board ("Nhiệm vụ của tôi").                      |
|                  | • Trip acceptance/rejection dialogs with mandatory reason entry.  |
|                  | • Milestone status updates and transit incident logging.          |
+------------------+-------------------------------------------------------------------+
| Accountant       | • Payment receipt entry form with transaction code validation.    |
|                  | • Automatic VAT invoice generation and fee itemization.           |
|                  | • Unpaid accounts filter and revenue reconciliation.              |
+------------------+-------------------------------------------------------------------+
| Manager          | • Executive summary view with key operational metric cards.       |
|                  | • Daily and monthly revenue summary reports.                      |
+------------------+-------------------------------------------------------------------+
| Admin            | • User account provisioning and status toggling.                  |
|                  | • Password reset dialogs and role/permission mapping matrix.       |
+------------------+-------------------------------------------------------------------+

```

\--Image of: --07-csharp-winforms-ui *Figure 6: C# WinForms Application Interface - Dispatch &amp; Incident Management Forms.*

---

## 6\. Repository Layout &amp; Artifacts

```
HIVE-Delivery-Coordination-System/
├── README.md                              &lt;-- Master Documentation File
├── docs/                                  &lt;-- Visual Diagram Assets
│   └── images/
│       ├── 01-hive-system-architecture.png
│       ├── 02-bpmn-tobe-workflow.png
│       ├── 03-bfd-diagram.png
│       ├── 04-dfd-level-0.png
│       ├── 05-uml-usecase-model.png
│       ├── 06-erd-physical-model.png
│       ├── 07-csharp-winforms-ui.png
│       ├── 08-dfd-context-level.png
│       ├── 09-dfd-level-1.png
│       └── 10-rbac-permission-matrix.png
├── 01-Business-Analysis/                  &lt;-- BABOK Specification Artifacts
│   ├── BRD_HIVE_Delivery_System.pdf       &lt;-- Business Requirements Document
│   ├── BPMN_AsIs_vs_ToBe.png              &lt;-- Business Process Models
│   ├── DFD_Context_Level0_Level1.png      &lt;-- Data Flow Diagrams
│   └── UML_Use_Case_Specifications.xlsx
├── 02-Database-Design/                    &lt;-- SQL Server Database Implementation
│   ├── ERD_Physical_Model.png             &lt;-- Relational ERD
│   └── QuanLyDieuPhoiVanChuyen_HIVE.sql   &lt;-- Master T-SQL Script (Schema, Triggers, Test Data)
└── 03-Software-Application/               &lt;-- C# WinForms Source Code
    ├── HIVE_Delivery_System.sln           &lt;-- Visual Studio Solution
    └── HIVE_Delivery_System/              &lt;-- C# Forms, Models, and Data Access Layers

```

---

## Academic Attribution &amp; Credits

This project was developed as a Professional Practice Report case study for the **Management Information Systems (MIS)** program at the **University of Finance - Marketing (UFM)** under the academic guidance of **M.Sc. Lâm Hoàng Trúc Mai**.
