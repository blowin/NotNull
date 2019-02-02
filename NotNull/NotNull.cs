using System;

namespace NotNull
{
  public struct NotNull<T> where T : class
  {
    public T Value { get; }

    public NotNull(T val)
    {
      if(val == null)
        throw new ArgumentNullException(nameof(val));

      Value = val;
    }

    public static explicit operator NotNull<T>(T val)
    {
      return new NotNull<T>(val);
    }

    public static explicit operator T(NotNull<T> notNull)
    {
      return notNull.Value;
    }
  }
}