using System;

public class ArrayList<T>
{
  private const int Initial_Capacity = 2;

  private T[] items;

  public ArrayList(int capacity = Initial_Capacity)
  {
    this.Capacity = capacity;
    this.items = new T[this.Capacity];
  }

  public int Count { get; private set; }

  public int Capacity { get; set; }

  public T this[int index]
  {
    get
    {
      if (index < 0 || index >= this.Count)
      {
        throw new ArgumentOutOfRangeException();
      }

      return this.items[index];
    }
    set
    {
      if (index < 0 || index >= this.Count)
      {
        throw new ArgumentOutOfRangeException();
      }

      this.items[index] = value;
    }
  }

  public void Add(T item)
  {
    if (this.Count >= this.Capacity)
    {
      this.Resize();
    }

    this.items[this.Count++] = item;
  }

  private void Resize()
  {
    T[] copy = new T[this.Capacity * 2];
    this.Capacity *= 2;
    Array.Copy(this.items, copy, this.Count);
    this.items = copy;
  }

  public T RemoveAt(int index)
  {

   // indexer property validate if index is in range and returns
   // the element at the current index

    T element = this[index];
     this[index] = default;
    this.Shift(index);
    this.Count--;

    if (this.Count <= this.Capacity / 4)
    {
      this.Shrink();
    }

    return element;
  }
  private void Shift(int index)
  {
    for (int i = index; i < this.Count; i++)
    {
      this.items[i] = this.items[i + 1];
    }
  }

  private void Shrink()
  {
    T[] copy = new T[this.Capacity / 2];
    Array.Copy(this.items, copy, this.Count);
    this.items = copy;
  }
}
