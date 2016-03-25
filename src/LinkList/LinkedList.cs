using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkList
{
    public class LinkedList<LLT>
    {
        private Node<LLT> Head { get; set; }
        private Node<LLT> Tail { get; set; }

        public void Add(LLT ele)
        {
            var newNode = new Node<LLT>()
            {
                Value = ele
            };

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else {
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        public LLT Lookup(int index) {

            var currentNode = Head;

            for (int i = 0; i < index && currentNode != null; i++) {
                currentNode = currentNode.Next;
            }

            if (currentNode == null || index < 0) {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            return currentNode.Value;
        }

        public void Delete(LLT ele) {

            var currentNode = Head;

            if (currentNode != null && ele.Equals(currentNode.Value)) {
                Head = Head.Next;
                return;
            }

            while (currentNode?.Next != null &&
                !currentNode.Next.Value.Equals(ele)) {
                currentNode = currentNode.Next;
            }

            if (currentNode?.Next != null) {
                
                currentNode.Next = currentNode.Next.Next;

                if (currentNode.Next == null) {
                    Tail = currentNode;
                }
            }
        }
    }

     class Node<T> {

        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}
