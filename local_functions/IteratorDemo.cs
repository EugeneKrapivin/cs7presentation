using System;
using System.Collections.Generic;

public class IteratorDemo
{

  public void Demo()
  {
    // no error? :(
    var iter = Iterator(10, -2);

    System.Console.WriteLine("We've to an iterator here, but no exception, why?");

    try
    {
      foreach (var i in iter)
      {
        System.Console.WriteLine("won't get here...");
      }
    }
    catch (System.Exception)
    {
      System.Console.WriteLine("did get here though, why is that?");
    }

    // try IterSafe1
    // try IterSafe
  }
  public static IEnumerable<int> Iterator(int start, int count)
  {
    if (count <= 0) throw new ArgumentException(nameof(count));

    for (var i = start; i < start + count; i++)
    {
      yield return i;
    }
  }

  public static IEnumerable<int> IteratorSafeOldWay(int start, int count)
  {
    if (count <= 0) throw new ArgumentException(nameof(count));

    return IteratorSafeOldWayImpel(start, count);
  }

  private static IEnumerable<int> IteratorSafeOldWayImpel(int start, int count)
  {
    for (var i = start; i < start + count; i++)
    {
      yield return i;
    }
  }

  private static IEnumerable<int> IteratorSafe(int start, int count)
  {
    if (count <= 0) throw new ArgumentException(nameof(count));

    return iterate(start, count);

    // no closures!
    IEnumerable<int> iterate(int s, int c)
    {
      for (var i = s; i < s + c; i++)
      {
        yield return i;
      }
    }

  }

  // the local functions version has 2 fewer allocations than the lambda expression version
  public static int LocalFunctionFactorial(int n)
  {
    return nthFactorial(n);

    // looks like a lmbda but really is a local function
    // doesn't really have allocations since it is implemented as a
    // private compiler named method that calls it self...
    int nthFactorial(int number) => (number < 2) ?
        1 : number * nthFactorial(number - 1);
  }

  public static int LambdaFactorial(int n)
  {
    // first *class* allocation
    Func<int, int> nthFactorial = default(Func<int, int>);
    // closure - second allocation *class*
    nthFactorial = (number) => (number < 2) ?
        1 : number * nthFactorial(number - 1);

    return nthFactorial(n);
  }

}