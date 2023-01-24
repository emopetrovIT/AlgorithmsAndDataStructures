using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
  private Node head;
  private Node tail;

  public int Count { get; private set; }

  public LinkedList()
  {
    this.head = null;
    this.tail = null;
    this.Count = 0;
  }

  public void AddFirst(T item)
  {
    Node newNode = new Node(item);
    if (IsEmpty())
    {
      this.head = newNode;
      this.tail = newNode;
    }
    else
    {
      newNode.Next = this.head;
      this.head = newNode;
    }

    this.Count++;
  }

  public void AddLast(T item)
  {
    Node newNode = new Node(item);

    if (IsEmpty())
    {
      this.head = newNode;
      this.tail = newNode;
    }
    else
    {

      this.tail.Next = newNode;
      this.tail = newNode;
    }

    this.Count++;
  }

  public T RemoveFirst()
  {
    if (this.IsEmpty())
    {
      throw new InvalidOperationException();
    }

    T item = this.head.Value;

    if (this.Count == 1)
    {
      this.head = null;
      this.tail = null;
    }
    else
    {
      this.head = this.head.Next;
    }
    this.Count--;

    return item;
  }

  public T RemoveLast()
  {
    if (this.IsEmpty())
    {
      throw new InvalidOperationException();
    }

    T item = this.tail.Value;

    if (this.Count == 1)
    {
      this.head = null;
      this.tail = null;
    }
    else
    {
      Node parentOfLastNode = GetParentOfLastNode();

      parentOfLastNode.Next = null;
      this.tail = parentOfLastNode;
    }

    this.Count--;

    return item;
  }

  private Node GetParentOfLastNode()
  {
    Node parentOfLastNode = this.head;

    while (parentOfLastNode.Next != this.tail)
    {
      parentOfLastNode = parentOfLastNode.Next;
    }

    return parentOfLastNode;
  }

  public IEnumerator<T> GetEnumerator()
  {
    Node iteratedNode = this.head;

    while (iteratedNode != null)
    {
      yield return iteratedNode.Value;
      iteratedNode = iteratedNode.Next;
    }
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return this.GetEnumerator();
  }

  private bool IsEmpty()
  {
    if (this.Count > 0)
    {
      return false;
    }

    return true;
  }

  private class Node
  {
    public Node(T value)
    {
      this.Value = value;
    }

    public T Value { get; set; }
    public Node Next { get; set; }
  }
}
