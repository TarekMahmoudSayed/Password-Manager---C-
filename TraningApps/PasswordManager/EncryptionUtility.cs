using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CSharpFundamentals.ConsoleApp.TraningApps.PasswordManager; 

internal class EncryptionUtility
{

    private static readonly string _originalChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    private static readonly string _altChars = "F2bDHi4YVQu7TUxhmfsq6tkXWl10ZNy9BnSAPIvjgKw3CrzReLEOJ5ca8MGopd";
    static public string Encrypt (string text)
    {
        var encrypted = new StringBuilder();

        foreach (var c in text)
        {

            var index = _originalChars.IndexOf(c);

            encrypted.Append(_altChars[index]);

        }


        return encrypted.ToString ();
    }
    static public string Decrypt (string text)
    {
        var decrypted = new StringBuilder();

        foreach (var c in text)
        {

            var index = _altChars.IndexOf(c);

            decrypted.Append(_originalChars[index]);

        }

        return decrypted.ToString ();
    }

}
