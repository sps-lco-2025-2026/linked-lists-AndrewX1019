using System.Diagnostics.Contracts;
using Microsoft.VisualBasic;

namespace LinkedListIntroduction.Lib;

public class IntegerLinkedList
{
    IntegerNode _head;
   
    public IntegerLinkedList()
    {
        _head = null;
    }
    public IntegerLinkedList(int v)
    {
        _head = new IntegerNode(v);
    }
    public IntegerLinkedList(int[] arr)
    {
        if (arr == null)
        {
            _head=null;
            return;
        }
        _head=new IntegerNode(arr[0]);
        for(int i = 1; i < arr.Count(); i++)
        {
            _head.Append(arr[i]);
        }
    }
    public int Count => _head == null ? 0 : _head.Count;
    public int Sum => _head == null ? 0 : _head.Sum;

    public void Append(int v)
    {
        if (_head == null)
        {
            _head = new IntegerNode(v);
        }
        else
        {
            _head.Append(v);//this is the other append   
        }
    }
    public void Prepend(int v)
    {
        var NewHead = new IntegerNode(v);
        NewHead.Append(_head._value);//this only adds value
        if (_head._next != null)
        {
            NewHead._next._next = _head._next;
        }
        _head = NewHead;
    }
    public bool Delete(int v)
    {
        if (_head == null)
        {
            return false;
        }
        if (_head._value == v)
        {
            _head = _head._next;//get a new head
            return true;
        }
        var current = _head;
        while (current._next != null && current._next._value != v)
        {
            current = current._next;
        }
        if (current._next != null)//==v jump over
        {
            current._next = current._next._next;
            return true;
        }
        return false;//not found
    }
    public bool Insert(int v, int n)
    {
        if (_head == null)
        {
            return false;
        }
        if (n > _head.Count)
        {
            return false;
        }
        if (n == 0)
        {
            Prepend(v);
            return true;
        }
        var current = _head;
        int Count=0;
        while (Count < n - 1)
        {
            current=current._next;
            Count++;
        }
        IntegerNode temp=current._next;
        current._next=null;
        current.Append(v);
        current._next._next=temp;
        return true;
    }
    public void Join(IntegerLinkedList l)
    {
        if (_head == null)
        {
            _head=l._head;
            return;
        }
        if (l._head == null)
        {
            return;
        }
        IntegerNode current=l._head;
        while (current._next != null)
        {
            Append(current._value);
            current=current._next;
        }
        Append(current._value);//need redo
    }
    public override string ToString()//?
    {
        return _head == null ? "{}" : $"{{{_head}}}";
    }
    public bool Find(int v)
    {
        if (_head == null)
        {
            return false;
        }
        var current = _head;
        while (current._value != v&&current._next!=null)
        {
            current=current._next;
        }
        return current._value==v;
    }
}
public class IntegerNode
{
    public int _value;
    public IntegerNode _next;//***

    internal int Count => _next == null ? 1 : 1 + _next.Count;
            
    internal int Sum => _next == null ? _value : _value + _next.Sum;


    internal IntegerNode(int v)
    {
        _value = v;
        _next = null;
    }
    internal void Append(int v)//tick
    {
        if (_next == null)
            _next = new IntegerNode(v);
        else
            _next.Append(v);
    }

    public override string ToString()
    {
        return _next == null ? _value.ToString() : $"{_value}, {_next}";
    }
}
