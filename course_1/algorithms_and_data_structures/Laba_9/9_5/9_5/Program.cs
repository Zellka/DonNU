using System;
using System.IO;

namespace _9_5
{
    class Program
    {
        public struct MatchDetails
        {
            public string leftTeams;
            public int leftCount;
            public string rightTeams;
            public int rightCount;
        }
        public static void Main(string[] args)
        {
            string[] teams = ReadFile();
            MatchDetails[] numMatch = new MatchDetails[8];
            BinaryTreeNode<MatchDetails>[] node = new BinaryTreeNode<MatchDetails>[15]; // 15 матчей - 15 узлов
            Random random = new Random();
            Match(numMatch, teams, random);
            EmptyTree(node);
            FilledTree(numMatch, node, random);
            PreOrderTraversal(node[0]);
        }
        public static string[] ReadFile()
        {
            string path = @"C:\Pr\участники.txt";
            StreamReader fileRead = new StreamReader(path);
            string text = fileRead.ReadToEnd();
            string[] teams = text.Split(' ');
            fileRead.Close();
            return teams;
        }
        public static void Match(MatchDetails[] numMatch, string[] teams, Random random)
        {
            MatchDetails match;
            for (int i = 0, j = 0; i < numMatch.Length; i++, j += 2) //j увеличивается на 2, т.к. берём по паре команд
            {
                match.leftTeams = teams[j];
                match.leftCount = random.Next(0, 5);
                match.rightTeams = teams[j + 1];
                match.rightCount = random.Next(0, 5);
                numMatch[i] = match;
            }
        }
        public static void EmptyTree(BinaryTreeNode<MatchDetails>[] node) //заполнение пустыми строками и неизвестными результатами 
        {
            MatchDetails noData;
            noData.leftTeams = "";
            noData.rightTeams = "";
            noData.leftCount = 000;
            noData.rightCount = 000;
            BinaryTree<MatchDetails> emptyTree = new BinaryTree<MatchDetails>();
            for (int i = 0, j = 3; i <= 6; i++)
            {
                if (i == 0)
                {
                    node[0] = emptyTree.AddRoot(noData);
                    node[1] = emptyTree.AddLeft(node[0], noData);
                    node[2] = emptyTree.AddRight(node[0], noData);
                }
                else
                {
                    node[j] = emptyTree.AddLeft(node[i], noData); j++;
                    node[j] = emptyTree.AddRight(node[i], noData); j++;
                }
            }
        }
        public static void FilledTree(MatchDetails[] numMatch, BinaryTreeNode<MatchDetails>[] node, Random random)
        {
            for (int i = node.Length - 1, j = numMatch.Length - 1; j > -1; i--, j--)
                node[i].data = numMatch[j];
            for (int i = 6; i > -1; i--)
                node[i].data = NewMatch(node[i].left.data, node[i].right.data, random);
        }
        static MatchDetails NewMatch(MatchDetails dataLeft, MatchDetails dataRight, Random random) 
        {                                                                                 
            string leftTeams, rightTeams;            //продвижение команд, в зависимости от результата
            if (dataLeft.leftCount >= dataLeft.rightCount)
                leftTeams = dataLeft.leftTeams;
            else
                leftTeams = dataLeft.rightTeams;
            if (dataRight.leftCount >= dataRight.rightCount)
                rightTeams = dataRight.leftTeams;
            else
                rightTeams = dataRight.rightTeams;
            MatchDetails newMatch;                   //заполнение результатов последующих матчей
            newMatch.leftTeams = leftTeams;
            newMatch.rightTeams = rightTeams;
            newMatch.leftCount = random.Next(0, 5);
            newMatch.rightCount = random.Next(0, 5);
            return newMatch;
        }
        static void PreOrder(BinaryTreeNode<MatchDetails> node, int level = 0)
        {
            if (node != null)
            {
                string output = node.data.leftTeams + " - " + node.data.rightTeams + " : " + node.data.leftCount + " - " + node.data.rightCount;
                for (int i = 0; i < level; i++)
                    output = "\t" + output;
                Console.WriteLine(output);
                PreOrder(node.left, level + 1);
                PreOrder(node.right, level + 1);
            }
        }
        static void PreOrderTraversal(BinaryTreeNode<MatchDetails> root) { PreOrder(root); }
    }
}
