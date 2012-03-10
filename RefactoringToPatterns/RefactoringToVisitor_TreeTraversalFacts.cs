using System.Collections.Generic;
using Xunit;
using refactoring_to_visitor.TreeTraversal;

namespace refactoring_to_visitor
{
    public class RefactoringToVisitor_TreeTraversalFacts
    {
        [Fact]
        public void test_to_ensure_refactoing()
        {
            var folder1 = new Folder
                              {
                                  FolderName = "FOLDER1",
                                  Category = "CATA1",
                                  Docs = new List<Doc>
                                             {
                                                 new Doc {Title = "DOC1", Elements = new List<IElement>{new Graph{Name = "GRAPH"}}}
                                             }
                              };
            var folder2 = new Folder
                              {
                                  FolderName = "FOLDER2",
                                  Category = "CATA1",
                                  Docs = new List<Doc>
                                             {
                                                 new Doc {Title = "DOC2"},
                                                 new Doc {Title = "DOC3"}
                                             }
                              };
            var doc = new Doc
                          {
                              Title = "DOC4",
                              Elements = new List<IElement>
                                             {
                                                 new Graph {Name = "GRAPH1", Size = 10, Text = "TEXT"},
                                                 new Movie {Name = "MI", Size = 65535, Text = "WB"}
                                             }
                          };
            var tree = new Tree
                           {
                               Name = "TEST TREE",
                               Folders = new List<Folder>
                                             {
                                                 folder1,
                                                 folder2,
                                             },
                               Docs = new List<Doc>
                                          {
                                              doc
                                          }
                           };


            const string expected = @"TEST TREE
FOLDER1
CATA1
DOC1
<Graph>: GRAPH, , 0
FOLDER2
CATA1
DOC2
DOC3
DOC4
<Graph>: GRAPH1, TEXT, 10
[Movie]: MI, WB, 65535
";
            Assert.Equal(expected, tree.ListContent(new TreeVisitor()));
        }
    }
}