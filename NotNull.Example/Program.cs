using System;
using Blowin.NotNull;

namespace NotNull.Example
{
  internal class Program
  {
    public sealed class Person
    {
      public NotNull<string> Name { get; set; } = "Tary";

      public NotNull<string> Surname { get; set; } = "D";
      
      public int Age { get; set; } = 20;
    }
    
    public static void Main(string[] args)
    {
      var tary = new Person();

      tary.Name = "Taryy"; // OK

      try
      {
        tary.Name = null;
      }
      catch (ArgumentNullException e)
      {
        Console.WriteLine("Argument null");
      }
      
      Console.WriteLine(MyConcat("F1", "F2")); // F1F2

      try
      {
        Console.WriteLine(MyConcat("F1", null));
      }
      catch (ArgumentNullException e)
      {
        Console.WriteLine("Argument null");
      }
    }

    public static NotNull<string> MyConcat(NotNull<string> str1, NotNull<string> str2)
    {
      return str1.Value + str2.Value;
    }
  }
}