using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSharpFundamentals.ConsoleApp.TraningApps.PasswordManager; 

static public class App
{
    private static readonly string FilePath =
    Path.Combine(AppContext.BaseDirectory, "Passwords.txt");
    static private bool _okey = true;
    static private readonly string MasterName = "MasterKey" ;
    private static Dictionary<string, string> AllEntriesPasswords = new Dictionary<string, string>();
    private static void MainMenu ()
    {

        LoadDataFromFile();

        Console.WriteLine("=================================");
        Console.WriteLine("\tPassword Manager ");
        Console.WriteLine("=================================");
        Console.WriteLine("\t[1] List All Passwords. ");
        Console.WriteLine("\t[2] Add/ Change Password. ");
        Console.WriteLine("\t[3] Gt Password. ");
        Console.WriteLine("\t[4] Delete Password. ");
        Console.WriteLine("\t another Choice To Exit . ");
        Console.WriteLine("---------------------------------");

        int choice = ReadPasswordManagerMenuOption(out _okey);

        if (_okey)
        {
            PerformPasswordManagerMenuOption(choice);
        }else
        {
            return;
        }

    }
    private static int ReadPasswordManagerMenuOption (out bool okey)
    {
        Console.Write("Please Enter Your Choice [1 to 4] : ");
        int choice = int.Parse (Console.ReadLine());
        
        if (choice == 1 || choice == 2 || choice == 3 || choice == 4 )
        {
            okey = true;
        }else
        {
            okey = false;
        }

        return choice;
    }
    private static void PerformPasswordManagerMenuOption (int Choice)
    {

        Console.WriteLine("---------------------------------");
        switch (Choice)
        {
            case 1:
                ListAllPassword();
                break;
            case 2:
                AddOrChangePassword();
                break;
            case 3:
                GetPassword();
                break;
            case 4:
                DeletePassword();
                break;
            default:
                break;
             

        }
        Console.WriteLine("---------------------------------");

    }
    private static void DeletePassword()
    {
        Console.WriteLine("Please Enter App Name : ");
        string appName = Console.ReadLine();

        if (AllEntriesPasswords.ContainsKey(appName))
        {
            AllEntriesPasswords.Remove(appName);
            Console.WriteLine("Password Deleted Successfully");
        }
        else
        {
            Console.WriteLine("Password Not Found !");
        }

        SaveDataToFile();
    }
    private static void GetPassword()
    {
        Console.WriteLine("Please Enter App Name : ");
        string appName = Console.ReadLine();

        if (AllEntriesPasswords.ContainsKey (appName))
        {
            Console.WriteLine($"Password = {AllEntriesPasswords[appName]}");
        }else
        {
            Console.WriteLine("Password Not Found !");
        }

    }

    private static void AddOrChangePassword()
    {
        Console.WriteLine("Please enter Website/App Name : ");
        string appName = Console.ReadLine();

        Console.WriteLine("Please enter your Password : ");
        string password = Console.ReadLine();

        if (AllEntriesPasswords.ContainsKey(appName))
        {
            AllEntriesPasswords[appName] = password;
        }else
        {
            AllEntriesPasswords.Add(appName, password);
        }

        Console.WriteLine("Password Added Successfully");


        SaveDataToFile();

    }

    private static void ListAllPassword()
    {

        foreach (var line in AllEntriesPasswords)
        {
            if (line.Key != MasterName)
                Console.WriteLine($"{line.Key} = {line.Value}");
        }
    }

    private static void LoadDataFromFile()
    {
        AllEntriesPasswords.Clear(); 

        if (File.Exists (FilePath))
        {
            var EnterisPassword = File.ReadAllText(FilePath);

            foreach (var line in EnterisPassword.ToString().Split(Environment.NewLine))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var equalIndex = line.IndexOf('=');
                    string appName = line.Substring(0, equalIndex);
                    string password = EncryptionUtility.Decrypt(line.Substring(equalIndex + 1));

                    AllEntriesPasswords.Add(appName, password);
                }
            }
        }

    }

    private static void SaveDataToFile ()
    {

        var allEntriesPasswords = new StringBuilder();

        foreach (var item in AllEntriesPasswords)
        {
            string Line = item.Key + "=" + EncryptionUtility.Encrypt(item.Value);
            allEntriesPasswords.Append(Line+Environment.NewLine);
        }

        File.WriteAllText(FilePath, allEntriesPasswords.ToString());

    }

    static public void Login(string[] args)
    {

        LoadDataFromFile();

        if (AllEntriesPasswords.ContainsKey(MasterName))
        {
            Console.Write("Please Enter Master Password ? ");
            string input = Console.ReadLine();

            if (AllEntriesPasswords.TryGetValue(MasterName, out var stored) && (stored) == input)
            {
                Run(args);
            }
            else {
                _okey = false;
                Console.WriteLine("Invalid Password !");
            }
        }else
        {
            Console.Write("please Enter Master Key Password : ");
            string password = Console.ReadLine();

            AllEntriesPasswords.Add(MasterName, password);
            SaveDataToFile();
            Console.Clear();
            Run(args);
        }
    }

    static private void Run(string[] args)
    {
        while (_okey)
        {
            MainMenu();
            Console.ReadKey();
            Console.Clear();
        }
        
    }



}
