using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ESAPIProxy.Tests
{
    [TestFixture]
    public class PatientTreeTests
    {
        [Test]
        public void Test_TreeBuild()
        {
            var tags = new List<TagInfo>();
            tags.Add(new TagInfo("Root"){ID = 0, ParentID = 0});
            tags.Add(new TagInfo("Leaf-1"){ID = 1, ParentID = 0});
            tags.Add(new TagInfo("Leaf-2") {ID = 2, ParentID = 0});
            tags.Add(new TagInfo("Leaf-3") {ID = 3, ParentID = 0});
            tags.Add(new TagInfo("Leaf-1.1") {ID = 4, ParentID = 1});
            tags.Add(new TagInfo("Leaf-1.2") {ID = 5, ParentID = 1});

            var tree = Node.BuildTreeAndGetRoots(tags);
            Debug.WriteLine(tree);
            //Count nodes with visitor pattern
        }

        [Test]
        public void Test_TreeBuild_Manual()
        {
            List<Node> tree = new List<Node>();
            Node rootPatient = new Node() { TagInfo = new TagInfo("Patient") { ID = 0, ParentID = 0 } };
            tree.Add(rootPatient);

            var course1 = new Node() { TagInfo = new TagInfo("Course-1") };
            var course2 = new Node() { TagInfo = new TagInfo("Course-2") };

            rootPatient.AddChildren(course1);
            rootPatient.AddChildren(course2);

            var planSetups = new Node() { TagInfo = new TagInfo(description: "PlanSetups") };
            var planSums = new Node() { TagInfo = new TagInfo(description: "PlanSums") };

            course1.AddChildren(planSetups);
            course1.AddChildren(planSums);
            course2.AddChildren(planSetups);

            var plan1 = new Node() {TagInfo = new TagInfo(description: "Plan-1")};
            var plan2 = new Node() {TagInfo = new TagInfo(description: "Plan-2")};
            var plan3 = new Node() {TagInfo = new TagInfo(description: "Plan-3")};
            var plan4 = new Node() {TagInfo = new TagInfo(description: "Plan-4")};

            planSetups.AddChildren(plan1);
            planSetups.AddChildren(plan2);
            planSetups.AddChildren(plan3);
            planSetups.AddChildren(plan4);

            var planSum1 = new Node() { TagInfo = new TagInfo(description: "PlanSum1: Plan1 + Plan2") };
            var planSum2 = new Node() { TagInfo = new TagInfo(description: "PlanSum2: Plan3 + Plan4") };
            planSums.AddChildren(planSum1);
            planSums.AddChildren(planSum2);

            PrintTree printOut = new PrintTree();
            foreach (var node in tree)
            {
                node.Accept(printOut);
            }

            Debug.WriteLine(printOut.GetOutput());

            Debug.WriteLine(tree);
            //Count nodes with visitor pattern
        }


    }
}
