using System;
using System.Collections.Generic;

public interface Node
{
    Node next();
}
public class Kata
{
    public static int getLoopSize(Node startNode)
    {
        List<Node> seen = new List<Node>();
        Node currentNode;
        int counter = 0;
        int seenIndex;
        currentNode = startNode;
        seen.Add(currentNode);
        while ((seenIndex = seen.IndexOf(currentNode)) >= 0)
        {
            currentNode = currentNode.next;
            counter++;
        }
        return counter - seenIndex;
    }
}
class Program
{
    static void Main(string[] args)
    {

    }
}
