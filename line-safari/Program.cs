using System;
using System.Linq;
using System.Collections.Generic;

namespace codewars_line_safari
{
    class Program
    {
        class node
        {
            public char character;
            public int x;
            public int y;
            public bool traversed;
            public node(char inChar, int inX, int inY)
            {
                this.character = inChar;
                this.x = inX;
                this.y = inY;
                this.traversed = false;
            }

        }

        public static bool Line(char[][] grid)
        {
            int untraversedNodes;
            // this checks if we can traverse further and in unambigous way
            bool traverse(List<node> inNodes, node currentNode, node endNode)
            {
                char currChar, newFromDirection, fromDirection = '\0';
                int currX, currY, availableMoves;

                untraversedNodes = inNodes.Count();
                currX = currentNode.x; currY = currentNode.y;
                currChar = currentNode.character;
                do
                {
                    newFromDirection = '\0';
                    availableMoves = 0;
                    node upNode = new node('\0', -1, -1);
                    node downNode = new node('\0', -1, -1);
                    node leftNode = new node('\0', -1, -1);
                    node rightNode = new node('\0', -1, -1);
                    node nextNode = new node('\0', -1, -1);

                    switch (currChar)
                    {
                        case 'X':
                            // check UP
                            if (inNodes.Where(node => node.x == currX && node.y == currY - 1).Count() != 0)
                            {
                                upNode = inNodes.Where(node => node.x == currX && node.y == currY - 1).First();
                                if (upNode.character != '-' && fromDirection != 'U' && !upNode.traversed)
                                {
                                    newFromDirection = 'D';
                                    availableMoves++;
                                    nextNode = upNode;
                                };
                            }
                            // check DOWN
                            if (inNodes.Where(node => node.x == currX && node.y == currY + 1).Count() != 0)
                            {
                                downNode = inNodes.Where(node => node.x == currX && node.y == currY + 1).First();
                                if (downNode.character != '-' && fromDirection != 'D' && !downNode.traversed)
                                {
                                    if (availableMoves > 0) { return false; }
                                    newFromDirection = 'U';
                                    availableMoves++;
                                    nextNode = downNode;
                                };
                            }
                            // check LEFT
                            if (inNodes.Where(node => node.x == currX - 1 && node.y == currY).Count() != 0)
                            {
                                leftNode = inNodes.Where(node => node.x == currX - 1 && node.y == currY).First();
                                if (leftNode.character != '|' && fromDirection != 'L' && !leftNode.traversed)
                                {
                                    if (availableMoves > 0) { return false; }
                                    newFromDirection = 'R';
                                    availableMoves++;
                                    nextNode = leftNode;
                                };
                            }
                            // check RIGHT
                            if (inNodes.Where(node => node.x == currX + 1 && node.y == currY).Count() != 0)
                            {
                                rightNode = inNodes.Where(node => node.x == currX + 1 && node.y == currY).First();
                                if (rightNode.character != '|' && fromDirection != 'R' && !rightNode.traversed)
                                {
                                    if (availableMoves > 0) { return false; }
                                    newFromDirection = 'L';
                                    availableMoves++;
                                    nextNode = rightNode;
                                };
                            }
                            break;
                        case '-':
                            // check LEFT
                            if (inNodes.Where(node => node.x == currX - 1 && node.y == currY).Count() != 0)
                            {
                                leftNode = inNodes.Where(node => node.x == currX - 1 && node.y == currY).First();
                                if (leftNode.character != '|' && fromDirection != 'L' && !leftNode.traversed)
                                {
                                    if (availableMoves > 0) { return false; }
                                    newFromDirection = 'R';
                                    availableMoves++;
                                    nextNode = leftNode;
                                };
                            }
                            // check RIGHT
                            if (inNodes.Where(node => node.x == currX + 1 && node.y == currY).Count() != 0)
                            {
                                rightNode = inNodes.Where(node => node.x == currX + 1 && node.y == currY).First();
                                if (rightNode.character != '|' && fromDirection != 'R' && !rightNode.traversed)
                                {
                                    if (availableMoves > 0) { return false; }
                                    newFromDirection = 'L';
                                    availableMoves++;
                                    nextNode = rightNode;
                                };
                            }
                            break;
                        case '|':
                            // check UP
                            if (inNodes.Where(node => node.x == currX && node.y == currY - 1).Count() != 0)
                            {
                                upNode = inNodes.Where(node => node.x == currX && node.y == currY - 1).First();
                                if (upNode.character != '-' && fromDirection != 'U' && !upNode.traversed)
                                {
                                    newFromDirection = 'D';
                                    availableMoves++;
                                    nextNode = upNode;
                                };
                            }
                            // check DOWN
                            if (inNodes.Where(node => node.x == currX && node.y == currY + 1).Count() != 0)
                            {
                                downNode = inNodes.Where(node => node.x == currX && node.y == currY + 1).First();
                                if (downNode.character != '-' && fromDirection != 'D' && !downNode.traversed)
                                {
                                    if (availableMoves > 0) { return false; }
                                    newFromDirection = 'U';
                                    availableMoves++;
                                    nextNode = downNode;
                                };
                            }
                            break;
                        case '+':
                            if (fromDirection == 'L' || fromDirection == 'R')
                            {
                                // check UP
                                if (inNodes.Where(node => node.x == currX && node.y == currY - 1).Count() != 0)
                                {
                                    upNode = inNodes.Where(node => node.x == currX && node.y == currY - 1).First();
                                    if (upNode.character != '-' && !upNode.traversed)
                                    {
                                        newFromDirection = 'D';
                                        availableMoves++;
                                        nextNode = upNode;
                                    };
                                }
                                // check DOWN
                                if (inNodes.Where(node => node.x == currX && node.y == currY + 1).Count() != 0)
                                {
                                    downNode = inNodes.Where(node => node.x == currX && node.y == currY + 1).First();
                                    if (downNode.character != '-' && !downNode.traversed)
                                    {
                                        if (availableMoves > 0) { return false; }
                                        newFromDirection = 'U';
                                        availableMoves++;
                                        nextNode = downNode;
                                    };
                                }
                            }
                            if (fromDirection == 'U' || fromDirection == 'D')
                            {
                                // check LEFT
                                if (inNodes.Where(node => node.x == currX - 1 && node.y == currY).Count() != 0)
                                {
                                    leftNode = inNodes.Where(node => node.x == currX - 1 && node.y == currY).First();
                                    if (leftNode.character != '|' && !leftNode.traversed)
                                    {
                                        if (availableMoves > 0) { return false; }
                                        newFromDirection = 'R';
                                        availableMoves++;
                                        nextNode = leftNode;
                                    };
                                }
                                // check RIGHT
                                if (inNodes.Where(node => node.x == currX + 1 && node.y == currY).Count() != 0)
                                {
                                    rightNode = inNodes.Where(node => node.x == currX + 1 && node.y == currY).First();
                                    if (rightNode.character != '|' && !rightNode.traversed)
                                    {
                                        if (availableMoves > 0) { return false; }
                                        newFromDirection = 'L';
                                        availableMoves++;
                                        nextNode = rightNode;
                                    };
                                }
                            }
                            break;
                        default:
                            return false;
                    }
                    Console.WriteLine("for {0} x: {1} y: {2}, moves {3}", currChar, currX, currY, availableMoves);
                    // check how many moves we can make
                    // if we cannot move and we're not on the last X then path is invalid
                    if (availableMoves == 0)
                    {
                        if (currX == endNode.x && currY == endNode.y)
                        {
                            untraversedNodes--;
                            return (untraversedNodes == 0);
                        }
                        else
                        { return false; }
                    }
                    // we already checked for more than 1 move so now we're left with only one move
                    // MAKE A MOVE
                    inNodes.Where(node => node.x == currX && node.y == currY).First().traversed = true;
                    untraversedNodes--;
                    currX = nextNode.x;
                    currY = nextNode.y;
                    currChar = nextNode.character;
                    fromDirection = newFromDirection;
                    currentNode = nextNode;
                }
                while (true);
            }

            bool toValid = false;
            bool backValid = false;
            List<node> nodes = new List<node>();
            int x, y = 0;
            // create nodes list
            foreach (char[] line in grid)
            {
                x = 0;
                foreach (char character in line)
                {
                    // Console.WriteLine("'{0}' x {1} y {2}", character, x, y);
                    if (character != ' ')
                    {
                        node newNode = new node(character, x, y);
                        nodes.Add(newNode);
                    }
                    x++;
                }
                y++;
            }
            // check if there are two X's
            int xCount = nodes.Count(f => f.character == 'X');
            Console.WriteLine("count of X's: {0}", xCount);
            if (xCount != 2)
            {
                return false;
            }
            // choose first and second starting point
            node firstX = nodes.Where(f => f.character == 'X').First();
            node secondX = nodes.Where(f => f.character == 'X').Last();


            //Console.WriteLine();
            Console.WriteLine("node count: {0}", nodes.Count);
            Console.WriteLine("First direction");
            toValid = traverse(nodes, firstX, secondX);
            nodes.All(n => { n.traversed = false; return true; });
            Console.WriteLine("Going back");
            backValid = traverse(nodes, secondX, firstX);

            return (toValid || backValid);
        }
        static void Main(string[] args)
        {
            char[][] grid = {
"   X     X   ".ToCharArray(),
"   ++++  +-+ ".ToCharArray(),
"    +++--+ | ".ToCharArray(),
"         +-+ ".ToCharArray()
        };

            //printGrid(grid);
            bool valid = Line(grid);
            Console.WriteLine("The path is valid: {0}", valid.ToString().ToUpper());
        }
    }
}
