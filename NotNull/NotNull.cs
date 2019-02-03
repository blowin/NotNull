using System;
using System.Collections.Generic;

namespace Blowin.NotNull
{
  public struct NotNull<T> : 
    IEquatable<NotNull<T>>, 
    IEquatable<T>,
    IComparable<NotNull<T>>,
    IComparable<T>,
    IComparable
    where T : class
  {
    public T Value { get; }

    public NotNull(T val)
    {
      if(val == null)
        throw new ArgumentNullException(nameof(val));

      Value = val;
    }

    public static implicit operator NotNull<T>(T val)
    {
      return new NotNull<T>(val);
    }

    public static implicit operator T(NotNull<T> notNull)
    {
      return notNull.Value;
    }

    public bool Equals(NotNull<T> other)
    {
      return Equals(other.Value);
    }

    public bool Equals(T other)
    {
      return EqualityComparer<T>.Default.Equals(Value, other);
    }

    public override bool Equals(object obj)
    {
      if (obj is NotNull<T>)
        return Equals((NotNull<T>)obj);

      if (obj is T)
        return Equals((T)obj);
      
      return false;
    }
    
    public int CompareTo(T other)
    {
      return Comparer<T>.Default.Compare(Value, other);
    }

    public int CompareTo(NotNull<T> other)
    {
      return CompareTo(other.Value);
    }

    public int CompareTo(object obj)
    {
      if (obj is NotNull<T>)
        return CompareTo((NotNull<T>)obj);

      if (obj is T)
        return CompareTo((T)obj);

      return 1;
    }

    public override int GetHashCode()
    {
      return Value.GetHashCode();
    }
    
    public override string ToString()
    {
      return "NotNull(" + Value.ToString() + ")";
    }
  }

  public static class NotNull
  {
    public static NotNull<T> From<T>(T val) where T : class
    {
      return new NotNull<T>(val);
    }
  }
}