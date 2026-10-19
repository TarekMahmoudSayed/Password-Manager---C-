Password Manager (Console App)

A simple console-based password manager written in C# (.NET) as part of my learning journey in C# fundamentals.

⚠️ Educational project only. This app uses a basic substitution cipher to "encrypt" passwords, which is not secure. Do not use it to store real passwords.

Features
Master password protection (set on first run, required on every launch)
List all saved passwords
Add a new password or change an existing one
Get the password of a specific app/website
Delete a saved password
Data is saved to a local text file and reloaded on the next run
Getting Started
Requirements
.NET SDK (the version used by the project)
Run
bash
git clone https://github.com/<your-username>/<your-repo>.git
cd <your-repo>
dotnet run
First run
The app asks you to create a Master Key password.
From the next launch, you must enter it to access the menu.
Menu
=================================
        Password Manager
=================================
    [1] List All Passwords.
    [2] Add/ Change Password.
    [3] Get Password.
    [4] Delete Password.
    Any other choice to exit.
---------------------------------
How It Works
Entries are kept in memory in a Dictionary<string, string> (app name → password).
On every change, the data is written to Passwords.txt next to the executable, one entry per line in the format AppName=EncryptedPassword.
EncryptionUtility maps each letter/digit to another one using a fixed substitution table. Any other character (symbols, spaces) is left unchanged.
Project Structure
PasswordManager/
├── App.cs                 # Menu, login, and file load/save logic
└── EncryptionUtility.cs   # Simple substitution-cipher Encrypt/Decrypt
Concepts Practiced
Dictionary<TKey, TValue>
File I/O (File.ReadAllText, File.WriteAllText, Path.Combine)
StringBuilder
switch statements and menu loops
static classes and members
out parameters and int.TryParse
Separation of concerns (UI/logic vs. encryption helper)
Known Limitations
The substitution cipher is trivial to break.
The master password is stored in the same file as the other entries (encrypted with the same weak cipher).
Passwords are displayed in plain text on screen.
Any menu input other than 1–4 exits the app.
Letters, digits, and symbols are handled, but only letters and digits are actually substituted.
Ideas for Improvement
 Replace the cipher with AES encryption (System.Security.Cryptography.Aes)
 Store a salted hash of the master password (e.g. PBKDF2) instead of the password itself
 Hide password input while typing
 Add an explicit Exit option
 Split storage logic into a separate PasswordStore class
 Add a random password generator
License

This project is for learning purposes. Feel free to use it as a reference.
