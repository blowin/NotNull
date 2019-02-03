using System;

namespace Blowin.NotNull
{
  public static class NotNullEx
  {
    public static NotNull<T> ToNotNull<T>(this T val) where T : class
    {
      return new NotNull<T>(val);
    }

    public static NotNull<T> ToNotNull<T>(this T val, T defaultV) where T : class
    {
      return new NotNull<T>(val ?? defaultV);
    }

    public static NotNull<T> ToNotNull<T>(this T val, Func<T> defaultFactory) where T : class
    {
      if (val != null) 
        return new NotNull<T>(val);
      
      if(defaultFactory == null)
        throw new ArgumentNullException(nameof(defaultFactory));
        
      return new NotNull<T>(defaultFactory());
    }
  }
}