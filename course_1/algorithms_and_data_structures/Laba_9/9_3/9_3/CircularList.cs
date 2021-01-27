using System;
using System.Collections;
using System.Collections.Generic;

namespace _9_3
{
	public class CircularListNode<T>
	{
		public CircularListNode(T data) { Data = data; }
		public T Data { get; set; }
		public CircularListNode<T> Next { get; set; }
	}
	public class CircularList<T> : IEnumerable<T>
	{
		CircularListNode<T> head, tail;
		int count;
		public void Add(T data)
		{
			CircularListNode<T> node = new CircularListNode<T>(data);
			if (head == null)
			{
				head = node;
				tail = node;
				tail.Next = head;
			}
			else
			{
				node.Next = head;
				tail.Next = node;
				tail = node;
			}
			count++;
		}
		public bool Contains(T data)
		{
			CircularListNode<T> position = head;
			if (position == null) return false;
			do
			{
				if (position.Data.Equals(data))
					return true;
				position = position.Next;
			}
			while (position != head);
			return false;
		}
		public CircularListNode<T> Find(T data)
		{
			CircularListNode<T> position = head;
			if (position == null) return null;
			do
			{
				if (position.Data.Equals(data))
					return position;
				position = position.Next;
			} while (position != head);
			return null;
		}
		public void Replace(T data)
		{
			CircularListNode<T> position = Find(data);
			tail = position;
			head = position.Next;
			head = tail;
		}
		IEnumerator IEnumerable.GetEnumerator() { return ((IEnumerable)this).GetEnumerator(); }
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			CircularListNode<T> position = head;
			do
			{
				if (position != null)
				{
					yield return position.Data;
					position = position.Next;
				}
			} while (position != head);
		}
	}
}
