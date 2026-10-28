/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public void ReorderList(ListNode head) {
        if (head == null || head.next == null) return;

        ListNode nextNode = head;
        Stack<ListNode> stack = new Stack<ListNode>();
        while(nextNode != null)
        {
            stack.Push(nextNode);
            nextNode = nextNode.next;
        }

        int count = stack.Count / 2;
        nextNode = head;
        for(int i = 0; i < count; i++)
        {
            var lastNode = stack.Pop();
            var nextNextNode = nextNode.next;
            nextNode.next = lastNode;
            lastNode.next = nextNextNode;
            nextNode = nextNextNode;
        }
        nextNode.next = null;
    }
}
