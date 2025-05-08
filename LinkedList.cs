namespace LinkedList {
    public class GenericLinkedList<T> {
        private class Node(T t) {
            public T data { get; set; } = t;
            public Node? next { get; set; }
        }

        private Node? head;

        public void Print() {
            Node? curr = head;
            while(curr != null) {
                Console.Write(curr.data);
                curr = curr.next;
            }
        }

        public void Push(T t) {
            Node temp = new(t);
            temp.next =  head;
            head = temp;
        }

        public T Pop() {
            if(head != null) {
                T temp = head.data;
                head = head.next;
                return temp;
            } else {
                throw new InvalidOperationException("Cannot pop from an empty list.");
            }
        }

        public void Insert(T t, int n) {
            int i = 0;
            Node? curr = head;
            if(n == 0) {
                Node? temp = new(t);
                temp.next = head;
                head = temp;
                return;
            }
            while(curr != null) {
                if(i == n-1){
                    Node? temp = new(t);
                    temp.next = curr.next;
                    curr.next = temp;
                    return;
                }
                i++;
                curr = curr.next;
            }
            throw new InvalidOperationException("Cannot insert past the end of a list.");
        }

        public void Delete(int n) {
            int i = 0;
            Node? curr = head;
            if(n == 0){
                Pop();
                return;
            }
            while(curr != null) {
                if(i == n-1) {
                    if(curr.next == null) {
                        throw new InvalidOperationException("Item marked for deleteion not found");
                    }
                    curr.next = curr.next.next;
                    return;
                }
                curr = curr.next;
                i++;
            }
        }

        public T Search(int n) {
            int i = 0;
            Node? curr = head;
            while(curr != null) {
                if(i == n) {
                    return curr.data;
                }
                curr = curr.next;
                i++;
            }
            throw new InvalidOperationException("Item not found.");
        }
    }
}