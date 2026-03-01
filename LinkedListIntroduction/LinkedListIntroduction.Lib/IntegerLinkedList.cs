using System.Diagnostics.Contracts;

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
    public void Insert(int v, int n)
    {
        IntegerNode current = _head;
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
    }
    public override string ToString()//?
    {
        return _head == null ? "{}" : $"{{{_head}}}";
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
