using System;
using System.Collections.Generic;
using System.Collections;

namespace _9_6_1_6_
{
    public class ListNode<T>
    {
		public ListNode(T data) { Data = data; }
		public T Data { get; set; }
		public ListNode<T> Next { get; set; }
	}
	public class List<T> : IEnumerable<T>
	{
		ListNode<T> head, tail;
		int count;
		public void Add(T data)
		{
			ListNode<T> node = new ListNode<T>(data);
	        if (head == null)
				head = node;
			else
				tail.Next = node;
			tail = node;
			count++;
		}
		public bool Contains(T data)
		{
			ListNode<T> current = head;
			while (current != null)
			{
				if (current.Data.Equals(data))
					return true;
				current = current.Next;
			}
			return false;
		}
		public int Count { get { return count; } }
		IEnumerator IEnumerable.GetEnumerator() { return ((IEnumerable)this).GetEnumerator(); }
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			ListNode<T> current = head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}
	}
}
