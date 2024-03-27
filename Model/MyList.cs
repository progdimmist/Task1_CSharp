using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Task;

public class Node<T>
{
    public Node(T data)
    {
        Data = data;
    }
    public T Data { get; set; }
    public Node<T>? Next { get; set; }
}

public class MyList<T> : IEnumerable<T>
{
    Node<T>? head; //первый элемент
    Node<T>? tail; //последний элемент
    int count;  //количество элементов

    public void add(T data)
    {
        Node<T> node = new Node<T>(data);

        if (head == null)
            head = node;
        else
            tail!.Next = node;
        tail = node;

        count++;
    }
    
    public bool remove(T data)
    {
        Node<T>? current = head;
        Node<T>? previous = null;

        while (current != null && current.Data != null)
        {
            if (current.Data.Equals(data))
            {
                if (previous != null) // Если узел в середине или в конце
                {
                    previous.Next = current.Next; // убираем узел current, теперь previous ссылается не на current, а на current.Next

                    if (current.Next == null) // Если узел последний,
                        tail = previous;
                }
                else
                {
                    head = head?.Next; // если удаляется первый элемент

                    if (head == null) // если после удаления список пуст, сбрасываем tail
                        tail = null;
                }
                count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }
        return false;
    }

    public int Count { get { return count; } }
    public bool IsEmpty { get { return count == 0; } }
    
    public void clear()
    {
        head = null;
        tail = null;
        count = 0;
    }
    
    public bool contains(T data)
    {
        Node<T>? current = head;
        while (current != null && current.Data != null)
        {
            if (current.Data.Equals(data)) return true;
            current = current.Next;
        }
        return false;
    }
    // добвление в начало
    public void appendFirst(T data)
    {
        Node<T> node = new Node<T>(data);
        node.Next = head;
        head = node;
        if (count == 0)
            tail = head;
        count++;
    }

    public T getElementAt(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException("Index out of range");
        }

        Node<T>? current = head;
        for (int i = 0; i < index; i++)
        {
            current = current?.Next;
        }

        return current!.Data;
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        Node<T>? current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    // реализация интерфейса IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }
}
