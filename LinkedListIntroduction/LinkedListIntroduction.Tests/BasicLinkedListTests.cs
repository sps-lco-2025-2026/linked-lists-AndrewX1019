using LinkedListIntroduction.Lib; 

namespace LinkedListIntroduction.Tests;

[TestClass]
public sealed class BasicLinkedListTests
{

    [TestMethod]
    public void TestEmpty()
    {
        IntegerLinkedList l = new IntegerLinkedList();
        Assert.AreEqual(0, l.Count);
    }

    [TestMethod]
    public void TestCount()
    {
        var l = new IntegerLinkedList(5);
        l.Append(7);
        l.Append(9);
        Assert.AreEqual(3, l.Count);
    }

    [TestMethod]
    public void TestSum()
    {
        var l = new IntegerLinkedList(5);
        l.Append(7);
        l.Append(9);
        Assert.AreEqual(21, l.Sum);
    }

    [TestMethod]
    public void TestToStringExplicit()
    {
        var l = new IntegerLinkedList(5);
        l.Append(7);
        l.Append(9);
        Assert.AreEqual("{5, 7, 9}", l.ToString());
    }

    [TestMethod]
    public void TestPrepend()
    {
        var l = new IntegerLinkedList(5);
        l.Prepend(3);
        Assert.AreEqual("{3, 5}", l.ToString());
    }

    [TestMethod]
    public void TestDelete()
    {
        var l = new IntegerLinkedList(1);
        l.Append(5);
        l.Append(9);
        Assert.IsTrue(l.Delete(5));
        Assert.AreEqual("{1, 9}", l.ToString());

        Assert.IsFalse(l.Delete(2));
    }
    [TestMethod]
    public void TestInsert()
    {
        var l = new IntegerLinkedList(1);
        l.Append(3);
        l.Append(5);
        l.Append(7);
        l.Insert(4, 2);//insert after second position
        Assert.AreEqual("{1, 3, 4, 5, 7}", l.ToString());
        Assert.IsFalse(l.Insert(9, 6));
        l.Insert(0, 0);//just prepend
        Assert.AreEqual("{0, 1, 3, 4, 5, 7}", l.ToString());
    }
    [TestMethod]
    public void TestJoin()
    {
        var l = new IntegerLinkedList([1, 2, 3, 4, 5]);
        var s = new IntegerLinkedList([6, 7, 8, 9, 10]);
        l.Join(s);
        Assert.AreEqual("{1, 2, 3, 4, 5, 6, 7, 8, 9, 10}", l.ToString());
    }
    [TestMethod]
    public void TestFind()
    {
        var l = new IntegerLinkedList([1, 2, 3, 4, 5]);
        Assert.IsTrue(l.Find(3));
        Assert.IsFalse(l.Find(7));
    }
}
