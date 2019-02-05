using System;
using Blowin.NotNull;
using NUnit.Framework;

namespace NotNull.Test
{
  [TestFixture]
  public class Tests
  {
    [Test]
    public void ImplicitConvert()
    {
      var str = "Data";
      
      NotNull<string> notNull = str.ToNotNull();
      string notNullValue = notNull;

      Assert.AreEqual(str, notNullValue);
    }

    [Test]
    public void NullCreate()
    {
      string data = null;
      
      Assert.Catch<ArgumentNullException>(() =>
      {
        var notNull = data.ToNotNull();
      });
    }

    [Test]
    public void ToNotNullDefaultValue_If_Null()
    {
      string defaultV = "default";
      string data = null;

      var notNull = data.ToNotNull(defaultV);
      var notNullVal = notNull.Value;
      
      Assert.AreEqual(defaultV, notNullVal);
    }
    
    [Test]
    public void ToNotNullDefaultValue_If_Not_Null()
    {
      string defaultV = "default";
      string data = "data";

      var notNull = data.ToNotNull(defaultV);
      var notNullVal = notNull.Value;
      
      Assert.AreEqual(data, notNullVal);
    }
    
    [Test]
    public void ToNotNullDefaultValue_If_Null_Factory()
    {
      string defaultV = "default";
      string data = null;

      var notNull = data.ToNotNull(() => defaultV);
      var notNullVal = notNull.Value;
      
      Assert.AreEqual(defaultV, notNullVal);
    }
    
    [Test]
    public void ToNotNullDefaultValue_If_Not_Factory()
    {
      string defaultV = "default";
      string data = "data";

      var notNull = data.ToNotNull(() => defaultV);
      var notNullVal = notNull.Value;
      
      Assert.AreEqual(data, notNullVal);
    }

    [Test]
    public void CreateWay()
    {
      var data = "data";

      var notNull1 = data.ToNotNull();
      var notNull2 = new NotNull<string>(data);
      var notNull3 = Blowin.NotNull.NotNull.From(data);
      var notNull4 = (NotNull<string>)data;
      
      Assert.AreEqual(notNull1, notNull2);
      Assert.AreEqual(notNull2, notNull3);
      Assert.AreEqual(notNull3, notNull4);
      
      Assert.AreEqual(notNull1.Value, notNull2.Value);
      Assert.AreEqual(notNull2.Value, notNull3.Value);
      Assert.AreEqual(notNull3.Value, notNull4.Value);
    }
  }
}