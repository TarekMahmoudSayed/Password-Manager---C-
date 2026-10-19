# 🔐 Password Manager (Console App)

A simple console-based password manager written in **C# (.NET)** as part of my learning journey in C# fundamentals.

> ⚠️ **Educational project only.**
> This app uses a basic substitution cipher to "encrypt" passwords, which is **not secure**.
> Do **not** use it to store real passwords.

---

## ✨ Features

- Master password protection (set on first run, required on every launch)
- List all saved passwords
- Add a new password or change an existing one
- Get the password of a specific app/website
- Delete a saved password
- Data is saved to a local text file and reloaded on the next run

---

## 🚀 Getting Started

### Requirements

- [.NET SDK](https://dotnet.microsoft.com/download)

### Run

```bash
git clone https://github.com/TarekMahmoudSayed/Password-Manager---C-.git
cd Password-Manager---C-
dotnet run
```

### First run

1. The app asks you to create a **Master Key password**.
2. From the next launch, you must enter it to access the menu.

---

## 📋 Menu

```text
=================================
        Password Manager
=================================
    [1] List All Passwords.
    [2] Add/ Change Password.
    [3] Get Password.
    [4] Delete Password.
    Any other choice to exit.
---------------------------------
```

---

## ⚙️ How It Works

- Entries are kept in memory in a `Dictionary<string, string>` (app name → password).
- On every change, the data is written to `Passwords.txt` next to the executable, one entry per line: `AppName=EncryptedPassword`
- `EncryptionUtility` maps each letter and digit to another one using a fixed substitution table. Any other character (symbols, spaces) is
