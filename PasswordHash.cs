using Microsoft.AspNetCore.Identity;
using System;

class Program
{
    static void Main(string[] args)
    {
        var hasher = new PasswordHasher<string>();
        var hashedPassword = hasher.HashPassword("user", "pwd");
        Console.WriteLine(hashedPassword);
    }
}