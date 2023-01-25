using System;

public class CircularQueue<T>
{
  private const int DefaultCapacity = 4;

  private T[] arr;
  private int head;
  private int tail;

  public int Count { get; private set; }
  public int Capacity { get; private set; }

  public CircularQueue(int capacity = DefaultCapacity)
  {
    this.Capacity = capacity;
    this.arr = new T[this.Capacity];
  }

  public void Enqueue(T element)
  {
    if (this.Count >= this.Capacity)
    {
      this.Resize();
    }

    this.arr[this.tail] = element;
    this.tail = (this.tail + 1) % this.Capacity;
    this.Count++;
  }

  private void Resize()
  {
    T[] newArray = new T[this.Capacity * 2];
    this.CopyAllElements(newArray);
    this.Capacity *= 2;
    this.arr = newArray;

    this.head = 0;
    this.tail = this.Count;
  }

  private void CopyAllElements(T[] newArray)
  {
    for (int i = 0; i < this.Count; i++)
    {
      int index = (this.head + i) % this.Capacity;
      newArray[i] = this.arr[index];
    }
  }

  // Should throw InvalidOperationException if the queue is empty
  public T Dequeue()
  {
    if (this.Count == 0)
    {
      throw new InvalidOperationException();
    }

    T element = this.arr[this.head];
    this.head = (this.head + 1) % this.Capacity;
    this.Count--;

    return element;
  }

  public T[] ToArray()
  {
    // Returning other reference to the elements I ensure that inner reference won't be manipulated from any other client code
    T[] copyArray = new T[this.Count];
    this.CopyAllElements(copyArray);
    return copyArray;
  }
}


public class Example
{
  public static void Main()
  {

    CircularQueue<int> queue = new CircularQueue<int>();

    queue.Enqueue(1);
    queue.Enqueue(2);
    queue.Enqueue(3);
    queue.Enqueue(4);
    queue.Enqueue(5);
    queue.Enqueue(6);

    Console.WriteLine("Count = {0}", queue.Count);
    Console.WriteLine(string.Join(", ", queue.ToArray()));
    Console.WriteLine("---------------------------");

    int first = queue.Dequeue();
    Console.WriteLine("First = {0}", first);
    Console.WriteLine("Count = {0}", queue.Count);
    Console.WriteLine(string.Join(", ", queue.ToArray()));
    Console.WriteLine("---------------------------");

    queue.Enqueue(-7);
    queue.Enqueue(-8);
    queue.Enqueue(-9);
    Console.WriteLine("Count = {0}", queue.Count);
    Console.WriteLine(string.Join(", ", queue.ToArray()));
    Console.WriteLine("---------------------------");

    first = queue.Dequeue();
    Console.WriteLine("First = {0}", first);
    Console.WriteLine("Count = {0}", queue.Count);
    Console.WriteLine(string.Join(", ", queue.ToArray()));
    Console.WriteLine("---------------------------");

    queue.Enqueue(-10);
    Console.WriteLine("Count = {0}", queue.Count);
    Console.WriteLine(string.Join(", ", queue.ToArray()));
    Console.WriteLine("---------------------------");

    first = queue.Dequeue();
    Console.WriteLine("First = {0}", first);
    Console.WriteLine("Count = {0}", queue.Count);
    Console.WriteLine(string.Join(", ", queue.ToArray()));
    Console.WriteLine("---------------------------");
  }
}
