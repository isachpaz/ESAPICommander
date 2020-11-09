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
            var tags = new List<Tag>();
            tags.Add(new Tag("Root"){ID = 0, ParentID = 0});
            tags.Add(new Tag("Leaf-1"){ID = 1, ParentID = 0});
            tags.Add(new Tag("Leaf-2") {ID = 2, ParentID = 0});
            tags.Add(new Tag("Leaf-3") {ID = 3, ParentID = 0});
            tags.Add(new Tag("Leaf-1.1") {ID = 4, ParentID = 1});
            tags.Add(new Tag("Leaf-1.2") {ID = 5, ParentID = 1});

            var tree = Node.BuildTreeAndGetRoots(tags);
            Debug.WriteLine(tree);
            //Count nodes with visitor pattern
        }

        [Test]
        public void Test_TreeBuild_Manual()
        {
            List<Node> tree = new List<Node>();
            Node rootPatient = new Node() { Source = new Tag("Patient") { ID = 0, ParentID = 0 } };
            tree.Add(rootPatient);

            var course1 = new Node() { Source = new Tag("Course-1") };
            var course2 = new Node() { Source = new Tag("Course-2") };

            rootPatient.AddChildren(course1);
            rootPatient.AddChildren(course2);

            var planSetups = new Node() { Source = new Tag(description: "PlanSetups") };
            var planSums = new Node() { Source = new Tag(description: "PlanSums") };

            course1.AddChildren(planSetups);
            course1.AddChildren(planSums);
            course2.AddChildren(planSetups);

            var plan1 = new Node() {Source = new Tag(description: "Plan-1")};
            var plan2 = new Node() {Source = new Tag(description: "Plan-2")};
            var plan3 = new Node() {Source = new Tag(description: "Plan-3")};
            var plan4 = new Node() {Source = new Tag(description: "Plan-4")};

            planSetups.AddChildren(plan1);
            planSetups.AddChildren(plan2);
            planSetups.AddChildren(plan3);
            planSetups.AddChildren(plan4);

            var planSum1 = new Node() { Source = new Tag(description: "PlanSum: Plan1 + Plan2") };
            var planSum2 = new Node() { Source = new Tag(description: "PlanSum: Plan3 + Plan4") };
            planSums.AddChildren(planSum1);
            planSums.AddChildren(planSum2);



            Debug.WriteLine(tree);
            //Count nodes with visitor pattern
        }


    }
}
