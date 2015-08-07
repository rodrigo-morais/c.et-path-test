using System;
using System.Collections.Generic;

namespace path
{

    public class Path
    {
        public string CurrentPath { get; private set; }

        public Path(string path)
        {
            this.CurrentPath = path;
        }

        public Path Cd(string newPath)
        {
            if (newPath.Length > 2 && newPath.Substring(0, 2) == "./")
            {
                newPath = newPath.Substring(2, newPath.Length - 2);
            }

            var paths = new List<string>();
            var newPathArray = newPath.Split('/');

            foreach (var word in this.CurrentPath.Substring(0, this.CurrentPath.Length))
            {
                paths.Add(word.ToString());
            }

            for (var counter = 0; counter < newPathArray.Length; counter = counter + 1)
            {
                if (newPathArray[counter] == "..")
                {
                    paths.RemoveAt(paths.Count - 2);
                    paths.RemoveAt(paths.Count - 1);
                }
                else if(newPathArray[counter].Length > 0)
                {
                    paths.Add("/");
                    paths.Add(newPathArray[counter]);
                }
            }

            
            return new Path(String.Join("", paths.ToArray()));
        }

        public static void Main(string[] args)
        {
            Path path = new Path("/a/b/c/d");
            Console.WriteLine(path.Cd("../x").CurrentPath);

            Console.WriteLine("");
            Console.WriteLine("");

            path = new Path("/a/b/c/d");
            Console.WriteLine(path.Cd("../../x").CurrentPath);

            Console.WriteLine("");
            Console.WriteLine("");

            path = new Path("/a/b/c/d");
            Console.WriteLine(path.Cd("../../x/y/../z").CurrentPath);

            Console.WriteLine("");
            Console.WriteLine("");

            path = new Path("/a/b/c/d");
            Console.WriteLine(path.Cd("x").CurrentPath);

            Console.WriteLine("");
            Console.WriteLine("");

            path = new Path("/a/b/c/d");
            Console.WriteLine(path.Cd("/x").CurrentPath);

            Console.WriteLine("");
            Console.WriteLine("");

            path = new Path("/a/b/c/d");
            Console.WriteLine(path.Cd("x/y/z").CurrentPath);

            Console.WriteLine("");
            Console.WriteLine("");

            path = new Path("/a/b/c/d");
            Console.WriteLine(path.Cd("./x").CurrentPath);
            
            Console.WriteLine("");
            Console.WriteLine("");

            path = new Path("/a/b/c/d");
            Console.WriteLine(path.Cd("./x/y/z").CurrentPath);

            Console.Read();
        }
    }
}
