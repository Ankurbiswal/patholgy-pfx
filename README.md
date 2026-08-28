# 🏥 Pathology Lab Management Software

A complete Pathology Lab Management System built with C# WinForms + SQL Server.

## ✅ Features
- Patient Registration & Billing
- 15+ Lab Test Modules (Blood, Biochemist, Hormone, Urine, Stool, Serology, Culture & Sensitivity, Seminal Fluid, Cytology, Histopathology, X-Ray, Body Fluid, Widal, Outsource)
- Crystal Reports — 85+ report templates
- Doctor Commission Tracking
- Accounts (Voucher, Cashbook, Ledger)
- Stock / Inventory Management
- OPD Module
- Pending Reports Tracker
- Auto daily backup
- Multi-PC network support

---

## 📦 What to Install on Client PC (3 things only)

| # | Software | Download | Required |
|---|----------|----------|---------|
| 1 | **SQL Server Express 2019** | [Download here](https://go.microsoft.com/fwlink/p/?linkid=2215158&clcid=0x409&culture=en-us&country=us) | ✅ Must |
| 2 | **SAP Crystal Reports Runtime (32-bit)** | [Download here](https://www.sap.com/cmp/syb/crm-xu15-int-crruntimes/index.html) | ✅ Must |
| 3 | **.NET Framework 3.5** | Already on Windows 10/11. For Win 7/8: [Download](https://www.microsoft.com/en-us/download/details.aspx?id=21) | ⚠️ Only if needed |

---

## 🚀 Installation Steps (Do in Order)

### Step 1 — Install SQL Server Express
1. Download SQL Server Express from link above
2. Run installer → choose **"Basic"** installation
3. When asked for SA password → set it to: `software`
4. Note the instance name (usually `SQLEXPRESS`)

### Step 2 — Install Crystal Reports Runtime
1. Download SAP Crystal Reports Runtime (32-bit / x86)
2. Run installer, follow prompts
3. Restart PC after installation

### Step 3 — Setup the Database
1. Open the `Database/` folder
2. **Double-click `SETUP_DATABASE.bat`** → runs as Administrator
3. It will create the database and all tables automatically
4. You should see: `SUCCESS! Database setup complete.`

### Step 4 — Copy the App
1. Copy the `Deploy/` folder to the client PC (e.g., `C:\PathologyLab\`)
2. Create a desktop shortcut to `Pathology.exe`

### Step 5 — First Login
- Username: `Admin`
- Password: `Admin`

**Change password after first login!** (Admin Panel → User Management)

---

## 🌐 Multi-PC / Network Setup

To use on multiple PCs (reception + lab + doctor):

1. Install SQL Server on **one server PC only** (not on every PC)
2. On all other PCs: copy the `Deploy/` folder only (no SQL Server needed)
3. On each client PC, edit `Pathology.exe.config`:
   ```xml
   <!-- Change .\sqlexpress to the server PC's IP address -->
   <add name="PathologyDB"
        connectionString="Data Source=192.168.1.10\SQLEXPRESS;Initial Catalog=pathology2627;..." />
   ```
4. Make sure SQL Server port 1433 is open in Windows Firewall on the server PC

---

## 🔧 Troubleshooting

| Problem | Solution |
|---------|---------|
| "Cannot connect to database" | Double-click `Tools/Start_SQL_Server.bat` |
| Reports not printing | Crystal Reports Runtime not installed — install it |
| App doesn't open | .NET Framework 3.5 missing — install from Windows Features |
| Wrong server IP | Edit `Pathology.exe.config` → change `Data Source=` |
| Forgot password | Contact software vendor to reset in database |

---

## 💾 Backup

- **Automatic:** App creates a backup every time it closes → saved to `Documents\PathologyBackups\`
- **Manual:** Inside app → `Tools` menu → `Backup`
- **Store backups on external drive or Google Drive — critical!**

---

## 📞 Support
Contact your software vendor for support.
